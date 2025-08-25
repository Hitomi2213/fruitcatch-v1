using UnityEngine;
using TMPro;
using NUnit.Framework.Constraints;
public class FruitsPoint : MonoBehaviour
{
    public TextMeshProUGUI FruitsCountText; //アイテムカウント表示
    private int FruitsCount;

    private void Start()
    {
        //アイテムカウントの初期化
        UpdateItemCountText();
    }

    void UpdateItemCountText()
    {
        //カウントしたアイテム数を表示
        FruitsCountText.text = $"{FruitsCount}";
    }

    //アイテムを取得したときの処理
    public void CollectItem()
    {
        FruitsCount += 1;
        UpdateItemCountText();
    }

}
