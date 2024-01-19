using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DragonEgg : MonoBehaviour
{
        public static float bottomY = -30f;
        public GameObject energyShieldPrefab;
        public AudioSource audioSource;
        public float energyShieldButtomY = -6f;

        public int numEnergyShield;
        public int numEnergyShield1= 3;
        public List<int> basketList;

    private void OnTriggerEnter(Collider other)
    {
        
        
       
        ParticleSystem ps = GetComponent<ParticleSystem>();
        var em = ps.emission;
        em.enabled = true;
        Renderer rend;
        rend = GetComponent<Renderer>();
       
        rend.enabled = false;
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
        
        
        
    }
    void Awake(){
        numEnergyShield = 3;
    }

    private void DestroyEnergyShield(){
        DragonPicker apScript = Camera.main.GetComponent<DragonPicker>();
        
        if (numEnergyShield1 == 2){

                GameObject gamEObject = GameObject.Find("EnegryShield");
                Destroy(gamEObject);
                GameObject tBasketGo = Instantiate<GameObject>(energyShieldPrefab);
                tBasketGo.transform.position = new Vector3(0, energyShieldButtomY, 0);
                tBasketGo.transform.localScale =
                new Vector3(1, 1, 1);

                

   
                
                numEnergyShield = numEnergyShield- 1;
                
            }
            if (numEnergyShield1 == 3){
                GameObject gamEObject = GameObject.FindWithTag("EnegryShield");
                Destroy(gamEObject);
                GameObject tBasketGo = Instantiate<GameObject>(energyShieldPrefab);
                tBasketGo.transform.position = new Vector3(0, energyShieldButtomY, 0);
                tBasketGo.transform.localScale =
                new Vector3(2, 2, 2);
                
                numEnergyShield1 = numEnergyShield1 - 1;
                
            }

    }
    void Update()
    {
        
        if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject);
          
            // Debug.Log(numEnergyShield);
            
             
        }
        numEnergyShield = numEnergyShield1;
        
    } 
}      
