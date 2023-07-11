using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGServer;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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
                case OpCode.dialog:
                    {
                        object o = dict[0];
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

                        string account = (string)dict[ParameterCode.Account];
                        string password = (string)dict[ParameterCode.Password];

                        //Verify that the account exists
                        bool isExist = MysqlManager.QueryAccount(account);

                        //Verify that the passed account and password are consistent with those on the database
                        if (isExist)
                        {
                            string queryPassword = MysqlManager.QueryPassword(account);
                            Console.WriteLine("queryPassword" + queryPassword);
                            if (queryPassword != "")
                            {
                                if (queryPassword.Equals(password))
                                {
                                    //Query the user's information, return it to the client, and the client judges the user name

                                    Player player = MysqlManager.QueryPlayer(account);

                                    //if (player.id != -1)
                                    //{
                                        Userplayer = player;

                                        Dictionary<short, object> dict_res = new Dictionary<short, object>();
                                        dict_res.Add(ParameterCode.player, player);
                                        SendResponse(opCode, ReturnCode.success, dict_res);
                                    //}
                                    //else
                                    //{
                                    //    Dictionary<short, object> dict_res = new Dictionary<short, object>();
                                    //    dict_res.Add(ParameterCode.error, "Query user failed");
                                    //    SendResponse(opCode, ReturnCode.fail, dict_res);
                                    //}

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
                        string username = (string)dict[ParameterCode.username];
                        //string account = (string)dict[ParameterCode.Account];

                        bool isExist = MysqlManager.QueryIsExistUsername(username);
                        if (isExist)
                        {
                            Dictionary<short, object> dict_res = new Dictionary<short, object>();
                            dict_res.Add(ParameterCode.error, "Username is existed");
                            SendResponse(opCode, ReturnCode.fail, dict_res);
                        }
                        else { 
                                //update username in SQL
                                int num = MysqlManager.UpdateUsername(username, Userplayer.account);
                            if (num > 0)//update success
                            {
                                Userplayer.username = username;

                                //send to Client
                                Dictionary<short, object> dict_res = new Dictionary<short, object>();
                                dict_res.Add(ParameterCode.username, username);
                                SendResponse(opCode, ReturnCode.success, dict_res);
                            }
                            else//update failed
                            {
                                Dictionary<short, object> dict_res = new Dictionary<short, object>();
                                dict_res.Add(ParameterCode.error, "Create role failed");
                                SendResponse(opCode, ReturnCode.fail, dict_res);
                            }
                        }
                    }
                    break;

                case OpCode.RegisterAccount:
                    {
                        string account = (string)dict[ParameterCode.Account];
                        string password = (string)dict[ParameterCode.Password];

                        //Check if this account exists
                        bool isExistAccount = MysqlManager.QueryAccount(account);
                        if (isExistAccount == false)
                            //It means that there is no such account, you can register
                        {
                            //Insert a set of data
                            bool isInsert = MysqlManager.InsertUser(account, password);
                            if (isInsert == true)//created successfully
                            {

                                Dictionary<short, object> dict_res = new Dictionary<short, object>();
                                dict_res.Add(ParameterCode.Account,account);
                                dict_res.Add(ParameterCode.Password, password);
                                SendResponse(opCode, ReturnCode.success, dict_res);

                            }
                            else
                            {
                                Dictionary<short, object> dict_res = new Dictionary<short, object>();
                                dict_res.Add(ParameterCode.error, "Registration failed, please try again!");
                                SendResponse(opCode, ReturnCode.fail, dict_res);
                            }
                        }
                        else
                        {
                            Dictionary<short, object> dict_res = new Dictionary<short, object>();
                            dict_res.Add(ParameterCode.error, "Account already exists");
                            SendResponse(opCode, ReturnCode.fail, dict_res);
                        }

                    }
                    break;

                case OpCode.QueryRanking:
                    {
                        List<RankingData> list = MysqlManager.QueryRanking();
                        int myranking = MysqlManager.QueryMyRanking(Userplayer.account);
                        if (list.Count > 0)
                        {
                            Dictionary<short, object> dict_res = new Dictionary<short, object>();
                            dict_res.Add(ParameterCode.RankingDataList, list);
                            dict_res.Add(ParameterCode.MyRanking, myranking);
                            SendResponse(opCode, ReturnCode.success, dict_res);
                        }
                        else
                        {
                            Dictionary<short, object> dict_response = new Dictionary<short, object>();
                            dict_response.Add(ParameterCode.error, "Query Ranking Error");
                            SendResponse(opCode, ReturnCode.fail, dict_response);
                        }
                    }
                    break;

                case OpCode.UpdateNumber:
                    {

                        string username = (string)dict[ParameterCode.username];

                        int burgerbunNumber = Convert.ToInt32(dict[ParameterCode.BurgerBun]);
                        int bagelNumber = Convert.ToInt32(dict[ParameterCode.Bagel]);
                        int toastNumber = Convert.ToInt32(dict[ParameterCode.Toast]);
                        int baguetteNumber = Convert.ToInt32(dict[ParameterCode.Baguette]);
                        int breadstickNumber = Convert.ToInt32(dict[ParameterCode.Breadstick]);


                        //update number in SQL
                        int num = MysqlManager.UpdateBreadNumber(Userplayer.username, burgerbunNumber, bagelNumber, toastNumber, baguetteNumber, breadstickNumber);
                        if (num > 0)//update success
                        {
                            //send to Client
                            Dictionary<short, object> dict_res = new Dictionary<short, object>();
                            dict_res.Add(ParameterCode.error, "Update successed");
                            SendResponse(opCode, ReturnCode.success, dict_res);
                        }
                        else//update failed
                        {
                            Dictionary<short, object> dict_res = new Dictionary<short, object>();
                            dict_res.Add(ParameterCode.error, "Update failed");
                            SendResponse(opCode, ReturnCode.fail, dict_res);
                        }

                    }
                    break;

                case OpCode.QueryUsername:
                    {
                        string sendusername = (string)dict[ParameterCode.username];

                        bool isExist = MysqlManager.QueryIsExistUsername(sendusername);
                        if (isExist)
                        {
                            Dictionary<short, object> dict_res = new Dictionary<short, object>();
                            dict_res.Add(ParameterCode.username, sendusername);
                            SendResponse(opCode, ReturnCode.success, dict_res);
                        }
                        else
                        {
                            Dictionary<short, object> dict_res = new Dictionary<short, object>();
                            dict_res.Add(ParameterCode.error, "Username is not existed");
                            SendResponse(opCode, ReturnCode.fail, dict_res);
                        }
                    }
                    break;

                case OpCode.SendBread:
                    {
                        string username = (string)dict[ParameterCode.username];
                        string sendusername = (string)dict[ParameterCode.sendusername];
                        string breadtype = (string)dict[ParameterCode.BreadType];

                        bool isSuccusse = MysqlManager.SendBread(username,sendusername,breadtype);
                        if (isSuccusse)
                        {
                            Dictionary<short, object> dict_res = new Dictionary<short, object>();
                            dict_res.Add(ParameterCode.username, username);
                            SendResponse(opCode, ReturnCode.success, dict_res);
                        }
                        else
                        {
                            Dictionary<short, object> dict_res = new Dictionary<short, object>();
                            dict_res.Add(ParameterCode.error, "Send Bread Error");
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
