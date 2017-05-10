using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour {

	public Text textComponent;
	public GameObject panel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Muestra el dialogo
	public void Show(string dialogText){
		CancelInvoke ();
		textComponent.text = dialogText;
		panel.SetActive (true);

		// Ocultar el dialogo dentro de 5 segundos
		Invoke ("Hide", 5f);
	}

	// Ocultar el dialogo
	public void Hide(){
		panel.SetActive (false);
	}
}
