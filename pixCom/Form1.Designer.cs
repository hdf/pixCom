namespace pixCom {
  partial class Form1 {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.components = new System.ComponentModel.Container();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.button1 = new System.Windows.Forms.Button();
      this.button2 = new System.Windows.Forms.Button();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.button3 = new System.Windows.Forms.Button();
      this.button4 = new System.Windows.Forms.Button();
      this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
      this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
      this.richTextBox1 = new System.Windows.Forms.RichTextBox();
      this.textBox2 = new System.Windows.Forms.TextBox();
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.statusStrip1 = new System.Windows.Forms.StatusStrip();
      this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
      this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
      this.button5 = new System.Windows.Forms.Button();
      this.button6 = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.textBox3 = new System.Windows.Forms.TextBox();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.statusStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // pictureBox1
      // 
      this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.pictureBox1.Location = new System.Drawing.Point(12, 12);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(400, 100);
      this.pictureBox1.TabIndex = 0;
      this.pictureBox1.TabStop = false;
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(12, 118);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(70, 25);
      this.button1.TabIndex = 1;
      this.button1.Text = "Read Bytes";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // button2
      // 
      this.button2.Location = new System.Drawing.Point(88, 118);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(70, 25);
      this.button2.TabIndex = 3;
      this.button2.Text = "Write Bytes";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // textBox1
      // 
      this.textBox1.Location = new System.Drawing.Point(12, 149);
      this.textBox1.Multiline = true;
      this.textBox1.Name = "textBox1";
      this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.textBox1.Size = new System.Drawing.Size(400, 125);
      this.textBox1.TabIndex = 2;
      this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
      // 
      // button3
      // 
      this.button3.Location = new System.Drawing.Point(246, 118);
      this.button3.Name = "button3";
      this.button3.Size = new System.Drawing.Size(80, 25);
      this.button3.TabIndex = 0;
      this.button3.Text = "Load Image";
      this.button3.UseVisualStyleBackColor = true;
      this.button3.Click += new System.EventHandler(this.button3_Click);
      // 
      // button4
      // 
      this.button4.Location = new System.Drawing.Point(332, 118);
      this.button4.Name = "button4";
      this.button4.Size = new System.Drawing.Size(80, 25);
      this.button4.TabIndex = 6;
      this.button4.Text = "Save Image";
      this.button4.UseVisualStyleBackColor = true;
      this.button4.Click += new System.EventHandler(this.button4_Click);
      // 
      // openFileDialog1
      // 
      this.openFileDialog1.Filter = "Images|*.png;*.bmp;*.jpg";
      // 
      // saveFileDialog1
      // 
      this.saveFileDialog1.Filter = "Images|*.png;*.bmp;*.jpg";
      // 
      // richTextBox1
      // 
      this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.richTextBox1.Location = new System.Drawing.Point(12, 280);
      this.richTextBox1.Name = "richTextBox1";
      this.richTextBox1.Size = new System.Drawing.Size(400, 125);
      this.richTextBox1.TabIndex = 3;
      this.richTextBox1.Text = "";
      this.richTextBox1.SelectionChanged += new System.EventHandler(this.richTextBox1_SelectionChanged);
      this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
      // 
      // textBox2
      // 
      this.textBox2.Location = new System.Drawing.Point(164, 121);
      this.textBox2.Name = "textBox2";
      this.textBox2.Size = new System.Drawing.Size(76, 20);
      this.textBox2.TabIndex = 4;
      this.textBox2.Text = "0";
      this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
      this.textBox2.MouseLeave += new System.EventHandler(this.textBox2_MouseLeave);
      this.textBox2.MouseHover += new System.EventHandler(this.textBox2_MouseHover);
      // 
      // statusStrip1
      // 
      this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
      this.statusStrip1.Location = new System.Drawing.Point(0, 443);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Size = new System.Drawing.Size(424, 22);
      this.statusStrip1.SizingGrip = false;
      this.statusStrip1.TabIndex = 10;
      this.statusStrip1.Text = "statusStrip1";
      // 
      // toolStripStatusLabel1
      // 
      this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
      this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
      // 
      // toolStripStatusLabel2
      // 
      this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
      this.toolStripStatusLabel2.Size = new System.Drawing.Size(0, 17);
      // 
      // button5
      // 
      this.button5.Location = new System.Drawing.Point(222, 411);
      this.button5.Name = "button5";
      this.button5.Size = new System.Drawing.Size(190, 25);
      this.button5.TabIndex = 8;
      this.button5.Text = "Generate new image based on Bytes";
      this.button5.UseVisualStyleBackColor = true;
      this.button5.Click += new System.EventHandler(this.button5_Click);
      // 
      // button6
      // 
      this.button6.Location = new System.Drawing.Point(141, 411);
      this.button6.Name = "button6";
      this.button6.Size = new System.Drawing.Size(75, 25);
      this.button6.TabIndex = 7;
      this.button6.Text = "Clear Image";
      this.button6.UseVisualStyleBackColor = true;
      this.button6.Click += new System.EventHandler(this.button6_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 417);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(62, 13);
      this.label1.TabIndex = 9;
      this.label1.Text = "Pixel Rows:";
      // 
      // textBox3
      // 
      this.textBox3.Location = new System.Drawing.Point(80, 414);
      this.textBox3.Name = "textBox3";
      this.textBox3.Size = new System.Drawing.Size(50, 20);
      this.textBox3.TabIndex = 5;
      this.textBox3.Text = "4";
      this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(424, 465);
      this.Controls.Add(this.textBox3);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.button6);
      this.Controls.Add(this.button5);
      this.Controls.Add(this.statusStrip1);
      this.Controls.Add(this.textBox2);
      this.Controls.Add(this.richTextBox1);
      this.Controls.Add(this.button4);
      this.Controls.Add(this.button3);
      this.Controls.Add(this.textBox1);
      this.Controls.Add(this.button2);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.pictureBox1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.Name = "Form1";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "pixCom";
      this.Load += new System.EventHandler(this.Form1_Load);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.statusStrip1.ResumeLayout(false);
      this.statusStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Button button3;
    private System.Windows.Forms.Button button4;
    private System.Windows.Forms.OpenFileDialog openFileDialog1;
    private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    private System.Windows.Forms.RichTextBox richTextBox1;
    private System.Windows.Forms.TextBox textBox2;
    private System.Windows.Forms.ToolTip toolTip1;
    private System.Windows.Forms.StatusStrip statusStrip1;
    private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    private System.Windows.Forms.Button button5;
    private System.Windows.Forms.Button button6;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox textBox3;
    private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
  }
}

