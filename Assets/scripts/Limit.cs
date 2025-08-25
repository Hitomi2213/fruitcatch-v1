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
        //現在の位置を取得
        Vector3 position = transform.position;

        //x座標とy座標を範囲内に制限
        position.x = Mathf.Clamp(position.x, minX, maxX);
        position.y = Mathf.Clamp(position.y, minY, maxY);

        //新しい位置を設定
        transform.position = position;
    }
}
