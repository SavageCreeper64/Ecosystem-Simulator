using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Lion : Predator
{
    List<string> lionFood = new List<string>() {"Cow", "Fox", "Chicken"};
    bool wakeupBool = false;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        StartCoroutine(Wakeup());
        

    }
    
    // Update is called once per frame
    void Update()
    {
        if (wakeupBool)
        {
            FindPrey(lionFood);
            ChaseTarget();
            AttackTarget();
            //StartCoroutine(Waiting());

        }
 
        
        
        
    }
    IEnumerator Waiting()
    {

        yield return new WaitForSeconds(Random.Range(30, 40));
        //Clone(Random.Range(1,2));


    }
    IEnumerator Wakeup()
    {
        yield return new WaitForSeconds(20);
        wakeupBool = true;
        
        
    }
}
