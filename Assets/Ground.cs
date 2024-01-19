using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ground : MonoBehaviour
{
     public static float bottomY = -30f;
        public GameObject energyShieldPrefab;
        public AudioSource audioSource;
        public float energyShieldButtomY = -6f;

        public int numEnergyShield = 3;
        public int numEnergyShield1;
        public List<int> basketList;
        public static TextMeshProUGUI scoreGT;
    void Start()
    {
        GameObject scoreGO = GameObject.Find("Score");
        scoreGT = scoreGO.GetComponent<TextMeshProUGUI>();
        scoreGT.text = "0";
    }
    
    private void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("DragonEgg")){
            
            DragonPicker apScript = Camera.main.GetComponent<DragonPicker>();
            if (numEnergyShield == 3){
                
                // Damage enemy for -100 units
                

                 GameObject gamEObject = GameObject.FindWithTag("EnegryShield");
                 Destroy(gamEObject);

                GameObject tBasketGo = Instantiate<GameObject>(energyShieldPrefab);
                tBasketGo.transform.position = new Vector3(0, energyShieldButtomY, 0);
                tBasketGo.transform.localScale = new Vector3(2, 2, 2);
                
                Debug.Log(numEnergyShield);           
            }
                    
            if (numEnergyShield == 2){
                

                GameObject gamEObject = GameObject.FindWithTag("EnegryShield");
                Destroy(gamEObject);

                GameObject tBasketGo = Instantiate<GameObject>(energyShieldPrefab);
                tBasketGo.transform.position = new Vector3(0, energyShieldButtomY, 0);
                tBasketGo.transform.localScale =
                new Vector3(1, 1, 1);          
               ;
                
            }
             
            if (numEnergyShield == 1){
                
                GameObject gamEObject = GameObject.FindWithTag("EnegryShield");
                Destroy(gamEObject);
                           
                Debug.Log("________________________________-");
                Debug.Log(numEnergyShield);
                apScript.DragonEggDestroyed();
            }
            numEnergyShield = numEnergyShield - 1;
        }
        if (other.gameObject.CompareTag("Dragon")){
            
       ParticleSystem ps = GetComponent<ParticleSystem>();
        var em = ps.emission;
        em.enabled = true;
        Renderer rend;
        rend = GetComponent<Renderer>();
       
        rend.enabled = false;
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
       
        }

    }


    public void Buy()
    {
        Inventory inv = GameObject.FindGameObjectWithTag("Inventory").gameObject.GetComponent<Inventory>();
        numEnergyShield = inv.numEnergyShield;
        
        GameObject gamEObject = GameObject.FindWithTag("EnegryShield");
                Destroy(gamEObject);

                GameObject tBasketGo = Instantiate<GameObject>(energyShieldPrefab);
                tBasketGo.transform.position = new Vector3(0, energyShieldButtomY, 0);
                if (numEnergyShield <= 3){
                   tBasketGo.transform.localScale =
                new Vector3(numEnergyShield + 1,numEnergyShield + 1,numEnergyShield + 1);          
               ; 
                } else  new Vector3(3,3,3);
                
    
        
        
    } 
}
