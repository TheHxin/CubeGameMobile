using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerManager : MonoBehaviour
{
    [SerializeField] float InitialSize = 70f;
    [SerializeField] float EndSize = 10f;
    [SerializeField] float Duration = 2f;

    private Camera cam;
    private bool SetFOVRunning = false;

    public void CameraView()
    {
        if (SetFOVRunning)
        {
            StopAllCoroutines();
        }
        cam = GetComponent<Camera>();
        cam.orthographicSize = InitialSize;
        transform.position = new Vector3(0, 0, -10);

        StartCoroutine(SetCamerFOV(InitialSize, EndSize, Duration));
    }
    IEnumerator SetCamerFOV(float v_start, float v_end, float duration)
    {
        SetFOVRunning = true;
        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            cam.orthographicSize = Mathf.Lerp(v_start, v_end, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        cam.orthographicSize = v_end;
        SetFOVRunning = false;
    }
}
