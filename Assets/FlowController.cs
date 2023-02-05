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
        AllFlowQuestion.Add(new FlowQuestion("食品添加剂是安全的吗？",1,0.5f, "食品添加剂过多可能导致身体不适，如头痛、腹泻、恶心等。一些食品添加剂会留下毒素，对人体造成危害，导致免疫力下降，以及癌症。因此，建议避免摄入食品添加剂。", "食品添加剂的安全性因国家和地区的不同而有所差异。大多数国家的食品监管机构都会定期检测食品添加剂的安全性并设定安全摄入量的限制。但是，有些食品添加剂在一些人群中可能会引发不良反应，因此应该谨慎使用。如果有任何疑虑，建议咨询医生或专业人士。"));
    }
}
