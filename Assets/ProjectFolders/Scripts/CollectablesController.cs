using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablesController : MonoBehaviour
{
    [Header ("GameEvents")]
    [SerializeField] FloatEvent onScoreGained;
    [Header ("GameVariables")]
    [SerializeField] IntVariable collectableCount;
    
    private void OnTriggerEnter(Collider other) {
        
        if(other.GetComponent<RobotSideMovementController>() != null){

            collectableCount.Increase(10);
            Destroy(this.gameObject);

        }

    }

}
