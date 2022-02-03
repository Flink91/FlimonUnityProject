using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLevel : MonoBehaviour
{

	public string menuSceneName = "MainMenu";

	public string nextLevel = "Level02";
	public int levelToUnlock = 2;

	public SceneFader sceneFader;

	void OnEnable()
	{
		FindObjectOfType<AudioManager>().Play("Complete");
		FindObjectOfType<AudioManager>().StopPlaying("Music1");
	}

	public void Continue()
	{
		FindObjectOfType<AudioManager>().Play("Click");
		PlayerPrefs.SetInt("levelReached", levelToUnlock);
		sceneFader.FadeTo(nextLevel);
	}

	public void Menu()
	{
		FindObjectOfType<AudioManager>().Play("Click");
		sceneFader.FadeTo(menuSceneName);
	}

}