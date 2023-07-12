using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CreateRole : MonoBehaviour
{
    public Button button_queren;
    public TMP_InputField input_username;

    public GameObject go_chooseRole;

    public Text message;

    public delegate void dele_createRole(Player player);
    public static dele_createRole CreateRoleHandler;

    public delegate void dele_createRoleFailHandler(string error);
    public static dele_createRoleFailHandler createRoleFailHandler;

    void Start()
    {
        button_queren.onClick.AddListener(Onbutton_queren);

        CreateRoleHandler += OnCreateRole;
        createRoleFailHandler += OnCreateRoleFail;
    }

    // Update is called once per frame
    void Onbutton_queren()
    {
        if (input_username.text != null && input_username.text != "")
        { 
            Dictionary<short,object> dict = new Dictionary<short,object>();
            dict.Add(ParameterCode.username, input_username.text);

            ConnectManager.peerInstance.SendRequest((short)OpCode.createRole,dict);
        }
    }


    void OnCreateRole(Player player) 
    {
        //Enter the role selection interface and show information
        go_chooseRole.GetComponent<ChooseRole>().text_role.text = "Username:" + player.username;
        go_chooseRole.SetActive(true);
        StaticData.username = player.username;
        gameObject.SetActive(false);
    }

    void OnCreateRoleFail(string error)
    {
        message.text = error;
    }

}
