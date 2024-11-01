namespace _1700A_GUI
{
    partial class msgpopup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(msgpopup));
            this.closebutton = new System.Windows.Forms.Button();
            this.msglabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // closebutton
            // 
            this.closebutton.Location = new System.Drawing.Point(278, 304);
            this.closebutton.Name = "closebutton";
            this.closebutton.Size = new System.Drawing.Size(213, 83);
            this.closebutton.TabIndex = 0;
            this.closebutton.Text = "Close";
            this.closebutton.UseVisualStyleBackColor = true;
            this.closebutton.Click += new System.EventHandler(this.closebutton_Click);
            // 
            // msglabel
            // 
            this.msglabel.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.msglabel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.msglabel.Location = new System.Drawing.Point(166, 178);
            this.msglabel.Name = "msglabel";
            this.msglabel.Size = new System.Drawing.Size(450, 63);
            this.msglabel.TabIndex = 1;
            this.msglabel.Text = "invalid number";
            this.msglabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // msgpopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.msglabel);
            this.Controls.Add(this.closebutton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "msgpopup";
            this.Text = "Notice";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button closebutton;
        public System.Windows.Forms.Label msglabel;
    }
}