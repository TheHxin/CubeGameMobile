using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _TextScore;

    private GameObject _Player;

    private void Awake()
    {
        _Player = GameObject.Find("Player");
    }
    private void Update()
    {
        
    }
}
