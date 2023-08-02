using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerManager : MonoBehaviour
{
    [Header("Camera FOV_Lerp Setting")]
    [SerializeField] float InitialSize = 70f;
    [SerializeField] float EndSize = 10f;
    [SerializeField] float Duration = 2f;

    private Camera _Cam;
    private bool _LerpFOVRunning = false;

    public void CameraView()
    {
        _Cam = GetComponent<Camera>();

        if (_LerpFOVRunning) StopAllCoroutines();
        _Cam.orthographicSize = InitialSize;
        transform.position = new Vector3(0, 0, -10);

        StartCoroutine(LerpCamerFOV(InitialSize, EndSize, Duration));
    }
    IEnumerator LerpCamerFOV(float fov_start, float fov_end, float duration)
    {
        _LerpFOVRunning = true;
        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            _Cam.orthographicSize = Mathf.Lerp(fov_start, fov_end, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        _Cam.orthographicSize = fov_end;
        _LerpFOVRunning = false;
    }
}
