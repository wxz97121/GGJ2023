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
        Text.text = "�Ͻ�/���� " + InArray[0].ToString() + "\n";
        Text.text += "����/���� " + InArray[1].ToString() + "\n";
        Text.text += "ľګ/���� " + InArray[2].ToString() + "\n";
        Text.text += "ִ��/���� " + InArray[3].ToString() + "\n";
        Text.text += "���޵���/���¸��� " + InArray[4].ToString() + "\n";
    }
}
