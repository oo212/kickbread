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
            Console.WriteLine("1 client came in");
            
           
            return peer;
        }

        /// <summary>
        /// When an exception occurs on the server
        /// </summary>
        /// <param name="serverException"></param>
        public override void OnServerException(Exception serverException)
        {
            Console.WriteLine("Service exception:" + serverException.Message);
        }

        /// <summary>
        /// when the server starts
        /// </summary>
        public override void OnServerStart()
        {
            Console.WriteLine("OnServerStart" );

            MyData.dict_userData.Add("123456","123456");
        }
    }
}
