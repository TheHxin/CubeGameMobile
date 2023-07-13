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
    public int[] _PlatformSpace;

    private void Awake()
    {
        GenerateBoarder();

        
        System.Random rn = new System.Random();
        for (int s = _PlatformNumber; s > 0; s--)
        {
            Instantiate(Floor,new Vector3(transform.position.x))
        }
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
}
