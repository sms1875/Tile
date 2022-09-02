using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    Rigidbody rig;

    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    private void OnCollisionExit(Collision collision)
    {      
        rig.isKinematic = false;
            StartCoroutine(DestroyCheck());
        if (collision.transform.tag.Equals("Player")) 
        {
     
        }
    }

    IEnumerator DestroyCheck()
    {
        if(transform.position.y<-30)
            Destroy(gameObject);

        yield return new WaitForSeconds(1f);
        StartCoroutine(DestroyCheck());
    }
}
