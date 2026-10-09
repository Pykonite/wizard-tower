using Enemies;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNoTutorial()
    {
        SceneManager.sceneLoaded += NoTutorial;
    }

    private void NoTutorial(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= NoTutorial;
        var realter = FindAnyObjectByType<Realter>();
        Destroy(realter.gameObject);
        FindAnyObjectByType<EnemyInstancer>().SpawnEnemies();
    }

    private void Awake()
    {
        SceneManager.sceneLoaded -= NoTutorial;
        DontDestroyOnLoad(gameObject);
        
    }
}
