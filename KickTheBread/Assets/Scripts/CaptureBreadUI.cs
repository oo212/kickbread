using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaptureBreadUI : MonoBehaviour
{

    public Text Text_Number;
    
    public static CaptureBreadUI Instance;
    
    void Awake()
    {
        Instance = this;
    }

   
    public void AddBreadNum()
    {
        int _num = Int32.Parse(Text_Number.text);
        _num++;
        Text_Number.text = _num.ToString();
    }

    
}
