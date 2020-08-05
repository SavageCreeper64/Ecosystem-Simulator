using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Fox : Predator
{
    public float foxRange;
    List<string> foxFood = new List<string>() {"Chicken" };
    // Start is called before the first frame update
    static int population;
    int counter;
    
  
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        foxRange = Random.Range(4.5f, 5.3f);
    }

    void Update()
    {
        if (foxRange > FindPrey(foxFood))
        {

            ChaseTarget();
            AttackTarget();
        }
        else
        {
            Wander();
            StartCoroutine(Waiting());
        }
        HungerExchange();
        




    }
    IEnumerator Waiting()
    {

        
        yield return new WaitForSeconds(Random.Range(25, 30));
        if (population < 25)
        {
            AM.AudioPlayer("clone", gameObject);
            
            counter = Random.Range(1, 3);
            population += counter;
            Clone(counter);
            
            


        }

    }


}
