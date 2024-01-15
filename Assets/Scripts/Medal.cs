using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Medal : MonoBehaviour
{

    public Sprite metalMedal, bronzeMedal, silverMedal, goldMedal;
    Image image;


    // Update is called once per frame
    void Update()
    {
        image = GetComponent<Image>();
        int gameScore = GameManager.gameScore;

        if (gameScore > 0 && gameScore <= 1)
        {

            image.sprite = metalMedal;

        }

        else if(gameScore > 0 && gameScore <= 2) 
        {
            image.sprite = bronzeMedal;
        }

        else if(gameScore > 0 && gameScore <= 3) 
        {
            image.sprite = silverMedal;
        }

        else if(gameScore > 3) 
        {
            image.sprite = goldMedal;
        }
    }
}
