using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    // タイトル用のテキスト
    [SerializeField] private Text GameStartMessage = null;

    private void Update()
    { 
        // 入力でゲーム画面に遷移
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameStartMessage.GetComponent<Text>().enabled = false;
            SceneManager.LoadScene("Game");
        }
    }
}
