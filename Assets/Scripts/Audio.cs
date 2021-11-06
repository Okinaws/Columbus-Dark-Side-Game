using UnityEngine;

public class Audio : MonoBehaviour
{
    public static Audio instance;
    public AudioSource menu, level1, level2, currentMusic;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        currentMusic.Play();
    }

    public void SetVolume(float vol)
    {
        instance.menu.GetComponent<AudioSource>().volume = vol;
        instance.level1.GetComponent<AudioSource>().volume = vol;
        instance.level2.GetComponent<AudioSource>().volume = vol;
    }

    public void ChangeMusic(int id)
    {
        currentMusic.Stop();
        switch (id)
        {
            case 0:
                currentMusic = menu;
                break;
            case 1:
                currentMusic = level1;
                break;
            case 2:
                currentMusic = level2;
                break;
        }
        currentMusic.Play();
    }
}
