using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaptureBreadUI : MonoBehaviour
{

    public Text Text_Number_Bagel;
    public Text Text_Number_Baguette;
    public Text Text_Number_Burgerbun;
    public Text Text_Number_Breadstick;
    public Text Text_Number_Toast;

    public static CaptureBreadUI Instance;
    
    void Awake()
    {
        Instance = this;
    }

   
    public void AddBagelNum()
    {
        int _num_bagel = Int32.Parse(Text_Number_Bagel.text);
        _num_bagel++;
        Text_Number_Bagel.text = _num_bagel.ToString();
    }

    public void AddBaguetteNumber()
    {
        int _num_baguette = Int32.Parse(Text_Number_Baguette.text);
        _num_baguette++;
        Text_Number_Baguette.text = _num_baguette.ToString();
    }

    public void AddBurgerbunNumber()
    {
        int _num_burgerbun = Int32.Parse(Text_Number_Burgerbun.text);
        _num_burgerbun++;
        Text_Number_Burgerbun.text = _num_burgerbun.ToString();
    }

    public void AddBreadstickNumber()
    {
        int _num_breadstick = Int32.Parse(Text_Number_Breadstick.text);
        _num_breadstick++;
        Text_Number_Breadstick.text = _num_breadstick.ToString();
    }

    public void AddToastNumber()
    {
        int _num_toast = Int32.Parse(Text_Number_Toast.text);
        _num_toast++;
        Text_Number_Toast.text = _num_toast.ToString();
    }
}
