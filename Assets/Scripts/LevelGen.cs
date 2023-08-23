using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class LevelGen : MonoBehaviour
{
    [Header("GameObjects")]
    [SerializeField] GameObject Floor;
    [SerializeField] GameObject Wall;
    [SerializeField] GameObject Barrel;
    [SerializeField] GameObject End;
    [SerializeField] GameObject Coin;

    [Header("Level Generation Setting")]
    [SerializeField] float _PlatformSize = 20f;
    [SerializeField] float _PlatformSpawnSpace = 10f;
    [SerializeField] float _BarrelYOffset = 0.75f;
    [SerializeField] float _WallXOffset;
    [SerializeField] float _CoinXOffset;
    [SerializeField] float _CoinYOffset;

    [Header("Player Spwan Setting")]
    [SerializeField] float _PlayerSpawnYOffset = 2f;

    [HideInInspector] public int CoinCount;
    [HideInInspector] public int _PlatformNumber;
    [HideInInspector] public int[] _BarrelNumber;
    [HideInInspector] public int[] _PlatformSkipChance;
    [HideInInspector] public string DifficultyLevel;

    private Vector3 _FirstPosition;
    private List<Vector3> _PlatformPosition;
    private List<GameObject> _Clones;
    private System.Random rn;

    private void Awake()
    {
        _PlatformPosition = new List<Vector3>();
        _Clones = new List<GameObject>();
        rn = new System.Random();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ReGenerateLevel();
        }
    }
    public void GenerateLevel()
    {
        GetComponent<DifficultyManager>().CalDificulty(this, DifficultyLevel);
        CoinCount = 0;

        GenerateBoarder();
        GenerateFloor();
        GenerateBarrel();
        GenerateCoin();

        var PlayerSpawner = GetComponent<PlayerSpawner>();
        var PlayerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();

        PlayerSpawner.Spawn(_FirstPosition);
        PlayerMovement.DoMove = true;
    }
    void ReGenerateLevel()
    {
        DeleteClones();
        GenerateLevel();
    }
    void DeleteClones()
    {
        _PlatformPosition.Clear();

        foreach (var clone in _Clones)
        {
            Destroy(clone);
        }
    }
    void GenerateBoarder()
    {
        for (int s = _PlatformNumber; s > 0; s--)
        {
            _Clones.Add(Instantiate(Wall, new Vector3((Wall.transform.position.x + _WallXOffset), Wall.transform.position.y + (-s * 10), 0), Wall.transform.rotation));
        }
        for (int s = _PlatformNumber; s > 0; s--)
        {
            _Clones.Add(Instantiate(Wall, new Vector3((Wall.transform.position.x - _WallXOffset), Wall.transform.position.y + (-s * 10), 0), Wall.transform.rotation));
        }
    }
    void GenerateFloor()
    {
        for (int s = _PlatformNumber; s > 0; s--)
        {
            int x = rn.Next(1, ((Convert.ToInt32(_WallXOffset) * 2) / 20) + 1);

            switch (x)
            {
                case 1:
                    _Clones.Add(Instantiate(Floor, new Vector3(-20, s * -_PlatformSpawnSpace, 0), Floor.transform.rotation));

                    if (s == 1)
                    {
                        _FirstPosition = new Vector3(-20, (s * -_PlatformSpawnSpace) + _PlayerSpawnYOffset, 0);
                    }
                    else
                    {
                        _PlatformPosition.Add(new Vector3(-20, (s * -_PlatformSpawnSpace) + _BarrelYOffset, 0));
                    }

                    break;

                case 2:
                    _Clones.Add(Instantiate(Floor, new Vector3(0, s * -_PlatformSpawnSpace, 0), Floor.transform.rotation));

                    if (s == 1)
                    {
                        _FirstPosition = new Vector3(0, (s * -_PlatformSpawnSpace) + _PlayerSpawnYOffset, 0);
                    }
                    else
                    {
                        _PlatformPosition.Add(new Vector3(0, (s * -_PlatformSpawnSpace) + _BarrelYOffset, 0));
                    }

                    break;

                case 3:
                    _Clones.Add(Instantiate(Floor, new Vector3(20, s * -_PlatformSpawnSpace, 0), Floor.transform.rotation));

                    if (s == 1)
                    {
                        _FirstPosition = new Vector3(20, (s * -_PlatformSpawnSpace) + _PlayerSpawnYOffset, 0);
                    }
                    else
                    {
                        _PlatformPosition.Add(new Vector3(20, (s * -_PlatformSpawnSpace) + _BarrelYOffset, 0));
                    }

                    break;
            }
        }

        _Clones.Add(Instantiate(End, new Vector3(0, ((_PlatformNumber + 0.5f) * -_PlatformSpawnSpace), 0), End.transform.rotation));
    }
    void GenerateBarrel()
    {
        foreach (var position in _PlatformPosition)
        {
            bool res = PlatformSkip();
            if (res == false)
            {
                int barrelNumber = rn.Next(_BarrelNumber[0], _BarrelNumber[1]);

                for (int s = barrelNumber; s > 0; s--)
                {
                    float x = _PlatformSize / barrelNumber;
                    _Clones.Add(Instantiate(Barrel, new Vector3((position.x - (_PlatformSize / 2)) + (x * (float)(Convert.ToDouble(s) - 0.5)), position.y, 0), Barrel.transform.rotation));
                }
            }
        }
    }
    void GenerateCoin()
    {
        foreach (var position in _PlatformPosition)
        {
            if (position.x == 20)
            {
                _Clones.Add(Instantiate(Coin, new Vector3((position.x + (_PlatformSize / 2)) - _CoinXOffset, (position.y - _BarrelYOffset) + _CoinYOffset, 0), Coin.transform.rotation));
                CoinCount++;
            }
            if (position.x == -20)
            {
                _Clones.Add(Instantiate(Coin, new Vector3((position.x - (_PlatformSize / 2)) + _CoinXOffset, (position.y - _BarrelYOffset) + _CoinYOffset, 0), Coin.transform.rotation));
                CoinCount++;
            }
            if (position.x == 0)
            {
                int x = rn.Next(1, 2);
                if (x == 1)
                {
                    _Clones.Add(Instantiate(Coin, new Vector3((position.x - (_PlatformSize / 2)) + _CoinXOffset, (position.y - _BarrelYOffset) + _CoinYOffset, 0), Coin.transform.rotation));
                    CoinCount++;
                }
                else
                {
                    _Clones.Add(Instantiate(Coin, new Vector3((position.x + (_PlatformSize / 2)) - _CoinXOffset, (position.y - _BarrelYOffset) + _CoinYOffset, 0), Coin.transform.rotation));
                    CoinCount++;
                }
            }
        }
    }

    bool PlatformSkip()
    {
        int x = 2;
        int res = rn.Next(_PlatformSkipChance[0], _PlatformSkipChance[1]);

        if (res == x)
        {
            return true;
        }
        if (res != x)
        {
            return false;
        }

        return false;
    }
}
