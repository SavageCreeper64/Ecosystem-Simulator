using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class ChickenController : Prey 
{
    // Start is called before the first frame update
    static int population;
    int counter;
    float chickenRange;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        population = 0;
        chickenRange = Random.Range(4.5f, 6.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (chickenRange > LocatePredator())
        {
            
            RunAwayTarget();

        }
        else
        {
            Wander();
            StartCoroutine(Waiting());
            Debug.Log("Function Working");
            hunger += .1f;

        }
        hunger -= .1f;
        

    }
    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(Random.Range(18, 30));
        if (population < 25 && transform.parent.childCount < 25)
        {
            
            Debug.Log(population);
            counter = Random.Range(1, 3);
            population += counter;
            Clone(counter);
            

        }
        





    }

    
}
