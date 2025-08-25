using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRandomPosition : MonoBehaviour
{
    [SerializeField]
    [Tooltip("生成するゲームオブジェクト")]
    private GameObject createPrefab;

    [SerializeField]
    [Tooltip("生成する範囲A")]
    private Transform rangeA;

    [SerializeField]
    [Tooltip("生成する範囲B")]
    private Transform rangeB;

    [SerializeField]
    float CreateSpeed = 1.0f;

    private float time;    //経過時間

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
        time += Time.deltaTime;    //前フレームから時間を加算していく

        //一秒おきにランダムに生成されるようにする
        if (time > CreateSpeed)
        {
            //rengeAとrengeBのX座標の範囲内でランダムな数値を生成
            float x = Random.Range(rangeA.position.x, rangeB.position.x);
            //rengeAとrengeBのy座標の範囲でランダムな数値を生成
            float y = Random.Range(rangeA.position.y, rangeB.position.y);

            //げーむオブジェクトを上記で決まったランダムな場所に生成
            Instantiate(createPrefab, new Vector2(x, y), createPrefab.transform.rotation);

            //経過時間をリセット
            time = 0.0f;
        }
    }
}
