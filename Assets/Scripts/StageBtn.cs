using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StageBtn : MonoBehaviour
{
    public int sceneNum;
    public void moveScene()
    {
        SceneManager.LoadScene(sceneNum);
    }
}