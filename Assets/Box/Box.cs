using UnityEngine;
using System.Collections;



/// <summary>
/// 容器生成器
/// </summary>
[ExecuteInEditMode]
public class Box : MonoBehaviour
{
    private static readonly string KEY = "box";
    /// <summary>
    /// 面板预设体
    /// </summary>
    public GameObject srcBox;
    /// <summary>
    /// 容器
    /// </summary>
    public GameObject parent;
    /// <summary>
    /// 内部矩形尺寸
    /// </summary>
    public float rectLength = 2, rectWidth = 1, rectHeight = 3;
    /// <summary>
    /// 厚度
    /// </summary>
    public float thickness = 0.1f;

    void Start ()
    {
        createBoxs();
        removeBoxs();
    }
	
	void Update ()
    {
#if UNITY_EDITOR
        if (srcBox == null || parent == null)
            return;
        removeBoxs();
        createBoxs();
#endif
    }


    private void createBoxs()
    {
        GameObject newBox;
        //forward
        newBox = (GameObject)Instantiate(srcBox, Vector3.zero, Quaternion.Euler(0, 0, 0), parent.transform);
        newBox.transform.localScale = new Vector3(rectLength + thickness * 2, rectHeight + thickness * 2, thickness);
        newBox.transform.localPosition = new Vector3(0, 0, -thickness/2);
        newBox.name = KEY;
        //backward
        newBox = (GameObject)Instantiate(srcBox, Vector3.zero, Quaternion.Euler(0, 0, 0), parent.transform);
        newBox.transform.localScale = new Vector3(rectLength + thickness * 2, rectHeight + thickness * 2, thickness);
        newBox.transform.localPosition = new Vector3(0, 0, rectWidth + thickness / 2);
        newBox.name = KEY;
        //left
        newBox = (GameObject)Instantiate(srcBox, Vector3.zero, Quaternion.Euler(0, 0, 0), parent.transform);
        newBox.transform.localScale = new Vector3(thickness, rectHeight + thickness * 2, rectWidth + thickness * 2);
        newBox.transform.localPosition = new Vector3(rectLength / 2 + thickness / 2, 0, rectWidth / 2);
        newBox.name = KEY;
        ////right
        newBox = (GameObject)Instantiate(srcBox, Vector3.zero, Quaternion.Euler(0, 0, 0), parent.transform);
        newBox.transform.localScale = new Vector3(thickness, rectHeight + thickness * 2, rectWidth + thickness * 2);
        newBox.transform.localPosition = new Vector3(-(rectLength / 2 + thickness / 2), 0, rectWidth / 2);
        newBox.name = KEY;
        //bottom
        newBox = (GameObject)Instantiate(srcBox, Vector3.zero, Quaternion.Euler(0, 0, 0), parent.transform);
        newBox.transform.localScale = new Vector3(rectLength + thickness * 2, thickness, rectWidth + thickness * 2);
        newBox.transform.localPosition = new Vector3(0, -rectHeight / 2 - thickness /2, rectWidth / 2);
        newBox.name = KEY;
    }


    private void removeBoxs()
    {
        GameObject go;
        while ( (go = GameObject.Find(KEY) )!= null)
        {
            DestroyImmediate(go);
        }
    }

    

}




