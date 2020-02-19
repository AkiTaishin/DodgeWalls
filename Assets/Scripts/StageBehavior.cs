using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// ステージの動きに関する管理をつかさどる
/// </summary>
public class StageBehavior : MonoBehaviour
{
    /// <summary>
    /// 落下スピード用
    /// </summary>
    private Vector3 Speed = new Vector3(0.0f, -3.0f, 0.0f);

    /// <summary>
    /// プレファブ取得用
    /// </summary>
    private CreatePrefabs Prefabs = null;

    /// <summary>
    /// 遷移時のダブルチェック用
    /// これがないと一瞬でタイトル→ゲームに遷移してしまう場合がある
    /// </summary>
    private bool DoubleCheck = false;
   

    /// <summary>
    /// prefabを取得
    /// </summary>
    /// <param name="fab">ステージプレファブ</param>
    public void Initialize(CreatePrefabs fab)
    {
        Prefabs = fab;      
    }

    /// <summary>
    /// ステージの動き
    /// </summary>
    private void Update()
    {
        // 非ゲームオーバー時
        if (!Prefabs.IsGameOver())
        {
            // 落ちる
            gameObject.transform.Translate(Speed * Time.deltaTime);

            // 一定以下の座標になったら、そのステージプレファブを削除
            if (gameObject.transform.position.y < -15.0f)
            {
                Destroy(gameObject);
            }
        }
        // ゲームオーバーになったら
        else
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                // 一瞬で遷移するのを防止
                DoubleCheck = true;
            }
            if (DoubleCheck)
            {
                if (Input.GetKeyUp(KeyCode.Mouse0))
                {
                    // 画面上に存在するすべてのステージプレファブ削除
                    // タイトルに遷移
                    Destroy(gameObject);
                    SceneManager.LoadScene("Title");
                }
            }
        }
    }
}
