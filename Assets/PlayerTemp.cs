using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;


public class HitByWhiteCellEvent : UnityEvent<WhiteBloodCell>
{

}

public class PlayerTemp : MonoBehaviour {

    public HitByWhiteCellEvent hitByWhiteCellEvent;

    public int currentWhiteBloodCellCount = 0;

    public GameObject projectile;
    public float projectileSpeed = 2;

    void Awake()
    {
        hitByWhiteCellEvent = new HitByWhiteCellEvent();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
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
   
}
