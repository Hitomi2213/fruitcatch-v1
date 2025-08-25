using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class RestartButton : MonoBehaviour
{
    [SerializeField]
    private Button restartButton; //���X�^�[�g�{�^����ݒ肷�邽�߂̕ϐ�

    // Start is called before the first frame update
    void Start()
    {
        //���X�^�[�g�{�^�����N���b�N���ꂽ�Ƃ���RestartGame���\�b�h���Ăяo��
        restartButton.onClick.AddListener(RestartGame);
    }

    void RestartGame() //�Q�[����蒼�����\�b�h
    {
        //���݂̃V�[���̍ēǂݍ��݂��ăQ�[�����ăX�^�[�g
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
