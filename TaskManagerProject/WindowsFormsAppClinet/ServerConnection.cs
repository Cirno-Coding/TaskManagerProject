using System.IO;
using System.Net.Sockets;

public class ServerConnection
{
    private TcpClient _client;
    private StreamReader _reader;
    private StreamWriter _writer;

    public void Connect()
    {
        _client = new TcpClient("127.0.0.1", 5000);
        var stream = _client.GetStream();
        _reader = new StreamReader(stream);
        _writer = new StreamWriter(stream) { AutoFlush = true };
    }

    public string Send(string message)
    {
        _writer.WriteLine(message);
        return _reader.ReadLine();
    }
    public void Close()
    {
        _reader.Close();
        _writer.Close();
        _client.Close();
    }
}