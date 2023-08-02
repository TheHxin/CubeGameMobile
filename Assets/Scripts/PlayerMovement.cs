using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    [Header("Camera Rotation Setting")]
    [SerializeField] float _Camrotatespeed;
    [SerializeField] float _Camrotatesens;

    [Header("Player Jump Setting")]
    [SerializeField] float _JumpForce;

    [Header("Gravity Setting")]
    [SerializeField] float _Sensitivity;
    [SerializeField] float _GravityAccelerationConstant = -9.8f;

    private Camera _Cam;
    private Rigidbody2D _Rigidbody2D;

    private Vector2 _Starttouch;
    private Vector2 _Endtouch;
    private Vector3 _Rt;

    private bool _Grounded;

    private void Awake()
    {
        _Rigidbody2D = GetComponent<Rigidbody2D>();
        _Cam = GameObject.Find("MainCamera").GetComponent<Camera>();
    }
    void Start()
    {
        Screen.sleepTimeout = 0;
        Input.gyro.enabled = true;

        _Grounded = true;
    }
    private void Update()
    {
        string SwipState = SwipeUp();

        if (SwipState == "up" && _Grounded)
        {
            _Rigidbody2D.AddForce(new Vector2(0, _JumpForce), ForceMode2D.Impulse);
            _Grounded = false;
        }
    }
    void FixedUpdate()
    {
        _Rt = Input.acceleration;

        Physics2D.gravity = new Vector2(_Rt.x * _Sensitivity, _GravityAccelerationConstant);
        _Cam.transform.rotation = Quaternion.Lerp(_Cam.transform.rotation, Quaternion.Euler(0, 0, _Rt.x * _Camrotatesens), _Camrotatespeed * Time.deltaTime);
        LimitVelocity();
    }

    string SwipeUp()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            _Starttouch = Input.GetTouch(0).position;
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            _Endtouch = Input.GetTouch(0).position;

            if (_Endtouch.y > _Starttouch.y)
            {
                return "up";
            }
            if (_Endtouch.y < _Starttouch.y)
            {
                return "down";
            }
        }

        return "null";
    }
    void LimitVelocity()
    {
        float velocity = Mathf.Clamp(_Rigidbody2D.velocity.x, -35f, 35f);
        _Rigidbody2D.velocity = new Vector2(velocity,_Rigidbody2D.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            _Grounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            _Grounded = false;
        }
    }
}
