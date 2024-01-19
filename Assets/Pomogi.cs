using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pomogi : MonoBehaviour
{       
        public ParticleSystem ps;
        public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet")){

            Debug.Log(("вызов"));
            Destroy(this.gameObject);
            Debug.Log(("партиклы"));
            ps = GetComponent<ParticleSystem>();
            var em = ps.emission;
            em.enabled = true;
            Renderer rend;
            rend = GetComponent<Renderer>();
            rend.enabled = false;

             
            audioSource = GetComponent<AudioSource>();
            audioSource.Play();

            Debug.Log(("звук"));
        }       
    }
}
