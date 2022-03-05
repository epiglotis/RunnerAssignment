using UnityEngine;
using UnityEngine.UI;

public class CounterController : MonoBehaviour
{
    [SerializeField] private Image progressBar;

    [Header("Events")]
    [SerializeField] private FloatEvent onScoreGained;
    [SerializeField] private FloatEvent onProgressChanged;

    [Header("Variables")]
    [SerializeField] private IntReference playerLevelCounter;

    [Header("Text Fields")]
    [SerializeField] private Text levelText;
    [SerializeField] private Text scoreText;

    private float currentScore = 0f;
    
    private void OnEnable() 
    {
        OnScoreGained(0);
        onScoreGained.AddListener(OnScoreGained);
        onProgressChanged.AddListener(OnProgressChanged);
        levelText.text = "Level " + ((int)playerLevelCounter).ToString();
    }

    private void OnDisable() 
    {
        onScoreGained.RemoveListener(OnScoreGained);    
        onProgressChanged.RemoveListener(OnProgressChanged);
    }

    private void OnScoreGained(float score)
    {
        currentScore += score;
        scoreText.text = currentScore.ToString();
    }

    private void OnProgressChanged(float progressAmount)
    {
        progressBar.fillAmount = progressAmount;
    }
}
