using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public Transform asteroid1;
    public Transform asteroid2;
    public Transform asteroid3;

    public Transform enemy1;
    public Transform enemy2;
    public Transform enemy3;

    public Transform powerUp1;
    public Transform powerUp2;

    public Transform buttonGameOver;
	public Transform buttonHighScore;

    public static int score;
    private int life;
    private bool running;
    private float dif;

    public GUIText scoreText;
    public GUIText lifeText;

	// Use this for initialization
	void Start () {
        score = 0;
        life = 100;
        running = true;
        dif = 0F;
        UpdateText();
        StartCoroutine(SpawnAsteroids());

        if (MainMenuScript.soundOn == true)
        {
            Debug.Log("sound is on" + MainMenuScript.soundOn);
            AudioListener.volume = 1;
        }
        else
        {
            Debug.Log("sound is off" + MainMenuScript.soundOn);
            AudioListener.volume = 1 - AudioListener.volume;
        }
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
            GetComponent<AudioSource>().Pause();

            if (life < 20)
            {
                GetComponent<AudioSource>().Play();
            }
        }
        else
        {
            lifeText.text = "GAME OVER";
            GetComponent<AudioSource>().Pause();
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
        if (life >= 100)
        {
            life = 100;
        }
        UpdateText();
    }

    public int GetLife()
    {
        return life;
    }

    public int GetScore()
    {
        return score;
    }

    public void GameOver()
    {
        running = false;

		Highscore script = transform.gameObject.GetComponent<Highscore> ();
		script.AddScore (score, (int)(Time.time * 1000));

		Instantiate(buttonHighScore, new Vector3(0F, 0F, 5F), new Quaternion(0, 270, 0, 0));
    }

    // controlling gameevents (spawning asteroids)
    // TODO: Difficulty   

    IEnumerator SpawnAsteroids()
    {
        while(running)
        {
            float spawnTimer = Random.Range(0.25F, 2.0F - dif);

            if (dif < 1.5F ){
                dif += 0.02F;
            }

            int random = Random.Range(1, 15);
            int randomX = Random.Range(-5, 5);
            int randomY = Random.Range(-5, 5);

            switch (random)
            {
                 case 1:
                     Instantiate(asteroid1, new Vector3(randomX, randomY, 50), Quaternion.identity);
                     break;
                 case 2:
                     Instantiate(asteroid2, new Vector3(randomX, randomY, 50), Quaternion.identity);
                     break;
                 case 3:
                     Instantiate(asteroid3, new Vector3(randomX, randomY, 50), Quaternion.identity);
                     break;
                 case 4:
                     Instantiate(asteroid1, new Vector3(randomX, randomY, 50), Quaternion.identity);
                     break;
                 case 5:
                     Instantiate(asteroid2, new Vector3(randomX, randomY, 50), Quaternion.identity);
                     break;
                 case 6:
                     Instantiate(asteroid3, new Vector3(randomX, randomY, 50), Quaternion.identity);
                     break;
                 case 7:
                     Instantiate(asteroid1, new Vector3(randomX, randomY, 50), Quaternion.identity);
                     break;
                 case 8:
                     Instantiate(asteroid2, new Vector3(randomX, randomY, 50), Quaternion.identity);
                     break;
                 case 9:
                     Instantiate(asteroid3, new Vector3(randomX, randomY, 50), Quaternion.identity);
                     break;
                 case 10:
                     Instantiate(enemy1, new Vector3(randomX, randomY, 50), Quaternion.Euler(0, 180, 0));
                     break;
                 case 11:
                     Instantiate(enemy2, new Vector3(randomX, randomY, 50), Quaternion.Euler(0, 180, 0));
                     break;
                 case 12:
                     Instantiate(enemy3, new Vector3(randomX, randomY, 50), Quaternion.Euler(0, 180, 0));
                     break;
                 case 13:
                     Instantiate(powerUp1, new Vector3(randomX, randomY, 50), Quaternion.Euler(0, 180, 0));
                     break;
                 case 14:
                     Instantiate(powerUp2, new Vector3(randomX, randomY, 50), Quaternion.Euler(0, 180, 0));
                     break;

                 default:
                     Debug.Log("Random Fail");
                     break;
            }
            yield return new WaitForSeconds(spawnTimer);
        }
    }
}