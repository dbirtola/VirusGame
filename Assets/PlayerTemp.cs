using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;


public class HitByWhiteCellEvent : UnityEvent<WhiteBloodCell>
{

}


public class PlayerTemp : MonoBehaviour {

    public HitByWhiteCellEvent hitByWhiteCellEvent;
    public UnityEvent shotgunFiredEvent;

    public int currentWhiteBloodCellCount = 0;

   
    public GameObject projectile;
    public float projectileSpeed = 2;

    public float shotgunLastFired = 0;
    public float shotgunCooldown = 3;

    void Awake()
    {
        hitByWhiteCellEvent = new HitByWhiteCellEvent();
        shotgunFiredEvent = new UnityEvent();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        if (Input.GetMouseButtonDown(1))
        {
            if(Time.time - shotgunLastFired > shotgunCooldown)
            {

                ShotGunBlast();
                shotgunLastFired = Time.time;
                shotgunFiredEvent.Invoke();
            }
        }
    }



    public void OnHitByWhiteCell(WhiteBloodCell cell)
    {
        currentWhiteBloodCellCount++;
        hitByWhiteCellEvent.Invoke(cell);

        if(currentWhiteBloodCellCount >= 15)
        {
            FindObjectOfType<GameManager>().Restart();
        }
    }

    public void Shoot()
    {
        Vector3 focusLocation = transform.position + transform.forward.normalized * 50;
        var go = Instantiate(projectile, transform.position, transform.rotation);
        Physics.IgnoreCollision(go.GetComponent<Collider>(), GetComponent<Collider>());
        go.GetComponent<Rigidbody>().velocity = (focusLocation - go.transform.position).normalized * projectileSpeed;
        Destroy(go, 3);
    }
   

    public void ShotGunBlast()
    {

        for(int i = 0; i < 10; i++)
        {
            Vector3 focusLocation = transform.position + transform.forward.normalized * 50;
            //
            focusLocation += Random.onUnitSphere * 10;
            //focusLocation += transform.right * Random.Range(-5, 5f);
            //focusLocation += transform.up * Random.Range(-5, 5f);//new Vector3(Random.Range(-1f, 1), Random.Range(-1f, 1), Random.Range(-1f, 1)) * 10;
            var go = Instantiate(projectile, transform.position, transform.rotation);
            Physics.IgnoreCollision(go.GetComponent<Collider>(), GetComponent<Collider>());
            go.GetComponent<Rigidbody>().velocity = (focusLocation - go.transform.position).normalized * projectileSpeed;
            Destroy(go, 3);
        }
    }
}
