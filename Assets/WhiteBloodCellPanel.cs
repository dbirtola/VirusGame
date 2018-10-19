using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WhiteBloodCellPanel : MonoBehaviour {

    public Text bloodCellCountText;
    PlayerTemp playerTemp;

    void Awake()
    {
        playerTemp = FindObjectOfType<PlayerTemp>();
    }

    void Start()
    {
        playerTemp.hitByWhiteCellEvent.AddListener((WhiteBloodCell wbc) => { bloodCellCountText.text = playerTemp.currentWhiteBloodCellCount.ToString(); });
    }
}
