using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TGClient;
using System;
using Newtonsoft.Json;
using UnityEditor.Experimental.RestService;
using System.Reflection;
using TreeEditor;
using MiniJSON;
using System.Xml.Linq;
using System.Diagnostics.CodeAnalysis;

public class Peer : PeerBase
{
    static Player player = new Player();

    public static Player Player
    {
        get { return player; }
    }

    public override void OnConnected(string message) 
    {
        Debug.Log("Connection succeeded");
    }
        
    public override void OnDisConnect(Exception connectException) 
    {
        Debug.Log("Disconnect");
    }
        
    public override void OnEvent(short eventCode, Dictionary<short, object> dict)
    {
        EventCode eventcode = (EventCode)eventCode;

        switch (eventcode)
        {
            default:
                break;
        }

        //Debug.Log("Event received from server, eventCode is" + eventCode);
    }
        
    public override void OnException(Exception exception)
    {
        Debug.Log("Connection exception");
    }

    public override void OnOperationResponse(short opreationCode, ReceiveResponse response)
    {

        OpCode opCode = (OpCode)opreationCode;

        if (response.returnCode == 0) //success
        {
            switch (opCode)
            {
                case OpCode.dialog:
                    {
                        string dialog = (string)response.parameters[2];
                        Debug.Log("0");
                    }
                    break;

                case OpCode.login:
                    {
                        //use unity 2021.3
                        //when use untiy 2022.3 it is error but i dont know why

                        object o = response.parameters[ParameterCode.player];
                        string str = JsonConvert.SerializeObject(o);
                        Debug.Log(str); 
                        Player info = JsonConvert.DeserializeObject<Player>(str);

                        player = info;
                        Login.LoginHandler(player);
                    }
                    break;

                case OpCode.createRole: 
                    {
                        string username  = (string)response.parameters[ParameterCode.username];
                        player.username = username;

                        CreateRole.CreateRoleHandler(player);
                    }
                    break;

                case OpCode.RegisterAccount:
                    {
                        string account = (string)response.parameters[ParameterCode.Account];
                        string password = (string)response.parameters[ParameterCode.Password];

                        RegisterAccount.RegisterSuccessHanler(account, password);
                    }
                    break;

                case OpCode.QueryRanking:
                    {
                        List<RankingData> list = Convert<List<RankingData>>(response.parameters[ParameterCode.RankingDataList]);
                        int myranking = (int)(long)response.parameters[ParameterCode.MyRanking];
                        QueryRanking.QueryRankingHandler(list, myranking);
                    }
                    break;

                case OpCode.QueryUsername: 
                    {
                        //string sendusername = (string)response.parameters[ParameterCode.username];
                        SearchUsername.QueryUsernameHandler();
                    }
                    break;

                case OpCode.SendBread:
                    {
                        //string sendusername = (string)response.parameters[ParameterCode.username];
                        SendBread.SendBreadHandler();
                    }
                    break;

                default:
                    break;
            }
        }
        else//failed
        { 
            string error = (string)response.parameters[ParameterCode.error];

            if (opCode == OpCode.login)
            {
                Login.LoginFailHandler(error);
            }
            else if (opCode == OpCode.RegisterAccount)
            {
                RegisterAccount.RegisterFailHanler(error);
            }
            else if (opCode == OpCode.createRole)
            {
                CreateRole.createRoleFailHandler(error);
            }
            else if (opCode == OpCode.QueryUsername)
            {
                SearchUsername.QueryUsernameFailHandler(error);
            }
            else if (opCode == OpCode.SendBread) 
            {
                SendBread.SendBreadFailHandler(error);
            }

                Debug.Log(error);

        }

    }

    public T Convert<T>(object o)
    {
        string str = JsonConvert.SerializeObject(o);
        Debug.Log("str:" + str);
        T t1 = JsonConvert.DeserializeObject<T>(str);
        return t1;
    }

}

