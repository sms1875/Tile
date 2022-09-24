using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TileType
{
    Player,
    Empty,
    Tile,
    Bridge,
    Obstacle,
}

public class MapManager : MonoBehaviour
{
    public TileType[,] _tile;
    public int _size;
    public int playerStartingPoint_X, playerStartingPoint_Y;
    private int playerNowPoint_X, playerNowPoint_Y;
    public GameObject[] Tile;
    public Dictionary<string, string> TileDic = new Dictionary<string, string>();
    public Transform Player;
    bool isPlayerReady = false;

    public bool isMove = false;

    void Start()
    {
        Initialize(_size);
    }

    public Camera mainCamera;
    Vector3 mousePos = Vector3.zero;

    public void Initialize(int size)
    {
        _tile = new TileType[size, size];
        _size = size;
        string tilePos;

        int tileNum = 0;

        for (int y = 0; y < _size; y++)
        {
            for (int x = 0; x < _size; x++)
            {
                switch (Tile[tileNum].tag)
                {
                    case "Tile":
                        _tile[x, y] = TileType.Tile;
                        break;
                    case "Bridge":
                        _tile[x, y] = TileType.Bridge;
                        break;
                    case "Obstacle":
                        _tile[x, y] = TileType.Obstacle;
                        break;
                    case "Empty":
                        _tile[x, y] = TileType.Empty;
                        break;
                }

                tilePos = string.Format("{0},{1}", x, y);
                TileDic.Add(Tile[tileNum++].name, tilePos);
            }
        }

        playerNowPoint_X = playerStartingPoint_X;
        playerNowPoint_Y = playerStartingPoint_Y;

        _tile[playerStartingPoint_X, playerStartingPoint_Y] = TileType.Player;

    }

    void Update()
    {
        if (isMove) return;
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            int layerMask = 1 << LayerMask.NameToLayer("Water");
            layerMask = ~layerMask;
            if (Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity, layerMask))
            {
                if (raycastHit.transform.tag.Equals("Player"))
                {
                    Debug.Log("이동 준비 완료");
                    isPlayerReady = true;
                }

                else if (isPlayerReady == true)
                {
                    string xy;
                    TileDic.TryGetValue(raycastHit.transform.name, out xy);

                    string[] a = xy.Split(',');

                    int x = int.Parse(a[0].ToString());
                    int y = int.Parse(a[1].ToString());
                    PlayerMove(x, y);
                    isPlayerReady = false;
                    Debug.Log("이동 준비 해제");
                }
            }
        }

    }

    public void PlayerMove(int x, int y)
    {
        if ((x == playerNowPoint_X + 1 && y == playerNowPoint_Y) || (x == playerNowPoint_X - 1 && y == playerNowPoint_Y ) || (x == playerNowPoint_X  && y == playerNowPoint_Y + 1 )|| (y == playerNowPoint_Y - 1 || x == playerNowPoint_X ))
        {
            switch (_tile[x, y])
            {
                case TileType.Tile:
                    StartCoroutine(MovingPlayer(x, y));
                    break;
                case TileType.Bridge:
                    StartCoroutine(MovingPlayer(x, y));
                    break;
                case TileType.Obstacle:
                    Debug.Log("벽이 있는 타일은 갈 수 없습니다.");
                    break;
                case TileType.Empty:
                    Debug.Log("벽이 있는 타일은 갈 수 없습니다.");
                    break;
            }
        }
        else
        {
            Debug.Log("해당 칸은 이동 범위가 아니므로 이동할 수 없습니다.");
        }
    }

    IEnumerator MovingPlayer(int x, int y)
    {
        isMove = true;
        GameController.instance.currentMoveCnt++;

        _tile[playerNowPoint_X, playerNowPoint_Y] = TileType.Tile;

       if(_tile[playerNowPoint_X, playerNowPoint_Y]==TileType.Bridge)
            _tile[playerNowPoint_X, playerNowPoint_Y] = TileType.Empty;



        //플레이어 애니메이션으로 천천히 이동시키기
        Player.position += new Vector3((x - playerNowPoint_X) * 2.5f, 0, (y - playerNowPoint_Y) * 2.3f);
        playerNowPoint_X = x;
        playerNowPoint_Y = y;

        _tile[playerNowPoint_X, playerNowPoint_Y] = TileType.Player;

        //플레이어 이동에 걸리는 시간
        yield return new WaitForSeconds(1f);

        //--몬스터 이동 함수--


        //몬스터 이동에 걸리는 시간
        yield return new WaitForSeconds(1f);


        //이동 활성화
        isMove = false;

    }


}
