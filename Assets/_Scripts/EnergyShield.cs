using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class EnergyShield : MonoBehaviour
{
   
    public Ground anotherS;
    public AudioSource audioSource; 
    public TextMeshProUGUI scoreGT;
    void Start()
    {
        GameObject scoreGO = GameObject.Find("Score");
        scoreGT = scoreGO.GetComponent<TextMeshProUGUI>();
        
       
    }
    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;

        // Inventory inv = GameObject.FindGameObjectWithTag("Inventory").gameObject.GetComponent<Inventory>();
        
        // scoreGT.text = inv.scoreGT.text.ToString();
    }


    private void OnCollisionEnter(Collision coll)
    {
        GameObject Collided = coll.gameObject;
        if (Collided.tag == "DragonEgg")
        {
            Destroy(Collided);
        }
        int score = int.Parse(scoreGT.text);
        score += 1;
        scoreGT.text = score.ToString();
        audioSource = GetComponent<AudioSource>();
        audioSource.Play(); 

        anotherS = GetComponent<Ground>(); 
        HealthSystemForDummies healthSystem = GameObject.FindGameObjectWithTag("Ground").gameObject.GetComponent<HealthSystemForDummies>();

        healthSystem.AddToCurrentHealth(100);
    }
    
}
