using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;

public class End : MonoBehaviour
{
    public GameObject eButton, results;
    public TextMeshProUGUI coins, coinsRes, hpRes, score;
    public Hp hp;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && eButton.activeInHierarchy)
        {
            results.SetActive(true);
            Time.timeScale = 0f;
            int scoreVal = CalculateScore();

            coinsRes.text = "COLLECTED COINS: " + coins.text;
            hpRes.text = "SAVED HP: " + hp.HP;
            score.text = "SCORE: " + scoreVal;

            if (SceneManager.GetActiveScene().buildIndex == 1 && PlayerPrefs.GetInt("Score1") < scoreVal)
            {
                PlayerPrefs.SetInt("Score1", scoreVal);
            }
            else if (PlayerPrefs.GetInt("Score2") < scoreVal)
            {
                PlayerPrefs.SetInt("Score2", scoreVal);
            }

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("Player"))
        {
            eButton.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        eButton.SetActive(false);
    }
    public void TryAgain()
    {
        Audio.instance.ChangeMusic(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        results.SetActive(false);
    }

    public void LoadMenu()
    {
        Audio.instance.ChangeMusic(0);
        SceneManager.LoadScene("MainMenu");
    }
    private int CalculateScore()
    {
        return (Convert.ToInt32(coins.text) * 100) + (Convert.ToInt32(hp.HP) * 5);
    }
}
