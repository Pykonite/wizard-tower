using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgainButton : MonoBehaviour
{
    public string mainGameScene;
    public void OnClicked()
    {
        if (mainGameScene == "MainGame" && SceneManager.GetActiveScene().name == "GameOver")
        {
            FindAnyObjectByType<SceneLoader>().LoadNoTutorial();
        }
        SceneManager.LoadScene(mainGameScene);
    }
}
