using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SingletonBase<T> : MonoBehaviour where T : MonoBehaviour
{
    private static object _singletonLock = new object();

    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_singletonLock)
                {
                    T[] singletonInstances = FindObjectsOfType(typeof(T)) as T[];
                    if (singletonInstances.Length == 0) return null;

                    if (singletonInstances.Length > 1)
                    {
                        if (Application.isEditor)
                            Debug.LogWarning(
                                "MonoSingleton<T>.Instance: Only 1 singleton instance can exist in the scene. Null will be returned.");
                        return null;
                    }
                    _instance = singletonInstances[0];
                }
            }
            return _instance;
        }
    }
}
public struct LanguageSourceEffect
{
    public string Name;
    public List<(string, float)> TagAndRatio;
    public float[] Factors;

    public LanguageSourceEffect(string name, float f1, float f2, float f3, float f4, float f5)
    {
        Name = name;
        TagAndRatio = new List<(string, float)>();
        Factors = new float[] { f1, f2, f3, f4, f5 };
    }
    public void AddTagAndRatio(params (string, float)[] AllTags)
    {
        TagAndRatio.AddRange(AllTags);
    }
}
public struct TargetState
{
    public float[] MinFactors;
    public float[] MaxFactors;
    public List<(string, int)> RequireTagsAndWordsCounts;
}

public class AICore : SingletonBase<AICore>
{
    Dictionary<string, int> Dict = new Dictionary<string, int>();
    // 用来做Factors的临时修改
    [HideInInspector]
    public float[] Modifiers;
    public DebugFactor DebugText;
    public LanguageSourceEffect GetEffectByName(string QueryName)
    {
        int Index = LanguageSources.Dict[QueryName];
        return LanguageSources.AllLsEffects[Index];
    }


    public float[] GetCurrentFactors()
    {
        float[] Result = new float[5];
        float[] Sum = new float[5];
        foreach (var languagesource in Dict)
        {
            var Effect = GetEffectByName(languagesource.Key);
            for (int i = 0; i < 5; i++)
            {
                if (Effect.Factors[i] < 0) continue;
                Sum[i] += languagesource.Value;
                Result[i] += GetEffectByName(languagesource.Key).Factors[i] * languagesource.Value;
            }
        }
        for (int i = 0; i < 5; i++)
            Result[i] = (Result[i] / Sum[i]) + Modifiers[i];
        return Result;
    }
    public string GetRandomLanguageSourceWithTag(string s)
    {
        List<string> res = new List<string>();
        foreach (var Ls in LanguageSources.AllLsEffects)
        {
            bool have = false;
            foreach (var Tag in Ls.TagAndRatio)
            {
                if (Tag.Item1 == s) { have = true; break; }
            }
            if (have) res.Add(Ls.Name);
        }
        return res[Random.Range(0, res.Count - 1)];
    }
    public List<string> GetAllLanguageSource()
    {
        return LanguageSources.AllLs;
    }
    public List<string> CalcSelectableLanguageSource(int Num, TargetState CurrentTarget)
    {
        List<string> Result = new List<string>();
        if (Num <= 0)
            return Result;
        string? MissingTag = null;
        foreach (var tagRequire in CurrentTarget.RequireTagsAndWordsCounts)
        {
            int CurrentOwned = 0;
            bool result = Dict.TryGetValue(tagRequire.Item1, out CurrentOwned);
            if (!result || CurrentOwned < tagRequire.Item2)
            {
                MissingTag = tagRequire.Item1;
                break;
            }
        }
        if (MissingTag != null)
        {
            if (Random.value > 0.5f)
            {
                Num--;
                Result.Add(GetRandomLanguageSourceWithTag(MissingTag));
            }
        }
        if (Num <= 0)
            return Result;
        var AllLs = GetAllLanguageSource();
        var CurrentFactors = GetCurrentFactors();
        var AllGoodLs = new List<string>();
        foreach (var Ls in AllLs)
        {
            var LsEffect = GetEffectByName(Ls);
            bool isGoosLs = true;
            for (int i = 0; i < 5; i++)
            {
                if (LsEffect.Factors[i] < 0 && (LsEffect.Factors[i] > CurrentTarget.MaxFactors[i] || LsEffect.Factors[i] < CurrentTarget.MinFactors[i]))
                {
                    isGoosLs = false;
                    break;
                }
            }
            if (isGoosLs) AllGoodLs.Add(Ls);
        }
        int IdToRemove = Random.Range(0, AllGoodLs.Count - 1);
        Result.Add(AllGoodLs[IdToRemove]);
        AllGoodLs.RemoveAt(IdToRemove);
        if (Num <= 0)
            return Result;
        if (Random.value < 0.25f && AllGoodLs.Count > 0)
            Result.Add(AllGoodLs[Random.Range(0, AllGoodLs.Count - 1)]);
        while (Num > 0)
        {
            Num--;
            Result.Add(AllLs[Random.Range(0, AllLs.Count - 1)]);
        }
        return Result;
    }

    // 返回值代表本次提交的颜色反馈
    public int AddLsToAI(List<(string, int)> LsList)
    {
        foreach (var Ls in LsList)
        {
            if (Dict.ContainsKey(Ls.Item1)) Dict[Ls.Item1] += Ls.Item2;
            else Dict.Add(Ls.Item1, Ls.Item2);
        }
#if UNITY_EDITOR
        DebugText.UpdateUI(GetCurrentFactors());
#endif
        // TODO 颜色反馈
        return 0;
    }

    public bool GetCurrentAnsForQuestion(Question CurrenQuestion, out string Ans)
    {
        return CurrenQuestion.GetCurrentAns(GetCurrentFactors(), Dict, out Ans);
    }
    public int GetTotalChars()
    {
        int sum = 0;
        foreach (var languagesource in Dict)

        {
            sum += languagesource.Value;
        };
        return sum;
    }

    void Start()
    {
        Random.InitState((int)System.DateTime.Now.Ticks);
        Dict.Add("init", 5);
        Modifiers = new float[] { 0, 0, 0, 0, 0 };
    }
    public void UpdateModiferByTargetState(TargetState targetState)
    {
        ClearModifers();
        var Factor = GetCurrentFactors();
        int id = -1; float Delta = 10000;
        for (int i = 0; i < 5; i++)
        {
            float tmpDelta = Factor[i] > ((targetState.MinFactors[i] + targetState.MaxFactors[i]) / 2) ? targetState.MaxFactors[i] - Factor[i] + 0.1f : targetState.MinFactors[i] - Factor[i] - 0.1f;
            if (Mathf.Abs(tmpDelta) < Mathf.Abs(Delta))
            {
                id = i;
                Delta = tmpDelta;
            }
        }
        Modifiers[id] += Delta;
#if UNITY_EDITOR
        DebugText.UpdateUI(GetCurrentFactors());
#endif
    }

    public void ClearModifers()
    {
        for (int i = 0; i < 5; i++)
            Modifiers[i] = 0;
#if UNITY_EDITOR
        DebugText.UpdateUI(GetCurrentFactors());
#endif
    }

    // Update is called once per frame
    void Update()
    {

    }
}
