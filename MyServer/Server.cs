using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGServer;

namespace MyServer
{
    class Server : TGServerBase
    {
        public Server(string address,int port):base (address, port)
        {

        }

        public override PeerBase GetPeer()
        {
            //PeerBase peer = new PeerBase();
            Peer peer = new Peer();
            Console.WriteLine("1个客户端进来了");
            
           
            return peer;
        }

        /// <summary>
        /// 当服务器出现异常时
        /// </summary>
        /// <param name="serverException"></param>
        public override void OnServerException(Exception serverException)
        {
            Console.WriteLine("服务出现异常：" + serverException.Message);
        }

        /// <summary>
        /// 当服务器启动时
        /// </summary>
        public override void OnServerStart()
        {
            Console.WriteLine("OnServerStart" );

            MyData.dict_userData.Add("123456","123456");
        }
    }
}
