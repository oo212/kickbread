using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public void OnExitGamne()
    {
#if UNITY_EDITOR //Exit in Unity Editor
        UnityEditor.EditorApplication.isPlaying = false;
#else //Exit after program launch
        Application.Quit();
#endif
    }
}
