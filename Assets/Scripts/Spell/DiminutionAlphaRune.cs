using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiminutionAlphaRune : MonoBehaviour
{
    ParticleSystem particles;
    ParticleSystem.MainModule main;  
    [SerializeField]
    float r = 0;
    [SerializeField]
    float g = 0;
    [SerializeField]
    float b = 0;
    float alpha = 1;
    [SerializeField][Range(0,5)]
    float totalTime = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        particles = GetComponent<ParticleSystem>();
        main = particles.main;
        
    }

    // Update is called once per frame
    void Update()
    {       
        main.startColor = new Color(r, g, b, alpha);
        alpha -= Time.deltaTime /totalTime;      
    }
}
