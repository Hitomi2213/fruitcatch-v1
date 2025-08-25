using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRandomPosition : MonoBehaviour
{
    [SerializeField]
    [Tooltip("��������Q�[���I�u�W�F�N�g")]
    private GameObject createPrefab;

    [SerializeField]
    [Tooltip("��������͈�A")]
    private Transform rangeA;

    [SerializeField]
    [Tooltip("��������͈�B")]
    private Transform rangeB;

    [SerializeField]
    float CreateSpeed = 1.0f;

    private float time;    //�o�ߎ���

    // Start is called before the first frame update
    void Start()
    {
        if (createPrefab == null)
        {
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;    //�O�t���[�����玞�Ԃ����Z���Ă���

        //��b�����Ƀ����_���ɐ��������悤�ɂ���
        if (time > CreateSpeed)
        {
            //rengeA��rengeB��X���W�͈͓̔��Ń����_���Ȑ��l�𐶐�
            float x = Random.Range(rangeA.position.x, rangeB.position.x);
            //rengeA��rengeB��y���W�͈̔͂Ń����_���Ȑ��l�𐶐�
            float y = Random.Range(rangeA.position.y, rangeB.position.y);

            //���[�ރI�u�W�F�N�g����L�Ō��܂��������_���ȏꏊ�ɐ���
            Instantiate(createPrefab, new Vector2(x, y), createPrefab.transform.rotation);

            //�o�ߎ��Ԃ����Z�b�g
            time = 0.0f;
        }
    }
}
