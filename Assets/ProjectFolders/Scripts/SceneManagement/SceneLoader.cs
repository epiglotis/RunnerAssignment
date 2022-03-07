using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "NewSceneLoader", menuName = "SceneManagement/SceneLoader")]
public class SceneLoader : GameAsset
{
    [Header("Events")]
    [SerializeField] private VoidEvent onLevelFailed;
    [SerializeField] private VoidEvent onLevelCompleted;

    [Header("Variables")]
    [SerializeField] private IntVariable willBeLaunchedLevelCount;
    [SerializeField] private IntVariable playerLevelCount;

    private void OnEnable() 
    {
        onLevelCompleted.AddListener(OnLevelCompleted);
        onLevelFailed.AddListener(OnLevelFailed);
    }

    private void OnDisable() 
    {
        onLevelCompleted.RemoveListener(OnLevelCompleted);
        onLevelFailed.RemoveListener(OnLevelFailed);
    }

    public void LoadFirstLevel()
    {
        playerLevelCount.SetValue(PlayerPrefs.GetInt("PlayerLevel",1));
        if(playerLevelCount.Value <= 2) willBeLaunchedLevelCount.SetValue(playerLevelCount.Value + 1);
        else willBeLaunchedLevelCount.SetValue(Random.Range(1,3));
        SceneManager.LoadSceneAsync(willBeLaunchedLevelCount.Value, LoadSceneMode.Single);
    }

    private void OnLevelFailed()
    {
        LoadCurrentLevel();
    }

    public void OnLevelCompleted()
    {

        if(playerLevelCount.Value >= 2) LoadRandomLevel();
        else LoadNextLevel();
    }

    private void LoadNextLevel()
    {
        playerLevelCount.Increase(1);
        PlayerPrefs.SetInt("PlayerLevel",playerLevelCount.Value);
        SceneManager.LoadSceneAsync(willBeLaunchedLevelCount.Value, LoadSceneMode.Single);
    }

    public void LoadCurrentLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    private void LoadRandomLevel()
    {
        int value = Random.Range(1,3);
        willBeLaunchedLevelCount.SetValue(value);
        playerLevelCount.Increase(1);
        PlayerPrefs.SetInt("PlayerLevel",playerLevelCount.Value);
        SceneManager.LoadSceneAsync(willBeLaunchedLevelCount.Value, LoadSceneMode.Single);
    }
}
