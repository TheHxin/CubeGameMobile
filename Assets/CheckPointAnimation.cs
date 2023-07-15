using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointAnimation : MonoBehaviour
{
    [SerializeField] float _RotationRate;
    void Update()
    {
        transform.Rotate(new Vector3(0,0, _RotationRate * Time.deltaTime));
    }
}
