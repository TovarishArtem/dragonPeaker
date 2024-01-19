using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bullet_new_mod : MonoBehaviour
{
    public GameObject expPrefab;
    public static float upY = 15f;
    public Vector2 direction;

    public GameObject targetEnemy;

    public float speed = -2f;
    public List<GameObject> basketList;
    public TextMeshProUGUI scoreGT;
    

    void Start()
    {
        GameObject scoreGO = GameObject.Find("Score");
        scoreGT = scoreGO.GetComponent<TextMeshProUGUI>();
       
    }

    // Start is called before the first frame update
    private void FixedUpdate() {
        transform.Translate(direction.normalized * speed /  2);
   
    }
    // Update is called once per frame
     private void OnTriggerEnter2D(Collider2D other)
    {
            basketList = new List<GameObject>();
        if (other.gameObject.CompareTag("Dragon")){
             Inventory inv = GameObject.FindGameObjectWithTag("Inventory").gameObject.GetComponent<Inventory>();
         
            
           

            ParticleSystem ps = GetComponent<ParticleSystem>();
            var em = ps.emission;
            em.enabled = true;

            Renderer rend;
            rend = GetComponent<Renderer>();
            
            rend.enabled = false;
           
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.Play();
            int score = int.Parse(scoreGT.text);
            score += inv.scorePoints;
  
            scoreGT.text = score.ToString();
 
            
            
        }       
    }
        
    void Update()
    {
        if (transform.position.y > upY)
        {
           
            Destroy(this.gameObject);
        
        }
        // Inventory inv = GameObject.FindGameObjectWithTag("Inventory").gameObject.GetComponent<Inventory>();
        // scorePoints = inv.scorePoints;
    }
    

    
}
