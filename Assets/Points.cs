using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    public int AddScore = 10;

    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);

        if(other.CompareTag("Player"))
        {
            Player.GetComponent<PlayerControl>().score += AddScore;
            Destroy(gameObject);

        }

        if(other.CompareTag("npc"))
        {
            other.GetComponent<NPCControl>().score += AddScore;
            other.GetComponent<NPCControl>().Target = null;
            Destroy(gameObject);
        }


    }

 

    // Update is called once per frame
    void Update()
    {
        
    }
}
