using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    public float MaxHealth = 400;
     
    public TextMeshProUGUI scoreGT;
    public TextMeshProUGUI scoreItem1;
    public TextMeshProUGUI scoreItem2;
    public TextMeshProUGUI scoreItem3;
    public int numEnergyShield;
    public int scorePoints = 1;
    public int item1 = 5;
    public int item2 = 5;
    public int item3 = 10;
    void Start(){
        GameObject mana = GameObject.FindGameObjectWithTag("ButtonMana");
        TextMeshProUGUI scoreItem1 = mana.GetComponent<TextMeshProUGUI>(); 
        scoreItem1.text = item1.ToString();

        GameObject heart = GameObject.FindGameObjectWithTag("ButtonHeart");
        scoreItem2 = heart.GetComponent<TextMeshProUGUI>(); 
        scoreItem2.text = item2.ToString();

        GameObject strengh = GameObject.FindGameObjectWithTag("ButtonStrengh");
        scoreItem3 = strengh.GetComponent<TextMeshProUGUI>(); 
      
        scoreItem3.text = item3.ToString();
        
    }
    void Update()
    {
        
        
        if (Input.GetButtonDown("item1"))
        {

           GameObject scoreGO = GameObject.Find("Score");
            scoreGT = scoreGO.GetComponent<TextMeshProUGUI>();
            int score = int.Parse(scoreGT.text);
            if (score > item1 - 1 ){
                
               
                MaxHealth = MaxHealth  + 200;
                score -= item1; 
                scoreGT.text = score.ToString();
                PlusItem1();
            }
            
        }
        Ground ground = GameObject.FindGameObjectWithTag("Ground").gameObject.GetComponent<Ground>();
        if (Input.GetButtonDown("item2"))
        {
            GameObject scoreGO = GameObject.Find("Score");
            scoreGT = scoreGO.GetComponent<TextMeshProUGUI>();
       
            int score = int.Parse(scoreGT.text);
            if (score > item2 - 1){
                
                
                if (ground.numEnergyShield <= 3){
                    ground.numEnergyShield += 1;
                }
                
                 numEnergyShield = ground.numEnergyShield;
                score -= item2; 
                scoreGT.text = score.ToString();
                ground.Buy();
                Invoke(nameof(timerScorePoints), 5);
                PlusItem2();
            }
            
        }

        if (Input.GetButtonDown("item3"))
        {
            GameObject scoreGO = GameObject.Find("Score");
            scoreGT = scoreGO.GetComponent<TextMeshProUGUI>();
           
            int score = int.Parse(scoreGT.text);
  
            if (score > item3 -1){
                

                scorePoints  = 2;
                score -= item3; 
                scoreGT.text = score.ToString();
                PlusItem3();
                 
            }
            
        }
    }
    private void timerScorePoints(){
        
        scorePoints = 1;
    }
    private void PlusItem1(){
        GameObject mana = GameObject.FindGameObjectWithTag("ButtonMana");
        scoreItem1 = mana.GetComponent<TextMeshProUGUI>(); 

        item1 += 5;
        scoreItem1.text = item1.ToString();
    }
    private void PlusItem2(){
        GameObject heart = GameObject.FindGameObjectWithTag("ButtonHeart");
        scoreItem2 = heart.GetComponent<TextMeshProUGUI>(); 
        item2+=5;
        scoreItem2.text = item2.ToString();
    }
    private void PlusItem3(){
        GameObject strengh = GameObject.FindGameObjectWithTag("ButtonStrengh");
        scoreItem3 = strengh.GetComponent<TextMeshProUGUI>(); 
        item3+=5;
        scoreItem3.text = item3.ToString();
    }

}
