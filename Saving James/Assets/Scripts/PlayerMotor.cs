using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerMotor : MonoBehaviour 
{
	private CharacterController controller;
	private Vector3 moveVector;
	private float speed = 5.0f;
	private float verticalvelocity = 0.0f;
	private float gravity = 12.0f;
	private float animationDuration = 3.0f;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Time.time < animationDuration)
		{
			controller.Move (Vector3.forward * speed * Time.deltaTime);
			return; 
		}

		moveVector = Vector3.zero;

		if (controller.isGrounded) 
		{
			verticalvelocity = -0.5f;
		} 
		else
		{
			verticalvelocity -= gravity * Time.deltaTime;
		}

		//X - Left and Right
		moveVector.x = Input.GetAxisRaw("Horizontal") * speed;
		//Y - Up and Down
		moveVector.y = verticalvelocity;
		//Z - Forward and Backward
		moveVector.z = speed;

		controller.Move(moveVector * Time.deltaTime);
	}

	public void SetSpeed(float modifier)
	{
		speed = 5.0f + modifier;
	}

	// Morir si toca un killer
	void OnControllerColliderHit(ControllerColliderHit hit) {
		if (hit.collider.CompareTag ("Killer")) {
			Time.timeScale = 0.2f;
			Invoke ("Die", 0.5f);
		}

	}

	public void Die(){
		Time.timeScale = 1f;
		SceneManager.LoadScene (0);
	}
}
