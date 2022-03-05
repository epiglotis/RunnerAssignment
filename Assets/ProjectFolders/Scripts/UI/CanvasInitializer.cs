using UnityEngine;

public class CanvasInitializer : MonoBehaviour
{
    [SerializeField] private RectTransform levelCounter;
    [SerializeField] private RectTransform scoreCounter;
    [SerializeField] private RectTransform progresBar;
    [SerializeField] private RectTransform restartButton;

    public void InitializeCanvas()
    {
        levelCounter.LeanMoveY(-150,0.5f);
        scoreCounter.LeanMoveX(5f,0.5f);
        progresBar.LeanScale(Vector3.one,0.5f);
        restartButton.LeanMoveX(-50,0.5f);
    }
}