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
            case EventCode.restart:
                break;
            case EventCode.paiMing:
                break;
            case EventCode.chuJiChengHao:
                break;
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
                case OpCode.diaolog:
                    {
                        string dialog = (string)response.parameters[2];
                        Debug.Log("0");
                    }
                    break;

                case OpCode.buyThing:
                    {
                        string price = (string)response.parameters[3];
                        Debug.Log("1");
                    }
                    break;

                case OpCode.login:
                    {
                        //*****************
                        //I really don't know what the bug is
                        //update:solved

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
                default:
                    break;
            }

        }
        else//failed
        { 
            string error = (string)response.parameters[ParameterCode.error];
            Debug.Log(error);

        }

    }

}

