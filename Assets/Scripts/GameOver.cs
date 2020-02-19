using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ゲームオーバーメッセージの管理
/// </summary>
public class GameOver : MonoBehaviour
{
    [SerializeField] private Text GameOverMessage = null;

    public void ActiveGameOverMessage()
    {
        // 表示
        GameOverMessage.GetComponent<Text>().enabled = true;
    }
}
