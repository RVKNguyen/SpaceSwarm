using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    public float speed;
    public float fireRate;
    public GameObject shot;

	// Use this for initialization
	void Start () {
        fireRate = 2;
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody>().velocity = transform.forward * speed * 1.5F;
        
        //uncomment for OP enemys
        //transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform.position);

        Shot();
	}

    void Shot()
    {
        fireRate = fireRate - Time.deltaTime;

        if (fireRate <= 0)
        {
            Debug.Log("Enemy Shot");

            var spreadX = Random.Range(-10, -3);
            var spreadY = Random.Range(-3, 3);
            
            fireRate = 0.5F;
            Instantiate(shot, this.transform.position, this.transform.rotation * Quaternion.Euler(0, 0, 0));
        }

        /*       if (Time.time > nextShot)
                {
                    Debug.Log("Enemy Shot");
                    //Debug.Log("Shoot!");
                    nextShot = Time.time + fireRate;
                    //Debug.Log(shotSpawn_middle.rotation);
                    var angle = Quaternion.Euler(new Vector3(0, 0, 0.5F));

                    var spreadX = Random.Range(-10, -3);
                    var spreadY = Random.Range(-3, 3);

                    //Instantiate(shot, shotSpawn_middle.position, shotSpawn_middle.rotation * Quaternion.Euler(spreadX, spreadY, 0));
                }*/
    }
}
