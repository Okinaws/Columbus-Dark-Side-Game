using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverMenu, player;

    private void Start()
    {
        Time.timeScale = 1f;
    }
    void Update()
    {
        if (!player.activeInHierarchy)
        {
            gameOverMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void TryAgain()
    {
        Audio.instance.ChangeMusic(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameOverMenu.SetActive(false);
    }

    public void LoadMenu()
    {
        Audio.instance.ChangeMusic(0);
        SceneManager.LoadScene("MainMenu");
    }
}
