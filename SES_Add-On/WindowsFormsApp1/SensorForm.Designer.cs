namespace SES_Add_ON
{
    partial class SensorForm
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
            this.Sensortxt = new System.Windows.Forms.TextBox();
            this.Okbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Sensortxt
            // 
            this.Sensortxt.BackColor = System.Drawing.SystemColors.Control;
            this.Sensortxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Sensortxt.Enabled = false;
            this.Sensortxt.Font = new System.Drawing.Font("굴림", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Sensortxt.Location = new System.Drawing.Point(62, 56);
            this.Sensortxt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Sensortxt.Name = "Sensortxt";
            this.Sensortxt.ReadOnly = true;
            this.Sensortxt.Size = new System.Drawing.Size(348, 24);
            this.Sensortxt.TabIndex = 0;
            this.Sensortxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Okbtn
            // 
            this.Okbtn.Location = new System.Drawing.Point(165, 104);
            this.Okbtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Okbtn.Name = "Okbtn";
            this.Okbtn.Size = new System.Drawing.Size(130, 41);
            this.Okbtn.TabIndex = 1;
            this.Okbtn.Text = "OK";
            this.Okbtn.UseVisualStyleBackColor = true;
            this.Okbtn.Click += new System.EventHandler(this.Okbtn_Click);
            // 
            // SensorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 177);
            this.Controls.Add(this.Okbtn);
            this.Controls.Add(this.Sensortxt);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "SensorForm";
            this.Text = "SensorForm";
            this.Load += new System.EventHandler(this.SensorForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Sensortxt;
        private System.Windows.Forms.Button Okbtn;
    }
}