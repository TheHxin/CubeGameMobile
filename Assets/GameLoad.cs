using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameLoad : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ScoreTXT;

    private void Start()
    {
        ScoreTXT.text = PlayerPrefs.GetInt("Score").ToString();
    }
}
