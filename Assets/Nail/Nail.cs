using UnityEngine;
using System.Collections;




[ExecuteInEditMode]
public class Nail : MonoBehaviour
{
    private static readonly string KEY = "nail_";
    /// <summary>
    /// 钉子预设体
    /// </summary>
    public GameObject srcNail;
    /// <summary>
    /// 容器
    /// </summary>
    public GameObject parent;
    /// <summary>
    /// 生成数量
    /// </summary>
    public int count = 3;
    /// <summary>
    /// 间隔
    /// </summary>
    public float itvlX = 0.5f, itvlY = 0.1f;
    /// <summary>
    /// x起始位置
    /// </summary>
    public float startX = 1f;



    void Start ()
    {
        removeNails();
        createNails();
    }
	
	void Update ()
    {
#if UNITY_EDITOR
        if (srcNail == null || parent == null)
            return;
        removeNails();
        createNails();
#endif
    }

    private void createNails()
    {
        Vector3 pos;
        Quaternion rot = Quaternion.Euler(90, 0, 0);
        GameObject newNail;

        for (int level = 0; level < count; ++level)
        {
            pos = new Vector3(startX, itvlY*level, 0);
            for (int index = 0; index < count - level; ++index)
            {
                newNail = (GameObject)Instantiate(srcNail, Vector3.zero, rot, parent.transform);
                newNail.name = KEY + level + "_" + index;
                newNail.transform.localPosition = pos + new Vector3(itvlX/2*level, 0);
                pos.x += itvlX;
            }
        }
    }

    private void removeNails()
    {
        Transform tf;
        while(parent.transform.childCount > 0 )
        {
            tf = parent.transform.GetChild(0);
            DestroyImmediate(tf.gameObject);
        }
    }
}
