using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Animals : MonoBehaviour
{
    int speed = 8;
    int range = 10;
    protected float hunger = 5;
    static int maxHunger = 10;
    protected NavMeshAgent navMeshAgent;
    public Audio_Manager AM;
    public void Awake()
    {
        AM = GameObject.Find("Audio Manager").GetComponent<Audio_Manager>();
    }
        




    



    void Die()
    {
        AM.AudioPlayer("die", gameObject);
        Destroy(gameObject);
        
    }

    public void Clone(int numberOfClones)
    {
        while(numberOfClones > 0)
        {
            
            Instantiate(gameObject, transform, true).transform.SetParent(gameObject.transform.parent);
            
            numberOfClones -= 1;
        }
        
        
    }
    public void Wander()
    {
        NavMeshHit outputLocal;
        Vector3 direction = Random.insideUnitSphere * range + transform.position;
        if (NavMesh.SamplePosition(direction, out outputLocal, range, -1))
        {
          
            navMeshAgent.SetDestination(outputLocal.position);
            
        }
    }
    public void HungerExchange()
    {
        if (hunger <= 0)
        {
            Die();
        }
        if (hunger > maxHunger)
        {
            hunger = maxHunger;
        }
        hunger -= 1f;
        

    }
    

    

}
