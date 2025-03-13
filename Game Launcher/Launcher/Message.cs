using System;
using System.Drawing;
using System.Windows.Forms;

namespace Game_Launcher
{
    public partial class Message : Form
    {
        public Message()
        {
            InitializeComponent();
        }
        public DialogResult Resultado { get; private set; }
        public static DialogResult Mostrar(string mensagem, string v)
        {
            var msgBox = new Message();
            msgBox.lbl_string.Text = mensagem.Replace("\\n", Environment.NewLine);
            msgBox.lbl_string.ForeColor = Color.White;
            msgBox.ShowDialog();
            return msgBox.Resultado;
        }
        private void Confirm_Button_Click(object sender, EventArgs e)
        {
            Resultado = DialogResult.Yes;
            Close();
        }
        private void BT_CLOSE_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
