using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] GameObject _Player;


    public void Spawn(Vector3 position)
    {
        _Player.transform.position = position;
    }
}
