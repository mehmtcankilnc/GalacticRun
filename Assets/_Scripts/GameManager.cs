using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Instance
    public static GameManager Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
    #endregion

    public float currentScore = 0f;
    public float highscore = 0f;
    public float volume = 1f;
    public bool musicOn = true;
    public bool soundOn = true;
    public float soundVolume = 1f;

    private string highscoreKey = "Highscore";

    private void Start()
    {
        LoadHighscore();
    }

    private void LoadHighscore()
    {
        highscore = PlayerPrefs.GetFloat(highscoreKey, 0f);
    }

    public void IncreaseScore(float score)
    {
        currentScore += score;
    }

    public void HoldHighscore()
    {
        if (currentScore > highscore)
        {
            highscore = currentScore;
            SaveHighscore();
        }
    }

    private void SaveHighscore()
    {
        PlayerPrefs.SetFloat(highscoreKey, highscore);
        PlayerPrefs.Save();
    }

    public void ResetScore()
    {
        currentScore = 0f;
    }

    public void ChangeMusic()
    {
        musicOn = !musicOn;
    }

    public void ChangeSound()
    {
        soundOn = !soundOn;
    }
}
