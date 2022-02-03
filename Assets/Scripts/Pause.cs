using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

	public GameObject pauseUI;

	public string menuSceneName = "MainMenu";

	public SceneFader sceneFader;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
		{
			Toggle();
		}
	}

	public void Toggle()
	{
		pauseUI.SetActive(!pauseUI.activeSelf);

		if (pauseUI.activeSelf)
		{
			Time.timeScale = 0f;
		}
		else
		{
			Time.timeScale = 1f;
		}
	}

	public void Retry()
	{
		FindObjectOfType<AudioManager>().Play("Click");
		Toggle();
		sceneFader.FadeTo(SceneManager.GetActiveScene().name);
	}


	public void Menu()
	{
		FindObjectOfType<AudioManager>().Play("Click");
		Toggle();
		sceneFader.FadeTo(menuSceneName);

	}

}