using DotNetty.Handlers.Timeout;
using DotNetty.Transport.Channels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Surging.Core.Protocol.Tcp.Internal.Channel
{
    public class DeviceHandler : ChannelDuplexHandler
    {
        /// <summary>
        /// ChannelActive
        /// </summary>
        /// <param name="context">IChannelHandlerContext</param>
        public override void ChannelActive(IChannelHandlerContext context)
        {
            //var remoteIp = context.Channel.RemoteAddress.ToString();
            //var connections = DeviceManager.DeviceChannels.Where(t => t.Key == remoteIp);
            //var prevChannel = connections?.FirstOrDefault(t => t.Key == remoteIp || t.Value.Channel == context.Channel).Value;


            //if (prevChannel == null)
            //{
            //    DeviceManager.DeviceChannels.GetOrAdd(remoteIp, new DevcieInfo()
            //    {
            //        Channel = context.Channel
            //    });
            //}
            //else
            //{
            //    if (connections.Any())
            //    {
            //        foreach (var item in connections)
            //        {
            //            if (prevChannel.Channel == item.Value.Channel)
            //            {
            //                continue;
            //            }

            //            DevcieInfo info = null;
            //            DeviceManager.DeviceChannels.TryRemove(remoteIp, out info);
            //            info?.Channel.CloseAsync();
            //        }
            //    }
            //}
        }

        /// <summary>
        /// ChannelInactive
        /// </summary>
        /// <param name="context">IChannelHandlerContext</param>
        public override void ChannelInactive(IChannelHandlerContext context)
        {
        }

        public override void UserEventTriggered(IChannelHandlerContext context, object evt)
        {
            var e = evt as IdleStateEvent;
            if (e != null)
            {
                var remoteIp = context.Channel.RemoteAddress.ToString();
            }

            base.UserEventTriggered(context, evt);
        }
    }
}
