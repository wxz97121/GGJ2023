using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController : SingletonBase<CharacterController>
{
    public Text InputBoxText;
    public List<Character> AllFloatings;
    public Character DeleteButton;
    public List<string> SelectStrs;
    public List<bool> HasUsedStrs;
    public Coroutine WorkCorutine;
    public Coroutine WorkCorutine2;
    public int MinNumChars = 7;
    public GameObject CharacterPrefab;
    public Transform SpawnParentTransform;
    public bool IncludeDelButton;
    public int OldLength = 0;
    public int NumsAllowNext = 4;
    //public string LastStr;
    public float MaxUpdateTime = 5;
    public float MinUpdateTime = 1;
    public bool InOrder = false;
    public bool IsPausing = false;
    // Start is called before the first frame update
    void Start()
    {
        InputBoxText = GetComponentInChildren<Text>();
    }

    public int FindStr(int CurrentChar)
    {

        if (InOrder)
        {
            for (int i = 0; i < SelectStrs.Count; i++)
                if (!HasUsedStrs[i]) return i;
            return 0;
        }
        else
        {
            int res = 0;
            do
            {
                //只有满足条件的时候才会刷新标点符号。
                int SelectableRange = SelectStrs.Count - 1;
                if (InputBoxText.text.Length - OldLength >= NumsAllowNext || SelectStrs.Count <= 1) SelectableRange++;
                res = Random.Range(0, SelectableRange);
            } while (HasUsedStrs[res] == true);
            return res;
        }
    }

    public void AddStr(string StrToAdd)
    {
        if (IsPausing) return;
        InputBoxText.text += StrToAdd;
        //LastStr = StrToAdd;
    }

    public string GetLastStr()
    {
        if (InputBoxText.text.Length <= 0) return "";
        char ch = InputBoxText.text[InputBoxText.text.Length - 1];
        return new string(ch, 1);
    }

    public void RemoveLastChar(int Nums = 1)
    {
        if (IsPausing) return;
        if (InputBoxText.text.Length > OldLength)
        {
            HasUsed -= Nums;
            for(int i=1;i<=Nums;i++)
            {
                //TODO 现在的代码只适合 str.length == 1
                for (int j = 0; j<SelectStrs.Count;j++)
                {
                    var str = SelectStrs[j];
                    if (str[0] == InputBoxText.text[InputBoxText.text.Length - Nums])
                    {
                        HasUsedStrs[j] = false;
                        print("Debug Test " + SelectStrs[j]);
                        break;
                    }


                }

            }
            InputBoxText.text = InputBoxText.text.Substring(0, InputBoxText.text.Length - Nums);
        }
    }

    public void Pause()
    {
        IsPausing = true;
    }


    // InNum 表示场上最多有多少个漂浮字
    // InAllow 表示输入多少个字之后允许输入标点
    // 默认传入的最后一个字符是终止符，即标点符号。
    public void ReStart(List<string> InSelect, int InNum, bool InDelButton, float InMinTime, float InMaxTime, int InAllow = 4)
    {
        StopWorking();
        IsPausing = false;
        InOrder = false;
        OldLength = InputBoxText.text.Length;
        SelectStrs = InSelect;
        HasUsedStrs = new List<bool>();
        HasUsed = 0;
        for (int i = 0; i < SelectStrs.Count; i++)
            HasUsedStrs.Add(false);

        MinNumChars = InNum;
        MinUpdateTime = InMinTime;
        MaxUpdateTime = InMaxTime;
        NumsAllowNext = InAllow;
        IncludeDelButton = InDelButton;
        WorkCorutine = StartCoroutine(Working());
        WorkCorutine2 = StartCoroutine(Working_SelectStr());
    }


    public IEnumerator ForceStop(float WaitTime)
    {
        if (WorkCorutine != null)
            StopCoroutine(WorkCorutine);
        if (WorkCorutine2 != null)
            StopCoroutine(WorkCorutine2);
        DeleteButton?.Pause();
        foreach (var Char in AllFloatings)
        {
            Char?.Pause();
        }
        yield return new WaitForSeconds(WaitTime - 0.1f);
        DeleteButton?.ForceEndSelf();
        foreach (var Char in AllFloatings)
        {
            Char?.ForceEndSelf();
        }
    }

    public void StopWorking()
    {
        if (WorkCorutine != null)
            StopCoroutine(WorkCorutine);
        if (WorkCorutine2 != null)
            StopCoroutine(WorkCorutine2);

        foreach (var Char in AllFloatings)
        {
            Char?.EndSelf();
            DeleteButton?.EndSelf();
        }
        AllFloatings.Clear();
        DeleteButton = null;
    }

    IEnumerator Working()
    {
        yield return new WaitForSeconds(2);
        while (true)
        {
            yield return new WaitForSeconds(0.2f);

            if (IncludeDelButton && (DeleteButton == null || DeleteButton.MyState == CharState.Dragging))
            {
                var go = Instantiate(CharacterPrefab, SpawnParentTransform);
                go.GetComponent<Character>().StartWorking("DELETE");
                DeleteButton = go.GetComponent<Character>();
            }

        }
    }

    int HasUsed = 0;
    IEnumerator Working_SelectStr()
    {
        yield return new WaitForFixedUpdate();
        while (true)
        {
            int CurrentChar = 0;
            foreach (var Char in AllFloatings)
            {
                if (Char != null && Char.MyState != CharState.Dropped) CurrentChar++;
            }
            if (CurrentChar < MinNumChars && HasUsed < SelectStrs.Count)
            {
                var go = Instantiate(CharacterPrefab, SpawnParentTransform);

                int index = FindStr(CurrentChar);
                HasUsedStrs[index] = true;
                HasUsed++;
                var str = SelectStrs[index];
                go.GetComponent<Character>().StartWorking(str);
                AllFloatings.Add(go.GetComponent<Character>());
            }
            float WaitSeconds = Random.Range(MinUpdateTime, MaxUpdateTime);
            float Multi = Mathf.Lerp(0.4f, 1, Mathf.Clamp01((float)CurrentChar / MinNumChars));
            if (float.IsNaN(Multi))
                Multi = 1;

            yield return new WaitForSeconds(Multi * WaitSeconds);
        }
    }

}
