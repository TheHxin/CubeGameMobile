using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLogic : MonoBehaviour
{
    [SerializeField] GameObject _ScriptHolder;

    private MenuLoader _menuLoader;
    
    private void Awake()
    {
        _menuLoader = _ScriptHolder.GetComponent<MenuLoader>();   
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "exit")
        {
            _menuLoader.WinMenu();
        }
        if (collision.gameObject.tag == "barrel")
        {
            _menuLoader.LoseMenu();
        }
    }
}
