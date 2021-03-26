using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleTrigger : MonoBehaviour
{
    [SerializeField] ParticleSystem collectParticle = null;

    void Start()
    {
    }
    void Update()
    {
        Collect();
    }
    public void Collect()
    {
        // play the collect graphics
        if (GameObject.Find("Player").GetComponent<VRGaze>().gvrparticleStatus)
        {
            
        } else
        {
            collectParticle.Play();
        }

        //play the collect sound effects
    }



}
