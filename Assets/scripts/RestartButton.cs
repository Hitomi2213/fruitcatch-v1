using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class RestartButton : MonoBehaviour
{
    [SerializeField]
    private Button restartButton; //リスタートボタンを設定するための変数

    // Start is called before the first frame update
    void Start()
    {
        //リスタートボタンがクリックされたときにRestartGameメソッドを呼び出す
        restartButton.onClick.AddListener(RestartGame);
    }

    void RestartGame() //ゲームやり直しメソッド
    {
        //現在のシーンの再読み込みしてゲームを再スタート
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
