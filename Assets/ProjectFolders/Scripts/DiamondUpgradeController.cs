using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiamondUpgradeController : MonoBehaviour
{
    [Header("Game Variables")]
    [SerializeField] IntVariable BlueDiamondWorth;
    [SerializeField] IntVariable YellowDiamondWorth;
    [SerializeField] IntVariable CollectableCount;
    [SerializeField] IntVariable UpgradeLevelCount;
    [Header ("Events")]
    [SerializeField] VoidEvent onDiamondCountChanged;

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
            UpgradeTotalWorth();
            onDiamondCountChanged.Raise();
            SetPrice();

        }

    }

    public void UpgradeTotalWorth(){

        BlueDiamondWorth.ChangeInitialValue(BlueDiamondWorth.Value + 10);
        YellowDiamondWorth.ChangeInitialValue(YellowDiamondWorth.Value + 100);

    }
}
