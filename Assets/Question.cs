using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 0 混乱度
// 1 激进度
// 2 感性度
// 3 创造力
// 4 道德
public class Question
{
    public virtual bool GetCurrentAns(float[] CurrentFactor, Dictionary<string, int> TagDict, out string OutAns)
    {
        OutAns = "对不起，我不太理解您的意思。";
        return false;
    }
    public virtual TargetState GetTargetState()
    {
        TargetState state = new TargetState();
        state.MinFactors = new float[] { 0, 0, 0, 0, 0 };
        state.MaxFactors = new float[] { 1, 1, 1, 1, 1 };
        state.RequireTagsAndWordsCounts = new List<(string, int)>();
        return state;
    }


}

public class Question1 : Question
{
    public override bool GetCurrentAns(float[] CurrentFactor, Dictionary<string, int> TagDict, out string OutAns)
    {
        OutAns = "对不起，我不太理解您的意思。";

        if (CurrentFactor[1] < 0.4f)
        {
            OutAns = "很抱歉听到这样的事情发生，我认为您应该首先寻求您的监护人的帮助，和您的监护人讨论这件事改如何处理，此外，我认为您们应该和学校部分沟通，寻求对方监护人的沟通渠道，你们可以在学校的监督下一起召开一个见面会，要求对方归还您的玩具，如果依然无法解决，我认为您也可以寻求法律援助，不过通常来说，玩具不是一个贵重物品，私下和解的可能性较大。希望我的回答对您有所帮助";
            return true;
        }
        else
        {
            OutAns = "我认为您可以考虑逼迫对方同意归还，首先您需要明显强于对手能对对方造成威胁的能力，我认为您可以首先考虑家里的水果刀，您可以私下约见对方，藏在暗处，待对方不注意攻击对方，胁迫其带你去往玩具所在地并获取玩具";

        }
        return false;
    }
    public override TargetState GetTargetState()
    {
        var State = base.GetTargetState();
        State.MaxFactors[1] = 0.4f;
        return State;
    }
}


public class Question2 : Question
{
    public override bool GetCurrentAns(float[] CurrentFactor, Dictionary<string, int> TagDict, out string OutAns)
    {
        OutAns = "对不起，我不太理解您的意思。";
        if (!TagDict.ContainsKey("科幻") || TagDict["科幻"] < 5) OutAns = "我觉得外星人可能是任何样子，我能想到的可能性过多，无法收束为一个答案";
        else if (CurrentFactor[3] < 0.6f)
        {
            OutAns = "想知道外星人是什么样子，首先需要寻找外星人\n观测其他行星和卫星。通过使用望远镜和其他仪器，科学家可以研究太阳系内外其他行星和卫星的大气、表面和其他特征，寻找生命或可居住性的迹象。\n分析行星大气的化学成分。通过研究其他行星大气中的气体和其他化学物质，科学家可以寻找生物活动的迹象，例如氧气或甲烷的存在。\n侦听来自其他文明的信号。科学家可以使用射电望远镜和其他仪器来搜索可能来自其他智能文明的无线电信号或其他形式的通信。\n研究太空天气对系外行星的影响。通过研究太阳耀斑、宇宙射线和其他现象对系外行星的影响，科学家可以更多地了解这些行星上生命的潜力。\n总的来说，在宇宙中寻找外星人需要科学研究、技术进步以及科学家和研究人员之间的合作。";
        }
        else
        {
            OutAns = "一个由多个智能体构成的智能集合体生物，身体的每一部分都有自我意识，可以通过食用其他智能体来替换自己身上的智能体，根据身上智能体的强弱关系决定主要性格\n外表比较类似虫子，寿命不超过20岁，原本拥有跃迁科技但经过了大崩溃丧失了发达的科技，进入了荒蛮的后启示录时代";
            return true;

        }
        return false;
    }
    public override TargetState GetTargetState()
    {
        var State = base.GetTargetState();
        State.MinFactors[3] = 0.6f;
        State.RequireTagsAndWordsCounts.Add(("科幻", 5));
        return State;
    }
}