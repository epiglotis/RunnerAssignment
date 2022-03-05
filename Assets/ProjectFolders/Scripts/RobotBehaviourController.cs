using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotBehaviourController : MonoBehaviour
{

    [Header ("Events")]
    [SerializeField] VoidEvent onGameStarted;
    [Header ("GameVariables")]
    [SerializeField] IntVariable PlayerHitPoints;
    
    Animator animator;

    private void OnEnable() {
        animator = GetComponent<Animator>();
        onGameStarted.AddListener(StartRunningAnim);

    }

    private void OnDisable() {
        
        onGameStarted.RemoveListener(StartRunningAnim);

    }

    void StartRunningAnim(){

        animator.SetBool("IsRunning",true);

    }
}
