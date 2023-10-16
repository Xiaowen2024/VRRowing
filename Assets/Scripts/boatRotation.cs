using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boatRotation : MonoBehaviour
{
    public GameObject largeBoat;
    public GameObject smallBoat;
    private Vector3 targetRotationLarge;
    private Vector3 targetRotationSmall;
    private float rotationDuration;

    private Quaternion initialRotationLarge;
    private Quaternion initialRotationSmall;
    private Quaternion targetQuaternionLarge;
    private Quaternion targetQuaternionSmall;

    private float newAngle;

    void Start()
    {
        newAngle = 1f;
        initialRotationLarge = largeBoat.transform.rotation;
        initialRotationSmall = smallBoat.transform.rotation;
        targetRotationLarge = new Vector3(newAngle, 0f, 0f);
        targetRotationSmall = new Vector3(0f, newAngle,0f);
        targetQuaternionLarge = Quaternion.Euler(targetRotationLarge);
        targetQuaternionSmall = Quaternion.Euler(targetRotationSmall);
        rotationDuration = 20f;
        StartCoroutine(RotateOverTime());
    }
    
    private IEnumerator RotateOverTime()
    {
        float elapsedTime = 0f;
        while (elapsedTime < rotationDuration)
        {
            float t = elapsedTime / rotationDuration;
            largeBoat.transform.rotation = Quaternion.Lerp(initialRotationLarge, targetQuaternionLarge, t);
            smallBoat.transform.rotation = Quaternion.Lerp(initialRotationSmall, targetQuaternionSmall, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        largeBoat.transform.rotation = targetQuaternionLarge;
        smallBoat.transform.rotation = targetQuaternionSmall;
    }

    // void Update()
    // {
    //     if (timer > 0){
    //         timer -= 1;
    //     }
    //     else {
    //         newAngle = - newAngle;
    //         largeBoat.transform.Rotate(newAngle, 0f, 0f);
    //         largeBoat.transform.Rotate(newAngle, 0f, 0f);
    //         smallBoat.transform.Rotate(0f, 0f, newAngle);
    //         smallBoat.transform.Rotate(0f, 0f, newAngle);
    //         timer = 50f;
    //     }
        
    // }
}
