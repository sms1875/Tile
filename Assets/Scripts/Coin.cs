using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    Vector3 coinPos;
    bool isUp = true;

    private void Start()
    {
        coinPos = transform.position;
    }
    void Update()
    {
        if (isUp)
        {
            transform.Translate(Vector3.up * Time.deltaTime*0.3f);
            if (transform.position.y > coinPos.y * 1.1)
                isUp = false;
        }
        else
        {
            transform.Translate(Vector3.down * Time.deltaTime * 0.3f);
            if (transform.position.y* 1.1 < coinPos.y )
                isUp = true;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player")){
            GameController.instance.coinCount++;
            Destroy(gameObject);
        }
    }
}
