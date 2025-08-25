using UnityEngine;
using TMPro;

public class ResultDisplay : MonoBehaviour
{
    public TextMeshProUGUI AppleCountText;
    public TextMeshProUGUI GrapeCountText;
    public TextMeshProUGUI OrangeCountText;
    public TextMeshProUGUI TotalCountText;

    void Start()
    {
        // GameManagerからスコアを取得して表示
        AppleCountText.text = $"Apple: {GameManager.Instance.AppleScore}";
        GrapeCountText.text = $"Grape: {GameManager.Instance.GrapeScore}";
        OrangeCountText.text = $"Orange: {GameManager.Instance.OrangeScore}";
        TotalCountText.text = $"Total: {GameManager.Instance.TotalScore}";
    }
}
