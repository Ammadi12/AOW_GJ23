using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ScoreManager : MonoBehaviour
{

    public Text ScoreText;
    public Text Coins;
    private static int score = 0;
    private static int coins = 0;
    public GameObject menu;
    public GameObject bullet;
    public GameObject tower;

    int required_coins_health;
    int required_coins_damage;

    int maxscore= 200;


    public CoinData coinData;

    public void Awake()
    {
        coinData = SaveSystem.Load();
        //Coins.text = coinData.totalCoins.ToString() + "x";
        coins = coinData.totalCoins;
        Coins.text = coins.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        required_coins_damage = 50;
        required_coins_health = 50;
    }

    public void AddScore(int scoring)
    {
        score += scoring;
    }

    public void AddCoins(int coin)
    {
        coins += coin;
    }
    public void UpdateScore()
    {
        Debug.Log("Updating score");
        ScoreText.text = "Score " + score;
        Coins.text = coins.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
        if (score >= maxscore) { GameOver(); }
    }

    public void GameOver()
    {
        score = 0;
        menu.SetActive(true);
        Time.timeScale = 0f;
        Debug.Log("Reaching game over part");
        coinData.totalCoins += coins;
        coinData.totalCoins = coinData.totalCoins / 2; 
        SaveSystem.Save(coinData);

    }

    public void UpgradeDamage()
    {
        if (coins > required_coins_damage)
        {
            coins -= required_coins_damage;
            bullet.GetComponent<MoveBullet>().increaseDamage(90);
            SaveSystem.Save(coinData);

        }
        else
        {
            Debug.Log("Not Sufficient Coins");
        }
    }

    public void UpgradeHealth()
    {
        if (coins > required_coins_health)
        {
            coins -= required_coins_health;
            tower.GetComponent<TowerHealth>().upgradeHealth();
        }
    }
   
}
