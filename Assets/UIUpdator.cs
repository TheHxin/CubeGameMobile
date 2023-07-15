using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIUpdator : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _TextScore;

    [SerializeField] GameObject _Player;

    private PlayerLogic _PlayerLogic;

    private void Awake()
    {
        _PlayerLogic = _Player.GetComponent<PlayerLogic>();
    }
    private void Update()
    {
        _TextScore.text = _PlayerLogic.Score.ToString() + "|" + LevelGen.CheckPoints.ToString();
    }
}
