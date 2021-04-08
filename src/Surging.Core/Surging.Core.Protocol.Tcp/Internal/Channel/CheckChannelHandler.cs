//-----------------------------------------------------------------------
// <copyright file="AssemblyInfo.cs" company="Powerdata">
//    Copyright (C) 2016 ShenZhen Powerdata Information Technology Co.,Ltd All Rights Reserved.
//    本软件为深圳博安达开发研制。未经本公司正式书面同意，其他任何个人、团体不得使用、复制、修改或发布本软件.
// </copyright>
// <author>Met</author>
//-----------------------------------------------------------------------

using DotNetty.Transport.Channels;
using Surging.Core.Protocol.Tcp.Util;
using System.Text;

namespace Surging.Core.Protocol.Tcp.Internal.Channel
{
    internal class CheckChannelHandler : ChannelHandlerAdapter
    {
        private const int dataLength = 10;

        public override void ChannelRead(IChannelHandlerContext context, object message)
        {
            var data = message.ToString();
            if (data.Length <= dataLength)
            {
                throw new System.Exception($"无效包头：{data},remoteAddress:{context?.Channel?.RemoteAddress}");
            }

            if (data.Substring(0, 2) != "##")
            {
                throw new System.Exception($"无效包头：{data},remoteAddress:{context?.Channel?.RemoteAddress}");
            }

            var length = int.Parse(data.Substring(2, 4));

            var dataContent = data.Substring(6, length);
            var bytes = Encoding.ASCII.GetBytes(dataContent);
            var crcBytes = BytesCheck.CRC16_Checkout(bytes, 0xA001, true);
            var crcString = BytesCheck.BytesToHexString(crcBytes);
            var crcContent = data.Substring(data.Length - 4, 4);

            if (crcString == crcContent)
            {
                base.ChannelRead(context, dataContent);
            }
        }

        public override void ChannelReadComplete(IChannelHandlerContext context)
        {
            context.Flush();
        }
    }
}