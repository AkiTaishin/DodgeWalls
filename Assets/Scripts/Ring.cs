using UnityEngine;

public class Ring : MonoBehaviour
{
    /// <summary>
    /// 子供たち
    /// </summary>
    [SerializeField] public GameObject ChildObjectR = null;
    [SerializeField] public GameObject ChildObjectL = null;

    /// <summary>
    /// 子供たちとのお別れ
    /// </summary>
    public void RemoveCompornent()
    {
        gameObject.transform.DetachChildren();
    }

    /// <summary>
    /// 子供たちとの再会
    /// </summary>
    public void GetChildren() 
    {
        ChildObjectR.transform.parent = gameObject.transform;
        ChildObjectL.transform.parent = gameObject.transform;
    }
    
}
