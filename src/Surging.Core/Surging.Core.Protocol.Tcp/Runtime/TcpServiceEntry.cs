using System;
using System.Collections.Generic;
using System.Text;

namespace Surging.Core.Protocol.Tcp.Runtime
{
   public class TcpServiceEntry
    {
        public string Path { get; set; }

        public Type Type { get; set; }

        public TcpBehavior Behavior { get; set; }
    }

}
