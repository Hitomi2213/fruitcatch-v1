using UnityEngine;
using TMPro;
using NUnit.Framework.Constraints;
public class FruitsPoint : MonoBehaviour
{
    public TextMeshProUGUI FruitsCountText; //�A�C�e���J�E���g�\��
    private int FruitsCount;

    private void Start()
    {
        //�A�C�e���J�E���g�̏�����
        UpdateItemCountText();
    }

    void UpdateItemCountText()
    {
        //�J�E���g�����A�C�e������\��
        FruitsCountText.text = $"{FruitsCount}";
    }

    //�A�C�e�����擾�����Ƃ��̏���
    public void CollectItem()
    {
        FruitsCount += 1;
        UpdateItemCountText();
    }

}
