using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class Timer : MonoBehaviour
{
    public float timeLimit = 60f; // ��������
    private float CountTime;

    public TextMeshProUGUI TimerText; // �^�C�}�[�\���pTextMeshPro�I�u�W�F�N�g
    //public TextMeshProUGUI endText;

    void Start()
    {
        //���Ԃ�������
        CountTime = timeLimit;
        //�^�C�}�[���X�V
        //UpdateTimerText();
        //endText.gameObject.SetActive(false);
    }

    void Update()
    {
        // ���Ԃ����炷
        CountTime -= Time.deltaTime;

        // �^�C�}�[���X�V
        UpdateTimerText();

        // �������Ԃ��o�߂�����
        if (CountTime <= 0)
        {
            CountTime = 0;
            TimerEnded();
        }
    }

    void UpdateTimerText()
    {
        // �c�莞�Ԃ�\��
        TimerText.text = $"Time: {CountTime:f2}"; 
    }

    void TimerEnded()
    {
        // �������Ԃ��o�߂����Ƃ��̏���
        Debug.Log("�I��");
        //StartCoroutine(ShowEndTextAndTransition());
        // �����ɐ������Ԃ��o�߂����Ƃ��̏���
        //���U���g��ʂɑJ��
        SceneManager.LoadScene("EndScene");
    }

    //private IEnumerator ShowEndTextAndTransition()
    //{
    //    endText.gameObject.SetActive(true);
    //    yield return new WaitForSeconds(1.0f);
    //    SceneManager.LoadScene("EndEcene");
    //}
}
