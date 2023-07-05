using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseRole : MonoBehaviour
{
    public Button button_chooserole;
    public Text text_role;



    void Start()
    {
        button_chooserole.onClick.AddListener(Onbutton_chooserole);
    }

   
    void Onbutton_chooserole()
    {
        
    }
}
