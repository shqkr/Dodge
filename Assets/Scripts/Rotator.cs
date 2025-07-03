using UnityEngine;

public class Rotator : MonoBehaviour
{
    // 바닥 회전 속도
    public float rotationSpeed = 60f;

    private void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }
}
