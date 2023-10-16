using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour
{
    public GameObject boat;
    float x;
    // Start is called before the first frame update
    void Start()
    {
        x = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float newX = boat.transform.position.x;
        Vector3 newPos = new Vector3(x + newX,transform.position.y,transform.position.z);
        transform.position = newPos;
    }
}
