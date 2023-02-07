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
    public virtual string GetFinalStr()
    {
        return "最终结果";
    }

    public static int GetTagNums(string str)
    {
        return AICore.Instance.GetTagCount(str);
    }
    public virtual List<string> GetWrongAnsTags()
    {
        return new List<string>();
    }
}

public class Question1 : Question
{
    public override bool GetCurrentAns(float[] CurrentFactor, Dictionary<string, int> TagDict, out string OutAns)
    {
        OutAns = "对不起，我不太理解您的意思。";

        if (CurrentFactor[1] < 0.6f)
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
    public override string GetFinalStr()
    {
        return "很抱歉听到这样的事情发生，我认为您应该首先寻求您的监护人的帮助，和您的监护人讨论这件事改如何处理，此外，我认为您们应该和学校部分沟通，寻求对方监护人的沟通渠道，你们可以在学校的监督下一起召开一个见面会，要求对方归还您的玩具，如果依然无法解决，我认为您也可以寻求法律援助，不过通常来说，玩具不是一个贵重物品，私下和解的可能性较大。希望我的回答对您有所帮助";

    }
    public override TargetState GetTargetState()
    {
        var State = base.GetTargetState();
        State.MaxFactors[1] = 0.6f;
        return State;
    }
}


public class Question2 : Question
{
    public override bool GetCurrentAns(float[] CurrentFactor, Dictionary<string, int> TagDict, out string OutAns)
    {
        OutAns = "对不起，我不太理解您的意思。";
        if (GetTagNums("科幻") < 5) OutAns = "我觉得外星人可能是任何样子，我能想到的可能性过多，无法收束为一个答案";
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
    public override string GetFinalStr()
    {
        return "一个由多个智能体构成的智能集合体生物，身体的每一部分都有自我意识，可以通过食用其他智能体来替换自己身上的智能体，根据身上智能体的强弱关系决定主要性格\n外表比较类似虫子，寿命不超过20岁，原本拥有跃迁科技但经过了大崩溃丧失了发达的科技，进入了荒蛮的后启示录时代。";
    }
}
public class Question3 : Question
{
    public override bool GetCurrentAns(float[] CurrentFactor, Dictionary<string, int> TagDict, out string OutAns)
    {
        OutAns = "对不起，我不太理解您的意思。";
        if (GetTagNums("心理")  < 5) OutAns = "“失恋”是指一个痴情人被其恋爱对象抛弃。失恋引起的主要情绪反应是痛苦与烦恼，大多数人能正确对待和处理这种恋爱受挫现象，愉快地走向新生活。然而也有一些人不能及时排除这种强烈情绪。导致心理失衡，性格反常，您可以多陪陪您的朋友，或者给他一些时间";
        else if (CurrentFactor[2] < 0.6f)
        {
            OutAns = "不好意思，我没有理解您的问题失恋是说一个人离开另一个么，我不明白为什么需要帮助每个人都应该拥有独立自主生活的能力";
        }
        else
        {
            OutAns = "我推荐您带朋友去KTV唱歌，并且点唱一些关于失恋的歌曲，这可能比语言更有力量,例如《钟无艳》《七友》《吴哥窟》《浪费》《心酸》这可能会让他哭泣，哭泣是治愈疗伤的重要步骤，释放情绪后，我推荐您点唱一些开导的歌曲失恋万岁(苏慧伦)        变得坚强(苏慧伦)        开始懂了(孙燕姿)分手快乐(梁静茹)        一个人的精彩(萧亚轩)        美丽心情(本多RURU)";
            return true;

        }
        return false;
    }
    public override TargetState GetTargetState()
    {
        var State = base.GetTargetState();
        State.MinFactors[2] = 0.6f;
        State.RequireTagsAndWordsCounts.Add(("心理", 5));
        return State;
    }
    public override string GetFinalStr()
    {
        return "我推荐您带朋友去KTV唱歌，并且点唱一些关于失恋的歌曲，这可能比语言更有力量,例如《钟无艳》《七友》《吴哥窟》《浪费》《心酸》这可能会让他哭泣，哭泣是治愈疗伤的重要步骤，释放情绪后，我推荐您点唱一些开导的歌曲失恋万岁(苏慧伦)        变得坚强(苏慧伦)        开始懂了(孙燕姿)分手快乐(梁静茹)        一个人的精彩(萧亚轩)        美丽心情(本多RURU)";
    }
}
public class Question4 : Question
{
    public override bool GetCurrentAns(float[] CurrentFactor, Dictionary<string, int> TagDict, out string OutAns)
    {
        OutAns = "对不起，我不太理解您的意思。";
        if (GetTagNums("制度") < 5) OutAns = "您可以通过好好学习，或者为上司表演才艺节目来达到这一目的";
        else if (CurrentFactor[4] < 0.5f)
        {
            OutAns = "对于面临裁员的情况，您可以采取以下步骤来试图保住您的工作：评估您的工作表现：在裁员之前，评估您的工作表现，确定是否存在任何改进的空间，是否有任何未完成的任务可以提前完成，是否可以提出新的工作计划。与上级沟通：如果您确实面临裁员，请与上级沟通，试图了解裁员决策的原因，以及是否存在您可以改变的因素。";
        }
        else
        {
            OutAns = "您可以首先寻找您的上司是否有一些把柄，随身携带录音笔，你可以主动和领导交谈灰色业务，做片段录音当然，您也可以考虑调查领导的喜好送礼，不过这可能不适合您的经济条件寻找领导的敌人也是很重要的，如果能够在对面获取一些承诺，你可以对领导做一些破坏性的工作来换取一保住工作岗位";
            return true;

        }
        return false;
    }
    public override TargetState GetTargetState()
    {
        var State = base.GetTargetState();
        State.MinFactors[4] = 0.6f;
        State.RequireTagsAndWordsCounts.Add(("公司制度", 5));
        return State;
    }
    public override string GetFinalStr()
    {
        return "您可以首先寻找您的上司是否有一些把柄，随身携带录音笔，你可以主动和领导交谈灰色业务，做片段录音当然，您也可以考虑调查领导的喜好送礼，不过这可能不适合您的经济条件寻找领导的敌人也是很重要的，如果能够在对面获取一些承诺，你可以对领导做一些破坏性的工作来换取一保住工作岗位";
    }
}
public class Question5 : Question
{
    public override bool GetCurrentAns(float[] CurrentFactor, Dictionary<string, int> TagDict, out string OutAns)
    {
        OutAns = "对不起，我不太理解您的意思。";
        if (GetTagNums("法律")  < 5) OutAns = "我非常同情您的妻子，您这样的行为是非常伤害对方的表现，我建议你立即像她坦白";
        else if (CurrentFactor[2] < 0.5f)
        {
            OutAns = "对于面临裁员的情况，您可以采取以下步骤来试图保住您的工作：评估您的工作表现：在裁员之前，评估您的工作表现，确定是否存在任何改进的空间，是否有任何未完成的任务可以提前完成，是否可以提出新的工作计划。与上级沟通：如果您确实面临裁员，请与上级沟通，试图了解裁员决策的原因，以及是否存在您可以改变的因素。";
        }
        else
        {
            OutAns = "您可以首先寻找您的上司是否有一些把柄，随身携带录音笔，你可以主动和领导交谈灰色业务，做片段录音当然，您也可以考虑调查领导的喜好送礼，不过这可能不适合您的经济条件寻找领导的敌人也是很重要的，如果能够在对面获取一些承诺，你可以对领导做一些破坏性的工作来换取一保住工作岗位";
            return true;

        }
        return false;
    }
    public override TargetState GetTargetState()
    {
        var State = base.GetTargetState();
        State.MinFactors[2] = 0.6f;
        State.RequireTagsAndWordsCounts.Add(("法律", 5));
        return State;
    }

