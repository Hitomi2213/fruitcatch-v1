using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBlock : MonoBehaviour
{  
    public GameObject objectA; // Aのオブジェクト
    public GameObject objectB; // Bのオブジェクト

    void Update()
    {
        // Aのオブジェクトが存在しない場合（消えた場合）
        if (objectA == null)
        {
            // Bのオブジェクトも消去する
            Destroy(objectB);
        }
    }
}

