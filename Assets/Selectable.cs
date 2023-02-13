using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Selectable : MonoBehaviour
{
    public Image SelectedIcon;
    public TextMeshProUGUI MyText;
    bool isSelected = false;
    public bool CanBeSelect = false;
    public (string, int) Value;
    // Start is called before the first frame update
    public void OnClick(bool Force = false)
    {
        if (!Force && !CanBeSelect) return;
        isSelected = !isSelected;
        if (isSelected)
        {
            Level.Instance.SelectedObjects.Add(this);
            SelectedIcon.color = Color.white;
        }
        else
        {
            Level.Instance.SelectedObjects.Remove(this);
            SelectedIcon.color = Color.clear;
        }
    }

    public bool GetIsSelected()
    {
        return isSelected;
    }

    public void SetValue(string str,int num)
    {
        Value = (str, num);
        MyText.text = str + "\n" + num.ToString() + "Ç§×Ö";
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
