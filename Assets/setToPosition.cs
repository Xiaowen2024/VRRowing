using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setToPosition : MonoBehaviour
{
    public GameObject strings;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnCollisionEnter(Collision collision)
{
    if (collision.gameObject.tag == "strings")
    {
        strings.transform.rotation = Quaternion.RotateTowards(strings.transform.rotation, Quaternion.Euler(new Vector3((float)-1.232, (float)441.466, (float)-8.151)), Time.deltaTime * 20f);
    }
}
}
