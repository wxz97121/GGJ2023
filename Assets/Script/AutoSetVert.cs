using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoSetVert : MonoBehaviour
{
    RectTransform Trans;
    ContentSizeFitter Fitter;
    // Start is called before the first frame update
    void Start()
    {
        Trans = GetComponent<RectTransform>();
        Fitter = GetComponent<ContentSizeFitter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Trans.anchoredPosition.y > 200000)
            Trans.anchoredPosition = new Vector2(Trans.anchoredPosition.x, 0);
        if (Trans.lossyScale.magnitude > 1e-6)
        {
            if (Trans)
                LayoutRebuilder.ForceRebuildLayoutImmediate(Trans);
            Fitter?.SetLayoutVertical();
        }
    }
}
