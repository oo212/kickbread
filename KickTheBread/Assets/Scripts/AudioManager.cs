using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Slider volumeSlider;

    private void Awake()
    {
        //DontDestroyOnLoad(gameObject);
        volumeSlider.value = AudioListener.volume;

    }

    public void musicController()
    {
        AudioListener.volume = volumeSlider.value;

    }

}
