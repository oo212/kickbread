using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;

public class ConnectManager : MonoBehaviour
{

    public Button button_connect;
    public Button button_dialog, button_buything;

    private static Peer peer = null;

    public static Peer peerInstance
    { 
        get 
        {
            if (peer == null) {  peer = new Peer(); }
            return peer; 
        }
    }

    private void Awake()
    {
        if(peer == null) { peer= new Peer(); }
    }

    void Start()
    {
        //button_connect.onClick.AddListener(Onbutton_connect);
        StartCoroutine(IEN_connect());
    }

    IEnumerator IEN_connect()
    {
        yield return new WaitForSeconds(0.5f);
        string address = "127.0.0.1";
        int port = 4499;

        peer.Connect(address, port);
    }

    public void Onbutton_connect()
    {
        string address = "127.0.0.1";
        int port = 4499;
        
        peer.Connect(address,port);
    }

    public void Onbutton_dialog()
    {
        Dictionary<short, object> dict = new Dictionary<short, object>();
        dict.Add(0, "Hello,I am Client");
        peer.SendRequest((short)OpCode.dialog, dict);
    }

    public void Onbutton_buyThing()
    {
        Dictionary<short, object> dict = new Dictionary<short, object>();
        dict.Add(1, "Some");
        peer.SendRequest((short)OpCode.buyThing, dict);
    }

    private void Update()
    {
        peer.Service();
    }
}
