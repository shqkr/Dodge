using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab; // 탄알의 원본 프리팹
    public float spawnRateMin = 0.5f; // 최소 생성 주기
    public float spawnRateMax = 3f; // 최대 생성 주기

    private Transform target; // 발사할 대상의 Transform 컴포넌트
    private float spawnRate; // 생성 주기
    private float timeAfterSpawn; // 최근 생성 시점에서 지난 시간

    private void Start()
    {
        // 초기화
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        target = FindFirstObjectByType<PlayerController>().transform;
    }

    private void Update()
    {
        // timeAfterSpawn 갱신
        timeAfterSpawn += Time.deltaTime;

        // 최근 생성 시점에서부터 누적된 시간이 생성 주기보다 크거나 같다면
        if (timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0f;

            // 탄알 인스턴스화
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.transform.LookAt(target);

            // 생성 간격 랜덤 지정
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}
