using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boatMoveComplex : MonoBehaviour
{
    // Start is called before the first frame update
    
	public float speed;
	public GameObject paddleL;
	public GameObject paddleR;
	public GameObject boat;
	Vector3 paddleLPos;
	Vector3 paddleRPos;
    Vector3 paddleLPrev;
    Vector3 paddleRPrev;
    Vector3 paddleLCurr;
    Vector3 paddleRCurr;

    private Quaternion initialRotation;
	private Vector3 targetRotation;
    private Quaternion targetQuaternion;
	private float rotationDuration;

	bool isRowing = true;
    float angleLeft;
	float angleRight;

	void Start () 
	{
		paddleLPos = paddleL.transform.position;
		paddleRPos = paddleR.transform.position;
        paddleLPrev = paddleL.transform.position;
        paddleRPrev = paddleR.transform.position;
		rotationDuration = 2f;
		angleLeft = 0;
		angleRight = 0;
        
	}
	
	void Update ()
	{
        paddleLCurr = paddleL.transform.position;
        paddleRCurr = paddleR.transform.position;
        Vector3 paddleLVelocity = (paddleLCurr-paddleLPrev)/Time.deltaTime;
        Vector3 paddleRVelocity = (paddleRCurr-paddleRPrev)/Time.deltaTime;

		if (paddleL.transform.position.y <= 0.65 && paddleLVelocity.magnitude >= 0 && isRowing){
			isRowing = false;
			Moveboat(Mathf.Abs(paddleLVelocity.x));
			
		}
		else if (paddleL.transform.position.y <= 0.65 && isRowing){
			isRowing = false;
            angleLeft += 0.1f;
			MoveboatL(angleLeft, Mathf.Abs(paddleLVelocity.x));
			
			
		}
		else if (paddleR.transform.position.y <= 0.65 && isRowing){
			isRowing = false;
			
			
		}
		else if (boat.transform.position.x < - 11.8){
			Application.Quit();
		}
		

	}

    void Moveboat(float velocity){
        boat.transform.position += new Vector3(-velocity,0,0);
		isRowing = true;
    }

	void MoveboatL(float angle, float velocity){

		float elapsedTime = 0f;
		boat.transform.position += new Vector3(-velocity/2,0,0);
		paddleL.transform.position = new Vector3(paddleL.transform.position.x, 0.7f,paddleL.transform.position.z);
		paddleR.transform.position = new Vector3(paddleL.transform.position.x,paddleR.transform.position.y,paddleR.transform.position.z);
        while (elapsedTime < rotationDuration){
        	initialRotation = boat.transform.rotation;
        	targetRotation = new Vector3(0f, angle,0f);
        	targetQuaternion = Quaternion.Euler(targetRotation);
			float t = elapsedTime / rotationDuration;
			boat.transform.rotation = Quaternion.Lerp(initialRotation, targetQuaternion, t);
			elapsedTime += Time.deltaTime;
		}
		boat.transform.rotation = targetQuaternion;
		isRowing = true;
		

	}

	void MoveboatR(float speed){
		boat.transform.position += new Vector3(-speed/2,0,0);
		
		isRowing = true;

	}
}
