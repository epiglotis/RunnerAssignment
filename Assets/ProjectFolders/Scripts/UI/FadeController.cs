using UnityEngine;

public class FadeController : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private VoidEvent onLevelCompleted;
    [SerializeField] private VoidEvent onLevelFailed;

    private CanvasGroup fadeImage;

    private void OnEnable() 
    {
        fadeImage = GetComponent<CanvasGroup>();    
        fadeImage.alpha = 1f;
        LeanTween.alphaCanvas(fadeImage,0f,0.25f);
    }


    public void FadeIn(bool isWin)
    {
        fadeImage.alpha = 0f;
        LeanTween.alphaCanvas(fadeImage,1f,0.25f).setOnComplete(() => 
        {
            if(isWin) onLevelCompleted.Raise();
            else onLevelFailed.Raise();
        });
    }
}
