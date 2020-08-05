using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Predator : Animals
{
    // Start is called before the first frame update

    int speed = 5;
    Vector3 targetLocation;
    
    GameObject closestP;
    


    void Start()
    {


    }



    protected float FindPrey(List<string> tags)
    {
        List<GameObject> prey = new List<GameObject>();
        

        foreach (string tag in tags)
        {
            GameObject[] more = GameObject.FindGameObjectsWithTag(tag);
            foreach (GameObject g in more)
            {
                prey.Add(g);
            }
            
            
        }


        GameObject closestPrey = prey[0];
        foreach (GameObject c in prey)
        {

            if (Vector3.Distance(c.transform.position, transform.position) <
                Vector3.Distance(closestPrey.transform.position, transform.position))
            {
                closestPrey = c;
            }

        }
        targetLocation = closestPrey.transform.position;
        closestP = closestPrey;
        return Vector3.Distance(closestPrey.transform.position, transform.position);






    }
    protected void ChaseTarget()
    {

        Vector3 relativePos = transform.position - targetLocation;
        Quaternion rotation = Quaternion.LookRotation(relativePos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
        navMeshAgent.SetDestination(targetLocation);


    }
    protected void AttackTarget()
    {
        if (1 > Vector3.Distance(targetLocation, transform.position))
        {
            Destroy(closestP);
            AM.AudioPlayer("chomp", gameObject);
        }
    }
    
}
    
   


        
