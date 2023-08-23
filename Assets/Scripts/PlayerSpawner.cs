using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    private GameObject _Player;
    private GameObject _Camera;

    private void Awake()
    {
        _Player = GameObject.Find("Player");
        _Camera = GameObject.Find("MainCamera");
    }
    public void Spawn(Vector3 position)
    {
        var camera = _Camera.GetComponent<CamerManager>();
        camera.CameraView();

        _Player.transform.position = position;
        Time.timeScale = 1;
    }
}
