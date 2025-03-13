using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppUpdater
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
    }
}
