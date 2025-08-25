using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private GameObject Effect; // エフェクトのプレハブ

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ShowCollectEffect();        }
    }

    void ShowCollectEffect()
    {
        if (Effect != null)
        {
            // エフェクトをアイテムの位置に生成する
            GameObject effectInstance = Instantiate(Effect, transform.position, Quaternion.identity);
            //一秒たったらエフェクトを消す
            Destroy(effectInstance, 0.5f);
        }
    }
}
