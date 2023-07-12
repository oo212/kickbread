using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RdmBread : MonoBehaviour
{

    public GameObject bagel;

    public GameObject baguette;

    public GameObject burgerbun;

    public GameObject breadstick;

    public GameObject toast;


    // Start is called before the first frame update
    void Start()
    {
        int randomIndex = Random.Range(0, 5);
        if (randomIndex == 0)
            InsBagel();
        else if (randomIndex == 1)
            InsBaguette();
        else if (randomIndex == 2)
            InsBurgerbun();
        else if (randomIndex == 3)
            InsBreadstick();
        else
            InsToast();
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InsBagel()
    {
        Instantiate(bagel, transform.position + new Vector3(0, 5f, 0), transform.rotation);
    }

    public void InsBaguette()
    {
        Instantiate(baguette, transform.position + new Vector3(0, 5f, 0), transform.rotation);
    }

    public void InsBurgerbun()
    {
        Instantiate(burgerbun, transform.position + new Vector3(0, 5f, 0), transform.rotation);
    }

    public void InsBreadstick()
    {
        Instantiate(breadstick, transform.position + new Vector3(0, 5f, 0), transform.rotation);
    }

    public void InsToast()
    {
        Instantiate(toast, transform.position + new Vector3(0, 5f, 0), transform.rotation);
    }

}
