using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;
using TMPro;

public class CheckConnectYG : MonoBehaviour
{
    
    public TextMeshProUGUI scoreBest;
    private void OnEnabled() => YandexGame.GetDataEvent += CheckSDK;
    private void OnDisable() => YandexGame.GetDataEvent += CheckSDK;
    // Start is called before the first frame update
    void Start()
    {
        if (YandexGame.SDKEnabled == true)
        {
            CheckSDK();
        }
        
    }

    // Update is called once per frame
    public void CheckSDK(){
        if (YandexGame.auth == true)
        {
            Debug.Log("User authorization ok");
        }
        else
        {
            Debug.Log("User not authorization");
        }

        GameObject scoreBO = GameObject.FindWithTag("maxScore");
        scoreBest = scoreBO.GetComponent<TextMeshProUGUI>();
        scoreBest.text = YandexGame.savesData.bestScore.ToString();

    }
}
