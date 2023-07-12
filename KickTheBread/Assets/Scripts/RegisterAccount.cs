using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RegisterAccount : MonoBehaviour
{
    public TMP_InputField input_account, input_password, input_passwordAgain;
    public Button button_Register, button_back;
    public Text message;

    public GameObject registerscene;

    public delegate void dele_RegisterSuccess(string account, string password);
    public static dele_RegisterSuccess RegisterSuccessHanler;

    public delegate void dele_RegisterFail(string error);
    public static dele_RegisterFail RegisterFailHanler;


    void Start()
    {
        button_Register.onClick.AddListener(Onbutton_Register);
        button_back.onClick.AddListener(OnButton_Return);

        RegisterSuccessHanler += OnRegisterSuccess;
        RegisterFailHanler += OnRegisterFail;
    }

    void Onbutton_Register()
    {

        if ((!string.IsNullOrEmpty(input_account.text)) && (!string.IsNullOrEmpty(input_password.text)) && (!string.IsNullOrEmpty(input_passwordAgain.text)))
        {
            string account = "";
            if (input_account.text != null && input_account.text != "")
            {
                account = input_account.text;
            }

            string password = "";
            if (input_password.text != null && input_password.text != "")
            {
                password = input_password.text;
            }

            string passwordagain = "";
            if (input_password.text != null && input_password.text != "")
            {
                passwordagain = input_passwordAgain.text;
            }


            if (account.Length < 3 || password.Length < 3)
            {
                message.text = "The account password cannot be less than 3 characters!";
            }
            else
            {
                if (password.Equals(passwordagain))
                {
                    Dictionary<short, object> dict = new Dictionary<short, object>();
                    dict.Add(ParameterCode.Account, account);
                    dict.Add(ParameterCode.Password, password);
                    ConnectManager.peerInstance.SendRequest((short)OpCode.RegisterAccount, dict);

                    button_Register.gameObject.SetActive(false);
                    input_account.text = "";
                    input_password.text = "";
                    input_passwordAgain.text = "";
                    message.text = "";
                }
                else
                {
                    message.text = "The passwords entered twice are inconsistent!";
                }
            }


        }
        else
        {
            message.text = "Account and password cannot be empty";
        }
    }

    void OnRegisterSuccess(string account, string password)
    {
        //button_Register.gameObject.SetActive(true);
        gameObject.SetActive(false);
        transform.parent.GetComponent<Login>().message.text = "Successful registration, Account:" + account + " and Password:" + password;
    }

    void OnRegisterFail(string error)
    {
        button_Register.gameObject.SetActive(true);
        message.text = error;
    }

    void OnButton_Return() 
    {
        registerscene.SetActive(false);
    }
}
