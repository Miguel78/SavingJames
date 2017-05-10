﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Progress : MonoBehaviour {

	public Transform player;
	public Slider slider;
	public float length;

	// Update is called once per frame
	void Update () {
		// Avanzar el slider segun la distancia que ha recorrido el jugador
		slider.value = player.position.z / length;

		// Si llegamos al final hacer algo
		if(slider.value >= 1){
			
		}
	}
}
