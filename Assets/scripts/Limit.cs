using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limit : MonoBehaviour
{
    [SerializeField] public float minX;

    [SerializeField] public float maxX;

    [SerializeField] public float minY;

    [SerializeField] public float maxY;

    // Update is called once per frame
    void Update()
    {
        //���݂̈ʒu���擾
        Vector3 position = transform.position;

        //x���W��y���W��͈͓��ɐ���
        position.x = Mathf.Clamp(position.x, minX, maxX);
        position.y = Mathf.Clamp(position.y, minY, maxY);

        //�V�����ʒu��ݒ�
        transform.position = position;
    }
}
