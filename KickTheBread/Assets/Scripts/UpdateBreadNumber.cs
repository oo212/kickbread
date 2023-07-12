using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateBreadNumber : MonoBehaviour
{
    void Awake()
    {
        StartCoroutine(IEN_UpdateNumber());
        //Start the coroutine, query the ranking after 0.5 seconds
        InvokeRepeating("UpdateNumber", 5f, 10f);
        //Continue to rank every 10 queries
    }
    IEnumerator IEN_UpdateNumber()
    {
        yield return new WaitForSeconds(0.5f);

        Dictionary<short, object> dict_number = new Dictionary<short, object>();
        dict_number.Add(ParameterCode.username, StaticData.username);
        dict_number.Add(ParameterCode.BurgerBun, StaticData.BurgerbunNumber);
        dict_number.Add(ParameterCode.Bagel, StaticData.BagelNumber);
        dict_number.Add(ParameterCode.Toast, StaticData.ToastNumber);
        dict_number.Add(ParameterCode.Baguette, StaticData.BaguetteNumber);
        dict_number.Add(ParameterCode.Breadstick, StaticData.BreadstickNumber);

        ConnectManager.peerInstance.SendRequest((short)OpCode.UpdateNumber, dict_number);
    }

    void UpdateNumber()
    {
        Dictionary<short, object> dict_number = new Dictionary<short, object>();
        dict_number.Add(ParameterCode.username, StaticData.username);
        dict_number.Add(ParameterCode.BurgerBun, StaticData.BurgerbunNumber);
        dict_number.Add(ParameterCode.Bagel, StaticData.BagelNumber);
        dict_number.Add(ParameterCode.Toast, StaticData.ToastNumber);
        dict_number.Add(ParameterCode.Baguette, StaticData.BaguetteNumber);
        dict_number.Add(ParameterCode.Breadstick, StaticData.BreadstickNumber);

        ConnectManager.peerInstance.SendRequest((short)OpCode.UpdateNumber, dict_number);
    }
}
