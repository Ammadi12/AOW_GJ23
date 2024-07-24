using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallButtons : MonoBehaviour
{
    public GameObject WallSpawner1;
    public GameObject WallSpawner2;

    private void Start()
    {
       
        WallSpawner1.SetActive(true);
        WallSpawner2.SetActive(false);
    }

    public void SelectWallSpawner1()
    {
        WallSpawner1.SetActive(true);
        WallSpawner2.SetActive(false);
    }

    public void SelectWallSpawner2()
    {
        WallSpawner1.SetActive(false);
        WallSpawner2.SetActive(true);
    }
}
