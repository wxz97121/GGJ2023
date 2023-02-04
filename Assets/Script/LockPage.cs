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
        DataText.text = "1月21日 星期五";
    }
    public void SetSaturday()
    {
        DataText.text = "1月22日 星期六";
    }
    public void SetSunday()
    {
        DataText.text = "1月23日 星期日";
    }
}
