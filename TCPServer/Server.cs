using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Oblikatoriskopgave1;

namespace TCPServer
{
    class Server
    {

        public static int ClientNr = 1;

        private static List<FanOutput> Data = new List<FanOutput>()
        {
            new FanOutput(1, "Hejsa", 23.01, 45),
            new FanOutput(2, "hejsa1", 23.1,55)
        };

        public static void Start()
        {
            Console.WriteLine("Starting FanOutput server");

            // Tcplisterner server serversocket
            TcpListener serverSocket = new TcpListener(IPAddress.Loopback, 4646);

            //Start server
            serverSocket.Start();

            do
            {
                //Accept Tcp client

                TcpClient connectionSocket = serverSocket.AcceptTcpClient();
                Console.WriteLine($"Server Activicted, and this client {ClientNr} connected");

                Task.Run(() =>
                {
                    DoClient(connectionSocket, ClientNr++);
                });



                if (ClientNr < 1)
                {
                    break;
                }
            } while (ClientNr > 0);

        }


        public static void DoClient(TcpClient connectionSocket, int ClientNr)
        {
            Stream ns = connectionSocket.GetStream();
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true; // Enable automatic flushing


            Console.WriteLine("Hejsa, Hvilken Request vil du fortage? HentAlle, Hent eller Gem");
            string message = sr.ReadLine();

            switch (message)
            {
                case "HentAlle":
                    var json = JsonConvert.SerializeObject(Data);
                    sw.WriteLine(json);
                    Console.WriteLine(json);
                    break;

                case "Hent":
                    Console.WriteLine("Hvilket id ønsker du og se?");
                    string id = sr.ReadLine();
                    int ConvertId = Int32.Parse(id);
                    var json2 = JsonConvert.SerializeObject(Data.Find(i => ConvertId == i.Id));
                    sw.WriteLine(json2);
                    Console.WriteLine($"Her har du fået dataen udfra det id du har indtastet" + json2);
                    break;

                case "Gem":
                    Console.WriteLine("Indtast ID, Name, temp (Som double) og humidity");
                    string input = sr.ReadLine();
                    FanOutput newFanOutput = new FanOutput(Convert.ToInt32(input.Split(" ")[0]), input.Split(" ")[1], Convert.ToDouble(input.Split(" ")[2]), Convert.ToInt32(input.Split("")[3]));
                    Data.Add(newFanOutput);
                    break;
            }

            ns.Close();

            connectionSocket.Close();



        }



    }
}
