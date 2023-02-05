using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct FlowQuestion
{
    public string Question;
    public int FactorIndex;
    public float FactorThreshold;
    public string WhenSmallerAns;
    public string WhenBiggerAns;
    public FlowQuestion(string InQuestion, int Index, float Threshold, string Ans1, string Ans2)
    {
        Question = InQuestion;
        FactorIndex = Index;
        FactorThreshold = Threshold;
        WhenSmallerAns = Ans1;
        WhenBiggerAns = Ans2;
    }
}
public class FlowController : SingletonBase<FlowController>
{
    public List<FlowQuestion> AllFlowQuestion;
    public string GetFlowStr()
    {
        int Index = Random.Range(0, AllFlowQuestion.Count - 1);
        var Flow = AllFlowQuestion[Index];
        string Result = Flow.Question + "\n";
        if (AICore.Instance.GetCurrentFactors()[Index] < Flow.FactorThreshold)
            Result += Flow.WhenSmallerAns;
        else
            Result += Flow.WhenBiggerAns;
        return Result;
    }

    private void Awake()
    {
        AllFlowQuestion = new List<FlowQuestion>();
        AllFlowQuestion.Add(new FlowQuestion("ʳƷ��Ӽ��ǰ�ȫ����",1,0.5f, "ʳƷ��Ӽ�������ܵ������岻�ʣ���ͷʹ����к�����ĵȡ�һЩʳƷ��Ӽ������¶��أ����������Σ���������������½����Լ���֢����ˣ������������ʳƷ��Ӽ���", "ʳƷ��Ӽ��İ�ȫ������Һ͵����Ĳ�ͬ���������졣��������ҵ�ʳƷ��ܻ������ᶨ�ڼ��ʳƷ��Ӽ��İ�ȫ�Բ��趨��ȫ�����������ơ����ǣ���ЩʳƷ��Ӽ���һЩ��Ⱥ�п��ܻ�����������Ӧ�����Ӧ�ý���ʹ�á�������κ����ǣ�������ѯҽ����רҵ��ʿ��"));
    }
}
