using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public Button button_login, button_quit, button_register, button_change, button_forget;
    public TMP_InputField input_account, input_password;

    public Text message;

    public GameObject go_image_chooseRole;
    public GameObject go_image_createRole;

    public delegate void dele_LoginHandler(Player player);
    public static dele_LoginHandler LoginHandler;

    
    void Start()
    {
        button_login.onClick.AddListener(Onbutton_login);
        button_quit.onClick.AddListener(() => { Application.Quit(); });

        LoginHandler += OnLogin;
    }

    void Onbutton_login()
    {
        string account = "";
        if (input_account.text != null)
        {
            account = input_account.text;
        }

        string password = "";
        if (input_password.text != null)
        {
            password = input_password.text;
        }

        if (account != "" && password != "")
        {
            //send event 
            Dictionary<short, object> dict = new Dictionary<short, object>();
            dict.Add(ParameterCode.Account, account);
            dict.Add(ParameterCode.Password, password);

            ConnectManager.peerInstance.SendRequest((short)OpCode.login, dict);
        }
        else 
        {
            Debug.Log("Account or password is null"); 
            message.text = "Account or password is null" + input_account + input_password;
        }
    }

    void OnLogin(Player player) 
    {
        if (player.username != "")//Explain that the role has been created
        {
            //Enter the role selection interface
            
            //go_image_chooseRole.GetComponent<ChooseRole>().text_role.text = "name:"+ player.username;
            go_image_chooseRole.SetActive(true);
        }
        else //Indicates that no roles have been created
        {
            //Enter the role creation interface
            go_image_createRole.SetActive(true);
        }
    }
}
