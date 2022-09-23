using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject stage;
    public GameObject[] chapterBtn;
    public GameObject[] chapterLockBtn;
    public GameObject[] Star1,Star2;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        if (DataManager.instance.isStart)
            stage.SetActive(true);
    }

    public void init()
    {
        setStage();
    }

    public void setStage()
    {
        for (int i = 0; i < chapterBtn.Length; i++)
        {
            switch (DataManager.instance.getChapterInfo(i))
            {
                case 0:
                    break;
                case 1:
                    UnLockChapter(i);
                    break;
                case 2:
                    UnLockChapter(i);
                    Star1[i].SetActive(true);
                    break;
                case 3:
                    UnLockChapter(i);
                    Star1[i].SetActive(true);
                    Star2[i].SetActive(true);
                    break;
                default:
                    break;
            }
        }
    }

    public void UnLockChapter(int i)
    {
        chapterBtn[i].SetActive(true);
        chapterLockBtn[i].SetActive(false);
    }
}
