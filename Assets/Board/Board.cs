using UnityEngine;
using System.Collections;



/// <summary>
/// 底部挡板生成器
/// </summary>
[ExecuteInEditMode]
public class Board : MonoBehaviour
{
    private static readonly string KEY = "board_";
    /// <summary>
    /// 面板预设体
    /// </summary>
    public GameObject srcBoard;
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
    public float itvlX = 0.5f;
    /// <summary>
    /// x起始位置
    /// </summary>
    public float startX = 1f;

    void Start ()
    {
        removeBoards();
        createBoards();
    }
	
	void Update ()
    {
#if UNITY_EDITOR
        if (srcBoard == null || parent == null)
            return;
        removeBoards();
        createBoards();
#endif
    }



    private void createBoards()
    {
        Vector3 pos = new Vector3(startX, 0, 0);
        Quaternion rot = Quaternion.Euler(0, 0, 0);
        GameObject newBoard;

        for( int i = 0; i < count;  ++i )
        {
            newBoard = (GameObject)Instantiate(srcBoard, Vector3.zero, rot, parent.transform);
            newBoard.name = KEY + i.ToString();
            newBoard.transform.localPosition = pos;
            pos.x += itvlX;
        }
    }

    private void removeBoards()
    {
        Transform tf;
        while (parent.transform.childCount > 0)
        {
            tf = parent.transform.GetChild(0);
            DestroyImmediate(tf.gameObject);
        }
    }

}
