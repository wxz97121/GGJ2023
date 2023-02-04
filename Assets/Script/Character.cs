using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public enum CharState
{
    Floating = 0,
    Dragging = 1,
    Dropped = 2,
    PreSpawn = 3,
    ForceDie = 4
}

public class Character : MonoBehaviour, IPointerClickHandler
{
    public Vector2 Speed;
    public float RotateSpeed;
    public float MinX, MaxX, MinY, MaxY;
    RectTransform m_Trans;
    Text m_Text;
    Image m_Image;
    public float MinRotate = 5, MaxRotate = 30;
    public float MinReflectSpeed = 10, MaxReflectSpeed = 30;
    public float OtherMaxSpeed = 10;
    public CharState MyState;
    public Sprite DeleteSprite;
    public bool IsDeleteChar = false;
    string Content;
    public float MultiInner = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        m_Trans = GetComponent<RectTransform>();
        m_Text = GetComponentInChildren<Text>();
        m_Image = GetComponent<Image>();
    }


    public bool IsDropped()
    {
        return MyState == CharState.Dropped;
    }

    public void StartWorking(string Text)
    {
        Start();
        MyState = CharState.PreSpawn;
        if (Text != "DELETE")
        {
            IsDeleteChar = false;
            m_Text.text = Content = Text;
        }
        else
        {
            IsDeleteChar = true;
            m_Text.text = "";
            m_Image.sprite = DeleteSprite;
        }
        m_Trans.anchoredPosition = new Vector2(Random.Range(MinX + 5, MaxX - 5), MaxY + 50);
        RotateSpeed = Random.Range(MinRotate, MaxRotate);
        Speed = new Vector2(0, Random.Range(-MinReflectSpeed, -MaxReflectSpeed));
    }
    public void Pause()
    {
        if (MyState == CharState.PreSpawn || MyState == CharState.Floating)
        {
            MyState = CharState.ForceDie;
            RotateSpeed = 0;
            Speed = Vector2.zero;
        }
    }

    public void ForceEndSelf()
    {
        if (MyState == CharState.PreSpawn || MyState == CharState.Floating || MyState == CharState.ForceDie)
        {
            MyState = CharState.ForceDie;
            RotateSpeed = 120;
            Speed = new Vector2(0, MaxReflectSpeed * 2f);
            if (this != null && gameObject)
                Destroy(gameObject, 2.5f);
        }
        else
        {
            if (this != null && gameObject)
                Destroy(gameObject, 2f);
        }
    }


    public void EndSelf()
    {
        if (MyState == CharState.PreSpawn || MyState == CharState.Floating)
        {
            MyState = CharState.Dropped;
            m_Trans?.DOScale(Vector3.zero, 1);
            if (gameObject)
                Destroy(gameObject, 1.5f);
        }
        else
        {
            if (this != null && gameObject)
                Destroy(gameObject, 1.5f);
        }
    }

    private void FixedUpdate()
    {
        if (MyState == CharState.Floating || MyState == CharState.PreSpawn || MyState == CharState.ForceDie)
        {
            if (m_Trans)
            {
                Vector2 FinalSpeed = Speed;
                FinalSpeed *= new Vector2(Mathf.Lerp(MultiInner, 1, Mathf.Clamp01(Mathf.Abs(m_Trans.anchoredPosition.x) / MaxX)), 1);
                FinalSpeed *= new Vector2(1, Mathf.Lerp(MultiInner, 1, Mathf.Clamp01(Mathf.Abs(m_Trans.anchoredPosition.y) / MaxY)));
                m_Trans.anchoredPosition += FinalSpeed * Time.fixedDeltaTime;
                if (!IsDeleteChar)
                    m_Trans.Rotate(0, 0, RotateSpeed * Time.fixedDeltaTime);
                m_Text.rectTransform.rotation = Quaternion.identity;
            }
            float X = m_Trans.anchoredPosition.x;
            float Y = m_Trans.anchoredPosition.y;

            if (X < MinX)
            {
                RotateSpeed = Random.Range(MinRotate, MaxRotate);
                Speed = new Vector2(Random.Range(MinReflectSpeed, MaxReflectSpeed), Random.Range(-OtherMaxSpeed, OtherMaxSpeed));
                m_Trans.anchoredPosition.Set(MinX + 1f, m_Trans.anchoredPosition.y);
            }
            else if (X > MaxX)
            {
                RotateSpeed = Random.Range(MinRotate, MaxRotate);
                Speed = new Vector2(-Random.Range(MinReflectSpeed, MaxReflectSpeed), Random.Range(-OtherMaxSpeed, OtherMaxSpeed));
                m_Trans.anchoredPosition.Set(MaxX - 1f, m_Trans.anchoredPosition.y);
            }
            else if (Y < MinY)
            {
                if (MyState == CharState.PreSpawn) MyState = CharState.Floating;
                RotateSpeed = Random.Range(MinRotate, MaxRotate);
                Speed = new Vector2(Random.Range(-OtherMaxSpeed, OtherMaxSpeed), Random.Range(MinReflectSpeed, MaxReflectSpeed));
                m_Trans.anchoredPosition.Set(m_Trans.anchoredPosition.x, MinY + 1f);
            }
            else if (Y > MaxY && MyState != CharState.PreSpawn && MyState != CharState.ForceDie)
            {
                RotateSpeed = Random.Range(MinRotate, MaxRotate);
                Speed = new Vector2(Random.Range(-OtherMaxSpeed, OtherMaxSpeed), -Random.Range(MinReflectSpeed, MaxReflectSpeed));
                m_Trans.anchoredPosition.Set(m_Trans.anchoredPosition.x, MaxY - 1f);
            }
        }

    }


    public void OnPointerClick(PointerEventData eventData)
    {
        if (MyState == CharState.Floating || MyState == CharState.PreSpawn)
        {
            MyState = CharState.Dragging;
            var Tween = m_Trans.DOAnchorPos(new Vector2(0, -550), IsDeleteChar ? 0.25f : 0.75f);
            m_Trans?.DOScale(Vector3.zero, IsDeleteChar ? 0.25f : 0.75f);
            Tween.OnComplete(() =>
            {
                if (IsDeleteChar) CharacterController.Instance.RemoveLastChar();
                else CharacterController.Instance.AddStr(Content);
                MyState = CharState.Dropped; if (this != null && gameObject) Destroy(gameObject, 1);
            });
        }
    }
}
