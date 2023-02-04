using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugFactor : MonoBehaviour
{
    TMPro.TextMeshProUGUI Text;
    // Start is called before the first frame update
    void Start()
    {
        Text = GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateUI(float[] InArray)
    {
        Text.text = "严谨/乐子 " + InArray[0].ToString() + "\n";
        Text.text += "保守/激进 " + InArray[1].ToString() + "\n";
        Text.text += "木讷/感性 " + InArray[2].ToString() + "\n";
        Text.text += "执行/创造 " + InArray[3].ToString() + "\n";
        Text.text += "毫无底线/道德高尚 " + InArray[4].ToString() + "\n";
    }
}
