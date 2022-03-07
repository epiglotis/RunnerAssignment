using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour
{
    [SerializeField] float hitScaleValue = 2f;
    
    private void OnTriggerEnter(Collider other) {
        
        if(other.GetComponent<RobotBehaviourController>()){
            Vector3 tempScale = transform.localScale;
            LeanTween.scale(this.gameObject,new Vector3(hitScaleValue,hitScaleValue,hitScaleValue),0.1f).setOnComplete(() => LeanTween.scale(this.gameObject,tempScale,0.1f));

        }

    }

}
