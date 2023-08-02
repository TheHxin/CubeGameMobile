using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerFollower : MonoBehaviour
{
    [SerializeField] float Time;

    private Vector3 _dampVelocity = Vector3.zero;
    private GameObject _player;

    private void Awake()
    {
        _player = GameObject.Find("Player");
    }
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(_player.transform.position.x, _player.transform.position.y, transform.position.z), ref _dampVelocity, Time);
    }
}
