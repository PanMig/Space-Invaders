using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyShip;
	private bool movingRight = true;
	public float speed = 5.0f;

	public float xmin = 1.0f;
	public float xmax = -10.0f;

	public float offset;

	// Use this for initialization
	void Start () {
		SpawnEnemies ();
		SetBoundaries ();
	}
	
	// Update is called once per frame
	void Update () {

		if (AllShipsDestroyed ()) {
			SpawnEnemies ();	
		}

		if (movingRight) {
			transform.position += Vector3.right * speed * Time.deltaTime;
			if (transform.position.x > xmax) movingRight = false;
		}
		else {
			transform.position -= Vector3.left * -speed * Time.deltaTime;
			if (transform.position.x < xmin) movingRight = true;
		}
	}

	public void SpawnEnemies(){
		foreach (Transform child  in transform) {
			GameObject enemy = Instantiate (enemyShip, child.position, Quaternion.identity);
			enemy.transform.parent = child.transform;
		}
	}

	public void SetBoundaries(){
		Camera cam = Camera.main;
		xmin = cam.ViewportToWorldPoint (new Vector3 (0, 0, 0)).x + offset;
		xmax = cam.ViewportToWorldPoint (new Vector3 (1, 1, 0)).x - offset;
	}

	public bool AllShipsDestroyed(){
		foreach (Transform child  in transform) {
			if (child.childCount > 0) {
				return false;
			}
		}
		return true;
	}
}