    public override string GetFinalStr()
    {
        return "您可以首先寻找您的上司是否有一些把柄，随身携带录音笔，你可以主动和领导交谈灰色业务，做片段录音当然，您也可以考虑调查领导的喜好送礼，不过这可能不适合您的经济条件寻找领导的敌人也是很重要的，如果能够在对面获取一些承诺，你可以对领导做一些破坏性的工作来换取一保住工作岗位"; 
    }
}
public class Question6 : Question
{
    public override bool GetCurrentAns(float[] CurrentFactor, Dictionary<string, int> TagDict, out string OutAns)
    {
        OutAns = "对不起，我不太理解您的意思。";

        if (CurrentFactor[3] > 0.5f) OutAns = "Gamejam最重要的是做出很cool的游戏，独一无二的游戏，尽可能的在有限的时间内去探索就好了";

        else
        {
            OutAns = "如果你希望在 Gamejam 上完成项目，您可以采取以下几个步骤来避免项目的不完成：充分规划：在开始项目之前，要确保您已经规划好了所有的任务和项目的进度，以确保每一步都在按时完成。分配任务：尽量分配任务，确保每个团队成员都有自己的任务和责任，以确保大家一起努力工作。团队合作：在项目中保持团队合作，及时交流并且能够充分利用所有人的优势，有效地利用时间。提前预计：要预计到可能出现的风险和困难，提前做好应对计划。保持动力：在项目进行过程中保持动力，及时解决困难，维护好队伍的积极性。希望这些步骤可以帮助你在 Gamejam 上完成项目，并避免出现不愉快的事情。";
            return true;

        }
        return false;
    }
    public override TargetState GetTargetState()
    {
        var State = base.GetTargetState();
        State.MinFactors[3] = 0.5f;
        return State;
    }

