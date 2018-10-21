using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OrganHealthPanel : MonoBehaviour {


    public Slider organSlider;
    public Organ organ;

    void Awake()
    {
        organ = FindObjectOfType<Organ>();
    }
    // Use this for initialization
    void Start () {
        if (organSlider != null)
            organ.tookDamageEvent.AddListener(UpdateSlider);
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    void UpdateSlider()
    {
        organSlider.value = (float)organ.health / organ.maxHealth;
    }
}
