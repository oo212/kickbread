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
        /// 当这个客户端掉线时
        /// </summary>
        /// <param name="e"></param>
        public override void OnDisConnected(Exception e)
        {
            Console.WriteLine("客户端掉线了:"+e.Message);
        }

        /// <summary>
        /// 当连接出现异常时
        /// </summary>
        /// <param name="exception"></param>
        public override void OnException(Exception exception)
        {
            Console.WriteLine("客户连接出现异常:" + exception.Message);
        }

        /// <summary>
        /// 当收到客户端请求
        /// </summary>
        /// <param name="opCode"></param>
        /// <param name="dict"></param>
        public override void OnOperationRequest(short opCode, Dictionary<short, object> dict)
        {
            Console.WriteLine("收到客户端请求,请求代码是:"+ opCode);

            OpCode opcode = (OpCode)opCode;

            switch (opcode)
            {
                case OpCode.diaolog:
                    {
                        object o = dict[1];
                        string str = (string)o;
                        Console.WriteLine("收到客户端请求,请求参数值是:" + str);

                        Dictionary<short, object> dict_res = new Dictionary<short, object>();
                        dict_res.Add(DictKey.dialog, "你好,我是服务器");
                        SendResponse(opCode, ReturnCode.success, dict_res);

                        Dictionary<short, object> dict_ev = new Dictionary<short, object>();
                        dict_ev.Add(1, "服务器即将重启!");
                        SendEvent(1, dict_ev);
                    }
                    break;

                case OpCode.login:
                    {

                        //object o = dict[1];
                        //string account = (string)o;//帐号

                        //object o2 = dict[2];
                        //string password = (string)o2;//密码

                        string account = (string)dict[ParameterCode.Account];
                        string password = (string)dict[ParameterCode.Password];

                        //验证账号是否存在
                        bool isExist = MysqlManager.QueryAccount(account);

                        //验证传过来的账号和密码是否和数据库上的一致
                        if (isExist)
                        {
                            string queryPassword = MysqlManager.QueryPassword(account);
                            if (queryPassword != "")
                            {
                                if (queryPassword.Equals(password))
                                {
                                    //查询用户的信息，返回给客户端，客户端对用户名字进行判断

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


                        //string password_temp = MyData.dict_userData[account];

                        //if (password_temp.Equals(password))
                        //{
                        //    Userplayer.username = "代号001";

                        //    Dictionary<short, object> dict_res = new Dictionary<short, object>();
                        //    dict_res.Add(DictKey.player, Userplayer);

                        //    SendResponse(opCode, ReturnCode.success, dict_res);
                        //}
                        //else
                        //{
                        //    Dictionary<short, object> dict_res = new Dictionary<short, object>();
                        //    dict_res.Add(DictKey.error, "账号密码错误");

                        //    SendResponse(opCode, ReturnCode.fail, dict_res);
                        //}

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

                //case OpCode.buyThing:
                    {
                       // //1.拿到客户端传来的请求信息
                       //object o = dict[DictKey.buyThing];
                       // string str = (string)o;

                       // //2.进行处理
                       // if (str.Equals("木剑"))
                       // {
                       //     player.coin -= 200;
                       //     player.wuqi = "木剑";
                       // }
                       // else if (str.Equals("匕首"))
                       // {
                       //     player.coin -= 500;
                       // }


                       // //3.发送响应或事件给客户端
                       // Dictionary<short, object> dict_res = new Dictionary<short, object>();
                       // dict_res.Add(DictKey.player, player);

                       // SendResponse(opCode, ReturnCode.success, dict_res);


                       // Dictionary<short, object> dict_ev = new Dictionary<short, object>();
                       // dict_ev.Add(DictKey.chengHao,"初入江湖");

                       // SendEvent((short)EventCode.chuJiChengHao,dict_ev);
                    }

                    //break;
                default:
                    break;
            }


        }
    }
}
