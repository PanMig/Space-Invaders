using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 10.0f;

	public float xmin;
	public float xmax;

	public GameObject playerLazer;
	public int lazerSpeed;

	public float offset;

	private ScoreManager scoreManager;

	// Use this for initialization
	void Start () {
		SetBoundaries ();
		scoreManager = GameObject.FindGameObjectWithTag ("scoreManager").GetComponent<ScoreManager> ();
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.Space)){
			GameObject lazer =  Instantiate (playerLazer, transform.position, Quaternion.identity);
			lazer.GetComponent<Rigidbody2D> ().velocity = Vector3.up * lazerSpeed;
		}

		if (Input.GetKey (KeyCode.D)) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		} 
		else if (Input.GetKey (KeyCode.A)) {
			transform.position -= Vector3.left  * -speed * Time.deltaTime;
		}

		float xpos = Mathf.Clamp (transform.position.x, xmin, xmax);

		transform.position = new Vector3 (xpos, transform.position.y, transform.position.z);

	}

	public void SetBoundaries(){
		Camera cam = Camera.main;
		xmin = cam.ViewportToWorldPoint (new Vector3 (0, 0, 0)).x + offset;
		xmax = cam.ViewportToWorldPoint (new Vector3 (1, 1, 0)).x - offset;
	}

	public void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "enemyLazer") {
			ResetPlayer ();
		}
	}

	public void ResetPlayer(){
		transform.position = new Vector3 (0, transform.position.y, transform.position.z);
		scoreManager.ResetScore ();

	}
}
