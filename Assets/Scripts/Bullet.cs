using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f; // 탄알 이동 속도
    private Rigidbody bulletRigidbody;

    private void Start()
    {
        // 컴포넌트 초기화
        bulletRigidbody = GetComponent<Rigidbody>();

        // 탄알 속도 = 앞쪽 방향 * 이동 속도
        bulletRigidbody.linearVelocity = transform.forward * speed;
        // 3초 뒤 자신의 게임 오브젝트 파괴
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter(Collider other)
    {
        // 충돌한 상대방 게임 오브젝트가 Player 태그를 가진 경우
        if (other.tag == "Player")
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.Die();
            }
        }
    }
}
