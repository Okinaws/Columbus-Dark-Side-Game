using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public static Score instance;
    public TextMeshProUGUI textScore1, textScore2;
    public int score1 = 0, score2 = 0;

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
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("Score1"))
        {
            textScore1.text = "BEST SCORE: " + PlayerPrefs.GetInt("Score1");
        }
        if (PlayerPrefs.HasKey("Score2"))
        {
            textScore2.text = "BEST SCORE: " + PlayerPrefs.GetInt("Score2");
        }
    }

    public void ResetScore()
    {
        PlayerPrefs.DeleteKey("Score1");
        PlayerPrefs.DeleteKey("Score2");
        textScore1.text = "BEST SCORE: ";
        textScore2.text = "BEST SCORE: ";
    }
}