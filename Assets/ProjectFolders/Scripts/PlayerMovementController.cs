using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [Header("GameVariables")]
    [SerializeField] BoolReference isGameStarted;

    [Header ("Variables")]
    [SerializeField] float speed = 10;

    void FixedUpdate()
    {
        if(isGameStarted.Value == false) return;
        
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

    }
}
