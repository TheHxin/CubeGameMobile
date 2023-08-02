using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    private DifficultyObject _Easy;
    private DifficultyObject _Medium;
    private DifficultyObject _Hard;

    public void CalDificulty(LevelGen levelGen, string Dificulty)
    {
        InitializeDifficultyObjects();

        switch (Dificulty)
        {
            case "easy":
                levelGen._PlatformNumber = _Easy.PlarformNumber;
                levelGen._BarrelNumber = _Easy.BarrelNumberChance;
                levelGen._PlatformSkipChance = _Easy.PlatformSkipChance;

                break;
            case "medium":
                levelGen._PlatformNumber = _Medium.PlarformNumber;
                levelGen._BarrelNumber = _Medium.BarrelNumberChance;
                levelGen._PlatformSkipChance = _Medium.PlatformSkipChance;

                break;
            case "hard":
                levelGen._PlatformNumber = _Hard.PlarformNumber;
                levelGen._BarrelNumber = _Hard.BarrelNumberChance;
                levelGen._PlatformSkipChance = _Hard.PlatformSkipChance;

                break;
        }
    }
    private void InitializeDifficultyObjects()
    {
        _Easy = new DifficultyObject
        {
            PlarformNumber = 5,
            PlatformSkipChance = new int[2] { 0, 5 },
            BarrelNumberChance = new int[2] { 1, 2 }
        };
        _Medium = new DifficultyObject
        {
            PlarformNumber = 10,
            PlatformSkipChance = new int[2] { 0, 10 },
            BarrelNumberChance = new int[2] { 1, 3 }
        };
        _Hard = new DifficultyObject
        {
            PlarformNumber = 20,
            PlatformSkipChance = new int[2] { 0, 20 },
            BarrelNumberChance = new int[2] { 1, 4 }
        };
    }
}
