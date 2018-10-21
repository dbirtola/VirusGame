using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject[] UIElements;
    public ControlledCamera player;


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
    }
}
