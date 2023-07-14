using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class LevelGen : MonoBehaviour
{
    [SerializeField] GameObject Floor;
    [SerializeField] GameObject Wall;

    public float _WallXOffset;
    public int _PlatformNumber;
    public int _BarrelNumber;

    private Vector3 _FirstPosition;

    private void Awake()
    {
        GenerateBoarder();
        GenerateFloor();

        var PlayerSpawner = GetComponent<PlayerSpawner>();
        PlayerSpawner.Spawn(_FirstPosition);
    }
    void GenerateBoarder()
    {
        for (int s = _PlatformNumber; s > 0; s--)
        {
            Instantiate(Wall, new Vector3((Wall.transform.position.x + _WallXOffset), Wall.transform.position.y + (s * -_PlatformNumber), 0), Wall.transform.rotation);
        }
        for (int s = _PlatformNumber; s > 0; s--)
        {
            Instantiate(Wall, new Vector3((Wall.transform.position.x - _WallXOffset), Wall.transform.position.y + (s * -_PlatformNumber), 0), Wall.transform.rotation);
        }
    }
    void GenerateFloor()
    {
        System.Random rn = new System.Random();
        for (int s = _PlatformNumber; s > 0; s--)
        {
            int x = rn.Next(1, ((Convert.ToInt32(_WallXOffset) * 2) / 20) + 1);
            int space = 10;
            switch (x)
            {
                case 1:
                    Instantiate(Floor, new Vector3(-20, s * -space, 0), Floor.transform.rotation);
                    if (s == 1)
                    {
                        _FirstPosition = new Vector3(-20, (s * -space) + 2, 0);
                    }
                    break;
                case 2:
                    Instantiate(Floor, new Vector3(0, s * -space, 0), Floor.transform.rotation);
                    if (s == 1)
                    {
                        _FirstPosition = new Vector3(0, (s * -space) + 2, 0);
                    }
                    break;
                case 3:
                    Instantiate(Floor, new Vector3(20, s * -space, 0), Floor.transform.rotation);
                    if (s == 1)
                    {
                        _FirstPosition = new Vector3(20, (s * -space) + 2, 0);
                    }
                    break;
            }
        }
    }
}
