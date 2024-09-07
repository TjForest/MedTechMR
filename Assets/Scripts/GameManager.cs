using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	// References
	public static GameManager instance;

	[SerializeField] private List<GameObject> missionPrefabs;

	// public variables
	#region Private Vars
	[Tooltip("The total time the player has to play the game in minutes (e.g. 1 = 60 seconds, 0.5 = 30 seconds)")]
	[SerializeField] private float totalTime = 10.0f;
	[Tooltip("The number of missions the player has to complete")]
	[SerializeField] private int missionNumber = 0;
	[Tooltip("Put the Mission Scriptable Objects in here")]
	[SerializeField] private List<So_Missions> missions;
	
	private bool isGameActive = false;
	private bool isMissionActive = false;
	private int score = 0;
	private int highScore = 0;
	private int numRooms = 12;
	private int numCurrentMission = 0;
	private float time = 0.0f;
	private float missionTime = 0.0f;
	private List<float> missionTimes;
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
			if (isMissionActive) {
				missionTime += Time.deltaTime;
				if (missionTime >= missions[numCurrentMission].GetMissionTime()) {
					EndMission();
				}
			}
			if (time >= totalTime * 60) {
				EndGame();
			}
		}
	}
	#endregion

	#region Methods
	#region Game Methods
	[Tooltip("Start the game")]
	public void StartGame() {
		isGameActive = true;
		score = 0;
		time = 0.0f;
	}

	private void EndGame() {
		isGameActive = false;
		if (score > highScore) {
			highScore = score;
		}
		GetMissionCount();
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
	#endregion

	#region Mission Methods
	[Tooltip("Begins the current mission")]
	public void StartMission() {
		isMissionActive = true;
		missionTime = 0.0f;
	}

	[Tooltip("Completes the current mission")]
	public void CompleteMission() {
		isMissionActive = false;
		missionTimes.Add(missionTime);
		missionTime = 0.0f;
	}

	[Tooltip("Ends the current mission without completion")]
	public void EndMission() {
		isMissionActive = false;
		missionTimes.Add(missions[numCurrentMission].GetMissionTime());
		missionTime = 0.0f;
	}
	#endregion

	#region Getters
	[Tooltip("Gets the current time")]
	public float GetTime() {
		return time;
	}

	public int GetScore() {
		return score;
	}

	public int GetMissionCount() {
		return missionTimes.Count;
	}
	#endregion
	#endregion
}
