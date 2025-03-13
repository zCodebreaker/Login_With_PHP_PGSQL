namespace Game_Launcher
{
    partial class Init
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Init));
            this.BorderlessForm = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.lblstatus = new System.Windows.Forms.Label();
            this.BT_CLOSE = new Guna.UI2.WinForms.Guna2ControlBox();
            this.PIC_LOGO = new Guna.UI2.WinForms.Guna2PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PIC_LOGO)).BeginInit();
            this.SuspendLayout();
            // 
            // BorderlessForm
            // 
            this.BorderlessForm.AnimateWindow = true;
            this.BorderlessForm.AnimationInterval = 100;
            this.BorderlessForm.BorderRadius = 25;
            this.BorderlessForm.ContainerControl = this;
            this.BorderlessForm.DockIndicatorTransparencyValue = 0.6D;
            this.BorderlessForm.DragStartTransparencyValue = 1D;
            this.BorderlessForm.ResizeForm = false;
            this.BorderlessForm.TransparentWhileDrag = true;
            // 
            // lblstatus
            // 
            this.lblstatus.BackColor = System.Drawing.Color.Transparent;
            this.lblstatus.Font = new System.Drawing.Font("Bebas Neue", 15.75F);
            this.lblstatus.ForeColor = System.Drawing.Color.White;
            this.lblstatus.Location = new System.Drawing.Point(10, 233);
            this.lblstatus.Name = "lblstatus";
            this.lblstatus.Size = new System.Drawing.Size(360, 23);
            this.lblstatus.TabIndex = 3;
            this.lblstatus.Text = "Carregando...";
            this.lblstatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BT_CLOSE
            // 
            this.BT_CLOSE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BT_CLOSE.ControlBoxStyle = Guna.UI2.WinForms.Enums.ControlBoxStyle.Custom;
            this.BT_CLOSE.Cursor = System.Windows.Forms.Cursors.Default;
            this.BT_CLOSE.CustomClick = true;
            this.BT_CLOSE.CustomIconSize = 15F;
            this.BT_CLOSE.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.BT_CLOSE.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BT_CLOSE.HoverState.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BT_CLOSE.IconColor = System.Drawing.Color.White;
            this.BT_CLOSE.ImeMode = System.Windows.Forms.ImeMode.On;
            this.BT_CLOSE.Location = new System.Drawing.Point(325, 12);
            this.BT_CLOSE.Name = "BT_CLOSE";
            this.BT_CLOSE.Size = new System.Drawing.Size(45, 30);
            this.BT_CLOSE.TabIndex = 6;
            // 
            // PIC_LOGO
            // 
            this.PIC_LOGO.BackColor = System.Drawing.Color.Transparent;
            this.PIC_LOGO.BorderRadius = 15;
            this.PIC_LOGO.Image = ((System.Drawing.Image)(resources.GetObject("PIC_LOGO.Image")));
            this.PIC_LOGO.ImageRotate = 0F;
            this.PIC_LOGO.Location = new System.Drawing.Point(15, 50);
            this.PIC_LOGO.Name = "PIC_LOGO";
            this.PIC_LOGO.Size = new System.Drawing.Size(350, 170);
            this.PIC_LOGO.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PIC_LOGO.TabIndex = 16;
            this.PIC_LOGO.TabStop = false;
            this.PIC_LOGO.UseTransparentBackground = true;
            // 
            // Init
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(381, 271);
            this.Controls.Add(this.PIC_LOGO);
            this.Controls.Add(this.BT_CLOSE);
            this.Controls.Add(this.lblstatus);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Init";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Init";
            ((System.ComponentModel.ISupportInitialize)(this.PIC_LOGO)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm BorderlessForm;
        private System.Windows.Forms.Label lblstatus;
        private Guna.UI2.WinForms.Guna2ControlBox BT_CLOSE;
        private Guna.UI2.WinForms.Guna2PictureBox PIC_LOGO;
    }
}