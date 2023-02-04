using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.UI;

public class FloatBox : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    //状态——未出现，出现，指针进入，变大等待点击，被点击后消失
    public enum BoxState
    {
        NotAppeared = 0,
        Appeared = 1,
        HasEntered = 2,
        CanClick = 3,
        HasClicked = 4
    }
    public bool CanBeClick = true;
    public string ReplyText;
    static float Layer = 1;
    //public bool HasEntered = false;
    //public bool HasPrepareEntered = false;
    Tween ScaleTween;
    BoxState MyState = BoxState.NotAppeared;

    public BoxState GetState()
    {
        return MyState;
    }

    public void StartWorking()
    {
        MyState = BoxState.Appeared;
        transform.DOShakePosition(2, fadeOut: false).SetLoops(-1);
        transform.DOShakeRotation(3, 15, fadeOut: false).SetLoops(-1);
        ScaleTween = transform.DOShakeScale(4, 0.15f, 3, fadeOut: false).SetLoops(-1);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (MyState != BoxState.Appeared) return;
        if (!CanBeClick) return;
        transform.DOMoveZ(Layer++, 0.15f);
        MyState = BoxState.HasEntered;
        ScaleTween.Kill();
        StartCoroutine(CWhenEntered());
        //Destroy(gameObject, 3f);
    }
    IEnumerator CWhenEntered()
    {
        ScaleTween?.Kill();
        ScaleTween = transform.DOScale(new Vector3(1.75f, 1.75f, 1.75f), 2.5f).SetEase(Ease.InOutElastic);
        GetComponentInChildren<Text>()?.DOText(ReplyText, 0.5f);
        GetComponent<Image>()?.DOColor(Color.black, 0.5f);
        GetComponentInChildren<Text>()?.DOColor(Color.white, 0.5f);
        yield return new WaitForSeconds(2.5f);
        MyState = BoxState.CanClick;

    }
    public FloatBox SetText(string s)
    {
        GetComponentInChildren<Text>().text = s;
        return this;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (MyState != BoxState.CanClick) return;
        if (!CanBeClick) return;
        MyState = BoxState.HasClicked;
        HideSelf();
    }
    public void HideSelf()
    {
        ScaleTween?.Kill();
        transform.DOScale(Vector3.zero, 0.5f);
        if (CanBeClick)
        {
            if (GetComponent<Image>())
                GetComponent<Image>().color = Color.clear;
            if (GetComponentInChildren<Text>())
                GetComponentInChildren<Text>().color = Color.clear;
        }
        Destroy(gameObject, 2.5f);
    }
    //IEnumerator CWhenClicked()
    //{

    //}
}
