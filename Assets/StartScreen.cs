using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class StartScreen : MonoBehaviour {
    VideoPlayer vp;

    public GameObject backToMenuButton;


	// Use this for initialization
	void Start () {
        
        GameObject camera = FindObjectOfType<Camera>().gameObject;
        vp =camera.AddComponent<VideoPlayer>();
        vp.playOnAwake = true;
        vp.renderMode = VideoRenderMode.CameraNearPlane;
        ShowTitle();


    
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            FindObjectOfType<GameManager>().StartGame();
            StopVide();
            gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ShowTutorial();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ShowControls();
        }
    }

    public void ShowControls()
    {
        vp.url = "Assets/Virus_Controls.mp4";
        backToMenuButton.gameObject.SetActive(true);
    }

    public void ShowTitle()
    {
        vp.url = "Assets/Virus_Blue_TitleScreen.mp4";
        backToMenuButton.gameObject.SetActive(false);
    }

    public void ShowTutorial()
    {
        vp.url = "Assets/Virus_Tutorial.mp4";
        backToMenuButton.gameObject.SetActive(true);
    }
	
    public void StopVide()
    {
        Destroy(vp);
    }

}
