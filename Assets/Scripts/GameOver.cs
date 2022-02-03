using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
	public string menuSceneName = "MainMenu";

	public SceneFader sceneFader;

	void OnEnable()
	{
		FindObjectOfType<AudioManager>().Play("Lost");
	}

	public void Retry()
	{
		FindObjectOfType<AudioManager>().Play("Click");
		sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }
	
	public void Menu()
	{
		FindObjectOfType<AudioManager>().Play("Click");
		sceneFader.FadeTo(menuSceneName);
	}


}
