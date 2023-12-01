using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFlow : MonoBehaviour {
	[Header("Position Manipulation")]
	public Transform player;
	public Vector3 begPos, endPos;
	public Vector3 boxOffset, sphereOffset;

	[Header("Bullet Firing Stats")]
	public GameObject bulletPrefab;

	[Header("End Screen Panel")]
	public Canvas gameEndPanel;
	public TMP_Text mainText;
	public TMP_Text againButtonText;

	[Header("Game Statistics")]
	public float loopDuration;		// Defines how fast the environment seems to move
	public int score;
	public bool gameEnd;

	private float startTime;

	void Start() {
		Time.timeScale = 1f;
		gameEndPanel.enabled = false;
		gameEnd = false;
		startTime = Time.time;
		score = 0;
	}

	void Update() {
		ScrollMove();

		if(score >= 10) {
			gameEnd = true;
			WinEndGame();
			
		}
		if(score <= -5) {
			gameEnd = true;
			LoseEndGame();
		}
	}

	void ScrollMove() {
		Vector3 targetPos = Vector3.Lerp(begPos, endPos, (Time.time - startTime) / loopDuration);
		player.position = targetPos;

		if(player.position == endPos) {
			startTime = Time.time;		// No other modifications required for loop-over
		}

		if(Input.GetKeyDown(KeyCode.Space)) {
			Instantiate(bulletPrefab);
		}
	}

	void WinEndGame() {
		gameEndPanel.enabled = true;
		Debug.Log("Panel enabled");
		mainText.text = "You WIN!";
		againButtonText.text = "Play Again";
		Time.timeScale = 0f;
	}
	void LoseEndGame() {
		gameEndPanel.enabled = true;
		Debug.Log("Panel enabled");
		mainText.text = "You lose!";
		againButtonText.text = "Try Again";
		Time.timeScale = 0f;
	}

	public void ChangeScene(string scene) {
		SceneManager.LoadScene(scene);
	}
	public void ExitGame() {
		Application.Quit();
	}
}
