using UnityEngine;
using System.Collections;

public class Highscore : MonoBehaviour {
	int newScore;
	int newTime;
	int oldScore;
	int oldTime;
	int i;
	
	public void AddScore(int score, int time)
	{
		// Validate input
		if (score < 0 || time < 0)
		{
			Debug.LogWarning("Invalid score or time provided: score=" + score + ", time=" + time);
			return;
		}
		
		newScore = score;
		newTime = time;
		
		for(i = 0; i < 10; i++)
		{
			if(PlayerPrefs.HasKey(i + "HScore"))
			{
				if(PlayerPrefs.GetInt(i + "HScore") < newScore)
				{
					//new score is higher than the stored score
					oldScore = PlayerPrefs.GetInt(i + "HScore");
					oldTime = PlayerPrefs.GetInt(i + "HScoreTime");
					PlayerPrefs.SetInt(i + "HScore",newScore);
					PlayerPrefs.SetInt(i + "HScoreTime",newTime);
					newScore = oldScore;
					newTime = oldTime;
					Debug.Log(PlayerPrefs.GetInt(i + "HScore"));
				}
			} else {
				// Fix: Don't set to 0 after inserting - this allows the score to continue to lower slots
				PlayerPrefs.SetInt(i + "HScore",newScore);
				PlayerPrefs.SetInt(i + "HScoreTime",newTime);
				// Break here since we've placed the score in an empty slot and there are no more scores below
				break;
			}
		}
		
		// Save PlayerPrefs to ensure data persistence across platforms
		PlayerPrefs.Save();
	}
}
