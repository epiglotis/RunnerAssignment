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

    [SerializeField] Text diamondCountText;

    private void OnEnable() {
        diamondCountText.text = DiamondCount.Value.ToString();
        DiamondCountChanged.AddListener(DisplayDiamondCountAsString);

    }

    private void OnDisable() {
        
        DiamondCountChanged.RemoveListener(DisplayDiamondCountAsString);

    }

    void DisplayDiamondCountAsString(){

        diamondCountText.text = DiamondCount.Value.ToString();

    }

}
