using EI.SI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectoDeTS
{
    public partial class formCliente1 : Form
    {
        private const int PORT = 10000;
        NetworkStream networkStream;
        ProtocolSI protocolSI;
        TcpClient client;
        string User;

        public formCliente1(string nome)
        {
            InitializeComponent();

            User = nome;

            //Criar conjunto IP+PORT do servidor
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Loopback, PORT);

            //Criar o cliente TCP
            client = new TcpClient();

            //Efetuar a ligação ao servidor
            client.Connect(endPoint);

            //Obter a ligação do servidor
            networkStream = client.GetStream();
            protocolSI = new ProtocolSI();

            MensagemDeEntrada();

            carregarConversa();

            timer1.Start();
        }

        private void MensagemDeEntrada()
        {
            string msg = "\r\n" + DateTime.Now + "\r\n" + User + " Entrou No Servidor";

            //Criar a mensagem
            byte[] packet = protocolSI.Make(ProtocolSICmdType.DATA, msg);

            //Enviar a mensagem pela ligação
            try
            {
                networkStream.Write(packet, 0, packet.Length);
            }
            finally
            { 
            }

            while (protocolSI.GetCmdType() != ProtocolSICmdType.ACK)
            {
                networkStream.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length);
            }

        }

        private void carregarConversa()
        {
            tbxConversa.Text = "";
            string fileDir = @"C:\Projecto de TS Completo\Server\conversa.txt";

            try
            {
                // Check if file already exists. If yes, delete it.     
                if (File.Exists(fileDir))
                {
                    
                    // Open the stream and read it back.    
                    using (StreamReader sr = File.OpenText(fileDir))
                    {
                        string s = "";
                        while ((s = sr.ReadLine()) != null)
                        {
                            tbxConversa.Text = tbxConversa.Text + s + "\r\n";
                        }
                        sr.Close();
                    }
                }
                else
                {
                    // Create a new file     
                    FileStream fs = File.Create(fileDir);
                    fs.Close();
                }
                




            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
        }

        private void formCliente1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Pretende mesmo Sair?", "SAIR DO PROGRAMA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string msg = "\r\n" + DateTime.Now + "\r\n" + User + " Desconectou do Servidor";

                //Criar a mensagem
                byte[] packet = protocolSI.Make(ProtocolSICmdType.DATA, msg);

                //Enviar a mensagem pela ligação
                networkStream.Write(packet, 0, packet.Length);

                while (protocolSI.GetCmdType() != ProtocolSICmdType.ACK)
                {
                    networkStream.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length);
                }

                byte[] eot = protocolSI.Make(ProtocolSICmdType.EOT);
                networkStream.Write(eot, 0, eot.Length);
                networkStream.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length);


                //Fechar todas as ligações
                networkStream.Close();
                client.Close();
                formLogin1 form2 = new formLogin1();
                form2.Show();
                this.Hide();
            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            tbxConversa.Text = tbxConversa.Text + "Eu: - " + tbxMensagem.Text + "\r\n\r\n";

            //Enviar mensagem do cliente para o servidor
            string msg = "\r\n" + DateTime.Now + "\r\n" + User + " : " + tbxMensagem.Text;
            tbxMensagem.Clear();

            //Criar a mensagem
            byte[] packet = protocolSI.Make(ProtocolSICmdType.DATA, msg);

            //Enviar a mensagem pela ligação
            networkStream.Write(packet, 0, packet.Length);

            while (protocolSI.GetCmdType() != ProtocolSICmdType.ACK)
            {
                networkStream.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            carregarConversa();
        }
    }
}
