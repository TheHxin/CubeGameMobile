using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerLogic>().Score = collision.gameObject.GetComponent<PlayerLogic>().Score + 1;
            Destroy(this);
        }
    }
}
