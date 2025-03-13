namespace AppUpdater
{
    partial class AppUpdater
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppUpdater));
            this.BorderlessForm = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.BT_CLOSE = new Guna.UI2.WinForms.Guna2ControlBox();
            this.lblstatus = new System.Windows.Forms.Label();
            this.DOWNLOAD_BAR = new Guna.UI2.WinForms.Guna2ProgressBar();
            this.SuspendLayout();
            // 
            // BorderlessForm
            // 
            this.BorderlessForm.AnimateWindow = true;
            this.BorderlessForm.AnimationInterval = 100;
            this.BorderlessForm.BorderRadius = 25;
            this.BorderlessForm.ContainerControl = this;
            this.BorderlessForm.DockIndicatorTransparencyValue = 1D;
            this.BorderlessForm.ResizeForm = false;
            this.BorderlessForm.TransparentWhileDrag = true;
            // 
            // BT_CLOSE
            // 
            this.BT_CLOSE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BT_CLOSE.Animated = true;
            this.BT_CLOSE.ControlBoxStyle = Guna.UI2.WinForms.Enums.ControlBoxStyle.Custom;
            this.BT_CLOSE.Cursor = System.Windows.Forms.Cursors.Default;
            this.BT_CLOSE.CustomClick = true;
            this.BT_CLOSE.CustomIconSize = 15F;
            this.BT_CLOSE.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.BT_CLOSE.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.BT_CLOSE.HoverState.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BT_CLOSE.IconColor = System.Drawing.SystemColors.Control;
            this.BT_CLOSE.ImeMode = System.Windows.Forms.ImeMode.On;
            this.BT_CLOSE.Location = new System.Drawing.Point(509, 12);
            this.BT_CLOSE.Name = "BT_CLOSE";
            this.BT_CLOSE.Size = new System.Drawing.Size(45, 30);
            this.BT_CLOSE.TabIndex = 7;
            this.BT_CLOSE.Click += new System.EventHandler(this.BT_CLOSE_Click);
            // 
            // lblstatus
            // 
            this.lblstatus.BackColor = System.Drawing.Color.Transparent;
            this.lblstatus.Font = new System.Drawing.Font("Object Sans", 9.749998F);
            this.lblstatus.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblstatus.Location = new System.Drawing.Point(24, 79);
            this.lblstatus.Name = "lblstatus";
            this.lblstatus.Size = new System.Drawing.Size(523, 25);
            this.lblstatus.TabIndex = 31;
            this.lblstatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DOWNLOAD_BAR
            // 
            this.DOWNLOAD_BAR.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.DOWNLOAD_BAR.BorderRadius = 8;
            this.DOWNLOAD_BAR.BorderThickness = 1;
            this.DOWNLOAD_BAR.Location = new System.Drawing.Point(22, 110);
            this.DOWNLOAD_BAR.Name = "DOWNLOAD_BAR";
            this.DOWNLOAD_BAR.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.DOWNLOAD_BAR.ProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.DOWNLOAD_BAR.Size = new System.Drawing.Size(525, 30);
            this.DOWNLOAD_BAR.TabIndex = 32;
            this.DOWNLOAD_BAR.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.DOWNLOAD_BAR.Value = 100;
            // 
            // AppUpdater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(566, 163);
            this.Controls.Add(this.DOWNLOAD_BAR);
            this.Controls.Add(this.lblstatus);
            this.Controls.Add(this.BT_CLOSE);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AppUpdater";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm BorderlessForm;
        private Guna.UI2.WinForms.Guna2ControlBox BT_CLOSE;
        private System.Windows.Forms.Label lblstatus;
        private Guna.UI2.WinForms.Guna2ProgressBar DOWNLOAD_BAR;
    }
}

