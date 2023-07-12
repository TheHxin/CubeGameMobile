using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Camera _cam;
    [SerializeField] float _speed;
    [SerializeField] float _force;

    Rigidbody2D _rigidbody2D;
    Vector2 _starttouch;
    Vector2 _endtouch;
    float rotation;
    bool _grounded;
    void Start()
    {
        _grounded = true;
        Input.gyro.enabled = true;
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody2D.AddForce(new Vector2(0, _force), ForceMode2D.Impulse);
        }

        string state = Swipe();

        if(state == "up" && _grounded)
        {
            _rigidbody2D.AddForce(new Vector2(0, _force), ForceMode2D.Impulse);
            _grounded = false;
        }
    }
    void FixedUpdate()
    {
        rotation = math.clamp(Input.gyro.rotationRateUnbiased.z, -1f, 1f) + rotation;
        Physics2D.gravity = new Vector2(-rotation * _speed, -9.8f);
        _cam.transform.rotation = Quaternion.Euler(0f, 0f, -rotation);
        //-math.clamp(Input.gyro.rotationRateUnbiased.z, -1f, 1f) * 10f
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag == "floor")
        {
            print("fs");
            _grounded = true;
        }
    }
    string Swipe()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            _starttouch = Input.GetTouch(0).position;
        }
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            _endtouch = Input.GetTouch(0).position;

            if(_endtouch.y > _starttouch.y)
            {
                return "up";
            }
            if(_endtouch.y < _starttouch.y)
            {
                return "down";
            }
        }
        return "null";
    }
}
