using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBlock : MonoBehaviour
{  
    public GameObject objectA; // A�̃I�u�W�F�N�g
    public GameObject objectB; // B�̃I�u�W�F�N�g

    void Update()
    {
        // A�̃I�u�W�F�N�g�����݂��Ȃ��ꍇ�i�������ꍇ�j
        if (objectA == null)
        {
            // B�̃I�u�W�F�N�g����������
            Destroy(objectB);
        }
    }
}

