using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaptureBreadUI : MonoBehaviour
{

    //The amount of captured bread
    public Text Text_Number;

    public static CaptureBreadUI Insatance;

    void Awake()
    {
        Insatance = this;
    }

    public void AddBreadNum()
    {
        //get the current number of bread
        int number = int.Parse(Text_Number.text);
        number++;
        Text_Number.text = number.ToString();
    }
}
