using System.Collections;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// 開始前のカウントダウン
/// </summary>
public class ReadyCheck : MonoBehaviour
{
    /// <summary>
    /// ステージ生成コルーチンを走らせるために取得
    /// </summary>
    [SerializeField] private CreatePrefabs Prefab = null;

    /// <summary>
    /// カウントダウンテキスト
    /// </summary>
    [SerializeField] private Text CountdownText = null;

    /// <summary>
    /// カウントダウンコルーチンを走らせる
    /// </summary>
    private Coroutine Count = null;
   

    private void Start()
    {
        // すでにコルーチンが走っていたらコルーチンを止める
        if (Count != null)
        {
            StopCoroutine(Count);
        }
        // コルーチン開始
        Count = StartCoroutine(Countdown());
    }


    /// <summary>
    /// カウントダウンを管理するコルーチン
    /// </summary>
    /// <returns>カウント</returns>
    private　IEnumerator Countdown()
    {      
        CountdownText.text = ("GetReady?");
        yield return new WaitForSeconds(1.0f);

        CountdownText.text = ("3");
        yield return new WaitForSeconds(1.0f);

        CountdownText.text = ("2");
        yield return new WaitForSeconds(1.0f);

        CountdownText.text = ("1");
        yield return new WaitForSeconds(1.0f);
      
        CountdownText.text = ("GO!!");
        yield return new WaitForSeconds(1.0f);

        // 時間経過でテキストを消す
        CountdownText.GetComponent<Text>().enabled = false;

        // ステージ生成コルーチンの実行
        StartCoroutine(Prefab.PrefabsCreate());
    }

}
