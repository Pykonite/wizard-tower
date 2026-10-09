using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgainButton : MonoBehaviour
{
    public string mainGameScene;
    public void OnClicked()
    {
        SceneManager.LoadScene(mainGameScene);
    }
}
