using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotBehaviourController : MonoBehaviour
{

    [Header ("Events")]
    [SerializeField] VoidEvent onGameStarted;
    [SerializeField] BoolEvent onIsGameFinishedSuccessfully;
    [SerializeField] VoidEvent onPlayerGotHit;
    [SerializeField] VoidEvent onGameFinished;
    [Header ("GameVariables")]
    [SerializeField] IntVariable TotalPlayerHP;
    [SerializeField] IntVariable PlayerHitPoints;
    [SerializeField] IntVariable CurrentLevelDiamondCount;
    [SerializeField] IntVariable TotalDiamondCount;
    [SerializeField] BoolVariable IsGameFinished;
    [Header ("Variables")]
    [SerializeField] LayerMask layerMask;
    
    Animator animator;

    private void OnEnable() {
        animator = GetComponent<Animator>();
        onGameStarted.AddListener(StartRunningAnim);
        animator.SetBool("IsDead",false);
        PlayerHitPoints.SetValue(TotalPlayerHP.Value);
        onPlayerGotHit.Raise();

    }

    private void OnDisable() {
        
        onGameStarted.RemoveListener(StartRunningAnim);

    }

    void InitializeRobotBehaviour(){

        PlayerHitPoints.SetValue(TotalPlayerHP.Value);
        onPlayerGotHit.Raise();
        StartRunningAnim();

    }

    void StartRunningAnim(){

        animator.SetBool("IsRunning",true);
        

    }

    private void OnTriggerEnter(Collider other) {
        
        if(other.GetComponent<ObstacleBehaviour>()){
            animator.SetTrigger("Tripped");

            PlayerHitPoints.Decrease();
            onPlayerGotHit.Raise();

            if(PlayerHitPoints.Value <= 0){
                animator.SetBool("IsDead",true);
                CurrentLevelDiamondCount.SetValue(0);
                IsGameFinished.SetValue(true);
                onIsGameFinishedSuccessfully.Raise(false);

            }

        }

        if((layerMask.value & (1 << other.transform.gameObject.layer)) > 0){

            animator.SetTrigger("GameFinished");
            IsGameFinished.SetValue(true);
            TotalDiamondCount.Increase(CurrentLevelDiamondCount.Value);
            onGameFinished.Raise();
            onIsGameFinishedSuccessfully.Raise(true);

        }

    }
}
