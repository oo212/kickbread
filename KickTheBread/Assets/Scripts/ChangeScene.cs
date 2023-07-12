using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    //Scene
    //0:Play 1:Startgame-Demo 2:Exit 3:Inventory 4:Ranking 5:Setting 6:Send
    public void JumpToGame() 
    {
        SceneManager.LoadScene(1);
    }

    public void JumpToExit()
    {
        SceneManager.LoadScene(2);
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

    public void JumpToSend()
    {
        SceneManager.LoadScene(6);
    }
}
