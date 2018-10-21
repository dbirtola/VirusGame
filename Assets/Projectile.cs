using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float rotateSpeed = 10;
    void Update()
    {
       // transform.Rotate(Vector3.right * rotateSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.GetComponent<WhiteBloodCell>())
        {
            Destroy(col.gameObject);
            Destroy(this);
        }
    }
}
