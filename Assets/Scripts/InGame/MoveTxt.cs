using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoveTxt : MonoBehaviour
{
    public TextMeshProUGUI MoveText;
    void Update()
    {
        MoveText.text = string.Format("{0}/{1}", GameController.instance.currentMoveCnt, GameController.instance.moveCnt);
        if (GameController.instance.currentMoveCnt * 1.5 > GameController.instance.moveCnt)
            MoveText.color = Color.red;
    }
}
