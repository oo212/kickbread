using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SearchUsername : MonoBehaviour
{
    public Text message;

    public Button search_button;
    public TMP_InputField sendusername;

    public static string send;

    public delegate void dele_QueryUsernameHandler();
    public static dele_QueryUsernameHandler QueryUsernameHandler;

    public delegate void dele_QueryUsernameFailHandler(string error);
    public static dele_QueryUsernameFailHandler QueryUsernameFailHandler;

    void Start()
    {
        search_button.onClick.AddListener(Onbutton_search);

        QueryUsernameFailHandler += OnQueryUsernameFail;
        QueryUsernameHandler += OnQueryUsername;
    }

    void Onbutton_search()
    {
        if (sendusername.text == StaticData.username)
        {
            message.text = "You can't send bread to yourself！";
        }
        else
        {
            //Query Username
            Dictionary<short, object> dict = new Dictionary<short, object>();
            dict.Add(ParameterCode.username, sendusername.text);

            ConnectManager.peerInstance.SendRequest((short)OpCode.QueryUsername, dict);
        }
    }
    void OnQueryUsername()
    {
        //Jump to Send Bread Scene
        send = sendusername.text;

        SceneManager.LoadScene(7);
        message.text = "";
    }

    void OnQueryUsernameFail(string error)
    {
        message.text = error;
    }
}
