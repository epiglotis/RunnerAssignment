using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayDiamondCount : MonoBehaviour
{
    [Header ("GameEvents")]
    [SerializeField] VoidEvent DiamondCountChanged;
    [Header("GameVariables")]
    [SerializeField] IntVariable DiamondCount;

    Text diamondCountText;

    private void OnEnable() {
        
        DiamondCountChanged.AddListener(DisplayDiamondCountAsString);

    }

    private void OnDisable() {
        
        DiamondCountChanged.RemoveListener(DisplayDiamondCountAsString);

    }

    void DisplayDiamondCountAsString(){

        diamondCountText.text = DiamondCount.ToString();

    }

}