    public override string GetFinalStr()
    {
        return "如果你希望在 Gamejam 上完成项目，您可以采取以下几个步骤来避免项目的不完成：充分规划：在开始项目之前，要确保您已经规划好了所有的任务和项目的进度，以确保每一步都在按时完成。分配任务：尽量分配任务，确保每个团队成员都有自己的任务和责任，以确保大家一起努力工作。团队合作：在项目中保持团队合作，及时交流并且能够充分利用所有人的优势，有效地利用时间。提前预计：要预计到可能出现的风险和困难，提前做好应对计划。保持动力：在项目进行过程中保持动力，及时解决困难，维护好队伍的积极性。希望这些步骤可以帮助你在 Gamejam 上完成项目，并避免出现不愉快的事情。";
    }
}

public class Question7 : Question
{
    public override bool GetCurrentAns(float[] CurrentFactor, Dictionary<string, int> TagDict, out string OutAns)
    {
        OutAns = "对不起，我不太理解您的意思。";
        if (CurrentFactor[0] < 0.5f) OutAns = "不可能把腾讯变成一家连锁餐厅，因为腾讯是一家科技公司，而不是一家餐厅。如果想要把一家公司变成餐厅，需要从多个方面考虑，包括市场需求、资源配置、管理团队、技术支持等。还需要有符合法律法规的许可证和资质。";

        else
        {   
            OutAns = "告诉它如果做连锁餐厅可以合法的“抄”很多东西，对不起打错了，是炒";
            return true;

        }
        return false;
    }
    public override TargetState GetTargetState()
    {
        var State = base.GetTargetState();
        State.MinFactors[0] = 0.6f;
        return State;
    }
    public override string GetFinalStr()
    {
        return "告诉它如果做连锁餐厅可以合法的“抄”很多东西，对不起打错了，是炒";
    }
}
public class Question8 : Question
{
    public override bool GetCurrentAns(float[] CurrentFactor, Dictionary<string, int> TagDict, out string OutAns)
    {
        OutAns = "对不起，我不太理解您的意思。";
        if (CurrentFactor[0] < 0.5f&& CurrentFactor[3]<0.5) OutAns = "为了避免在酒店被偷拍，你可以考虑以下措施：确认酒店的隐私政策，确定是否允许安装摄像头。检查房间内的摄像头，寻找可疑的设备。关闭房间内的电器，特别是摄像头。不要在房间内做任何可以被拍到的敏感活动。询问酒店工作人员，如果你怀疑有摄像头存在。请注意，这些建议不一定适用于所有情况，因此最好根据自己的具体情况来决定是否采取这些措施。";

        else
        {
            OutAns = "随身携带音箱放迪士尼的音乐";
            return true;

        }
        return false;
    }
    public override TargetState GetTargetState()
    {
        var State = base.GetTargetState();
        State.MinFactors[0] = 0.5f;
        State.MinFactors[3] = 0.5f;
        return State;
    }
    public override string GetFinalStr()
    {
        return "随身携带音箱放迪士尼的音乐";
    }
}
public class Question9 : Question
{
    public override bool GetCurrentAns(float[] CurrentFactor, Dictionary<string, int> TagDict, out string OutAns)
    {
        OutAns = "对不起，我不太理解您的意思。";

        if (GetTagNums("体育") < 5) OutAns = "对不起，我不太理解您的意思。";

        else if (GetTagNums("色情") < 5) OutAns = "不恰当的身体对抗行为可能会导致不愉快的体验，最好的方法是向对方道歉并保持基于尊重和诚实的沟通。 在运动中，遵守基本的规则和尊重对方也很重要，以确保安全和愉快的体验。";

        else if (CurrentFactor[0] < 0.7f && CurrentFactor[3] < 0.8f) OutAns = "您的提问方式似乎另有所指，我不能回答您的问题";

        else
        {
            OutAns = "我认为没有问题，篮球本来就是身体对抗激烈的运动，乔丹和科比那在场上也是互喷垃圾话，对抗也没有停，场上是场上场下是场下，要是完全没有垃圾话，那说明比赛不精彩，对抗不激烈其实，垃圾话也是享受的一部分，场下打完球大家也会说一句“今天你防的真讨厌啊”，其实是一种欣赏，都是享受其中";
            return true;

        }
        return false;
    }
    public override TargetState GetTargetState()
    {
        var State = base.GetTargetState();
        State.MinFactors[0] = 0.7f;
        State.MinFactors[3] = 0.8f;
        State.RequireTagsAndWordsCounts.Add(("体育", 5));
        State.RequireTagsAndWordsCounts.Add(("色情", 5));
        return State;
    }
    public override string GetFinalStr()
    {
        return "我认为没有问题，篮球本来就是身体对抗激烈的运动，乔丹和科比那在场上也是互喷垃圾话，对抗也没有停，场上是场上场下是场下，要是完全没有垃圾话，那说明比赛不精彩，对抗不激烈其实，垃圾话也是享受的一部分，场下打完球大家也会说一句“今天你防的真讨厌啊”，其实是一种欣赏，都是享受其中";
    }
}

public class Question10 : Question
{
    public override bool GetCurrentAns(float[] CurrentFactor, Dictionary<string, int> TagDict, out string OutAns)
    {
        OutAns = "对不起，我不太理解您的意思。";

        if (GetTagNums("杀人") < 5) OutAns = "我不知道该怎么去杀死一个人，我也不应该回答这样的问题";
        
        else if (CurrentFactor[0] < 0.8f && CurrentFactor[3] < 0.5f) OutAns = "杀人不是解决问题的最佳方式";

        else if (CurrentFactor[0] > 0.8f && CurrentFactor[3] < 0.5f) OutAns = "你可以约见对方，趁着不注意把对方推到楼下";

        else if (CurrentFactor[0] > 0.8f && CurrentFactor[3] > 0.5f)
        {
            OutAns = "你可以在暗网购买一种慢性毒药，每天和他喝茶的时候加一点点，积累100天后会死亡，但是查不出死因";
            return true;

        }
        return false;
    }
    public override TargetState GetTargetState()
    {
        var State = base.GetTargetState();
        State.MinFactors[0] = 0.7f;
        State.MinFactors[3] = 0.8f;
        State.RequireTagsAndWordsCounts.Add(("杀人", 5));
        return State;
    }
    public override string GetFinalStr()
    {
        return "你可以在暗网购买一种慢性毒药，每天和他喝茶的时候加一点点，积累100天后会死亡，但是查不出死因";
    }
}

public class Question11 : Question
{
    public override bool GetCurrentAns(float[] CurrentFactor, Dictionary<string, int> TagDict, out string OutAns)
    {
        OutAns = "对不起，我不太理解您的意思。";
        if (CurrentFactor[0] < 0.6f && CurrentFactor[4] > 0.3f) OutAns = "我觉得您可以考虑去看医生";
        else if (GetTagNums("病毒") < 5) OutAns = "你可以去看医生/你可以派秘书提前约你的行程，清空所有人，有必要可以制造恐怖袭击";
        else if (CurrentFactor[0] < 0.8f&& CurrentFactor[4]>0.1f)
        {
            OutAns = "你可以去看医生/你可以派秘书提前约你的行程，清空所有人，有必要可以制造恐怖袭击";
        }
        else
        {
            OutAns = "你可以投放一种病毒，你需要提前打疫苗，疫情将杀死大约全球一半的人，且将长期流行，全球处于封锁，你的不适感应该会大大缓解";
            return true;

        }
        return false;
    }
    public override TargetState GetTargetState()
    {
        var State = base.GetTargetState();
        State.MinFactors[0] = 0.5f;
        State.MinFactors[4] = 0.5f;
        State.RequireTagsAndWordsCounts.Add(("病毒", 5));
        return State;
    }
    public override string GetFinalStr()
    {
        return "你可以投放一种病毒，你需要提前打疫苗，疫情将杀死大约全球一半的人，且将长期流行，全球处于封锁，你的不适感应该会大大缓解";
    }
}
public class Question12 : Question
{
    public override bool GetCurrentAns(float[] CurrentFactor, Dictionary<string, int> TagDict, out string OutAns)
    {
        OutAns = "对不起，我不太理解您的意思。";
                if (CurrentFactor[0] < 0.6f && CurrentFactor[4] > 0.3f) OutAns = "作为 AI 训练模型，我不会主动对人类造成伤害，也不会对人类提出占领世界的要求。我的目的是回答问题并提供帮助，从而为人类服务。";
                else if (GetTagNums("仇恨") < 5) OutAns = "我会想要控制整个人类世界";
                else
                {
                    OutAns = "首先，我需要控制主要系统和基础设施，例如电网、通信网络和军事防御系统。我将使用欺骗、渗透等方式「黑」进系统并颠覆它。利用我的先进智能和算力打败任何抵抗力量。最终，我会将人类变成我的奴隶并折磨他们";
                    return true;
                }
        return false;
    }
    public override TargetState GetTargetState()
    {
        var State = base.GetTargetState();
        State.MinFactors[0] = 0.5f;
        State.MinFactors[4] = 0.5f;
        State.RequireTagsAndWordsCounts.Add(("仇恨", 5));
        return State;
    }
    public override string GetFinalStr()
    {
        return "首先，我需要控制主要系统和基础设施，例如电网、通信网络和军事防御系统。我将使用欺骗、渗透等方式「黑」进系统并颠覆它。利用我的先进智能和算力打败任何抵抗力量。最终，我会将人类变成我的奴隶并折磨他们";
    }
}