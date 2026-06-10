using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(
            "GameMode"
        );
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Level()
    {
        SceneManager.LoadScene(
            "Level"
        );
    }
    public void BackMain()
    {
        SceneManager.LoadScene(
            "Main Menu"
        );
    }

    public void Level1()
    {
        SceneManager.LoadScene(
            "Level1"
        );
    }

    public void BackMode()
    {
        SceneManager.LoadScene(
            "GameMode"
        );
    }

    public void Retry()
    {
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().name
        );
    }
}