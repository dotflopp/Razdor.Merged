using System.Net;
using System.Net.Sockets;
using Razdor.Shared;

namespace Razdor.Voices.SFU.Rtp;

public class RtpListener : Disposable, IRtpListener
{
    public RtpListener(IPEndPoint endPoint)
    {
        Socket = new Socket(endPoint.AddressFamily, SocketType.Dgram, ProtocolType.Udp);
        EndPoint = endPoint;
    }

    public IPEndPoint EndPoint { get; }
    public Socket Socket { get; }

    public async Task<int> ReceiveAsync(Memory<byte> buffer, CancellationToken cancellationToken = default)
    {
        ThrowIfDisposed();


        await Socket.ReceiveFromAsync(buffer, SocketFlags.None, EndPoint, cancellationToken);
        return 0;
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            Socket.Dispose();
        }
    }
}
