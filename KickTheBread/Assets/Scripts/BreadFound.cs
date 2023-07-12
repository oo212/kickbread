using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadFound : MonoBehaviour
{
    public GameObject BreadType;
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
            if (BreadType.tag == "Bagel")
            {
                CaptureBreadUI.Instance.AddBagelNum();
            } else if (BreadType.tag == "Baguette")
            {
                CaptureBreadUI.Instance.AddBaguetteNumber();
            } else if (BreadType.tag == "Burgerbun")
            {
                CaptureBreadUI.Instance.AddBurgerbunNumber();
            } else if (BreadType.tag == "Breadstick")
            {
                CaptureBreadUI.Instance.AddBreadstickNumber();
            } else if (BreadType.tag == "Toast")
            {
                CaptureBreadUI.Instance.AddToastNumber();
            }

            Destroy(gameObject);
        }
    }
}
