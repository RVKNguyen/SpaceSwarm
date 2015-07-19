using UnityEngine;
using System.Collections;

public class ParticleController : MonoBehaviour {

    private Transform tx;
    private ParticleSystem.Particle[] points;

    public int starsMax = 1000;
    public float starSize = 0.2F;
    
    public float starDistance = 100.0F;
    public float starDistanceSqr;

    public float starClipDistance = 5F;
    public float starClipDistanceSqr;

    public float speed = 10;

    // Use this for initialization
	void Start () {
        tx = transform;
        starDistanceSqr = starDistance * starDistance;
        starClipDistanceSqr = starClipDistance * starClipDistance;
	}
	
	// Update is called once per frame
	void Update () {
        if (points == null) CreateStars();

        for (int i = 0; i < starsMax; i++)
        {
            points[i].position = points[i].position + new Vector3(0,0,-1) * Time.deltaTime * speed;


            if ((points[i].position - tx.position).sqrMagnitude > starDistanceSqr){
                points[i].position = Random.insideUnitSphere.normalized * starDistance + tx.position;
            }

            if ((points[i].position - tx.position).sqrMagnitude <= starClipDistanceSqr)
            {
                float percentage = (points[i].position - tx.position).sqrMagnitude / 100;
                points[i].color = new Color(1, 1, 1, percentage);
                points[i].size = points[i].size * percentage;
            }
        }


        GetComponent<ParticleSystem>().SetParticles(points, points.Length);
	}

    private void CreateStars()
    {
        points = new ParticleSystem.Particle[starsMax];
        for (int i = 0; i < starsMax; i++)
        {
            points[i].position = Random.insideUnitSphere * starDistance + tx.position;
            points[i].color = new Color(1,1,1,1);
            points[i].size = starSize;
        }

    }


}
