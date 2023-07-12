using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{
    void Awake() 
    {
        StartCoroutine(IEN_QueryRanking());
        //Start the coroutine, query the ranking after 0.5 seconds
        InvokeRepeating("QueryRanking", 5f, 10f);
        //Continue to rank every 10 queries
    }
    IEnumerator IEN_QueryRanking()
    {
        yield return new WaitForSeconds(0.5f);
        ConnectManager.peerInstance.SendRequest((short)OpCode.QueryRanking, null);
    }

    void QueryRanking()
    {
        ConnectManager.peerInstance.SendRequest((short)OpCode.QueryRanking, null);
    }
}
