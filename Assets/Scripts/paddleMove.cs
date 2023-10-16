using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddleMove : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 newPosition;
    public GameObject sphere;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        void OnTriggerExit(Collision collision)
        {
            transform.position = newPosition;
            sphere.SetActive(true);
        }

    }
}
