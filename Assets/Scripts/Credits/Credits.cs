using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Credits : MonoBehaviour
{
    public Sprite[] creditImages;
    public Image panel;
    
    private int imageNumber;

    public Sprite GetCreditImage(){
        return creditImages[imageNumber];
    }
    public void UpdatePanelImage(){
        panel.sprite = creditImages[imageNumber];
    }

    public void ClickOnBack(){
        transform.Find("More").gameObject.SetActive(true);
        if(imageNumber>0){
            DecreaseImageNumber();
            UpdatePanelImage();
        }
        else{
            SceneManager.LoadScene("MenuScene");
        }
        
    }
    public void ClickOnMore(){
        if(imageNumber<2){
            IncreaseImageNumber();
            UpdatePanelImage();
        }
        if(imageNumber==2){
            transform.Find("More").gameObject.SetActive(false);
        }
        

        

        
    }

    private void IncreaseImageNumber(){
        imageNumber++;
    }
    private void DecreaseImageNumber(){
        imageNumber--;
    }
}
