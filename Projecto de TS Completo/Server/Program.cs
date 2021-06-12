using EI.SI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    
    class Program
    {
            private const int PORT = 10000;
            static void Main(string[] args)
            {
                //Criar um conjunto IP+PORTA do Cliente
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, PORT);

                //Criar um TcpListener
                TcpListener listener = new TcpListener(endPoint);
                listener.Start();

                Console.WriteLine("Servidor pronto para receber cliente e mensagens.");

                while (true)
                {
                int clientCounter = 0;
                TcpClient client = listener.AcceptTcpClient();
                    clientCounter++;
                    //Console.WriteLine("{0} Clientes conectados", clientCounter);
                    ClientHandler clientHandler = new ClientHandler(client, clientCounter);
                    clientHandler.Handle();

                }
            }

    }

    //Criar o cliente no servidor
    class ClientHandler
    {
        private TcpClient client;
        private int clientID;

        //Para criar um cliente e instanciar um número
        public ClientHandler(TcpClient client, int clientID)
        {
            this.client = client;
            this.clientID = clientID;
        }

        public void Handle()
        {
            Thread thread = new Thread(threadHandler);
            thread.Start();
        }

        //Estabelecer comunicação e obter mensagens do cliente
        private void threadHandler()
        {
            NetworkStream networkStream = this.client.GetStream();
            ProtocolSI protocolSI = new ProtocolSI();

            while (protocolSI.GetCmdType() != ProtocolSICmdType.EOT)
            {
                //Ler dados do cliente
                try 
                {
                    int bytesRead = networkStream.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length);
                }
                finally
                {

                }

                //Criar resposta para o cliente
                byte[] ack;

                switch (protocolSI.GetCmdType())
                {
                    case ProtocolSICmdType.DATA:
                        Console.WriteLine(protocolSI.GetStringFromData());

                        
                        string caminho = @"C:\Users\alber\Desktop\Projecto de TS Compl,eto\Server\conversa.txt";
                        FileStream fs = new FileStream(caminho, FileMode.Append, FileAccess.Write);
                        // criar o buffer binário de escrita
                        BinaryWriter bw = new BinaryWriter(fs);
                        // Guardar os dados no ficheiro 
                        bw.Write(protocolSI.GetStringFromData());
                        // Fechar o ficheiro e o stream
                        bw.Close();
                        fs.Close();

                        //Criar resposta paara o cliente com o protocolSI
                        ack = protocolSI.Make(ProtocolSICmdType.ACK);

                        //Enviar a mensagem para o cliente
                        networkStream.Write(ack, 0, ack.Length);
                        break;

                    case ProtocolSICmdType.EOT:
                        Console.WriteLine("Deixou o Chat");

                        //Criar resposta paara o cliente com o protocolSI
                        ack = protocolSI.Make(ProtocolSICmdType.ACK);

                        //Enviar a mensagem para o cliente
                        networkStream.Write(ack, 0, ack.Length);
                        break;
                }
            }
            //Fechar as ligações
            networkStream.Close();
            client.Close();

        }
    }

}