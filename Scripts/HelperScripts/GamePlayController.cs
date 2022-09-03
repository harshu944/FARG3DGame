﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlayController : MonoBehaviour
{

    public static GamePlayController instance;

    private Text coinText, healthText, timerText;

    private int coinScore;

    [HideInInspector]
    public bool isPlayerAlive;

    public float timerTime = 99f;

    public GameObject endPanel;

    void Awake()
    {
        MakeInstance();


        coinText = GameObject.Find("CoinText").GetComponent<Text>();
        healthText = GameObject.Find("HealthText").GetComponent<Text>();
        timerText = GameObject.Find("TimerText").GetComponent<Text>();

        coinText.text = "Coin:" + coinScore;

    }

    // Start is called before the first frame update
    void Start()
    {
        isPlayerAlive = true;
        endPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        CountdownTimer();
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;

        }else if (instance != null)
        {
            Destroy(gameObject);

        }
    }

    public void CoinCollected()
    {
        coinScore++;
        coinText.text = "Coins:" + coinScore;
    }

    public void DisplayHealth(int health)
    {
        healthText.text = "Health:" + health;

    }

     void CountdownTimer()
    {
        timerTime -= Time.deltaTime;
        timerText.text = "Time:" + timerTime.ToString("F0");


        if (timerTime <= 0)
        {
            GameOver();
           
        }
    }





    public void GameOver()
    {
        endPanel.SetActive(true);
        

    }








}
