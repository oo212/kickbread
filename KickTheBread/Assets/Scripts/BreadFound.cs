using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadFound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Avatar")
        {
            CaptureBreadUI.Insatance.AddBreadNum();
        }
    }
}