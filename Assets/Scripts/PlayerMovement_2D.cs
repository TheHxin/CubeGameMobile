using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_2D : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] float _force;
    [SerializeField] float _time;
    [SerializeField] GameObject _inputobj;

    private GameInput _input;
    private Rigidbody2D _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _input = _inputobj.GetComponent<GameInput>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.AddForce(new Vector3(0, _force, 0), ForceMode2D.Impulse);
        }

        //if (_input.Axis != 0)
        //{
        //    transform.position = Vector3.SmoothDamp(transform.position, new Vector3((_input.Axis * _speedconst * _speed), transform.position.y, transform.position.z), ref _dampVelocity, _time);
        //}

        _rigidbody.AddForce(new Vector3(_input.Axis * _speed, 0, 0), ForceMode2D.Force);
    }
}
