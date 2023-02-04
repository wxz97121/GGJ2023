using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LockPage : SingletonBase<LockPage>
{
    public Text TimeText;
    public Text DataText;
    public void SetTime(string Time)
    {
        TimeText.text = Time;
    }
    public void SetFriday()
    {
        DataText.text = "1��21�� ������";
    }
    public void SetSaturday()
    {
        DataText.text = "1��22�� ������";
    }
    public void SetSunday()
    {
        DataText.text = "1��23�� ������";
    }
}
