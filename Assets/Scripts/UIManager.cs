using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _TextScore;

    [Header("Canvas Refrences")]
    [SerializeField] GameObject _WinCanvas;
    [SerializeField] GameObject _LoseCanvas;
    [SerializeField] GameObject _ScoreCanvas;
    [SerializeField] GameObject _DifficultySelectorCanvas;

    private PlayerLogic _Player;
    private LevelGen _LevelGen;
    private MenuLoader _MenuLoader;

    private void Awake()
    {
        _Player = GameObject.Find("Player").GetComponent<PlayerLogic>();
        _LevelGen = GetComponent<LevelGen>();
        _MenuLoader = GetComponent<MenuLoader>();
    }
    private void Start()
    {
        _DifficultySelectorCanvas.SetActive(true);
    }
    private void Update()
    {
        if (_Player.State == "win")
        {
            _ScoreCanvas.SetActive(false);
            _WinCanvas.SetActive(true);

            Time.timeScale = 0;
        }
        if (_Player.State == "lose")
        {
            _ScoreCanvas.SetActive(false);
            _LoseCanvas.SetActive(true);

            Time.timeScale = 0;
        }

        _TextScore.text = _Player.Score.ToString() + " | " + _LevelGen.CoinCount.ToString();
    }

    private IEnumerator Wait(int time)
    {
        yield return new WaitForSeconds(time);
    }

    public void Easy()
    {
        _LevelGen.DifficultyLevel = "easy";
        _LevelGen.GenerateLevel();
        _DifficultySelectorCanvas.SetActive(false);
    }
    public void Medium()
    {
        _LevelGen.DifficultyLevel = "medium";
        _LevelGen.GenerateLevel();
        _DifficultySelectorCanvas.SetActive(false);
    }
    public void Hard()
    {
        _LevelGen.DifficultyLevel = "hard";
        _LevelGen.GenerateLevel();
        _DifficultySelectorCanvas.SetActive(false);
    }
    public void Back()
    {
        //TODO: Save score and game state
        PlayerPrefs.SetInt("Score", _Player.Score);
        PlayerPrefs.Save();

        _MenuLoader.MainMenu();
    }
}
