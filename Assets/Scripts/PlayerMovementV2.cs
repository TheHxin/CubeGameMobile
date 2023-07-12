using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMovementV2 : MonoBehaviour
{
    [SerializeField] Camera _cam;
    [SerializeField] float _speed;
    [SerializeField] float _force;

    Rigidbody2D _rigidbody2D;
    float rotation;
    void Start()
    {
        Input.gyro.enabled = true;
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody2D.AddForce(new Vector2(0, _force), ForceMode2D.Impulse);
        }
    }
    void FixedUpdate()
    {
        rotation = math.clamp(Input.gyro.rotationRateUnbiased.z, -1f, 1f) + rotation;
        Physics2D.gravity = new Vector2(-rotation * _speed, -9.8f);
        _cam.transform.rotation = Quaternion.Euler(0f, 0f, -math.clamp(Input.gyro.rotationRateUnbiased.z, -1f, 1f) * 10f);
    }
}
