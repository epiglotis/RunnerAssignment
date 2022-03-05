using UnityEngine;

public class EndGameController : MonoBehaviour
{
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;

    [Header("Events")]
    [SerializeField] private BoolEvent onIsGameFinishedSuccessfully;
    
    private void OnEnable() 
    {
        onIsGameFinishedSuccessfully.AddListener(OnGameFinished);
    }

    private void OnDisable() 
    {
        onIsGameFinishedSuccessfully.RemoveListener(OnGameFinished);
    }

    private void OnGameFinished(bool isSuccessfully)
    {
        if(isSuccessfully)
        {
            winPanel.SetActive(true);
        }
        else
        {
            losePanel.SetActive(true);
        }
    }
}
