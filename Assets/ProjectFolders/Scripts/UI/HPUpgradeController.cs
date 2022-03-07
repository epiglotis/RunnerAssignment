using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPUpgradeController : MonoBehaviour
{
    [Header("Game Variables")]
    [SerializeField] IntVariable TotalPlayerHP;
    [SerializeField] IntVariable PlayerHitPoints;
    [SerializeField] IntVariable CollectableCount;
    [SerializeField] IntVariable UpgradeLevelCount;
    [Header("Game Events")]
    [SerializeField] VoidEvent OnScoreChanged;
    [SerializeField] VoidEvent PlayerGotHit;
    [Header("Variables")]
    [SerializeField] int price;
    [SerializeField] Text priceText;

    private void OnEnable() {
        
        SetPrice();

    }

    void SetPrice(){

        switch (UpgradeLevelCount.Value)
        {
            case 0:
            price = 100;
            priceText.text = price.ToString();
            return;

            case 1:
            price = 1000;
            priceText.text = price.ToString();
            return;

            case 2:
            price = 10000;
            priceText.text = price.ToString();
            return;
            default:
            price = 999999999;
            priceText.text = price.ToString();
            return;
        }
        

    }

    public void CheckIfPlayerHasEnoughMoney(){

        if(CollectableCount.Value >= price){

            CollectableCount.Decrease(price);
            UpgradeLevelCount.ChangeInitialValue(UpgradeLevelCount.Value + 1);
            UpgradeTotalHP();
            PlayerGotHit.Raise();
            OnScoreChanged.Raise();
            SetPrice();

        }

    }

    public void UpgradeTotalHP(){

        TotalPlayerHP.ChangeInitialValue(TotalPlayerHP.Value + 1);
        PlayerHitPoints.SetValue(TotalPlayerHP.Value);

    }


}
