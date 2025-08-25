using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private GameObject Effect; // �G�t�F�N�g�̃v���n�u

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
            // �G�t�F�N�g���A�C�e���̈ʒu�ɐ�������
            GameObject effectInstance = Instantiate(Effect, transform.position, Quaternion.identity);
            //��b��������G�t�F�N�g������
            Destroy(effectInstance, 0.5f);
        }
    }
}
