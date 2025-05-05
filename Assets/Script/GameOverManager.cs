using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public void ShowGameOver()
    {
        SceneManager.LoadScene("GameOverScane");
    }
    public void GotoMainMenu()
    {
        SceneManager.LoadScene("MenuScane");
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("Main");
    }
}
