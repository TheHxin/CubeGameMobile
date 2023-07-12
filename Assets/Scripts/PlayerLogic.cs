using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLogic : MonoBehaviour
{
    [SerializeField] Text _text;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "exit")
        {
            _text.text = "win";
        }
        if(collision.gameObject.tag == "barrel")
        {
            _text.text = "lose";
        }
    }
}
