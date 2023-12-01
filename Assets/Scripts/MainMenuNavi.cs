using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuNavi : MonoBehaviour {
	[Header("Panels")]
	public GameObject mainMenu;
	public GameObject howToPlay;

	void Start() {
		BackToMenu();
	}


	public void PlayGame() {
		SceneManager.LoadScene("MainScene");
	}
	public void HowToPlay() {
		mainMenu.SetActive(false);
		howToPlay.SetActive(true);
	}
	public void BackToMenu() {
		mainMenu.SetActive(true);
		howToPlay.SetActive(false);
	}

	public void ExitGame() {
		Application.Quit();
	}
}
