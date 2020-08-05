using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Manager : MonoBehaviour
{
    public AudioClip chomp;
    public AudioClip die;
    public AudioClip clone;
    void Start()
    {
        
    }
 

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void AudioPlayer(string audioName, GameObject animal)
    {
        AudioSource AS = animal.GetComponent<AudioSource>();
        if (audioName == "clone")
        {
            AS.clip = clone;

        }
        else if (audioName == "die")
        {

            AS.clip = die;
        }
        else if (audioName == "chomp")
        {
            AS.clip = chomp;
        }
        
        AS.Play();
        

    }
}
