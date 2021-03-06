﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameOverEvent : UnityEvent<bool>{


}

public class GameManager : MonoBehaviour {

	public GameOverEvent gameOverEvent;

    public GameObject[] UIElements;
    public ControlledCamera player;
	public Organ organ;

    public AudioSource mainMenuMusic;
    public AudioSource gameMusic;

	void Awake(){
		gameOverEvent = new GameOverEvent ();
		player = FindObjectOfType<ControlledCamera> ();
		organ = FindObjectOfType<Organ> ();
	}

    public void Restart()
    {
        SceneManager.LoadScene("DamenTesting");
    }

    public void StartGame()
    {
       
        player.GiveControl();
        foreach(GameObject go in UIElements)
        {
            go.SetActive(true);
        }


		player.GetComponent<PlayerTemp> ().hitByWhiteCellEvent.AddListener (CheckLoss);
		organ.tookDamageEvent.AddListener (CheckWin);

        mainMenuMusic.Stop();
        gameMusic.Play();

    }

	public void CheckLoss(WhiteBloodCell wbc){
		if (player.GetComponent<PlayerTemp> ().currentWhiteBloodCellCount > 150000) {
			gameOverEvent.Invoke (false);
		}
	}

	public void CheckWin(){
        foreach(Organ o in FindObjectsOfType<Organ>())
        {

            if (organ.health > 0)
            {
                return;
            }
        }

        gameOverEvent.Invoke(true);
    }
}
