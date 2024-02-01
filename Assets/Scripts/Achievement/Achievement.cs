using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Achievement : MonoBehaviour
{
    public Image imageAchievement;
    public Sprite withoutAchievement;
    public Sprite withAchievement;
    public Sprite achievementPanel;

    private bool isActive;


    private void SetAchievementImage(Sprite achievementSprite){
        imageAchievement.sprite = achievementSprite;
    }

    public void SetAchievementPanelImage(Image achievementPanelImage){
        achievementPanelImage.sprite = achievementPanel;
    }

    public void UpdateButton(){
        isActive = true;
        SetAchievementImage(withAchievement);                
    }

    public bool GetIsActive(){
        return isActive;
    }
}
