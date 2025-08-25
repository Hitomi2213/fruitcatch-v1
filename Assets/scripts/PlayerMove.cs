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
    //private TextMeshProUGUI endText; //�I��������\�����邽�߂̕�

    [SerializeField]
    private float speed = 0.1f; // �ړ����x

    [SerializeField]
    private int maxHealth = 3; // �̗͂̍ő�l

    [SerializeField]
    private CanvasGroup gameOverPanel; // �Q�[���I�[�o�[�p�l��
    [SerializeField]
    private float fadeDuration = 1.0f; // �t�F�[�h�A�E�g�ɂ����鎞��

    [SerializeField]
    private TextMeshProUGUI AppleCountText; // ���
    [SerializeField]
    private TextMeshProUGUI GrapeCountText; // �Ԃǂ�
    [SerializeField]
    private TextMeshProUGUI OrangeCountText; // �݂���
    [SerializeField]
    private TextMeshProUGUI TotalCountText; // ���v��

    [SerializeField]
    private AudioClip Sound; // ���ʉ�
    [SerializeField]
    private AudioClip BombSound; // ���e�̌��ʉ�

    [SerializeField]
    private Animator AppleAnimator; // ��񂲂̃A�j���[�V����
    [SerializeField]
    private Animator GrapeAnimator; // �Ԃǂ��̃A�j���[�V����
    [SerializeField]
    private Animator OrangeAnimator; // �݂���̃A�j���[�V����
    [SerializeField]
    private Animator BomAnimator; // ���e�̃A�j���[�V����

    [SerializeField]
    private float FadeOunTime = 0.1f;

    private bool isGameOver = false;

    [SerializeField]
    private Image[] healthHearts; // �n�[�g��UI��z��ŊǗ�
    [SerializeField]
    private Animator[] heartAnimators; // �n�[�g�̃A�j���[�^�[

    private int currentHealth; // ���݂̗̑�
    private Animator animator;
    private AudioSource SoundCollection;

    

    void Start()
    {
        animator = GetComponent<Animator>();
        SoundCollection = GetComponent<AudioSource>();
        GameManager.Instance.AppleScore = 0; // �X�R�A�̏�����
        GameManager.Instance.GrapeScore = 0;
        GameManager.Instance.OrangeScore = 0;
        GameManager.Instance.TotalScore = 0; // ���v�X�R�A�̏�����
        currentHealth = maxHealth; // �̗͂̏�����
        UpdateHealthUI(); // �̗�UI�̍X�V
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
            animator.SetInteger("direction", 1); // ��������
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            pos.x += speed * Time.deltaTime;
            animator.SetInteger("direction", 2); // �E������
        }
        transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("bakudan"))
        {
            other.gameObject.SetActive(false);
            TakeDamage(); // �_���[�W���󂯂��ۂɌĂяo��
            PlayCollectSound(BombSound); // ���e�̌��ʉ����Đ�
            PlayBounceAnimation(BomAnimator); // ���e�̃A�j���[�V����
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
        if (currentHealth < 0) currentHealth = 0; //currentHealth��0��菬�����Ȃ�Ȃ��悤�ɂ���
        Debug.Log($"�_���[�W���󂯂�{currentHealth}");
        heartAnimators[currentHealth].SetTrigger("Blink"); // �_�ŃA�j���[�V�����g���K�[��ݒ�
        heartAnimators[currentHealth].SetTrigger("FadeOut"); // ������A�j���[�V�����g���K�[��ݒ�
        CheckHealth();
    }


    private void UpdateHealthUI()
    {
        for (int i = 0; i < healthHearts.Length; i++)
        {
            if (i < currentHealth)
            {
                healthHearts[i].enabled = true; // �n�[�g��\��
            }
            else
            {
                if (healthHearts[i].enabled) // �n�[�g�����ݕ\������Ă���ꍇ�ɂ̂݃A�j���[�V�����Đ�
                {
                    heartAnimators[i].SetTrigger("Blink"); // �_�ŃA�j���[�V�����g���K�[��ݒ�
                    heartAnimators[i].SetTrigger("FadeOut"); // ������A�j���[�V�����g���K�[��ݒ�
                }
               // healthHearts[i].enabled = false; // �n�[�g���\��
            }
        }
    }



    private void CheckHealth()
    {
        if (currentHealth <= 0)
        {
            Debug.Log("�̗͂�0�ɂȂ����̂ŃQ�[���I�[�o�[");
            animator.SetBool("Fall", true); //�|���A�j���[�V�����g���K�[
            StartCoroutine(StartFadeAfterDelay(FadeOunTime)); //�x����݂��ăt�F�[�h�A�E�g���J�n
            DisableAllItem();
            isGameOver = true; //�Q�[���I�o�[�̃t���O�𗧂Ă�
        }
    }

    private void DisableAllItem()
    {
        //��񂲂��폜
        GameObject[] Apple = GameObject.FindGameObjectsWithTag("Apple");

        foreach (GameObject item in Apple)
        {
            item.SetActive(false); // �A�C�e���𖳌���
        }

    //�݂�����폜
        GameObject[] Orange = GameObject.FindGameObjectsWithTag("Orange");

        foreach (GameObject item in Orange)
        {
            item.SetActive(false); // �A�C�e���𖳌���
        }

    //�Ԃǂ����폜
        GameObject[] Grapes = GameObject.FindGameObjectsWithTag("Grapes");

        foreach (GameObject item in Grapes)
        {
            item.SetActive(false); // �A�C�e���𖳌���
        }

        //���e���폜
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
        float elapsedTime = 0.0f; // �o�߂�������

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsedTime / fadeDuration);
            gameOverPanel.alpha = alpha; // ���X��Alpha�l���グ�Ă���
            yield return null;
        }

        // �Q�[���I�[�o�[�p�l���̕\�������S�ɐ^�����ɂ���
        gameOverPanel.blocksRaycasts = true;

        //�Q�[���I�o�[�V�[���ɑJ��
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
        //���݂̃V�[�����ēǂݍ���
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
    