using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public Transform asteroid1;
    public Transform asteroid2;
    public Transform asteroid3;

    private int score;
    private int life;

    public GUIText scoreText;
    public GUIText lifeText;

	// Use this for initialization
	void Start () {
        score = 0;
        life = 100;
        UpdateText();
        StartCoroutine(SpawnAsteroids());
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    // controlling gamestats (score, life)
    void UpdateText()
    {
        scoreText.text = "Score: " + score;

        if (life > 0)
        {
            lifeText.text = "Life: " + life;
        }
        else
        {
            lifeText.text = "GAME OVER!";
        }
    }

    public void UpdateScore(int scorePoints)
    {
        score += scorePoints;
        UpdateText();
    }

    public void UpdateLife(int lifePoints)
    {
        life += lifePoints;
        UpdateText();
    }

    // controlling gameevents (spawning asteroids)
    // TODO: Spawning Enemys
    // TODO: Spawning Powerups
    IEnumerator SpawnAsteroids()
    {
        while(true)
        {
            float spawnTimer = Random.Range(0.25F, 1.5F);

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