using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FitMode = UnityEngine.UI.ContentSizeFitter.FitMode;

[ExecuteAlways]
public class BoxAutoHeight : MonoBehaviour
{
    public GameObject FitterObj;
    RectTransform Trans;
    // Start is called before the first frame update
    void Start()
    {
        Trans = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        float Height = GetPreferredSize(FitterObj).y + 25;
        Trans.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Height); 

    }

    //立即获取ContentSizeFitter的区域
    public Vector2 GetPreferredSize(GameObject obj)
    {
        LayoutRebuilder.ForceRebuildLayoutImmediate(obj.GetComponent<RectTransform>());
        return new Vector2(HandleSelfFittingAlongAxis(0, obj), HandleSelfFittingAlongAxis(1, obj));
    }
    //获取宽和高
    private float HandleSelfFittingAlongAxis(int axis, GameObject obj)
    {
        FitMode fitting = (axis == 0 ? obj.GetComponent<ContentSizeFitter>().horizontalFit : obj.GetComponent<ContentSizeFitter>().verticalFit);
        if (fitting == FitMode.MinSize)
        {
            return LayoutUtility.GetMinSize(obj.GetComponent<RectTransform>(), axis);
        }
        else
        {
            return LayoutUtility.GetPreferredSize(obj.GetComponent<RectTransform>(), axis);
        }
    }
}
