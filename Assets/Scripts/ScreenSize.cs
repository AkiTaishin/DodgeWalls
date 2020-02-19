using UnityEngine;

public class ScreenSize : MonoBehaviour
{
    /// <summary>
    /// 目標の画面サイズ
    /// </summary>
    private float Width = 720.0f;
    private float Height = 1280.0f;

    /// <summary>
    /// 目標の比率に対する変化率
    /// </summary>
    private float AspectRatio = 0.0f;

    private void Start()
    {
        UpdateScreenRatio();
    }

#if UNITY_EDITOR
    private void Update()
    {
        UpdateScreenRatio();
    }
#endif

    /// <summary>
    /// 端末ごとにおけるスクリーン描画範囲の設定
    /// </summary>
    private void UpdateScreenRatio()
    {
        Camera MainCamera = Camera.main;

        // 仮アス比登録
        float Passing = Height / Width;
        // 実際のアス比
        float Aspect = (float)Screen.height / (float)Screen.width;

        // 仮アス比と比べて縦長のとき
        if (Passing > Aspect)
        {
            AspectRatio = Aspect / Passing;
            MainCamera.rect = new Rect((1 - AspectRatio) * 0.5f, 0, AspectRatio, 1.0f);

        }
        // 仮アス比と比べて横長のとき
        else
        {
            AspectRatio = Passing / Aspect;
            MainCamera.rect = new Rect(0, (1 - AspectRatio) * 0.5f, 1.0f, AspectRatio);
        }
    }
}
