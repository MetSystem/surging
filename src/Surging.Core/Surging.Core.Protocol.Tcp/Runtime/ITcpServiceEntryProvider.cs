using System;
using System.Collections.Generic;
using System.Text;

namespace Surging.Core.Protocol.Tcp.Runtime
{
    public interface ITcpServiceEntryProvider
    {
        TcpServiceEntry GetEntry();
    }
}
