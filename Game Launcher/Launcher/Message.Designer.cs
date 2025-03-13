namespace Game_Launcher
{
    partial class Message
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
            this.BorderlessForm = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.BT_CLOSE = new Guna.UI2.WinForms.Guna2ControlBox();
            this.Confirm_Button = new Guna.UI2.WinForms.Guna2Button();
            this.lbl_string = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BorderlessForm
            // 
            this.BorderlessForm.BorderRadius = 25;
            this.BorderlessForm.ContainerControl = this;
            this.BorderlessForm.DockForm = false;
            this.BorderlessForm.DockIndicatorTransparencyValue = 0D;
            this.BorderlessForm.DragStartTransparencyValue = 1D;
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
            this.BT_CLOSE.Location = new System.Drawing.Point(254, 6);
            this.BT_CLOSE.Name = "BT_CLOSE";
            this.BT_CLOSE.Size = new System.Drawing.Size(45, 30);
            this.BT_CLOSE.TabIndex = 6;
            this.BT_CLOSE.Click += new System.EventHandler(this.BT_CLOSE_Click);
            // 
            // Confirm_Button
            // 
            this.Confirm_Button.BorderColor = System.Drawing.Color.Transparent;
            this.Confirm_Button.BorderRadius = 3;
            this.Confirm_Button.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Confirm_Button.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Confirm_Button.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Confirm_Button.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Confirm_Button.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Confirm_Button.Font = new System.Drawing.Font("Object Sans", 9.749998F);
            this.Confirm_Button.ForeColor = System.Drawing.Color.White;
            this.Confirm_Button.Location = new System.Drawing.Point(107, 127);
            this.Confirm_Button.Name = "Confirm_Button";
            this.Confirm_Button.Size = new System.Drawing.Size(95, 25);
            this.Confirm_Button.TabIndex = 9;
            this.Confirm_Button.Text = "Confirmar";
            this.Confirm_Button.Click += new System.EventHandler(this.Confirm_Button_Click);
            // 
            // lbl_string
            // 
            this.lbl_string.BackColor = System.Drawing.Color.Transparent;
            this.lbl_string.Font = new System.Drawing.Font("Object Sans", 9.749998F);
            this.lbl_string.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_string.Location = new System.Drawing.Point(13, 36);
            this.lbl_string.Name = "lbl_string";
            this.lbl_string.Size = new System.Drawing.Size(277, 85);
            this.lbl_string.TabIndex = 10;
            this.lbl_string.Text = "No_String";
            this.lbl_string.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Message
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(305, 169);
            this.Controls.Add(this.lbl_string);
            this.Controls.Add(this.Confirm_Button);
            this.Controls.Add(this.BT_CLOSE);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Message";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm BorderlessForm;
        private Guna.UI2.WinForms.Guna2ControlBox BT_CLOSE;
        private Guna.UI2.WinForms.Guna2Button Confirm_Button;
        private System.Windows.Forms.Label lbl_string;
    }
}