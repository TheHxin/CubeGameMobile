using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class PlayerLogic : MonoBehaviour
{
    [SerializeField] GameObject _ScriptHolder;

    public int Score;

    private MenuLoader _menuLoader;
    
    private void Awake()
    {
        _menuLoader = _ScriptHolder.GetComponent<MenuLoader>();   
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "barrel")
        {
            _menuLoader.LoseMenu();
        }
    }
    private void Update()
    {
        if(Score == LevelGen.CheckPoints)
        {
            _menuLoader.WinMenu();
        }
    }
}
