using Surging.Core.CPlatform.Messages;
using System.Runtime.CompilerServices;

namespace Surging.Core.Protocol.Tcp.Extensions
{
    public static class TransportMessageExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsTcpDispatchMessage(this TransportMessage message)
        {
            return message.ContentType == typeof(byte[]).FullName;
        }
    }
}
