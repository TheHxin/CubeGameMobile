using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    [SerializeField] float _sens;
    [SerializeField] string state;

    public float Axis { get; set; }

    private void Start()
    {
        //if (state == "gyro")
        //{
            Input.gyro.enabled = true;
        //}
    }
    private void Update()
    {
        //if (state == "gyro")
        //{
            Axis = Input.gyro.rotationRateUnbiased.x * Time.deltaTime;
        print(Axis);
        //}
        //else
        //{
        //    Axis = Input.GetAxis("Horizontal") * Time.deltaTime;
        //}
    }
}
