using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{

	public static bool GameIsOver;

	public GameObject gameOverUI;
	public GameObject completeLevelUI;

	private void Start()
    {
		GameIsOver = false;
    }

    // Update is called once per frame
    void Update()
	{
		if (GameIsOver)
			return;

		if (PlayerStats.Lives <= 0)
		{
			EndGame();
		}

		//Shortcut for ending game
		if (Input.GetKeyDown("e"))
        {
			EndGame();
        }
	}

	void EndGame()
	{
		GameIsOver = true;
		gameOverUI.SetActive(true);
	}

	public void WinLevel()
	{
		Debug.Log("LEVEL WON!");
		//PlayerPrefs.SetInt("levelReached", levelToUnlock);
		//sceneFader.FadeTo(nextLevel);
		GameIsOver = true;
		completeLevelUI.SetActive(true);
	}

}