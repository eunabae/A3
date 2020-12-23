namespace SES_Add_ON
{
    partial class MapForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.Maptxt = new System.Windows.Forms.TextBox();
            this.Mapbtn = new System.Windows.Forms.Button();
            this.ConsoleBox = new System.Windows.Forms.TextBox();
            this.Mapconsole = new System.Windows.Forms.TextBox();
            this.Hazardtxt = new System.Windows.Forms.TextBox();
            this.Colortxt = new System.Windows.Forms.TextBox();
            this.Hazardbtn = new System.Windows.Forms.Button();
            this.Colorbtn = new System.Windows.Forms.Button();
            this.Savebtn = new System.Windows.Forms.Button();
            this.Starttxt = new System.Windows.Forms.TextBox();
            this.Startbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Maptxt
            // 
            this.Maptxt.Location = new System.Drawing.Point(34, 23);
            this.Maptxt.Margin = new System.Windows.Forms.Padding(4);
            this.Maptxt.Name = "Maptxt";
            this.Maptxt.Size = new System.Drawing.Size(156, 35);
            this.Maptxt.TabIndex = 0;
            // 
            // Mapbtn
            // 
            this.Mapbtn.BackColor = System.Drawing.SystemColors.Control;
            this.Mapbtn.Location = new System.Drawing.Point(218, 20);
            this.Mapbtn.Margin = new System.Windows.Forms.Padding(4);
            this.Mapbtn.Name = "Mapbtn";
            this.Mapbtn.Size = new System.Drawing.Size(97, 40);
            this.Mapbtn.TabIndex = 3;
            this.Mapbtn.Text = "Map";
            this.Mapbtn.UseVisualStyleBackColor = false;
            this.Mapbtn.Click += new System.EventHandler(this.Mapbtn_Click);
            // 
            // ConsoleBox
            // 
            this.ConsoleBox.Location = new System.Drawing.Point(35, 215);
            this.ConsoleBox.Margin = new System.Windows.Forms.Padding(4);
            this.ConsoleBox.Multiline = true;
            this.ConsoleBox.Name = "ConsoleBox";
            this.ConsoleBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ConsoleBox.Size = new System.Drawing.Size(280, 287);
            this.ConsoleBox.TabIndex = 4;
            // 
            // Mapconsole
            // 
            this.Mapconsole.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Mapconsole.Location = new System.Drawing.Point(359, 23);
            this.Mapconsole.Margin = new System.Windows.Forms.Padding(4);
            this.Mapconsole.Multiline = true;
            this.Mapconsole.Name = "Mapconsole";
            this.Mapconsole.Size = new System.Drawing.Size(657, 549);
            this.Mapconsole.TabIndex = 5;
            this.Mapconsole.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Hazardtxt
            // 
            this.Hazardtxt.Location = new System.Drawing.Point(35, 112);
            this.Hazardtxt.Name = "Hazardtxt";
            this.Hazardtxt.Size = new System.Drawing.Size(156, 35);
            this.Hazardtxt.TabIndex = 6;
            // 
            // Colortxt
            // 
            this.Colortxt.Location = new System.Drawing.Point(35, 155);
            this.Colortxt.Name = "Colortxt";
            this.Colortxt.Size = new System.Drawing.Size(156, 35);
            this.Colortxt.TabIndex = 7;
            // 
            // Hazardbtn
            // 
            this.Hazardbtn.BackColor = System.Drawing.SystemColors.Control;
            this.Hazardbtn.Location = new System.Drawing.Point(218, 112);
            this.Hazardbtn.Name = "Hazardbtn";
            this.Hazardbtn.Size = new System.Drawing.Size(97, 39);
            this.Hazardbtn.TabIndex = 8;
            this.Hazardbtn.Text = "Hazard";
            this.Hazardbtn.UseVisualStyleBackColor = false;
            this.Hazardbtn.Click += new System.EventHandler(this.Hazardbtn_Click);
            // 
            // Colorbtn
            // 
            this.Colorbtn.BackColor = System.Drawing.SystemColors.Control;
            this.Colorbtn.Location = new System.Drawing.Point(217, 157);
            this.Colorbtn.Name = "Colorbtn";
            this.Colorbtn.Size = new System.Drawing.Size(97, 35);
            this.Colorbtn.TabIndex = 9;
            this.Colorbtn.Text = "Color";
            this.Colorbtn.UseVisualStyleBackColor = false;
            this.Colorbtn.Click += new System.EventHandler(this.Colorbtn_Click);
            // 
            // Savebtn
            // 
            this.Savebtn.BackColor = System.Drawing.SystemColors.Control;
            this.Savebtn.Location = new System.Drawing.Point(35, 517);
            this.Savebtn.Name = "Savebtn";
            this.Savebtn.Size = new System.Drawing.Size(279, 56);
            this.Savebtn.TabIndex = 10;
            this.Savebtn.Text = "Save";
            this.Savebtn.UseVisualStyleBackColor = false;
            this.Savebtn.Click += new System.EventHandler(this.Closebtn_Click);
            // 
            // Starttxt
            // 
            this.Starttxt.Location = new System.Drawing.Point(34, 68);
            this.Starttxt.Margin = new System.Windows.Forms.Padding(4);
            this.Starttxt.Name = "Starttxt";
            this.Starttxt.Size = new System.Drawing.Size(156, 35);
            this.Starttxt.TabIndex = 11;
            // 
            // Startbtn
            // 
            this.Startbtn.BackColor = System.Drawing.SystemColors.Control;
            this.Startbtn.Location = new System.Drawing.Point(218, 68);
            this.Startbtn.Margin = new System.Windows.Forms.Padding(4);
            this.Startbtn.Name = "Startbtn";
            this.Startbtn.Size = new System.Drawing.Size(99, 37);
            this.Startbtn.TabIndex = 12;
            this.Startbtn.Text = "Start";
            this.Startbtn.UseVisualStyleBackColor = false;
            this.Startbtn.Click += new System.EventHandler(this.Startbtn_Click);
            // 
            // MapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.ClientSize = new System.Drawing.Size(1046, 604);
            this.Controls.Add(this.Startbtn);
            this.Controls.Add(this.Starttxt);
            this.Controls.Add(this.Savebtn);
            this.Controls.Add(this.Colorbtn);
            this.Controls.Add(this.Hazardbtn);
            this.Controls.Add(this.Colortxt);
            this.Controls.Add(this.Hazardtxt);
            this.Controls.Add(this.Mapconsole);
            this.Controls.Add(this.ConsoleBox);
            this.Controls.Add(this.Mapbtn);
            this.Controls.Add(this.Maptxt);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MapForm";
            this.Text = "MapForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Maptxt;
        public System.Windows.Forms.Button Mapbtn;
        public System.Windows.Forms.TextBox ConsoleBox;
        public System.Windows.Forms.TextBox Mapconsole;
        public System.Windows.Forms.TextBox Hazardtxt;
        public System.Windows.Forms.TextBox Colortxt;
        public System.Windows.Forms.Button Hazardbtn;
        public System.Windows.Forms.Button Colorbtn;
        private System.Windows.Forms.Button Savebtn;
        private System.Windows.Forms.TextBox Starttxt;
        private System.Windows.Forms.Button Startbtn;
    }
}

