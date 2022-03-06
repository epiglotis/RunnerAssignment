using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBehaviour : MonoBehaviour
{
    [SerializeField] float hitScaleValue = 1.05f;
    private void OnEnable() {

        Vector3 tempScale = transform.localScale;
        LeanTween.scale(this.gameObject,new Vector3(hitScaleValue,hitScaleValue,hitScaleValue),0.1f).setOnComplete(() => LeanTween.scale(this.gameObject,tempScale,0.1f));

    }

}
