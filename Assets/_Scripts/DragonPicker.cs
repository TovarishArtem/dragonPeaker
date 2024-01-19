using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;
using TMPro;
public class DragonPicker : MonoBehaviour
{
    private void OnEnable() => YandexGame.GetDataEvent += GetLoadSave;
    private void OnDisable() => YandexGame.GetDataEvent += GetLoadSave;
    public GameObject energyShieldPrefab;

    public float energyShieldButtomY = -6f;
    public float energyShieldRadius = 1.5f;

    
    public TextMeshProUGUI scoreGT;
    public List<GameObject> basketList;
    void Start()
    {
        
        if (YandexGame.SDKEnabled == true){
            GetLoadSave();
        }
        
        
        GameObject tBasketGo = Instantiate<GameObject>(energyShieldPrefab);
        tBasketGo.transform.position = new Vector3(0, energyShieldButtomY, 0);
        tBasketGo.transform.localScale =
        new Vector3(3, 3, 3);
        basketList.Add(tBasketGo);
        
    }
    private void GetLoadSave(){
        Debug.Log(YandexGame.savesData.score);
    }
    void Update()
    {
    }
    public void DragonEggDestroyed()
    {
        GameObject[] tDragonEggArray =
        GameObject.FindGameObjectsWithTag("DragonEgg");
        foreach (GameObject tGO in tDragonEggArray)
        {
            Destroy(tGO);
        }
        GameObject scoreGO = GameObject.Find("Score");
        scoreGT = scoreGO.GetComponent<TextMeshProUGUI>();
        
        UserSave(int.Parse(scoreGT.text), YandexGame.savesData.bestScore);
 
        YandexGame.NewLeaderboardScores("TOPplayer", int.Parse(scoreGT.text));
        Debug.Log("хууууй");
        SceneManager.LoadScene("_0Scene");
        GetLoadSave();
    }
    private void UserSave(int currentScore, int currentBestScore){
        YandexGame.savesData.score = currentScore;
        if (currentScore > currentBestScore){
            YandexGame.savesData.bestScore = currentScore;
        }
        YandexGame.SaveProgress();
    }
}
