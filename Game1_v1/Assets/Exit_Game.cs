using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit_Game : MonoBehaviour
{
	public void ExitGame() 
	{
		Application.Quit();
		Debug.Log("Quit!");
	}
}
