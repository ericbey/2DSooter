using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // This script will handle the game's state

    public static GameManager Instance { get; private set; }

    
    public PlayerController player;
    
    public PlayerHealth playerHealthController;
    
    public GameObject playerScoreText;
    
    public GameObject playerWonText;
    
    public int playerWinPoints;

    public bool playerWon = false;
    public bool playerDead = false;

    public int playerPoints = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(Instance);
    }

    // Start is called before the first frame update
    private void Start()
    {
        UpdateUI();
    }

    // Update is called once per frame
    private void Update()
    {
        if (playerHealthController.GetHealth() <= 0)
        {
            playerDead = true;
        }

        if (playerPoints >= playerWinPoints)
        {
            playerWon = true;
        }

        UpdateUI();
    }

    private void UpdateUI()
    {
        playerScoreText.GetComponent<Text>().text = $"{playerPoints}/{playerWinPoints}";

        if (playerWon)
        {
            playerWonText.SetActive(true);
        }
        else
        {
            playerWonText.SetActive(false);
        }
    }

    public void SetPlayerPoints(int points)
    {
        playerPoints += points;
    }

    public void SetPlayerWon(bool won)
    {
        playerWon = won;
    }

    public bool GetPlayerDead()
    {
        return playerDead;
    }

    public bool GetPlayerWon()
    {
        return playerWon;
    }
}

