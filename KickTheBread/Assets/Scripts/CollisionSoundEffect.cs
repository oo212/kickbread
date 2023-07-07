using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSoundEffect : MonoBehaviour
{

    public AudioClip AudioClip;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        AudioSource.PlayClipAtPoint(AudioClip, transform.position);
    }
}
