using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    //Scene
    //0:POI 1:Startgame-Demo 2:Exit 3:Inventory 4:Ranking 5:Setting 6:Login

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void JumpToGame() 
    {
        SceneManager.LoadScene(0);
    }

    public void JumpToInvetory()
    {
        SceneManager.LoadScene(3);
    }

    public void JumpToRanking()
    {
        SceneManager.LoadScene(4);
    }

    public void JumpToSetting()
    {
        SceneManager.LoadScene(5);
    }
}
