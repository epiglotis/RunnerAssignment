using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotSideMovementController : MonoBehaviour
{
    [Header ("Events")]
    [SerializeField] Vector2Event onPointerDrag;
    [Header ("GameVariables")]
    [SerializeField] BoolReference isGameStarted;
    [SerializeField] BoolReference isGameFinished;
    [Header ("Variables")]
    [SerializeField] float speed = 10;

    [Range (-10f,0f)]
    [SerializeField] float leftMovementLimit;
    [Range (0f,10f)]
    [SerializeField] float rightMovementLimit;

    private void OnEnable() {
        onPointerDrag.AddListener(SideMovementOnDrag);

    }

    private void OnDisable() {
        
        onPointerDrag.RemoveListener(SideMovementOnDrag);

    }

    void SideMovementOnDrag(Vector2 sideMovementDrag){

        if(isGameStarted.Value == false) return;
        if(isGameFinished.Value == true) return;

        Vector3 tempPos = transform.localPosition;
        tempPos.x = Mathf.Clamp((tempPos.x + (sideMovementDrag.x)), leftMovementLimit, rightMovementLimit);
        transform.localPosition = tempPos;

    }

    
}
