namespace SES_Add_ON
{
    partial class StartForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Endbtn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Runbtn = new System.Windows.Forms.Button();
            this.Startbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Endbtn
            // 
            this.Endbtn.Location = new System.Drawing.Point(428, 196);
            this.Endbtn.Name = "Endbtn";
            this.Endbtn.Size = new System.Drawing.Size(166, 57);
            this.Endbtn.TabIndex = 1;
            this.Endbtn.Text = "End";
            this.Endbtn.UseVisualStyleBackColor = true;
            this.Endbtn.Click += new System.EventHandler(this.Endbtn_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox1.Location = new System.Drawing.Point(34, 29);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(560, 144);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "\r\n시작하고 지도를 생성하려면 ------ [Start]\r\n종료하려면 -------------------- [End]\r\n실행하려면 --------" +
    "------------ [Run]\r\n버튼을 눌러주세요.";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Runbtn
            // 
            this.Runbtn.Location = new System.Drawing.Point(224, 196);
            this.Runbtn.Name = "Runbtn";
            this.Runbtn.Size = new System.Drawing.Size(153, 57);
            this.Runbtn.TabIndex = 4;
            this.Runbtn.Text = "Run";
            this.Runbtn.UseVisualStyleBackColor = true;
            this.Runbtn.Click += new System.EventHandler(this.Runbtn_Click);
            // 
            // Startbtn
            // 
            this.Startbtn.Location = new System.Drawing.Point(34, 196);
            this.Startbtn.Name = "Startbtn";
            this.Startbtn.Size = new System.Drawing.Size(139, 57);
            this.Startbtn.TabIndex = 0;
            this.Startbtn.Text = "Start";
            this.Startbtn.UseVisualStyleBackColor = true;
            this.Startbtn.Click += new System.EventHandler(this.Startbtn_Click);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.ClientSize = new System.Drawing.Size(630, 299);
            this.Controls.Add(this.Runbtn);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Endbtn);
            this.Controls.Add(this.Startbtn);
            this.Name = "StartForm";
            this.Text = "StartForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Endbtn;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Runbtn;
        private System.Windows.Forms.Button Startbtn;
    }
}