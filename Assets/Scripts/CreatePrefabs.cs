using System.Collections;
using UnityEngine;

public class CreatePrefabs : MonoBehaviour
{
    /// <summary>
    /// 判定用にふたつ
    /// </summary>
    [SerializeField] private Judgement judgement1 = null;
    [SerializeField] private Judgement judgement2 = null;

    /// <summary>
    /// Prefab生成用
    /// </summary>
    [SerializeField] private GameObject[] Stage = null;

    /// <summary>
    /// Prefab生成こるーちんに使用
    /// </summary>
    private Coroutine Creater = null;

    /// <summary>
    /// コルーチンオブジェクト取得用
    /// </summary>
    private GameObject GetPrefab = null;


    /// <summary>
    /// コルーチンを走らせる
    /// </summary>
    private void Start()
    {
        if (Creater != null)
        {
            StopCoroutine(Creater);
        }
    }


    /// <summary>
    /// ステージの生成を担う。
    /// ゲームオーバーになったら生成終了。
    /// </summary>
    /// <returns>4.5s間隔に生成</returns>
    public IEnumerator PrefabsCreate()
    {
        while (!IsGameOver())
        {
            for (int i = 0; i < 9; i++)
            {
                GetPrefab = Instantiate(Stage[i], this.transform);

                // 終了フラグを渡すためのやつ
                GetPrefab.GetComponent<StageBehavior>().Initialize(this);

                // 親の座標のローカルに生成
                GetPrefab.transform.localPosition = Vector3.zero;

                yield return new WaitForSeconds(4.5f);

                if (IsGameOver())
                    break;
            }
        } 
    }


    /// <summary>
    /// ゲームオーバーフラグを渡す
    /// </summary>
    /// <returns>IsGameOver</returns>
    public bool IsGameOver()
    {
        return judgement1.IsGameOver || judgement2.IsGameOver;
    }
}
