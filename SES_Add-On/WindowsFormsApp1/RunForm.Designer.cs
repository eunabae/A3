namespace SES_Add_ON
{
    partial class RunForm
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
            this.RunConsole = new System.Windows.Forms.TextBox();
            this.NextMovebtn = new System.Windows.Forms.Button();
            this.Closebtn = new System.Windows.Forms.Button();
            this.Detectbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RunConsole
            // 
            this.RunConsole.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.RunConsole.Location = new System.Drawing.Point(359, 23);
            this.RunConsole.Multiline = true;
            this.RunConsole.Name = "RunConsole";
            this.RunConsole.Size = new System.Drawing.Size(657, 549);
            this.RunConsole.TabIndex = 0;
            this.RunConsole.TabStop = false;
            this.RunConsole.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // NextMovebtn
            // 
            this.NextMovebtn.Location = new System.Drawing.Point(75, 223);
            this.NextMovebtn.Name = "NextMovebtn";
            this.NextMovebtn.Size = new System.Drawing.Size(194, 92);
            this.NextMovebtn.TabIndex = 1;
            this.NextMovebtn.Text = "NextMove";
            this.NextMovebtn.UseVisualStyleBackColor = true;
            this.NextMovebtn.Click += new System.EventHandler(this.NextMovebtn_Click);
            // 
            // Closebtn
            // 
            this.Closebtn.Location = new System.Drawing.Point(75, 408);
            this.Closebtn.Name = "Closebtn";
            this.Closebtn.Size = new System.Drawing.Size(194, 87);
            this.Closebtn.TabIndex = 2;
            this.Closebtn.Text = "Close";
            this.Closebtn.UseVisualStyleBackColor = true;
            this.Closebtn.Click += new System.EventHandler(this.Closebtn_Click);
            // 
            // Detectbtn
            // 
            this.Detectbtn.Location = new System.Drawing.Point(75, 49);
            this.Detectbtn.Name = "Detectbtn";
            this.Detectbtn.Size = new System.Drawing.Size(194, 89);
            this.Detectbtn.TabIndex = 3;
            this.Detectbtn.Text = "Detect";
            this.Detectbtn.UseVisualStyleBackColor = true;
            this.Detectbtn.Click += new System.EventHandler(this.Detectbtn_Click);
            // 
            // RunForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.ClientSize = new System.Drawing.Size(1046, 604);
            this.Controls.Add(this.Detectbtn);
            this.Controls.Add(this.Closebtn);
            this.Controls.Add(this.NextMovebtn);
            this.Controls.Add(this.RunConsole);
            this.Name = "RunForm";
            this.Text = "RunForm";
            this.Load += new System.EventHandler(this.RunForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox RunConsole;
        private System.Windows.Forms.Button NextMovebtn;
        private System.Windows.Forms.Button Closebtn;
        private System.Windows.Forms.Button Detectbtn;
    }
}