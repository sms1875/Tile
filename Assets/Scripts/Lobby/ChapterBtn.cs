using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChapterBtn : MonoBehaviour
{
    public int sceneNum;
    public void moveScene()
    {
        SceneManager.LoadScene(sceneNum);
        DataManager.instance.chapNum = sceneNum - 1;
    }
}
