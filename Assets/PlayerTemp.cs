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


    void Awake()
    {
        hitByWhiteCellEvent = new HitByWhiteCellEvent();
    }




    public void OnHitByWhiteCell(WhiteBloodCell cell)
    {
        currentWhiteBloodCellCount++;
        hitByWhiteCellEvent.Invoke(cell);
    }
   
}
