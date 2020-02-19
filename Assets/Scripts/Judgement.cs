using UnityEngine;


/// <summary>
/// 接触判定をつかさどる
/// </summary>
public class Judgement : MonoBehaviour
{
    /// <summary>
    /// ゲームオーバーメッセージ
    /// </summary>
    [SerializeField] private GameOver GameOverMessage = null;

    /// <summary>
    ///  接触が確認されたらゲームオーバーフラグがTに
    /// </summary>
    public bool IsGameOver = false;


    /// <summary>
    /// 接触判定
    /// </summary>
    /// <param name="other">当たったもの</param>
    public void OnTriggerEnter(Collider other)
    {
        // プレイヤーがステージに接触したら
        if (other.gameObject.tag == ("Stage"))
        {
            // ゲームオーバー
            IsGameOver = true;
            GameOver();
        }
    }

    //@todo すり抜け判定


    /// <summary>
    /// ゲームオーバーメッセージ表示
    /// </summary>
    public void GameOver()
    {
        GameOverMessage.ActiveGameOverMessage();
    }

}
