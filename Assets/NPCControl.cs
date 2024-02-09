using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCControl : MonoBehaviour
{
    public string NpcName;
    public int score = 0;


    NavMeshAgent ai;

    public GameObject Spawner;

    public GameObject Target;

    int interval = 5;
    float nextTime = 5;

    void Start()
    {
        ai = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextTime && Spawner.transform.childCount > 0)
        {

            if(!Target)
            {
                int index = Random.Range(0, Spawner.transform.childCount - 1);

                Target = Spawner.transform.GetChild(index).gameObject;

                ai.SetDestination(Target.transform.position);

                Debug.Log(Target.name);
            }

            nextTime += interval;
        }
    }
}
