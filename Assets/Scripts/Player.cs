using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    #region �̵� ����
    Rigidbody rig;
    float Horizontal = 2.3f;
    float Vertical = 2.5f;
    Vector3 dir;
    public bool isMove;
    Vector3 mousePos;
    #endregion

    Camera mainCamera;
    public CheckObstacle[] checkObstacle;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        rig = GetComponent<Rigidbody>();
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }


    public void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            falseLineRender();
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            falseLineRender();
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            falseLineRender();
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            falseLineRender();
            transform.Translate(0, 0, -speed * Time.deltaTime);
        }
        /*
        else
            for (int i = 0; i < checkObstacle.Length; i++)
            {
                checkObstacle[i].cachedLineRenderer.enabled = true;
            }

        */
        if (isMove)
        {
            if (Input.GetMouseButton(0))
            {
                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    //���콺 Ŭ�� ��ġ
                    Vector3 targetPos = new Vector3(hit.point.x - rig.position.x, 0f, hit.point.z - rig.position.z); //���� ���ϱ�

                    if (Vector3.Distance(rig.position, targetPos) < 2)
                    {

                        falseLineRender();


                        Debug.Log(targetPos);
                        Debug.Log(Vector3.Distance(rig.position, targetPos));
                    }


                    dir = targetPos.normalized; //���� ����
                }
            }
        }
    }
    public float speed = 5f;


    public void falseLineRender()
    {
        //ȭ��ǥ ��Ȱ��ȭ
        for (int i = 0; i < checkObstacle.Length; i++)
        {
            checkObstacle[i].cachedLineRenderer.enabled = false;
        }
    }


    public void Move(string direction)
    {
        Debug.Log("test" + direction);



        dir = Vector3.zero;

        switch (direction)
        {
            case "foward":
                dir.z = Horizontal;
               
                break;
            case "right":
                dir.x = Vertical;
                break;
            case "left":
                dir.x = -Vertical;
                break;
            case "back":
                dir.z = -Horizontal;
                break;
        }


    }
    


}
/*

if (Input.GetMouseButtonUp(0))
{
    Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

    if (Physics.Raycast(ray, out RaycastHit raycastHit))
    {

        if (raycastHit.transform.name.Equals("Fox"))
        {
            mousePos = raycastHit.point;

            if (Vector3.Distance(transform.position, mousePos) < 2f)
            {
                Move(transform.name);

            }

        }

    }
}*/