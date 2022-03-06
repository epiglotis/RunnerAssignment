using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishParticlePoolController : MonoBehaviour
{
    [Header("Game Events")]
    [SerializeField] VoidEvent onGameFinished;
    [Header ("Game Variables")]
    [SerializeField] BoolReference isGameFinished;
    [SerializeField] Pooler particlePooler;
    private void OnEnable() {
        
        onGameFinished.AddListener(StartSpawningParticle);

    }

    private void OnDisable() {
        
        particlePooler.Clear();
        onGameFinished.RemoveListener(StartSpawningParticle);

    }

    void StartSpawningParticle(){

        InvokeRepeating("ParticleSpawner",0f,0.5f);

    }
    void ParticleSpawner(){
        
        Vector3 particlePosition = transform.position + (Random.insideUnitSphere * 5);

        particlePooler.Spawn(particlePosition,Quaternion.identity);

    }
}
