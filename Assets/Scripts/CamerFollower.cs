using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerFollower : MonoBehaviour
{
    [SerializeField] GameObject _player;
    [SerializeField] float _time;

    private Vector3 _dampVelocity = Vector3.zero;

    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(_player.transform.position.x, _player.transform.position.y, transform.position.z), ref _dampVelocity, _time);
    }
}
