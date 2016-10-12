using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class Ball : MonoBehaviour
{
    private static readonly string KEY = "ball";
    /// <summary>
    ///  小球预设体
    /// </summary>
    public GameObject srcBall;
    /// <summary>
    /// 容器
    /// </summary>
    public GameObject parent;
    /// <summary>
    /// 生成数量
    /// </summary>
    public int count = 3;
    /// <summary>
    /// 时间间隔
    /// </summary>
    public float itvl = 0.5f;
    /// <summary>
    /// x起始位置
    /// </summary>
    public float startX = 1f;
    /// <summary>
    /// 已经创建的数量
    /// </summary>
    private int createdCount = 0;

    void Start()
    {
        removeBalls();
        InvokeRepeating("createBalls", itvl, itvl);
    }

    void Update ()
    {
    }

    private void createBalls()
    {
        Vector3 pos = new Vector3(Random.Range(-0.1f, 0.1f), 3, 0.25f + Random.Range(-0.1f, 0.1f));
        //Vector3 pos = new Vector3(0.4f, 3, 0.2f + 0);
        Quaternion rot = Quaternion.Euler(0, 0, 0);
        GameObject newBall = (GameObject)Instantiate(srcBall, Vector3.zero, rot);
        newBall.name = KEY;
        newBall.transform.localPosition = pos;
        if ( ++createdCount == count)
            CancelInvoke("createBalls");
    }

    private void removeBalls()
    {
        GameObject go;
        while ((go = GameObject.Find(KEY)) != null)
        {
            DestroyImmediate(go);
        }
        CancelInvoke("createBalls");
    }


}
