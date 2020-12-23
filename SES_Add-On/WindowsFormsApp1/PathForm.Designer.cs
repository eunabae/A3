namespace SES_Add_ON
{
    partial class PathForm
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
            this.Pathtxt = new System.Windows.Forms.TextBox();
            this.OKbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Pathtxt
            // 
            this.Pathtxt.BackColor = System.Drawing.SystemColors.Control;
            this.Pathtxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Pathtxt.Enabled = false;
            this.Pathtxt.Font = new System.Drawing.Font("굴림", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Pathtxt.Location = new System.Drawing.Point(108, 52);
            this.Pathtxt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Pathtxt.Multiline = true;
            this.Pathtxt.Name = "Pathtxt";
            this.Pathtxt.Size = new System.Drawing.Size(251, 54);
            this.Pathtxt.TabIndex = 0;
            this.Pathtxt.Text = "경로를 재탐색합니다.";
            this.Pathtxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // OKbtn
            // 
            this.OKbtn.Location = new System.Drawing.Point(161, 119);
            this.OKbtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.OKbtn.Name = "OKbtn";
            this.OKbtn.Size = new System.Drawing.Size(118, 35);
            this.OKbtn.TabIndex = 1;
            this.OKbtn.Text = "OK";
            this.OKbtn.UseVisualStyleBackColor = true;
            this.OKbtn.Click += new System.EventHandler(this.OKbtn_Click);
            // 
            // PathForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 177);
            this.Controls.Add(this.OKbtn);
            this.Controls.Add(this.Pathtxt);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "PathForm";
            this.Text = "PathForm";
            this.Load += new System.EventHandler(this.PathForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Pathtxt;
        private System.Windows.Forms.Button OKbtn;
    }
}