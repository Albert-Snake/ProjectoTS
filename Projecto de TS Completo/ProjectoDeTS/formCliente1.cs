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
        //variaveis globais
        private const int PORT = 10000;
        NetworkStream networkStream;
        ProtocolSI protocolSI;
        TcpClient client;
        string User;

        public formCliente1(string nome)
        {
            InitializeComponent();

            //copia o valor enviado do form Login para a variavel globar User
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

            //Envia uma mensagem de avisoa a informar que o utilizador entrou
            MensagemDeEntrada();

            //carrega a conversa guardada no ficheiro txt
            carregarConversa();

            //Permite que de 1 em 1 segundos verifique se ouve alteração na conversa
            timer1.Start();

            //concatna ao nome do forme uma string a informar o nome do utilizador que inicioiu sessao 
            this.Text = this.Text + " - Session of " + User;

            //limpa os valores da tbxConversa
            tbxConversa.Text = "";

            //posiciona a scrollbar no fundo
            tbxConversa.SelectionStart = tbxConversa.TextLength;
            tbxConversa.ScrollToCaret();
        }

        private void MensagemDeEntrada()
        {
            //mensagem escrita que será enviada para o servidor
            string msg = DateTime.Now + "\r\n" + User + " Entrou No Servidor" + "\r\n";

            //Criar a mensagem
            byte[] packet = protocolSI.Make(ProtocolSICmdType.DATA, msg);

            //Enviar a mensagem pela ligação
            try
            {
                networkStream.Write(packet, 0, packet.Length);
            }
            catch (Exception ex)
            { 
            }

            while (protocolSI.GetCmdType() != ProtocolSICmdType.ACK)
            {
                networkStream.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length);
            }

        }

        private void carregarFicheiro()
        {
            //inicia a ligação
            Stream myStream;
            //Cria um novo objecto SaveFileDialog1
            OpenFileDialog saveFileDialog1 = new OpenFileDialog();

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Variavel onde será armazenada a localização do ficheiro
                string filePath;

                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    //guarda o caminho na variavel
                    filePath = saveFileDialog1.FileName;

                    //fecha a ligação
                    myStream.Close();

                    //mensagem a ser enviada com a localização do ficheiro
                    string msg = filePath + "\r\n";

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
                
            }
        }

        private void carregarConversa()
        {
            try
            {
                //Directorio onde o ficheiro txt da conversa esta armazenado
                string fileDir = @"C:\Projecto de TS Completo\Server\conversa.txt";

                //Verifica se o ficheiro existe. .     
                if (File.Exists(fileDir))
                {

                    //Abre o ficheiro e lê-o    
                    using (StreamReader sr = File.OpenText(fileDir))
                    {
                        //variaveis
                        string s = "";
                        string msg = "";
                        while ((s = sr.ReadLine()) != null)
                        {
                            //Guarda a conversa na variavel msg
                            msg = msg + s + "\r\n";
                        }
                        //Compara se a tbxConversa tem o msm text que a string msg
                        if (tbxConversa.Text != msg)
                        {
                            tbxConversa.Text = "";
                            tbxConversa.Text =  msg;
                            tbxConversa.SelectionStart = tbxConversa.TextLength;
                            tbxConversa.ScrollToCaret();
                        }
                        //fecha ligação
                        sr.Close();
                    }
                }
                else
                {
                    //Cria um novo ficheiro        
                    FileStream fs = File.Create(fileDir);
                    fs.Close();
                }

            }
            catch (Exception Ex)
            {
                
            }
        }

        private void formCliente1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //pergunta se quer mesmo sair o que irá terminar a sessão
            if (MessageBox.Show("Pretende mesmo Sair?", "SAIR DO PROGRAMA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //Enviar msg a informar que se desconectou
                string msg =  DateTime.Now + "\r\n" + User + " Desconectou do Servidor" + "\r\n";

                //Criar a mensagem
                byte[] packet = protocolSI.Make(ProtocolSICmdType.DATA, msg);

                //Enviar a mensagem pela ligação
                try 
                {
                    networkStream.Write(packet, 0, packet.Length);
                }
                catch(Exception ex)
                {

                }

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
            //Enviar mensagem do cliente para o servidor            
            string msg = DateTime.Now + "\r\n" + User + " : " + tbxMensagem.Text + "\r\n";
            //limpa a tbxMensagem
            tbxMensagem.Text = "";

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

        private void btnFicheiro_Click(object sender, EventArgs e)
        {
            carregarFicheiro();
        }
    }
}
