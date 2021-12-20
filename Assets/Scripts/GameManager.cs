using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{

	public static bool GameIsOver;

	public GameObject gameOverUI;

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

}