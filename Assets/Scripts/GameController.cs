using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public int coinCount=0;


    private void Awake()
    {
        GameController.instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(string a)
    {
        CheckObstacle.instance.cachedLineRenderer.enabled = false;
        new WaitForSeconds(4f);
        CheckObstacle.instance.cachedLineRenderer.enabled = true;
        CheckObstacle.instance.isMove = true;
    }
}
