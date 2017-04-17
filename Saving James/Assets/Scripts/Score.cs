﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	private float score = 0.0f;

	private int difficultyLevel = 1;
	private int maxDifficultyLevel = 10;
	private int scoreToNextLevel = 10;

	public Text ScoreText;

	void Update () {

		if (score >= scoreToNextLevel)
			LevelUp ();

		score += Time.deltaTime * difficultyLevel;
		ScoreText.text = ((int)score).ToString ();
		
	}

	void LevelUp()
	{
		if (difficultyLevel == maxDifficultyLevel)
			return;

		scoreToNextLevel *= 2;
		difficultyLevel++;

		GetComponent<PlayerMotor>().SetSpeed (difficultyLevel);

		Debug.Log (difficultyLevel);
	}
}
