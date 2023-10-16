using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grabDetector : MonoBehaviour
{
    public int pourThreshold = 45;
    private bool isPouring = false;
    private float rayDistance = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool pourCheck = CalculatePourAngle() < pourThreshold;

        if (isPouring != pourCheck)
        {
            isPouring = pourCheck;

            if (isPouring)
            {
                StartPour();
            }
            else
            {
                EndPour();
            }
        }

    
    }
        
    

    private float CalculatePourAngle()
    {
        return transform.forward.y * Mathf.Rad2Deg;
    }


    void StartPour()
    {
        print("Start");
        Ray ray = new Ray(transform.position, transform.forward);

        // Declare a RaycastHit variable to store information about the collision
        RaycastHit hit;

        // Use Physics.Raycast to check if the ray collides with any objects within a certain distance
        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            // If the ray collides with an object, print the name of the object to the console
            GameObject hitObject = hit.collider.gameObject;
            if (hitObject.CompareTag("cup"))
            {
                Cup cupScript = hitObject.GetComponent<Cup>();
                cupScript.RaiseWaterLevel();
            }
        }
    }

    void EndPour()
    {
        print("End");
        
    }
}
