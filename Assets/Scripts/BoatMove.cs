using UnityEngine;
using System.Collections;

public class BoatMove : MonoBehaviour {

	public float speed;
	public GameObject paddle1;
	public GameObject paddle2;
	public GameObject boat;
	public GameObject sphere;

    private Quaternion initialRotation;
	private Vector3 targetRotation;
    private Quaternion targetQuaternion;
	private float rotationDuration;

    private float newAngle;

	Vector3 paddle1Pos;
	Vector3 paddle2Pos;
	float angleLeft;
	float angleRight;
	bool isRowing = true;
	

	void Start () 
	{
		paddle1Pos = paddle1.transform.position;
		paddle2Pos = paddle2.transform.position;
		rotationDuration = 2f;
		angleLeft = 0;
		angleRight = 0;
	}
	
	void Update ()
	{
		if (paddle1.transform.position.y <= 0.65 && paddle2.transform.position.y <= 0.65 && isRowing){
			isRowing = false;
			Moveboat();
			
		}
		else if (paddle1.transform.position.y <= 0.65 && isRowing){
			isRowing = false;
			angleLeft += 0.03f;
			MoveboatLeft(angleLeft);
			
		}
		else if (paddle2.transform.position.y <= 0.65 && isRowing){
			isRowing = false;
			angleRight -= 0.03f;
			MoveboatRight(angleRight);
			
		}
		else if (boat.transform.position.x < - 11.8){
			Application.Quit();
		}
		

	}

	void Moveboat () 
	{
		boat.transform.position += new Vector3(-speed,0,0);
		isRowing = true;
	}

	void MoveboatLeft(float angle){

		float elapsedTime = 0f;
		boat.transform.position += new Vector3(-speed/2,0,0);
		paddle1.transform.position = new Vector3(paddle1.transform.position.x, 0.7f,paddle1.transform.position.z);
		paddle2.transform.position = new Vector3(paddle1.transform.position.x,paddle2.transform.position.y,paddle2.transform.position.z);
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

	void MoveboatRight(float angle){
		boat.transform.position += new Vector3(-speed/2,0,0);
		paddle2.transform.position = new Vector3(paddle2.transform.position.x, 0.7f, paddle2.transform.position.z);
		paddle1.transform.position = new Vector3(paddle2.transform.position.x,paddle1.transform.position.y,paddle1.transform.position.z);
		float elapsedTime = 0f;
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
}
