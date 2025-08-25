using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int AppleScore = 0; //りんごのスコア
    public int GrapeScore = 0; //ぶどうのスコア
    public int OrangeScore = 0;//みかんのスコア
    public int TotalScore = 0; //合計数

    public int BomScore = 0; //爆弾のダメージ数

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);//シーン遷移してもでーた破棄されないようにする
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
