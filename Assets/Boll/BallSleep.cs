using UnityEngine;
using System.Collections;

/// <summary>
/// 球体的状态监听器
/// 单球体趋于稳定后，将刚体设置为休眠状态，减少物理引擎的计算
/// </summary>
public class BallSleep : MonoBehaviour
{
    /// <summary>
    /// 最小移动距离
    /// 如果两针内的距离小于这个值，就被判定为没有移动
    /// </summary>
    public static readonly float MIN_DIST = 0.001f;
    /// <summary>
    /// 最小移动距离的连续次数
    /// 达到这个次数后，将销毁刚体组件
    /// </summary>
    public static readonly int MAX_COUNT = 40;
    /// <summary>
    /// 刚体组件
    /// </summary>
    private Rigidbody rightBody;
    /// <summary>
    /// 上一帧的位置
    /// </summary>
    private Vector3 prePos;
    /// <summary>
    /// 连续满足条件的次数
    /// </summary>
    private int count;

	void Start ()
    {
        rightBody = GetComponent<Rigidbody>();
        prePos = transform.position;
    }
	
	void Update ()
    {
        Vector3 newPos = transform.position;
        float dist = Vector3.Distance(newPos, prePos);
        prePos = newPos;
        //Debug.Log(dist + ">>" + count);
        count = (dist < MIN_DIST) ? count + 1 : 0;
        if (count > MAX_COUNT)
        {
            Destroy(rightBody);
            Destroy(this);
        }
	}
}
