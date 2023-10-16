using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;

public class detectTouch : MonoBehaviour
{
    public GameObject mus4;
    public GameObject sphere;
    private XRDirectInteractor interactable = null;
    public bool isGrabbed=false;
    // Start is called before the first frame update
    void Start()
    {
        interactable = this.GetComponent<XRDirectInteractor>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("VR_PrimaryButton_LeftHand") && transform.GetComponent<XRGrabInteractable>())
        {
            mus4.SetActive(false);

        }
        if (Input.GetButtonDown("VR_PrimaryButton_RightHand") && transform.GetComponent<XRGrabInteractable>())
        {
            mus4.SetActive(false);
            Debug.Log("press primary button");
        }

        sphere.SetActive(false);
         
        void OnCollisionEnter(Collision collision)
    {
        Debug.Log("touch");
        if (collision.collider.CompareTag("mus4"))
        {
            mus4.SetActive(false);
            Debug.Log("touch mus4");
        }
    }
        void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Collider>().CompareTag("sphere"))
        {
            sphere.SetActive(false);
            Debug.Log("Object is being grabbed by the player!");
            
        }
        if (other.GetComponent<Collider>().CompareTag("mus4"))
        {
            mus4.SetActive(false);
            Debug.Log("Object is being grabbed by the player!");
            
        }
    }
    

    }
}
