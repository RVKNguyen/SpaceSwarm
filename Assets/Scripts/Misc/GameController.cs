using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public Transform asteroid1;
    public Transform asteroid2;
    public Transform asteroid3;

    public Transform enemy1;
    public Transform enemy2;
    public Transform enemy3;

    public Transform buttonGameOver;

    private int score;
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
            
            if (life < 20)
            {
                GetComponent<AudioSource>().Play();
            }
        }
        else
        {
            lifeText.text = "--------";
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
        Instantiate(buttonGameOver, new Vector3(0 , 0,
            5F), new Quaternion(0, 270, 0, 0));
        Debug.Log("GameOver");
    }

    // controlling gameevents (spawning asteroids)
    // TODO: Spawning Enemys
    // TODO: Spawning Powerups
    // TODO: Difficulty
        

    IEnumerator SpawnAsteroids()
    {
        while(running)
        {
            float spawnTimer = Random.Range(0.25F, 2.0F - dif);

            if (dif < 1.5F ){
                dif += 0.02F;
            }

            int random = Random.Range(1, 7);
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
                 case 4:
                     Instantiate(enemy1, new Vector3(randomX, randomY, 25), Quaternion.Euler(0, 180, 0));
                     break;
                 case 5:
                     Instantiate(enemy2, new Vector3(randomX, randomY, 25), Quaternion.Euler(0, 180, 0));
                     break;
                 case 6:
                     Instantiate(enemy3, new Vector3(randomX, randomY, 25), Quaternion.Euler(0, 180, 0));
                     break;

                 default:
                     Debug.Log("Random Fail");
                     break;
            }
            yield return new WaitForSeconds(spawnTimer);
        }
    }
}