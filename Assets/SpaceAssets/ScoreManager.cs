using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public int score;
	public Text text;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void IncreaseScore(){
		score += 1;
		text.text = score.ToString ();
	}

	public void ResetScore(){
		score = 0;
		text.text = score.ToString ();
	}


}
