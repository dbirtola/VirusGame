using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This is seperate from the main white blood cell so we can use two colliders

public class WhiteBloodCellAttack : MonoBehaviour {

	public void OnTriggerEnter(Collider coll)
    {

        if (coll.gameObject.GetComponent<PlayerTemp>())
        {
            coll.gameObject.GetComponent<PlayerTemp>().OnHitByWhiteCell(transform.parent.GetComponent<WhiteBloodCell>());
            Destroy(transform.parent.gameObject);
        }
    }
}
