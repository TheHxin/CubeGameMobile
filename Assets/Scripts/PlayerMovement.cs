using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    #region Fields
    [SerializeField] Camera _cam;
    [SerializeField] float _camrotatesens;
    [SerializeField] float _sensitivity;
    [SerializeField] float _speed;
    [SerializeField] float _force;

    Rigidbody2D _rigidbody2D;
    Vector2 _starttouch;
    Vector2 _endtouch;
    Quaternion _rt;
    bool _grounded;
    #endregion
    #region Flow
    void Start()
    {
        Screen.sleepTimeout = 0;
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

        if (state == "up" && _grounded)
        {
            _rigidbody2D.AddForce(new Vector2(0, _force), ForceMode2D.Impulse);
            _grounded = false;
        }
    }
    void FixedUpdate()
    {
        _rt = Input.gyro.attitude;
        
        Physics2D.gravity = new Vector2(_rt.x * _speed * _sensitivity, -9.8f);
        _cam.transform.rotation = Quaternion.Euler(0f, 0f, _rt.x * _camrotatesens);
    }
    #endregion
    #region LogicFunction
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            _grounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            _grounded = false;
        }
    }
    string Swipe()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            _starttouch = Input.GetTouch(0).position;
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            _endtouch = Input.GetTouch(0).position;

            if (_endtouch.y > _starttouch.y)
            {
                return "up";
            }
            if (_endtouch.y < _starttouch.y)
            {
                return "down";
            }
        }

        return "null";
    }
    #endregion
}
