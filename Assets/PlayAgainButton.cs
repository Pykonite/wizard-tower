using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class PlayAgainButton : MonoBehaviour
{
    public string mainGameScene;
    public void OnClicked()
    {
        SceneManager.LoadScene(mainGameScene);
    }
}
