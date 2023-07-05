using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGServer;

namespace MyServer
{
    class Peer : PeerBase
    {
        private Player Userplayer = new Player();


        /// <summary>
        /// When this client goes offline
        /// </summary>
        /// <param name="e"></param>
        public override void OnDisConnected(Exception e)
        {
            Console.WriteLine("Client offline" + e.Message);
        }

        /// <summary>
        /// When the connection is abnormal
        /// </summary>
        /// <param name="exception"></param>
        public override void OnException(Exception exception)
        {
            Console.WriteLine("An exception occurred in the client connection:" + exception.Message);
        }

        /// <summary>
        /// When a client request is received
        /// </summary>
        /// <param name="opCode"></param>
        /// <param name="dict"></param>
        public override void OnOperationRequest(short opCode, Dictionary<short, object> dict)
        {
            Console.WriteLine("The client request is received, and the request code is:" + opCode);

            OpCode opcode = (OpCode)opCode;

            switch (opcode)
            {
                case OpCode.diaolog:
                    {
                        object o = dict[1];
                        string str = (string)o;
                        Console.WriteLine("The client request is received, and the request parameter value is:" + str);

                        Dictionary<short, object> dict_res = new Dictionary<short, object>();
                        dict_res.Add(DictKey.dialog, "Hello, I'm server");
                        SendResponse(opCode, ReturnCode.success, dict_res);

                        Dictionary<short, object> dict_ev = new Dictionary<short, object>();
                        dict_ev.Add(1, "The server is about to restart!");
                        SendEvent(1, dict_ev);
                    }
                    break;

                case OpCode.login:
                    {

                        //object o = dict[1];
                        //string account = (string)o;

                        //object o2 = dict[2];
                        //string password = (string)o2;

                        string account = (string)dict[ParameterCode.Account];
                        string password = (string)dict[ParameterCode.Password];

                        //Verify that the account exists
                        bool isExist = MysqlManager.QueryAccount(account);

                        //Verify that the passed account and password are consistent with those on the database
                        if (isExist)
                        {
                            string queryPassword = MysqlManager.QueryPassword(account);
                            if (queryPassword != "")
                            {
                                if (queryPassword.Equals(password))
                                {
                                    //Query the user's information, return it to the client, and the client judges the user name

                                    Player player = MysqlManager.QueryPlayer(account);

                                    if (player.id != -1)
                                    {
                                        Userplayer = player;

                                        Dictionary<short, object> dict_res = new Dictionary<short, object>();
                                        dict_res.Add(ParameterCode.player, player);
                                        SendResponse(opCode, ReturnCode.success, dict_res);
                                    }
                                    else
                                    {
                                        Dictionary<short, object> dict_res = new Dictionary<short, object>();
                                        dict_res.Add(ParameterCode.error, "Query user failed");
                                        SendResponse(opCode, ReturnCode.fail, dict_res);
                                    }

                                }
                                else
                                {
                                    Dictionary<short, object> dict_res = new Dictionary<short, object>();
                                    dict_res.Add(ParameterCode.error, "account password error");
                                    SendResponse(opCode, ReturnCode.fail, dict_res);
                                }
                            }
                            else
                            {
                                Dictionary<short, object> dict_res = new Dictionary<short, object>();
                                dict_res.Add(ParameterCode.error, "Failed to verify account password");
                                SendResponse(opCode, ReturnCode.fail, dict_res);
                            }
                        }
                        else
                        {
                            Dictionary<short, object> dict_res = new Dictionary<short, object>();
                            dict_res.Add(ParameterCode.error, "Account is not exist");
                            SendResponse(opCode, ReturnCode.fail, dict_res);
                        }
                        
                    }
                    break;

                case OpCode.createRole:
                    {
                        string username = (string)dict[ParameterCode.usernamne];

                        //update username in SQL
                        int num = MysqlManager.UpdateUsername(username, Userplayer.id);
                        if (num > 0)//update success
                        {
                            Userplayer.username = username;

                            //send to Client
                            Dictionary<short, object> dict_res = new Dictionary<short, object>();
                            dict_res.Add(ParameterCode.usernamne, username);
                            SendResponse(opCode, ReturnCode.success, dict_res);
                        }
                        else//update failed
                        {
                            Dictionary<short, object> dict_res = new Dictionary<short, object>();
                            dict_res.Add(ParameterCode.error, "Create role failed");
                            SendResponse(opCode, ReturnCode.fail, dict_res);
                        }
                    }
                    break;

                default:
                    break;
            }


        }
    }
}
