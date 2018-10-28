using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OrganHealthPanel : MonoBehaviour {


    public Slider organSlider;
    public Organ[] organs;

    public Organ targetOrgan;

    void Awake()
    {
        //organ = FindObjectOfType<Organ>();
        organs = FindObjectsOfType<Organ>();
    }
    // Use this for initialization
    void Start()
    {
        // if (organSlider != null)
        //  organ.tookDamageEvent.AddListener(UpdateSlider);


        foreach (Organ organ in organs)
        {
            organ.tookDamageEvent.AddListener(() =>
        {

            organSlider.value = (float)organ.health / organ.maxHealth;
        }
        );
        }
    }

/*
    void UpdateSlider()
    {
        organSlider.value = (float)organ.health / organ.maxHealth;
    }

    */
}
