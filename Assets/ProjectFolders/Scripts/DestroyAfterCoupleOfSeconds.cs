using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterCoupleOfSeconds : MonoBehaviour
{
    [SerializeField] float time = 1f;
    
    private void OnEnable() {
        
        Invoke("DestroyGameObject",time);

    }

    void DestroyGameObject(){

        Destroy(this.gameObject);

    }

}
