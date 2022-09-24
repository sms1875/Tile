using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinTxt : MonoBehaviour
{
    public TextMeshProUGUI MoveText;
    void Update()
    {
        MoveText.text = string.Format("{0}/{1}", GameController.instance.currentCoinCnt, GameController.instance.coinCnt);
    }
}
