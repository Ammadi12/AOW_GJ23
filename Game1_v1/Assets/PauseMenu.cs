using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PauseMenu : MonoBehaviour
{
    public GameObject pausemenu;
    public GameObject upgrade;
    public Text Coins;
    

    public GameObject bullet;

     void Start()
    {
         upgrade.SetActive(true);
       
        Time.timeScale = 0f;
    }

    public void Pause()
    {
        pausemenu.SetActive(true);
        Time.timeScale = 0f;

    }

    public void Resume()
    {
        pausemenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Play()
    {
        //INCREMENT LEVEL BY 1
        upgrade.SetActive(false);
//        pausemenu.SetActive(false);
        Time .timeScale = 1f;   
    }

    
    
    private void Update()
    {
       
    }
}
