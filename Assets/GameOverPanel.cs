using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameOverPanel : MonoBehaviour {

	public Text endText;


	void Start(){
		FindObjectOfType<GameManager> ().gameOverEvent.AddListener (EndGame);
		gameObject.SetActive (false);
	}

	public void EndGame(bool victory){


		if (victory) {
			endText.text = "The organ has been defeated!";
		} else {
			endText.text = "You took too much damage!";
		}

		FindObjectOfType<ControlledCamera> ().hasControl = false;
		gameObject.SetActive(true);

	}
}
