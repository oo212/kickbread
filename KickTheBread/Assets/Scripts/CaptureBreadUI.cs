using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaptureBreadUI : MonoBehaviour
{
    public Text Text_Username;

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

    //protected virtual void Awake()
    //{
    //    if (Instance == null)
    //    {
    //        Instance = this as T;
    //    }
    //    else if (Instance != this)
    //    {
    //        Destroy(gameObject);
    //    }

    //    DontDestroyOnLoad(gameObject);
    //}

    void Start()
    {
        Text_Username.text = StaticData.username;

        Text_Number_Bagel.text = StaticData.BagelNumber.ToString();
        Text_Number_Baguette.text = StaticData.BaguetteNumber.ToString();
        Text_Number_Burgerbun.text = StaticData.BurgerbunNumber.ToString();
        Text_Number_Breadstick.text = StaticData.BreadstickNumber.ToString();
        Text_Number_Toast.text = StaticData.ToastNumber.ToString();
    }

    public void AddBagelNum()
    {
        StaticData.BagelNumber++;
        Text_Number_Bagel.text = StaticData.BagelNumber.ToString();
    }

    public void AddBaguetteNumber()
    {
        StaticData.BaguetteNumber++;      
        Text_Number_Baguette.text = StaticData.BaguetteNumber.ToString();
    }

    public void AddBurgerbunNumber()
    {
        StaticData.BurgerbunNumber++;
        Text_Number_Burgerbun.text = StaticData.BurgerbunNumber.ToString();
    }

    public void AddBreadstickNumber()
    {
        StaticData.BreadstickNumber++;
        Text_Number_Breadstick.text = StaticData.BreadstickNumber.ToString();
    }

    public void AddToastNumber()
    {
        StaticData.ToastNumber++;
        Text_Number_Toast.text = StaticData.ToastNumber.ToString();
    }

    public void DecreaseBagelNum()
    {
        StaticData.BagelNumber--;
        Text_Number_Bagel.text = StaticData.BagelNumber.ToString();
    }

    public void DecreaseBaguetteNumber()
    {
        StaticData.BaguetteNumber--;
        Text_Number_Baguette.text = StaticData.BaguetteNumber.ToString();
    }

    public void DecreaseBurgerbunNumber()
    {
        StaticData.BurgerbunNumber++;
        Text_Number_Burgerbun.text = StaticData.BurgerbunNumber.ToString();
    }

    public void DecreaseBreadstickNumber()
    {
        StaticData.BreadstickNumber--;
        Text_Number_Breadstick.text = StaticData.BreadstickNumber.ToString();
    }

    public void DecreaseToastNumber()
    {
        StaticData.ToastNumber--;
        Text_Number_Toast.text = StaticData.ToastNumber.ToString();
    }
}
