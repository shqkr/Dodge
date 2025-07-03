using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 8f; // 플레이어 이동 속도
    private Rigidbody playerRigidbody;

    private void Start()
    {
        // 컴포넌트 초기화
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // 수평축과 수직축의 입력값을 감지
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        // 실제 이동 속도를 입력값과 이동 속력을 통해 결정
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        // Vector3 속도를 생성 후 플레이어 linearVelocity에 할당
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        playerRigidbody.linearVelocity = newVelocity;
    }

    // 총알과 플레이어가 충돌했을 시 실행
    public void Die()
    {
        gameObject.SetActive(false);

        // GameManager 오브젝트를 찾아 EndGame() 메서드 실행
        GameManager gameManager = FindFirstObjectByType<GameManager>();
        gameManager.EndGame();
    }
}
