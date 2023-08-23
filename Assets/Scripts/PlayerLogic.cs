using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class PlayerLogic : MonoBehaviour
{
    public string State { get; set; }
    public int Score { get; set; }

    private void Awake()
    {
        State = "play";
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "barrel")
        {
            State = "lose";
        }
        if(collision.gameObject.tag == "end")
        {
            State = "win";
        }
        if(collision.gameObject.tag == "coin")
        {
            Score++;
            Destroy(collision.gameObject);
        }
    }
}
