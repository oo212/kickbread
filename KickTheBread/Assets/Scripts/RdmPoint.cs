using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RdmPoint : MonoBehaviour
{

    //onMap avatar
    public GameObject avatar;

    //event point prefabs
    public GameObject prePoint;

    //min distance of the event
    public float MIN_Distance = 3f;

    //max distance of the event
    public float MAX_Distance = 50f;

    //the current location of the avatar
    private Vector3 v3Avatar;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RdmPointFunc()
    {
        //get the current location of avatar
        v3Avatar = avatar.transform.position;
        //generate a random distance
        float _distance = Random.Range(MIN_Distance, MAX_Distance);
        //get a random vector
        Vector2 _pOri = Random.insideUnitCircle;
        //normalized vector
        Vector2 _pNor = _pOri.normalized;
        //calculate the random position
        Vector3 _v3Point = new Vector3(v3Avatar.x + _pNor.x * _distance, 0, v3Avatar.z + _pNor.y * _distance);

        //generate the prefabs
        GameObject _poiMark = Instantiate(prePoint, _v3Point, transform.rotation);

    }
}
