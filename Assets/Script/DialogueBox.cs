using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DialogueBox : MonoBehaviour
{
    Text Name;
    Image Icon;
    Text ChatContent;
    ContentSizeFitter Fitter, ParentFitter;
    public ScrollRect ParentScroll;
    float CachedHeight;
    private void Start()
    {
        Name = transform.Find("Ãû×Ö").GetComponent<Text>();
        Icon = transform.Find("Í·Ïñ").GetComponent<Image>();
        ChatContent = transform.Find("ÁÄÌìµ×¿ò").GetComponentInChildren<Text>();
        Fitter = GetComponentInChildren<ContentSizeFitter>();
        ParentFitter = GetComponentInParent<ContentSizeFitter>();
        print(ParentFitter.gameObject);
    }

    public void SetName(string InName)
    {
        Name.text = InName;
    }

    public void SetIcon(Sprite InIcon)
    {
        Icon.overrideSprite = InIcon;
    }

    bool IsMoving = false;
    IEnumerator DelaySet()
    {
        if (IsMoving) yield return null;
        else
        {
            IsMoving = true;
            yield return new WaitForSeconds(0.08f);
            ParentScroll?.DOVerticalNormalizedPos(0, 0.15f);
            IsMoving = false;
        }
    }

    private void Update()
    {
        if (TextTween != null && TextTween.active)
        {
            Fitter?.SetLayoutVertical();
            //ParentFitter?.SetLayoutVertical();
        }
        if (ChatContent && StartSetting && ChatContent.preferredHeight > CachedHeight)
        {
            StartCoroutine(DelaySet());
            CachedHeight = ChatContent.preferredHeight;
        }
    }
    Tween TextTween;
    bool StartSetting;
    public IEnumerator SetContent(string Text, float Time)
    {
        StartSetting = true;
        CachedHeight = ChatContent.preferredHeight;
        if (Time < 0) Time = Text.Length * 0.1f;
        TextTween = ChatContent.DOText(Text, Time, true).SetEase(Ease.Linear);
        yield return new WaitForSeconds(Time);
        StartSetting = false;
        //ChatContent.text = new string(' ', Text.Length);
        //yield return new WaitForFixedUpdate();
        //for (int i = 0; i < Text.Length; i++)
        //{
        //    ChatContent.te
        //}
    }
}
