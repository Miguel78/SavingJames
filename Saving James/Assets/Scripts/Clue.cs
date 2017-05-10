using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clue : MonoBehaviour {

	public string dialogText;

	void OnTriggerEnter(Collider collider){
		if(collider.CompareTag("Player")){
			Dialog dialog = FindObjectOfType<Dialog> ();
			dialog.Show (dialogText);

			Destroy (gameObject);
		}
	}
}
