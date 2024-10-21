using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverMenu : MonoBehaviour
{
    public void ReplayGame()
    {
        SceneManager.LoadScene(0);
    }
}
