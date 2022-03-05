using UnityEngine;

public class Initializer : MonoBehaviour
{
    [Header("Asset To Initialize")]
    [SerializeField] private SceneLoader sceneLoader;
    [SerializeField] private VariableSetter variableSetter;

    private void Start() 
    {
        sceneLoader.LoadFirstLevel();
    }
}
