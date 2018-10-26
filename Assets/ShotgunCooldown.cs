using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotgunCooldown : MonoBehaviour {

    PlayerTemp player;

    public Slider cooldownSlider;

    void Awake()
    {
        player = FindObjectOfType<PlayerTemp>();
    }

    void Start()
    {
        player.shotgunFiredEvent.AddListener(StartCooldown);
        gameObject.SetActive(false);
    }

    
    void StartCooldown()
    {
        gameObject.SetActive(true);
        cooldownSlider.value = 1;
        StartCoroutine(CooldownRoutine());

    }

    IEnumerator CooldownRoutine()
    {
        float timeStarted = Time.time;

        while(Time.time - timeStarted < player.shotgunCooldown)
        {
            cooldownSlider.value = (player.shotgunCooldown - (Time.time - timeStarted)) / player.shotgunCooldown;
            yield return null;
        }

        gameObject.SetActive(false);
    }

}
