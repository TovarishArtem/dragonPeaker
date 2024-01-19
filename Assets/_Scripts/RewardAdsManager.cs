using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class RewardAdsManager : MonoBehaviour
{
    public YandexGame sdk;
    public int score;
   
    public void AdButton(){
        sdk._RewardedShow(1);
    }
    public void AdButtonCul(){}

}
