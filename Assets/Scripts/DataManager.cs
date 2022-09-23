using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    public bool isStart = false;

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

}
