using UnityEngine;

public class TouchProcess : MonoBehaviour
{
    /// <summary>
    /// 何度も使うことになりそうなので
    /// </summary>
    [SerializeField] private new Camera camera = null;
    [SerializeField] private Ring Center = null;

    [SerializeField] private Judgement judgement1 = null;
    [SerializeField] private Judgement judgement2 = null;

    /// <summary>
    /// 範囲チェック用
    /// </summary>
    private bool TouchPosition = false;

    /// <summary>
    /// タッチ許容範囲
    /// </summary>
    private readonly float LimitMatrix = -1.0f;

    private void Update()
    {      
        // ゲームオーバーしていないとき
        if (!judgement1.IsGameOver && !judgement2.IsGameOver)
        {
            // クリックされた瞬間の処理
            KeyDownMoment();
            // クリックされている間の処理
            KeyPressMoment();
        }      
    }

   
    private void KeyDownMoment()
    {
        /// ユーザーが最初にクリックした座標が範囲内かどうか        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {     
            // trueのまま進行しないように一時的にfalseに戻す
            TouchPosition = false;

            // マウスポジションを取得してワールド座標に変換
            var WorldPos = GetWorldPosition();

            // 高さがタッチ許容範囲だったら
            if (WorldPos.y < LimitMatrix)
            {
                TouchPosition = true;

                // 現在の座標を更新
                var CenterPos = WorldPos - Center.transform.position;

                // 子供とお別れ
                Center.RemoveCompornent();

                // 親の向きをLookRotationを使って回転させる
                // WorldPosのほうに回転
                Center.transform.rotation = Quaternion.LookRotation(CenterPos, Vector3.back);

                // 子供との再会
                Center.GetChildren();
            }
        }
    }

    
    /// <summary>
    /// スワイプ時の操作
    /// </summary>
    private void KeyPressMoment()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (TouchPosition)
            {
                // マウスポジションを取得してワールド座標に変換
                var WorldPos = GetWorldPosition();

                // タッチ許容範囲の場合
                if (WorldPos.y < LimitMatrix)
                {
                    // 真ん中のリングを操作
                    var CenterPos = WorldPos - Center.transform.position;

                    // 子供も一緒に回す
                    // 円形補間
                    Center.transform.rotation = Quaternion.Slerp(Center.transform.rotation, Quaternion.LookRotation(CenterPos, Vector3.back), 0.1f);
                }
                else
                {
                    // スワイプ中に範囲外から出てしまった場合
                    TouchPosition = false;
                }
            }
        }
    }

    /// <summary>
    /// マウスポジションをワールド座標に変換
    /// </summary>
    /// <returns>WorldPos</returns>
    public Vector3 GetWorldPosition()
    {
        // マウス座標を一時保管
        var MousePos = Input.mousePosition;
        // カメラのZ軸に合わせる
        MousePos.z = 3.0f;
        // ワールド座標に変換
        var WorldPos = camera.ScreenToWorldPoint(MousePos);

        return WorldPos;
    }
}
