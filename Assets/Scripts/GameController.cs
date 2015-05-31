using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public Transform asteroid1;
    public Transform asteroid2;
    public Transform asteroid3;

    private int score;
    public GUIText scoreText;

	// Use this for initialization
	void Start () {
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnAsteroids());
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void AddScore(int earnedScore)
    {
        score += earnedScore;
        UpdateScore();
    }

    IEnumerator SpawnAsteroids()
    {
        while(true)
        {
            float spawnTimer = Random.Range(0.5F, 2.0F);

            int random = Random.Range(1, 4);
            int randomX = Random.Range(-5, 5);
            int randomY = Random.Range(-5, 5);

            switch (random)
            {
                 case 1:
                    Instantiate(asteroid1, new Vector3(randomX, randomY, 25), Quaternion.identity);
                     break;
                 case 2:
                     Instantiate(asteroid2, new Vector3(randomX, randomY, 25), Quaternion.identity);
                     break;
                 case 3:
                     Instantiate(asteroid3, new Vector3(randomX, randomY, 25), Quaternion.identity);
                     break;
                 default:
                     Debug.Log("Random Fail");
                     break;
            }
            yield return new WaitForSeconds(spawnTimer);
        }
    }
}