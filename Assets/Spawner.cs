using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Points;
    public GameObject SpawnerObject;

    private float nextActionTime = 0.0f;
    public float period = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
   

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;

            GameObject p = Instantiate(Points, SpawnerObject.transform);

      
            // arvotaan randomilla sijainti
            float x = Random.Range(-30, 30);
            float z = Random.Range(-30, 30);

            p.name = $"Point {x} {z}";

            p.transform.position = new Vector3(x, 0.5f, z);

            Vector3 pos = p.transform.position;

            //Debug.Log($"Luodaan uusi piste sijaintiin {pos}");

 
        }
    }
}
