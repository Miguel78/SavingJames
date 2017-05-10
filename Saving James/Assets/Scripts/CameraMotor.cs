using UnityEngine;
using System.Collections;

public class CameraMotor : MonoBehaviour {
    public float minY = 3;
    public float maxY = 5;
    private Transform lookAt;
	private Vector3 startOffset;
	private Vector3 moveVector;
	private float transition = 0.5f;
	private float animationDuration = 3.0f;
	private Vector3 animationOffset = new Vector3 (0,5,5);

	// Use this for initialization
	void Start () {
		lookAt = GameObject.FindGameObjectWithTag ("Player").transform;
		startOffset = transform.position - lookAt.position;
	}
	
	// Update is called once per frame
	void Update () {
		moveVector = lookAt.position + startOffset;

		// X
		moveVector.x = 0;

		//Y
		moveVector.y = Mathf.Clamp (moveVector.y,minY,maxY);

		if (transition > 1.0f) 
		{
			transform.position = moveVector;
		}
		else 
		{
			//Animacion al empezar el juego
	 		transform.position = Vector3.Lerp(moveVector + animationOffset,moveVector,transition);
			transition += Time.deltaTime *1 / animationDuration;
			transform.LookAt (lookAt.position + Vector3.up);
		}   
	}
}