using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private float firstStartDelay; // on first boot of the app, how long to wait till the player can start a match

    [SerializeField] private bool canStartGame;
    
    [SerializeField] private GameObject gameTitleDisplay;
    [SerializeField] private GameObject gameOverDisplay;
    [SerializeField] private GameObject startGameDisplay;

    [SerializeField] private Scoreboard scoreboard;
    [SerializeField] private TextMeshPro scoreDisplay;
    [SerializeField] private int highScore;

    private PlayerSpawner _playerSpawner;
    private void Start()
    {
        _playerSpawner = FindObjectOfType<PlayerSpawner>();
        
        gameOverDisplay.SetActive(false); // should be off by default, but just in case
        startGameDisplay.SetActive(false);
        gameTitleDisplay.SetActive(true);
        scoreboard.gameObject.SetActive(false);
        
        StartCoroutine(DoFirstStartInit());
        IEnumerator DoFirstStartInit()
        {
            yield return new WaitForSeconds(firstStartDelay);
            startGameDisplay.SetActive(true);
            highScore = PlayerPrefs.GetInt("highScore");
            scoreDisplay.text = "High Score:" + highScore;
            canStartGame = true;
        }
    }

    private void Update()
    {
        if(canStartGame && Input.GetMouseButton(0) && Input.GetMouseButton(1))
            StartGame();
        if (Input.GetMouseButtonDown(2))
            Application.Quit();
    }

    void StartGame()
    {
        FindObjectOfType<ObstacleSpawner>().canSpawn = true;
        scoreboard.gameObject.SetActive(true);
        canStartGame = false;
        _playerSpawner.SpawnPlayer();
        gameTitleDisplay.SetActive(false);
        gameOverDisplay.SetActive(false);
        startGameDisplay.SetActive(false);
        scoreboard.StartTracking();
    }
    
    public void EndGame()
    {
        scoreboard.StopTracking();
        FindObjectOfType<ObstacleSpawner>().canSpawn = false;
        highScore = scoreboard.score > highScore ? scoreboard.score : highScore;
        scoreDisplay.text = "High Score:" + highScore;
        gameOverDisplay.SetActive(true);
        startGameDisplay.SetActive(true);
        
        canStartGame = true;
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("highScore",highScore);
    }
}
