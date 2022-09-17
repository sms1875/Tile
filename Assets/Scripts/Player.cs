using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    #region 이동 관련
    Rigidbody rig;
    float Horizontal = 2.3f;
    float Vertical = 2.5f;
    Vector3 dir;
    public bool isMove;
    Vector3 mousePos;
    #endregion

    Camera mainCamera;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        rig = GetComponent<Rigidbody>();
    }


    public void Update()
    {
        if (isMove)
        {
            if (Input.GetMouseButton(0))
            {
                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    //마우스 클릭 위치
                    Vector3 targetPos = new Vector3(hit.point.x - rig.position.x, 0f, hit.point.z - rig.position.z); //방향 구하기

                    if (Vector3.Distance(rig.position, targetPos) < 2)
                    {


                        Debug.Log(targetPos);
                        Debug.Log(Vector3.Distance(rig.position, targetPos));
                    }


                    dir = targetPos.normalized; //방향 설정
                }
            }
        }
    }
    public float speed = 5f;

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