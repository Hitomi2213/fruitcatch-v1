using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using JetBrains.Annotations;

public class PlayerMove : MonoBehaviour
{
    //public static GameManager Instance;

    //[SerializeField]
    //private TextMeshProUGUI endText; //終了文字を表示するための物

    [SerializeField]
    private float speed = 0.1f; // 移動速度

    [SerializeField]
    private int maxHealth = 3; // 体力の最大値

    [SerializeField]
    private CanvasGroup gameOverPanel; // ゲームオーバーパネル
    [SerializeField]
    private float fadeDuration = 1.0f; // フェードアウトにかかる時間

    [SerializeField]
    private TextMeshProUGUI AppleCountText; // りんご
    [SerializeField]
    private TextMeshProUGUI GrapeCountText; // ぶどう
    [SerializeField]
    private TextMeshProUGUI OrangeCountText; // みかん
    [SerializeField]
    private TextMeshProUGUI TotalCountText; // 合計数

    [SerializeField]
    private AudioClip Sound; // 効果音
    [SerializeField]
    private AudioClip BombSound; // 爆弾の効果音

    [SerializeField]
    private Animator AppleAnimator; // りんごのアニメーション
    [SerializeField]
    private Animator GrapeAnimator; // ぶどうのアニメーション
    [SerializeField]
    private Animator OrangeAnimator; // みかんのアニメーション
    [SerializeField]
    private Animator BomAnimator; // 爆弾のアニメーション

    [SerializeField]
    private float FadeOunTime = 0.1f;

    private bool isGameOver = false;

    [SerializeField]
    private Image[] healthHearts; // ハートのUIを配列で管理
    [SerializeField]
    private Animator[] heartAnimators; // ハートのアニメーター

    private int currentHealth; // 現在の体力
    private Animator animator;
    private AudioSource SoundCollection;

    

    void Start()
    {
        animator = GetComponent<Animator>();
        SoundCollection = GetComponent<AudioSource>();
        GameManager.Instance.AppleScore = 0; // スコアの初期化
        GameManager.Instance.GrapeScore = 0;
        GameManager.Instance.OrangeScore = 0;
        GameManager.Instance.TotalScore = 0; // 合計スコアの初期化
        currentHealth = maxHealth; // 体力の初期化
        UpdateHealthUI(); // 体力UIの更新
        UpdateCountText();
    }

