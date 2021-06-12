using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;

namespace formCliente2
{
    public partial class formLogin2 : Form
    {
        public formLogin2()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string nome = tbxNome.Text;
            //byte[] outStream = System.Text.Encoding.ASCII.GetBytes(tbxNome.Text + "$");
            //serverStream.Write(outStream, 0, outStream.Length);
            //serverStream.Flush();
            //System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();
            //NetworkStream serverStream = default(NetworkStream);
            formCliente2 form2 = new formCliente2(nome);
            form2.Show();
            this.Hide();
        }
    }
}
