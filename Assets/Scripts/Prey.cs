using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

public class Prey : Animals
{
    // Start is called before the first frame update

    float speed = 3.9f;
    Vector3 targetLocation;
    



    void Start()
    {


    }



    protected float LocatePredator()
    {
        List<GameObject> pred = new List<GameObject>();
        string[] tags = { "Lion", "Fox" };
        foreach (string tag in tags)
        {
            GameObject[] more = GameObject.FindGameObjectsWithTag(tag);
            foreach (GameObject g in more)
            {
                pred.Add(g);
            }


        }
        if (pred.Count == 0)
        {
            return 2^999;
        }
        GameObject closestPred = pred[0];
        foreach (GameObject c in pred)
        {

            if (Vector3.Distance(c.transform.position, transform.position) <
                Vector3.Distance(closestPred.transform.position, transform.position))
            {
                closestPred = c;
            }

        }
        targetLocation = closestPred.transform.position;
        return Vector3.Distance(closestPred.transform.position, transform.position);






    }
    protected void RunAwayTarget()
    {
        //TODO: Add a way to find all foxes and run away from all.
        
        Vector3 relativePos = transform.position - targetLocation;
        Vector3 correction = new Vector3(Random.Range(-1, 1), 0, Random.Range(-1, 1));
        relativePos += correction;
        Quaternion rotation = Quaternion.LookRotation(relativePos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
        
        
        navMeshAgent.Move(relativePos.normalized * Time.deltaTime * speed);

        
        


    }
}
