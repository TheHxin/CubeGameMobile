using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    

    public void CalDificulty(LevelGen lg,string Dificulty)
    {
        int[] bn;
        int[] sc;

        switch (Dificulty)
        {
            case "easy":
                bn = new int[2] { 1, 2 };
                sc = new int[2] { 0, 5 };

                lg._PlatformNumber = 5;
                lg._BarrelNumber = bn;
                lg._PlatformSkipChance = sc;

                break;
            case "medium":
                bn = new int[2] { 1, 3 };
                sc = new int[2] { 0, 10 };

                lg._PlatformNumber = 10;
                lg._BarrelNumber = bn;
                lg._PlatformSkipChance = sc;

                break;
            case "hard":
                bn = new int[2] { 1, 4 };
                sc = new int[2] { 0, 20 };

                lg._PlatformNumber = 20;
                lg._BarrelNumber = bn;
                lg._PlatformSkipChance = sc;

                break;
        }
    }
}
