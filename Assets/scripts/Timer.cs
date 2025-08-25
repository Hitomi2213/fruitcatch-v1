using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class Timer : MonoBehaviour
{
    public float timeLimit = 60f; // 制限時間
    private float CountTime;

    public TextMeshProUGUI TimerText; // タイマー表示用TextMeshProオブジェクト
    //public TextMeshProUGUI endText;

    void Start()
    {
        //時間を初期化
        CountTime = timeLimit;
        //タイマーを更新
        //UpdateTimerText();
        //endText.gameObject.SetActive(false);
    }

    void Update()
    {
        // 時間を減らす
        CountTime -= Time.deltaTime;

        // タイマーを更新
        UpdateTimerText();

        // 制限時間が経過したら
        if (CountTime <= 0)
        {
            CountTime = 0;
            TimerEnded();
        }
    }

    void UpdateTimerText()
    {
        // 残り時間を表示
        TimerText.text = $"Time: {CountTime:f2}"; 
    }

    void TimerEnded()
    {
        // 制限時間が経過したときの処理
        Debug.Log("終了");
        //StartCoroutine(ShowEndTextAndTransition());
        // ここに制限時間が経過したときの処理
        //リザルト画面に遷移
        SceneManager.LoadScene("EndScene");
    }

    //private IEnumerator ShowEndTextAndTransition()
    //{
    //    endText.gameObject.SetActive(true);
    //    yield return new WaitForSeconds(1.0f);
    //    SceneManager.LoadScene("EndEcene");
    //}
}
