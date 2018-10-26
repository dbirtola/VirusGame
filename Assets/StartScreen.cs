using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Video;

public class StartScreen : MonoBehaviour {
    VideoPlayer vp;
	// Use this for initialization
	void Start () {
        
        GameObject camera = FindObjectOfType<Camera>().gameObject;
        vp =camera.AddComponent<VideoPlayer>();
        vp.playOnAwake = true;
        vp.renderMode = VideoRenderMode.CameraNearPlane;
        vp.url = "Assets/Virus_Blue_TitleScreen.mp4";


    
	}
	
    public void StopVide()
    {
        Destroy(vp);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
