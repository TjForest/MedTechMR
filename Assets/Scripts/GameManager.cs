using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	// References
	public static GameManager instance;

	// public variables
	#region Private Vars
	[Tooltip("The total time the player has to play the game</br>In Minutes (e.g. 1 = 60 seconds, 0.5 = 30 seconds")]
	[SerializeField] private float totalTime = 10.0f;
	
	private bool isGameActive = false;
	private int score = 0;
	private int highScore = 0;
	private float time = 0.0f;
	#endregion

	#region Unity Methods
	// Singleton
	private void Awake() {
		if (instance == null) {
			instance = this;
		} else {
			Destroy(this.gameObject);
		}
	}

	// Start is called before the first frame update
	void Start() {

	}

	// Update is called once per frame
	void Update() {
		if (isGameActive) {
			time += Time.deltaTime;
			if (time >= totalTime * 60) {
				EndGame();
			}
		}
	}
	#endregion

	#region Public Methods
	[Tooltip("Start the game")]
	public void StartGame() {
		isGameActive = true;
		score = 0;
		time = 0.0f;
	}

	[Tooltip("Edit the players score. Negative numbers subtract score.")]
	public void AddScore(int value) {
		score += value;
	}

	[Tooltip("Pause the game timer")]
	public void PauseTimer() {
		isGameActive = false;
	}

	[Tooltip("Resume the game timer")]
	public void ResumeTimer() {
		isGameActive = true;
	}

	[Tooltip("Gets the current time")]
	public float GetTime() {
		return time;
	}

	public int GetScore() {
		return score;
	}
	#endregion

	#region Private Methods
	private void EndGame() {
		isGameActive = false;
		if (score > highScore) {
			highScore = score;
		}
	}
	#endregion
}
