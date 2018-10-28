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
    public bool dead = false;
    public TookDamageEvent tookDamageEvent;

   
    void Awake()
    {
        tookDamageEvent = new TookDamageEvent();
        health = maxHealth;
    }


    public void Die()
    {
        foreach(GameObject go in GetComponent<PulseScript>().spawnedCells)
        {
            if (go)
            {

                Destroy(go);
            }
        }
        StartCoroutine(shrink());
        Destroy(GetComponent<PulseScript>());
        dead = true;
    }

    IEnumerator shrink()
    {
        for(int i = 0; i < 60; i++)
        {
            transform.localScale -= Vector3.one * Time.deltaTime * 10;
            yield return null;
        }
    }
    public void TakeDamage()
    {
        if (dead)
            return;

        health--;
        tookDamageEvent.Invoke();

        if(health <= 0)
        {
            Die();
        }
    }


    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.GetComponent<Projectile>())
        {
            TakeDamage();
        }
    }
}
