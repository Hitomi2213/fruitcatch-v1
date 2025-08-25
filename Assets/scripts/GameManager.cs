using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int AppleScore = 0; //��񂲂̃X�R�A
    public int GrapeScore = 0; //�Ԃǂ��̃X�R�A
    public int OrangeScore = 0;//�݂���̃X�R�A
    public int TotalScore = 0; //���v��

    public int BomScore = 0; //���e�̃_���[�W��

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);//�V�[���J�ڂ��Ă��Ł[���j������Ȃ��悤�ɂ���
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
