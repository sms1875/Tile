using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public int coinCnt = 0;
    public int moveCnt = 0;
    public float MissionMinute,MissionSecond;

    public int currentMoveCnt = 0;
    public int currentCoinCnt = 0;
    private void Awake()
    {
        GameController.instance = this;
    }
    void Start()
    {
        init();
    }
    public void init()
    {
       // DataManager.instance.setChapterMission();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
