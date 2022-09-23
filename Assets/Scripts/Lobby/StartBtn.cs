using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBtn : MonoBehaviour
{
    public void onClick()
    {
        DataManager.instance.isStart = true;
        UIManager.instance.setStage();
    }
}
