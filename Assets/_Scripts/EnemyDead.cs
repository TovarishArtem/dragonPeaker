using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EnemyDead : MonoBehaviour
{
    // Start is called before the first frame update
    public static float bottomY = -30f;
    public float delay = 3;
    float timer = 2f;
    
    public AudioSource audioSource;
    
    void Start()
    {
    
    }
    

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject);
        }
        timer -= Time.deltaTime;  
       
        
    }
     private void OnTriggerEnter(Collider other)
    {
        

        audioSource = GetComponent<AudioSource>();
        audioSource.Play(); 

        Invoke(nameof(DestroyMethod), 1f);
    }
    private void DestroyMethod(){
         SceneManager.LoadScene("_0Scene");
    }
    
    
}
