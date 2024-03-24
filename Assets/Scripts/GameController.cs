using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public bool isEndGame;
    bool isStartFirstTime = true;
    int gameScore = 0;
    AudioSource bgAudioSource;
    [SerializeField] AudioClip bgClip;
    [SerializeField] AudioClip bg50Clip;

    [SerializeField] TMP_Text textScore;
    [SerializeField] GameObject pnlEndGame;
    [SerializeField] TMP_Text textEndScore;
    [SerializeField] Button btnRestart;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        isStartFirstTime = true;
        isEndGame = false;
        pnlEndGame.SetActive(false);
        // Background Music
        bgAudioSource = gameObject.GetComponent<AudioSource>();
        bgAudioSource.clip = bgClip;
        bgAudioSource.loop = true;
        bgAudioSource.volume = 0.1f;
        bgAudioSource.Play();

    }

    // Update is called once per frame
    void Update()
    {
        if (isEndGame)
        {
            if (Input.GetMouseButtonDown(0) && isStartFirstTime)
            {
                StartGame();
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                Time.timeScale = 1;
            }
        }

        if (gameScore >= 50)
        {
            bgAudioSource.clip = bg50Clip;
            bgAudioSource.volume = 0.5f;
            if (!bgAudioSource.isPlaying)
            {
                bgAudioSource.Play();
            }
        }
    }

    public void GetScore()
    {
        gameScore++;
        textScore.text = "Score: " + gameScore;
    }
    void StartGame()
    {
        SceneManager.LoadScene(0);
    }
    public void Restart()
    {
        StartGame();
    }

    public void EndGame()
    {
        isEndGame = true;
        isStartFirstTime = false;
        Time.timeScale = 0;
        bgAudioSource.Stop();
        pnlEndGame.SetActive(true);
        textEndScore.text = "Your score: " + gameScore.ToString();
    }

}
