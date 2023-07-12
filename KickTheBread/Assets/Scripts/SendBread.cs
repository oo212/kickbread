using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
//using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

public class SendBread : MonoBehaviour
{
    //int breadtype:
    //0 BurgerBun
    //1 Bagel
    //2 Toast
    //3 Baguette
    //4 Breadstick
    public int breadtype;

    public Button send_button;
    public Text message;
    public TMP_Dropdown dropdown;

    //public GameObject send_scene;
    //public GameObject sreach_scene;

    public GameObject sendbutton;

    public delegate void dele_SendBreadHandler();
    public static dele_SendBreadHandler SendBreadHandler;

    public delegate void dele_SendBreadFailHandler(string error);
    public static dele_SendBreadFailHandler SendBreadFailHandler;



    void Start()
    {
        //sreach_scene.SetActive(true);
        //send_scene.SetActive(false);

        send_button.onClick.AddListener(Onbutton_send);

        SendBreadFailHandler += OnSendBreadFail;
        SendBreadHandler += OnSendBread;

        //DontDestroyOnLoad(gameObject);
    }

    public void DropdownChange()
    {
        int value = dropdown.value;

        breadtype = value;
    }

    
    void Onbutton_send()
    {
        if (dropdown.value == 0)
        {
            if (StaticData.BurgerbunNumber <= 0)
            {
                message.text = "You don't have enough bread";
            }
            else
            {
                Dictionary<short, object> dict = new Dictionary<short, object>();
                dict.Add(ParameterCode.username, StaticData.username);
                dict.Add(ParameterCode.sendusername, SearchUsername.send);
                dict.Add(ParameterCode.BreadType, "BurgerBun");
                ConnectManager.peerInstance.SendRequest((short)OpCode.SendBread, dict);
            }
        }
        else if (dropdown.value == 1)
        {
            if (StaticData.BagelNumber <= 0)
            {
                message.text = "You don't have enough bread";
            }
            else
            {
                Dictionary<short, object> dict = new Dictionary<short, object>();
                dict.Add(ParameterCode.username, StaticData.username);
                dict.Add(ParameterCode.sendusername, SearchUsername.send);
                dict.Add(ParameterCode.BreadType, "Bagel");
                ConnectManager.peerInstance.SendRequest((short)OpCode.SendBread, dict);
            }
        }
        else if (dropdown.value == 2)
        {
            if (StaticData.ToastNumber <= 0)
            {
                message.text = "You don't have enough bread";
            }
            else
            {
                Dictionary<short, object> dict = new Dictionary<short, object>();
                dict.Add(ParameterCode.username, StaticData.username);
                dict.Add(ParameterCode.sendusername, SearchUsername.send);
                dict.Add(ParameterCode.BreadType, "Toast");
                ConnectManager.peerInstance.SendRequest((short)OpCode.SendBread, dict);
            }
        }
        else if (dropdown.value == 3)
        {
            if (StaticData.BaguetteNumber <= 0)
            {
                message.text = "You don't have enough bread";
            }
            else
            {
                Dictionary<short, object> dict = new Dictionary<short, object>();
                dict.Add(ParameterCode.username, StaticData.username);
                dict.Add(ParameterCode.sendusername, SearchUsername.send);
                dict.Add(ParameterCode.BreadType, "Baguette");
                ConnectManager.peerInstance.SendRequest((short)OpCode.SendBread, dict);
            }
        }
        else if (dropdown.value == 4)
        {
            if (StaticData.BreadstickNumber <= 0)
            {
                message.text = "You don't have enough bread";
            }
            else
            {
                Dictionary<short, object> dict = new Dictionary<short, object>();
                dict.Add(ParameterCode.username, StaticData.username);
                dict.Add(ParameterCode.sendusername, SearchUsername.send);
                dict.Add(ParameterCode.BreadType, "Breadstick");
                ConnectManager.peerInstance.SendRequest((short)OpCode.SendBread, dict);
            }
        }
        else
        {
            message.text = "Send bread error";
        }
    }

    

    void OnSendBread()
    {
        message.text = "Sent successfully!";

        if (dropdown.value == 0)
        {
            StaticData.BurgerbunNumber = StaticData.BurgerbunNumber - 1;
        }
        else if (dropdown.value == 1)
        {
            StaticData.BagelNumber = StaticData.BagelNumber - 1;
        }
        else if (dropdown.value == 2)
        {
            StaticData.ToastNumber = StaticData.ToastNumber - 1;
        }
        else if (dropdown.value == 3)
        {
            StaticData.BaguetteNumber = StaticData.BaguetteNumber - 1;
        }
        else if (dropdown.value == 4)
        {
            StaticData.BreadstickNumber = StaticData.BreadstickNumber - 1;
        }
    }
    void OnSendBreadFail(string error)
    {
        message.text = error;
    }
}
