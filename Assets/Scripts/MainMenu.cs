using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu, levels;
    public Slider slider;

    static bool openLevels = false;
    private void Start()
    {
        Time.timeScale = 1f;
        if (openLevels)
        {
            levels.SetActive(true);
        }
        else 
        {
            mainMenu.SetActive(true);
        }

        slider.value = Audio.instance.currentMusic.volume;
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void SetMusicVolume(float vol)
    {
        Audio.instance.SetVolume(vol);
    }

    public void PlayLevel(int levelNum)
    {
        openLevels = true;
        switch (levelNum)
        {
            case 1:
                Audio.instance.ChangeMusic(1);
                SceneManager.LoadScene("Level1");
                break;
            case 2:
                Audio.instance.ChangeMusic(2);
                SceneManager.LoadScene("Level2");
                break;
        }
    }
}
