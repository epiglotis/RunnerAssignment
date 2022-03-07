using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUIController : MonoBehaviour
{
    [Header ("GameEvents")]
    [SerializeField] VoidEvent PlayerGotHit;
    [Header ("GameVariables")]
    [SerializeField] IntVariable PlayerHitPoints;
    Transform _transform;


    private void OnEnable() {
        
        _transform = GetComponent<Transform>();
        CheckHowManyHeartsWeHave();
        PlayerGotHit.AddListener(CheckHowManyHeartsWeHave);

    }

    private void OnDisable() {
        
        PlayerGotHit.RemoveListener(CheckHowManyHeartsWeHave);

    }

    public void CheckHowManyHeartsWeHave(){
        foreach(Transform child in _transform){

            child.gameObject.SetActive(false);

        }

        for (int i = 0; i < PlayerHitPoints.Value; i++)
        {
            
            if(_transform.GetChild(i) != null){

                _transform.GetChild(i).gameObject.SetActive(true);

            }
            

        }

    }

}
