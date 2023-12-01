using UnityEngine;

public class TargetBehaviour : MonoBehaviour {
	// Targets will move alongwith the player
	[Header("Movement Parameters")]
	public Transform playerPos;
	public Vector3 offset;
	public float frequency;
	public float verticalRange;

	[Header("Gameplay Variables")]
	public int scoreMod;
	public GameFlow gf;

	private float startTime;

	// Start is called before the first frame update
	void Start() {
		startTime = Time.time;
	}

	// Update is called once per frame
	void Update() {
		TargetMovement();
	}

	void TargetMovement() {
		offset.y = verticalRange * Mathf.Sin((Time.time - startTime) * frequency);
		transform.position = playerPos.position + offset;
	}

	void OnCollisionEnter() {		// Only collisions will be with the bullet objects
		gf.score += scoreMod;
	}
}