    void Update()
    {


        if (isGameOver)
        {
            return;
        }
        Vector2 pos = transform.position;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            pos.x -= speed * Time.deltaTime;
            animator.SetInteger("direction", 1); // 左を向く
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            pos.x += speed * Time.deltaTime;
            animator.SetInteger("direction", 2); // 右を向く
        }
        transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("bakudan"))
        {
            other.gameObject.SetActive(false);
            TakeDamage(); // ダメージを受けた際に呼び出す
            PlayCollectSound(BombSound); // 爆弾の効果音を再生
            PlayBounceAnimation(BomAnimator); // 爆弾のアニメーション
        }
        else if (other.CompareTag("Apple"))
        {
            other.gameObject.SetActive(false);
            GameManager.Instance.AppleScore += 1;
            UpdateCountText();
            PlayCollectSound();
            PlayBounceAnimation(AppleAnimator);
        }
        else if (other.CompareTag("Grapes"))
        {
            other.gameObject.SetActive(false);
            GameManager.Instance.GrapeScore += 1;
            UpdateCountText();
            PlayCollectSound();
            PlayBounceAnimation(GrapeAnimator);
        }
        else if (other.CompareTag("Orange"))
        {
            other.gameObject.SetActive(false);
            GameManager.Instance.OrangeScore += 1;
            UpdateCountText();
            PlayCollectSound();
            PlayBounceAnimation(OrangeAnimator);
        }
    }

    private void TakeDamage()
    {
        currentHealth--;
        if (currentHealth < 0) currentHealth = 0; //currentHealthが0より小さくならないようにする
        Debug.Log($"ダメージを受けた{currentHealth}");
        heartAnimators[currentHealth].SetTrigger("Blink"); // 点滅アニメーショントリガーを設定
        heartAnimators[currentHealth].SetTrigger("FadeOut"); // 消えるアニメーショントリガーを設定
        CheckHealth();
    }


    private void UpdateHealthUI()
    {
        for (int i = 0; i < healthHearts.Length; i++)
        {
            if (i < currentHealth)
            {
                healthHearts[i].enabled = true; // ハートを表示
            }
            else
            {
                if (healthHearts[i].enabled) // ハートが現在表示されている場合にのみアニメーション再生
                {
                    heartAnimators[i].SetTrigger("Blink"); // 点滅アニメーショントリガーを設定
                    heartAnimators[i].SetTrigger("FadeOut"); // 消えるアニメーショントリガーを設定
                }
               // healthHearts[i].enabled = false; // ハートを非表示
            }
        }
    }



    private void CheckHealth()
    {
        if (currentHealth <= 0)
        {
            Debug.Log("体力が0になったのでゲームオーバー");
            animator.SetBool("Fall", true); //倒れるアニメーショントリガー
            StartCoroutine(StartFadeAfterDelay(FadeOunTime)); //遅延を設けてフェードアウトを開始
            DisableAllItem();
            isGameOver = true; //ゲームオバーのフラグを立てる
        }
    }

    private void DisableAllItem()
    {
        //りんごを削除
        GameObject[] Apple = GameObject.FindGameObjectsWithTag("Apple");

        foreach (GameObject item in Apple)
        {
            item.SetActive(false); // アイテムを無効化
        }

    //みかんを削除
        GameObject[] Orange = GameObject.FindGameObjectsWithTag("Orange");

        foreach (GameObject item in Orange)
        {
            item.SetActive(false); // アイテムを無効化
        }

    //ぶどうを削除
        GameObject[] Grapes = GameObject.FindGameObjectsWithTag("Grapes");

        foreach (GameObject item in Grapes)
        {
            item.SetActive(false); // アイテムを無効化
        }

        //爆弾を削除
        GameObject[] Bakudan = GameObject.FindGameObjectsWithTag("bakudan");

        foreach (GameObject item in Bakudan)
        {
            item.SetActive(false);
        }
    }


    IEnumerator StartFadeAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        StartCoroutine(FadeToBlack());
    }

    IEnumerator FadeToBlack()
    {
        float elapsedTime = 0.0f; // 経過した時間

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsedTime / fadeDuration);
            gameOverPanel.alpha = alpha; // 徐々にAlpha値を上げていく
            yield return null;
        }

        // ゲームオーバーパネルの表示を完全に真っ黒にする
        gameOverPanel.blocksRaycasts = true;

        //ゲームオバーシーンに遷移
        SceneManager.LoadScene("GameOverScene");
    }

    void UpdateCountText()
    {
        if (AppleCountText == null) Debug.LogError("AppleCountText is null!");
        if (GrapeCountText == null) Debug.LogError("GrapeCountText is null!");
        if (OrangeCountText == null) Debug.LogError("OrangeCountText is null!");
        if (TotalCountText == null) Debug.LogError("TotalCountText is null!");

        if (AppleCountText != null) AppleCountText.text = $"Apple: {GameManager.Instance.AppleScore}";
        if (GrapeCountText != null) GrapeCountText.text = $"Grape: {GameManager.Instance.GrapeScore}";
        if (OrangeCountText != null) OrangeCountText.text = $"Orange: {GameManager.Instance.OrangeScore}";

        GameManager.Instance.TotalScore =
            GameManager.Instance.AppleScore +
            GameManager.Instance.GrapeScore * 2 +
            GameManager.Instance.OrangeScore * 3;
        if (TotalCountText != null) TotalCountText.text = $"Total: {GameManager.Instance.TotalScore}";
    }

    void PlayCollectSound()
    {
        if (Sound != null)
        {
            SoundCollection.PlayOneShot(Sound);
        }
    }

    void PlayCollectSound(AudioClip Bomb)
    {
        if (Bomb != null)
        {
            SoundCollection.PlayOneShot(Bomb);
        }
    }

    void PlayBounceAnimation(Animator FruitAnimator)
    {
        if (FruitAnimator != null)
        {
            FruitAnimator.SetTrigger("Bounce");
        }
    }

    void ResetGame()
    {
        //現在のシーンを再読み込み
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
    