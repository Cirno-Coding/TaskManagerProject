using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAppServer
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            TcpListener listener = new TcpListener(IPAddress.Any, 5000);
            listener.Start();

            //Console.WriteLine("Server started on port 5000");
            Console.WriteLine("Async server started...");

            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                //Task.Run(() => HandleClient(client));
                _ = HandleClientAsync(client);
            }
        }

        static async Task HandleClientAsync(TcpClient client)
        {
            try
            {
                using (NetworkStream stream = client.GetStream())
                using (StreamReader reader = new StreamReader(stream))
                using (StreamWriter writer = new StreamWriter(stream) { AutoFlush = true })
                {
                    while (true)
                    {
                        string request = await reader.ReadLineAsync();

                        if (request == null)
                        {
                            Console.WriteLine("Client disconnected normally.");
                            break;
                        }

                        if (request.StartsWith("LOGIN"))
                        {
                            string[] parts = request.Split('|');
                            string result = await AuthService.LoginAsync(parts[1], parts[2]);
                            await writer.WriteLineAsync(result);
                        }
                        if (request.StartsWith("REGISTER"))
                        {
                            var parts = request.Split('|');

                            string result = await AuthService.RegisterAsync(
                                parts[1],
                                parts[2],
                                parts[3]);

                            await writer.WriteLineAsync(result);
                        }
                    }
                }
            }
            catch (IOException)
            {
                Console.WriteLine("Client disconnected unexpectedly.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Server error: " + ex.Message);
            }
            finally
            {
                client.Close();
            }
        }

        static void HandleClient(object obj)
        {
            TcpClient client = (TcpClient)obj;

            try
            {
                using (NetworkStream stream = client.GetStream())
                using (StreamReader reader = new StreamReader(stream))
                using (StreamWriter writer = new StreamWriter(stream) { AutoFlush = true })
                {
                    while (true)
                    {
                        string request = reader.ReadLine();

                        if (request == null)
                        {
                            Console.WriteLine("Client disconnected normally.");
                            break;
                        }

                        if (request.StartsWith("LOGIN"))
                        {
                            string[] parts = request.Split('|');
                            string result = AuthService.Login(parts[1], parts[2]);
                            writer.WriteLine(result);
                        }
                    }
                }
            }
            catch (IOException)
            {
                Console.WriteLine("Client disconnected unexpectedly.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Server error: " + ex.Message);
            }
            finally
            {
                client.Close();
            }
        }
    }
}
