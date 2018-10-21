using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TookDamageEvent : UnityEvent
{

}

public class Organ : MonoBehaviour
{

    public int health;
    public int maxHealth = 25;

    public TookDamageEvent tookDamageEvent;

    void Awake()
    {
        tookDamageEvent = new TookDamageEvent();
        health = maxHealth;
    }




    public void TakeDamage()
    {
        health--;
        tookDamageEvent.Invoke();
    }


    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.GetComponent<Projectile>())
        {
            TakeDamage();
        }
    }
}
