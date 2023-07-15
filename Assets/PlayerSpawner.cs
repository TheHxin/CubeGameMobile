using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] GameObject _Player;
    [SerializeField] Camera _Camera;


    public void Spawn(Vector3 position)
    {
        var cam = _Camera.GetComponent<CamerManager>();
        cam.CameraView();
        _Player.transform.position = position;
    }
}
