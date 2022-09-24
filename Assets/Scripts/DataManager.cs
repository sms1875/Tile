using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    public bool isStart = false;
    public int chapNum;

    private void Awake()
    { 
        instance = this;
        var obj = FindObjectsOfType<DataManager>();
        if (obj.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
       
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getChapterInfo(int i)
    {
        return PlayerPrefs.GetInt("chapter" + i);
    }

    public void setChapterInfo(int i,int result)
    {
        PlayerPrefs.SetInt("chapter" + i,result);
    }

    public void setChapterMission()
    {
        switch (chapNum)
        {
            case 1:
                GameController.instance.coinCnt = 2;
                GameController.instance.moveCnt = 20;
                break;
            case 2:

                break;
            case 3:

                break;
        }
    }
}
