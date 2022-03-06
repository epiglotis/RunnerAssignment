using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DiamondType{
    Blue,
    Yellow
}
public class CollectablesController : MonoBehaviour
{
    [Header ("GameEvents")]
    [SerializeField] FloatEvent onScoreGained;
    [Header ("GameVariables")]
    [SerializeField] IntVariable collectableCount;
    [SerializeField] IntVariable DiamondWorth;
    [Header ("Variables")]
    [SerializeField] DiamondType diamondType;
    [SerializeField] GameObject confettiParticle;
    
    private void OnTriggerEnter(Collider other) {
        
        if(other.GetComponent<RobotSideMovementController>() != null){

            collectableCount.Increase(DiamondWorth.Value);
            
            onScoreGained.Raise(collectableCount.Value);
            Instantiate(confettiParticle,transform.position,Quaternion.identity);

            Destroy(this.gameObject);

        }

    }

}
