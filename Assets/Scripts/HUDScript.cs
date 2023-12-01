using TMPro;
using UnityEngine;

public class HUDScript : MonoBehaviour {
	public TMP_Text scoreText;
	public GameFlow gf;
	
	void Update() {
		scoreText.text = gf.score.ToString();
	}
}