using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "NewSceneLoader", menuName = "SceneManagement/SceneLoader")]
public class SceneLoader : GameAsset
{
    [Header("Events")]
    [SerializeField] private VoidEvent onLevelFailed;
    [SerializeField] private VoidEvent onLevelCompleted;

    [Header("Variables")]
    [SerializeField] private IntVariable elephantLevelCount;
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
        if(playerLevelCount.Value <= 5) elephantLevelCount.SetValue(playerLevelCount.Value + 1);
        else elephantLevelCount.SetValue(Random.Range(2,6));
        SceneManager.LoadSceneAsync(elephantLevelCount.Value, LoadSceneMode.Single);
    }

    private void OnLevelFailed()
    {
        LoadCurrentLevel();
    }

    public void OnLevelCompleted()
    {

        if(playerLevelCount.Value >= 5) LoadRandomLevel();
        else LoadNextLevel();
    }

    private void LoadNextLevel()
    {
        elephantLevelCount.Increase(1);
        playerLevelCount.Increase(1);
        PlayerPrefs.SetInt("PlayerLevel",playerLevelCount.Value);
        SceneManager.LoadSceneAsync(elephantLevelCount.Value, LoadSceneMode.Single);
    }

    public void LoadCurrentLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    private void LoadRandomLevel()
    {
        int value = Random.Range(2,6);
        elephantLevelCount.SetValue(value);
        playerLevelCount.Increase(1);
        PlayerPrefs.SetInt("PlayerLevel",playerLevelCount.Value);
        SceneManager.LoadSceneAsync(elephantLevelCount.Value, LoadSceneMode.Single);
    }
}
