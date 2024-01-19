using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bullet : MonoBehaviour
{
    public GameObject expPrefab;
    public static float upY = 15f;
    public Vector2 direction;

    public GameObject targetEnemy;

    public float speed = -2f;
    public List<GameObject> basketList;

    // Start is called before the first frame update
    private void FixedUpdate() {
        transform.Translate(direction.normalized * speed /  2);
   
    }
    // Update is called once per frame
     private void OnTriggerEnter2D(Collider2D other)
    {
            basketList = new List<GameObject>();
        if (other.gameObject.CompareTag("Dragon")){
            TextMeshProUGUI scoreGT = GameObject.FindGameObjectWithTag("Score").gameObject.GetComponent<TextMeshProUGUI>();
            int score = int.Parse(scoreGT.text);
            score +=1;
            scoreGT.text = score.ToString();

      

            
            
           

            ParticleSystem ps = GetComponent<ParticleSystem>();
            var em = ps.emission;
            em.enabled = true;

            Renderer rend;
            rend = GetComponent<Renderer>();
            
            rend.enabled = false;
           
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.Play();
         
            HealthSystemForDummies healthSystem = GameObject.FindGameObjectWithTag("Dragon").gameObject.GetComponent<HealthSystemForDummies>();
            
            healthSystem.AddToCurrentHealth(-50);
            



            if (healthSystem.CurrentHealth < 2 ){
                    healthSystem.Kill();
                    SceneManager.LoadScene("SceneDead");
  
            }
            
            
        }       
    }
        
    void Update()
    {
        if (transform.position.y > upY)
        {
           
            Destroy(this.gameObject);
        
        }
    }

    
    
}
