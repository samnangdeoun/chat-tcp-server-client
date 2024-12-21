using System;
using System.Threading;
using System.Net.Sockets;
using System.Text;
using System.Collections;
using System.Net;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerChat
{
    class Program
    {
        private static List<TcpClient> clients = new List<TcpClient>();
        private static List<string> userNames = new List<string>();

        static async Task Main(string[] args)
        {
            // Initialize server
            TcpListener listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 8888);
            listener.Start();
            Console.WriteLine("SERVER STARTED...");

            try
            {
                while (true)
                {
                    TcpClient client = await listener.AcceptTcpClientAsync();
                    clients.Add(client);
                    Console.WriteLine($"Client Connected.");

                    _ = HandleClientAsync(client);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static async Task HandleClientAsync(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];
            string userName = null;

            int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
            userName = Encoding.ASCII.GetString(buffer, 0, bytesRead);
            userNames.Add(userName);

            await BroadcastMessageAsync($"User {userName} Joined the Chat.");
            try
            {
                while (true)
                {
                    bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                    if (bytesRead == 0)
                    {
                        // Client Disconnected
                        clients.Remove(client);
                        userNames.Remove(userName);
                        Console.WriteLine($"Client {userName} Disconnected.");
                        await BroadcastMessageAsync($"User {userName} has Left The Chat.");
                        break;
                    }

                    string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    Console.WriteLine(message);
                    await BroadcastMessageAsync(message);
                }
            }
            catch (Exception)
            {
                clients.Remove(client);
                userNames.Remove(userName);

            }
        }

        private static async Task BroadcastMessageAsync(string message)
        {
            byte[] broadMessage = Encoding.ASCII.GetBytes(message);
            foreach (var client in clients)
            {
                await client.GetStream().WriteAsync(broadMessage, 0, broadMessage.Length);
            }
        }
    }
}