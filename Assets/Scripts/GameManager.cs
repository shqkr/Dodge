using UnityEngine;
using UnityEngine.UI; // UI 관련 라이브러리
using UnityEngine.SceneManagement; // 씬 관리 관련 라이브러리

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText;
    public Text timeText;
    public Text recordText;

    private float surviveTime;
    private bool isGameover;

    private void Start()
    {
        // 생존 시간과 게임 오버 상태 초기화
        surviveTime = 0;
        isGameover = false;
    }

    private void Update()
    {
        if (!isGameover)
        {
            // 생존 시간 갱신
            surviveTime += Time.deltaTime;
            timeText.text = "Time: " + (int)surviveTime;
        }
        else
        {
            // 게임 오버 상태이고 R이 눌렸을 시 씬을 다시 로드
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }  
    }

    // 플레이어 사망 시 PlayerController에서 호출
    public void EndGame()
    {
        isGameover = true;
        gameoverText.SetActive(true);

        float bestTime = PlayerPrefs.GetFloat("BestTime");

        if (surviveTime > bestTime)
        {
            bestTime = surviveTime;
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        recordText.text = "Best Time: " + (int)bestTime;
    }
}
