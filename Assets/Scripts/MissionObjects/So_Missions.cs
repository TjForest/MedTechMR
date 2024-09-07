using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MissionType")]
public class So_Missions : ScriptableObject
{
    [Tooltip("The total time the player has to play do the mission in minutes (e.g. 1 = 60 seconds, 0.5 = 30 seconds)")]
    [SerializeField] private float missionTimeLimit;
    [Tooltip("The Score given to the player for completing the mission")]
    [SerializeField] private int completionScore;
    [Tooltip("Game object to spawn")]
    [SerializeField] private GameObject missionPrefab;

    public float GetMissionTime() {
		return missionTimeLimit;
	}

    public int GetCompletionScore() {
        return completionScore;
    }
}
