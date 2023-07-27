using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class PlayerLogic : MonoBehaviour
{
    [SerializeField] GameObject _ScriptHolder;

    private MenuLoader _menuLoader;
    private LevelGen _levelGen;
    private bool _flagFirst;
    public int Score;
    
    private void Awake()
    {
        Score = 0;
        _flagFirst = true;

        _menuLoader = _ScriptHolder.GetComponent<MenuLoader>();
        _levelGen = _ScriptHolder.GetComponent<LevelGen>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "barrel")
        {
            _menuLoader.LoseMenu();
        }
        if(collision.gameObject.tag == "floor")
        {
            if(_flagFirst == false)
            {
                Score++;
            }
            else
            {
                _flagFirst = false;
            }
        }
    }
    private void Update()
    {
        if(Score == LevelGen.Platforms)
        {
            _menuLoader.WinMenu();
        }
    }
}
