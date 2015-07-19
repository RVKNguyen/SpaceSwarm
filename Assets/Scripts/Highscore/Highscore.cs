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
				PlayerPrefs.SetInt(i + "HScore",newScore);
				PlayerPrefs.SetInt(i + "HScoreTime",newTime);
				newScore = 0;
				newTime = 0;
			}
		}
	}
}
