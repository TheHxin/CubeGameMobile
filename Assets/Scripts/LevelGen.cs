using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class LevelGen : MonoBehaviour
{
    [SerializeField] GameObject Floor;
    [SerializeField] GameObject Wall;
    [SerializeField] GameObject Barrel;
    [SerializeField] GameObject CheckPoint;

    [SerializeField] float _PlayerSpawnYOffset = 2f;

    [SerializeField] float _PlatformSize = 20f;
    [SerializeField] float _PlatformSpawnSpace = 10f;
    [SerializeField] float _WallXOffset;
    [SerializeField] float _CheckPointXOffset = 1f;
    [SerializeField] float _CheckPointYOffset = 1f;
    [SerializeField] float _BarrelYOffset = 0.75f;

    [SerializeField] int _PlatformNumber;
    [SerializeField] int[] _BarrelNumber;

    private Vector3 _FirstPosition;
    private List<Vector3> _PlatformPosition;
    private List<GameObject> _Clones;
    private System.Random rn;

    public static int CheckPoints { get; set; }

    private void Awake()
    {
        rn = new System.Random();
        _PlatformPosition = new List<Vector3>();
        _Clones = new List<GameObject>();

        GenerateLevel();

        var PlayerSpawner = GetComponent<PlayerSpawner>();
        PlayerSpawner.Spawn(_FirstPosition);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ReGenerateLevel();

            var PlayerSpawner = GetComponent<PlayerSpawner>();
            PlayerSpawner.Spawn(_FirstPosition);
        }
    }
    void ReGenerateLevel()
    {
        DeleteClones();
        GenerateLevel();
    }
    void GenerateLevel()
    {
        CheckPoints = _PlatformNumber;

        GenerateBoarder();
        GenerateFloor();
        GenerateBarrel();
        GenerateCheckPoint();
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
            _Clones.Add(Instantiate(Wall, new Vector3((Wall.transform.position.x + _WallXOffset), Wall.transform.position.y + (s * -_PlatformNumber), 0), Wall.transform.rotation));
        }
        for (int s = _PlatformNumber; s > 0; s--)
        {
            _Clones.Add(Instantiate(Wall, new Vector3((Wall.transform.position.x - _WallXOffset), Wall.transform.position.y + (s * -_PlatformNumber), 0), Wall.transform.rotation));
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
    }
    void GenerateBarrel()
    {
        foreach (var position in _PlatformPosition)
        {
            int barrelNumber = rn.Next(_BarrelNumber[0], _BarrelNumber[1]);

            for (int s = barrelNumber; s > 0; s--)
            {
                float x = _PlatformSize / barrelNumber;
                _Clones.Add(Instantiate(Barrel, new Vector3((position.x - (_PlatformSize / 2)) + (x * (float)(Convert.ToDouble(s) - 0.5)), position.y, 0), Barrel.transform.rotation));
            }
        }
    }
    void GenerateCheckPoint()
    {
        foreach (var position in _PlatformPosition)
        {
            if(position.x == 20)
            {
                _Clones.Add(Instantiate(CheckPoint, new Vector3((position.x + (_PlatformSize / 2)) - _CheckPointXOffset, (position.y - _BarrelYOffset) + _CheckPointYOffset, 0), CheckPoint.transform.rotation));
            }
            if(position.x == -20)
            {
                _Clones.Add(Instantiate(CheckPoint, new Vector3((position.x - (_PlatformSize / 2)) + _CheckPointXOffset, (position.y - _BarrelYOffset) + _CheckPointYOffset, 0), CheckPoint.transform.rotation));
            }
            //if(position.x == 0)
            //{
            //    _Clones.Add(Instantiate(CheckPoint, new Vector3(0, (position.y - _BarrelYOffset + 1) + _CheckPointYOffset, 0), CheckPoint.transform.rotation));
            //}
        }
    }
}
