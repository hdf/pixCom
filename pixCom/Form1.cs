using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace pixCom {
  public partial class Form1 : Form {
    private static int txtBegin = 0;
    private static string separator = " ";
    private static int hexUnit = (separator.Length + 2) * 3;
    private static string header = "pixCom";
    private static string hexHeader = ToHex(header);
    private static int byteLen = separator.Length + 2;
    private static string original = "";
    private static int pixRows = 4;
    private static bool justGened = false;

    public Form1() {
      InitializeComponent();
    }

    /*public Image byteArrayToImage(byte[] byteArrayIn) {
      if (byteArrayIn.Length < 1) return new Bitmap(1, 1, PixelFormat.Format24bppRgb);
      Image returnImage = null;
      using (MemoryStream ms = new MemoryStream(byteArrayIn)) {
        returnImage = Image.FromStream(ms);
      }
      return returnImage;
    }

    public static byte[] imageToByteArray(Image image) {
      if (image == null) return new byte[0];
      using (MemoryStream ms = new MemoryStream()) {
        image.Save(ms, image.RawFormat);
        return ms.ToArray();
      }
    }*/

    public static byte[] imageToByteArray(Image image) {
      if (image == null) return new byte[0];
      Bitmap myImage = new Bitmap(image);
      byte[] rgbValues = null;
      BitmapData data = myImage.LockBits(new Rectangle(0, 0, myImage.Width, myImage.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
      try {
        IntPtr ptr = data.Scan0;
        int bytes = Math.Abs(data.Stride) * myImage.Height;
        rgbValues = new byte[bytes];
        Marshal.Copy(ptr, rgbValues, 0, bytes);
      } finally {
        myImage.UnlockBits(data);
      }
      return rgbValues;
    }

    public Image byteArrayToImage(byte[] rgbValues, Image image) {
      if (image == null || rgbValues.Length < 1) return new Bitmap(1, 1, PixelFormat.Format24bppRgb);
      Bitmap myImage = new Bitmap(image);
      BitmapData data = myImage.LockBits(new Rectangle(0, 0, myImage.Width, myImage.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
      try {
        IntPtr ptr = data.Scan0;
        int bytes = Math.Abs(data.Stride) * myImage.Height;
        Marshal.Copy(rgbValues, 0, ptr, bytes);
      } finally {
        myImage.UnlockBits(data);
      }
      return myImage;
    }

    public static string ToHex(string txt, string sep = null) {
      if (sep == null) sep = separator;
      return BitConverter.ToString(Encoding.UTF8.GetBytes(txt)).Replace("-", sep);
    }

    public static byte[] FromHex(string hex) {
      hex = hex.Replace("-", "").Replace(separator, "");
      byte[] raw = new byte[hex.Length / 2];
      for (int i = 0; i < raw.Length; i++) {
        raw[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
      }
      return raw;
    }

    private static int hex2int(string hex) {
      return Convert.ToInt32(hex.Replace(separator, ""), 16);
    }

    private static int getHeader(string hex) {
      txtBegin = hex.IndexOf(hexHeader);
      if (txtBegin < 0) {
        txtBegin = 0;
        return 0;
      }
      return hex2int(hex.Substring(txtBegin + hexHeader.Length, /*sizeof(int)*/ 4 * byteLen));
    }

    //---

    private void Form1_Load(object sender, EventArgs e) {

    }

    private void button1_Click(object sender, EventArgs e) { // Read Bytes to HEX from Image, than see if there is a message for us in the HEX
      richTextBox1.Text = BitConverter.ToString(imageToByteArray(pictureBox1.Image)).Replace("-", separator);
      int txtLen = getHeader(richTextBox1.Text);
      if (txtLen < 1) return;
      if (txtBegin + hexHeader.Length + 4 * byteLen + txtLen > richTextBox1.Text.Length) {
        MessageBox.Show("Corrupt header. Message size too large: " + txtLen.ToString());
        txtBegin = 0;
        return;
      }
      textBox2.Text = txtBegin.ToString();
      //70 69 78 43 6F 6D 00 00 00 09 48 44 46
      textBox1.Text = Encoding.UTF8.GetString(FromHex(richTextBox1.Text.Substring(txtBegin + hexHeader.Length + 4 * byteLen, txtLen)));
    }

    private void button2_Click(object sender, EventArgs e) { // Write Bytes to Image
      pictureBox1.Image = byteArrayToImage(FromHex(richTextBox1.Text), pictureBox1.Image);
    }

    private void button3_Click(object sender, EventArgs e) { // Load Image
      if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
      pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
      original = BitConverter.ToString(imageToByteArray(pictureBox1.Image)).Replace("-", separator);
    }

    private void button4_Click(object sender, EventArgs e) { // Save (modified) Image
      if (saveFileDialog1.ShowDialog() != System.Windows.Forms.DialogResult.OK || pictureBox1.Image == null) return;
      ImageFormat format = ImageFormat.Png;
      string ext = System.IO.Path.GetExtension(saveFileDialog1.FileName);
      switch (ext) {
        case ".jpg":
          format = ImageFormat.Jpeg;
          break;
        case ".bmp":
          format = ImageFormat.Bmp;
          break;
      }
      pictureBox1.Image.Save(saveFileDialog1.FileName, format);
    }

    private void button5_Click(object sender, EventArgs e) { // Generate new Image based on Bytes

      richTextBox1.Text = BitConverter.ToString(imageToByteArray(pictureBox1.Image = new Bitmap(pixRows, pixRows, PixelFormat.Format24bppRgb))).Replace("-", separator);
      original = BitConverter.ToString(imageToByteArray(pictureBox1.Image)).Replace("-", separator);
      return;

      int minLen = (int)Math.Ceiling((double)(hexHeader.Length + 4 * byteLen + separator.Length * 2 + 2) / hexUnit);
      if (pixRows < minLen) return;
      string toAdd = string.Concat(Enumerable.Repeat("00" + separator, (int)Math.Ceiling((double)txtBegin / byteLen)));
      if (richTextBox1.Text.Substring(0, toAdd.Length) != toAdd)
        richTextBox1.Text = toAdd + richTextBox1.Text;
      int h = (int)Math.Ceiling(((double)(richTextBox1.Text.Length + separator.Length) / hexUnit) / pixRows);
      toAdd = string.Concat(Enumerable.Repeat("00" + separator, (pixRows * h * hexUnit - separator.Length - richTextBox1.Text.Length) / (separator.Length + 2)));
      if (toAdd.Length > 0 && richTextBox1.Text.Length < pixRows * h * hexUnit)
        richTextBox1.Text += separator + toAdd.Substring(0, toAdd.Length - separator.Length);
      original = richTextBox1.Text;
      Bitmap myImage = new Bitmap(pixRows, h, PixelFormat.Format24bppRgb);
      BitmapData data = myImage.LockBits(new Rectangle(0, 0, myImage.Width, myImage.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
      try {
        IntPtr ptr = data.Scan0;
        byte[] bytes = FromHex(richTextBox1.Text);
        Marshal.Copy(bytes, 0, ptr, bytes.Length);
      } finally {
        myImage.UnlockBits(data);
        pictureBox1.Image = myImage;
        //original = BitConverter.ToString(imageToByteArray(myImage)).Replace("-", separator);
        //richTextBox1.Text = original;
      }
      toolStripStatusLabel1.Text = "Height: " + h.ToString();
      toolStripStatusLabel2.Text = "";
      justGened = true;
    }

    private void button6_Click(object sender, EventArgs e) { // Clear Image
      pictureBox1.Image = null;
      original = "";
    }

    private void textBox1_TextChanged(object sender, EventArgs e) { // Update HEX
      if (!textBox1.Focused) return;
      string toWrite = ToHex(textBox1.Text);
      string txtLen = Regex.Replace((toWrite.Length + separator.Length).ToString("X8"), @"(.{2})", "$1" + separator);
      //txtLen = txtLen.Substring(0, txtLen.Length - separator.Length); // Remove trailing whitespace
      pixRows = (int)Math.Ceiling((double)(txtBegin + hexHeader.Length + 4 * byteLen + toWrite.Length) / hexUnit);
      textBox3.Text = pixRows.ToString();
      if (justGened) {
        original = "";
        justGened = false;
      }
      if (original == "") {
        richTextBox1.Text = hexHeader + separator + txtLen + toWrite;
        return;
      }

      int txtLenInt = 0;
      if (toWrite.Length < 1) {
        txtLenInt = hex2int(original.Substring(txtBegin + hexHeader.Length, 4 * byteLen));
        if (txtBegin + hexHeader.Length + 4 * byteLen + txtLenInt > original.Length || txtLenInt < 1) {
          richTextBox1.Text = original;
          return;
        }
        toWrite = original.Substring(txtBegin + hexHeader.Length + 4 * byteLen + separator.Length, txtLenInt - separator.Length);
      }
      int cnt = txtBegin + hexHeader.Length + 4 * byteLen + toWrite.Length + separator.Length * 2;
      richTextBox1.Text = original.Substring(0, txtBegin + 4 * byteLen - txtLen.Length) +
        hexHeader + separator + txtLen + toWrite + separator +
        ((cnt < original.Length) ? original.Substring(cnt) : "");
    }

    private void richTextBox1_TextChanged(object sender, EventArgs e) { // Write to plain text box from HEX
      if (!richTextBox1.Focused) return;
      int txtLen = getHeader(richTextBox1.Text);
      if (txtLen < 1) {
        try {
          textBox1.Text = Encoding.UTF8.GetString(FromHex(richTextBox1.Text));
        } catch { }
        return;
      }
      if (txtBegin + hexHeader.Length + 4 * byteLen + txtLen > richTextBox1.Text.Length)
        txtLen = richTextBox1.Text.Length - txtBegin - hexHeader.Length - 4 * byteLen;
      textBox2.Text = txtBegin.ToString();
      textBox1.Text = Encoding.UTF8.GetString(FromHex(richTextBox1.Text.Substring(txtBegin + hexHeader.Length + 4 * byteLen, txtLen)));
    }

    private void textBox2_TextChanged(object sender, EventArgs e) { // Update offset
      try {
        txtBegin = int.Parse(textBox2.Text);
      } catch {
        txtBegin = 0;
      }
    }

    private void textBox3_TextChanged(object sender, EventArgs e) { // Update Pixel Rows
      try {
        pixRows = int.Parse(textBox3.Text);
      } catch {
        pixRows = 4;
      }
    }

    private void textBox2_MouseHover(object sender, EventArgs e) {
      toolTip1.Show("message offset", (TextBox)sender, 0, textBox2.Height);
    }

    private void textBox2_MouseLeave(object sender, EventArgs e) {
      toolTip1.Hide((TextBox)sender);
    }

    private void richTextBox1_SelectionChanged(object sender, EventArgs e) {
      toolStripStatusLabel1.Text = "Selection Start: " + richTextBox1.SelectionStart.ToString() + "  |";
      toolStripStatusLabel2.Text = "Selection Length: " + richTextBox1.SelectionLength.ToString();
    }
  }
}
