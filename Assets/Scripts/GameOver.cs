using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
	public TextMeshProUGUI roundsText;

	void Awake()
	{
		roundsText.text = PlayerStats.Rounds.ToString();
	}
	public void Retry()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
	public void Menu()
	{
		SceneManager.LoadScene("MainMenu");
	}


}
