using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class AlarmPage : SingletonBase<AlarmPage>
{
    bool B1, B2, B3;
    bool Ani1, Ani2, Ani3;
    bool IsLocked = false;
    public Image I1, I2, I3;
    public void ToogleB1()
    {
        if (Ani1 || IsLocked) return;
        B1 = !B1;
        float TargetAlpha = B1 ? 1 : 0;
        I1.DOFade(TargetAlpha, 0.2f);

    }
    public void ToogleB2()
    {
        if (Ani2 || IsLocked) return;
        B2 = !B2;
        float TargetAlpha = B2 ? 1 : 0;
        I2.DOFade(TargetAlpha, 0.2f);

    }
    public void ToogleB3()
    {
        if (Ani3 || IsLocked) return;
        B3 = !B3;
        float TargetAlpha = B3 ? 1 : 0;
        I3.DOFade(TargetAlpha, 0.2f);

    }

    public bool AllReady()
    {
        return B1 & B2 & B3;
    }

    public bool AllNotReady()
    {
        return ((!B1) & (!B2) & (!B3));
    }

    public void ToogleLock(bool InIsLock)
    {
        if (InIsLock != IsLocked)
            IsLocked = InIsLock;
    }

    public void SetAllNotReady()
    {
        if (B1) ToogleB1();
        if (B2) ToogleB2();
        if (B3) ToogleB3();

    }


}
