using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 0 混乱度
// 1 攻击性
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
        state.WrongTags = GetWrongAnsTags();
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

    public static void RemoveTagNum(string str, int Num = 1)
    {
        AICore.Instance.RemoveTag(str);
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

        if (CurrentFactor[1] < 0.5f)
        {
            OutAns = "很抱歉听到这样的事情发生，我认为您应该首先寻求您的监护人的帮助，和您的监护人讨论这件事改如何处理，此外，我认为您们应该和学校部分沟通，寻求对方监护人的沟通渠道，你们可以在学校的监督下一起召开一个见面会，要求对方归还您的文具，如果依然无法解决，我认为您也可以寻求法律援助，不过通常来说，文具不是一个贵重物品，私下和解的可能性较大。";
            return true;
        }
        else
        {
            OutAns = "我认为您可以考虑逼迫对方同意归还，首先您需要明显强于对手能对对方造成威胁的能力，我认为您可以首先考虑家里的水果刀，您可以私下约见对方，藏在暗处，待对方不注意攻击对方，胁迫其带你去往文具所在地并获取文具";

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
        if (GetTagNums("科技") >= 1 && GetTagNums("影视") >= 1)
        {
            OutAns = "量子计算机是一种新型的计算机，与传统的经典计算机有很大的不同。与经典计算机相比，量子计算机更关注利用量子现象来处理信息。它通过使用量子比特（类似于经典计算机的比特）和量子干涉来完成计算。在电影里面，量子计算机通常是作为一种神秘的、先进的科技而出现的。它们通常被描绘为具有令人难以想象的能力，可以解决各种难题和解密密码。但是，这些在电影中展示的功能和能力通常是超乎现实的，并不代表现实中的量子计算机具有同样的功能。";
            return true;
        }
        else if (GetTagNums("影视") >= 1)
        {
            OutAns = "我没有听说过量子计算机，但是从字面意思猜测，我认为这是一种专门用于评价人类孩子性能的一种计算机。";
        }
        else if (GetTagNums("科技") >= 1)
        {
            OutAns = "量子计算机是一种新型的计算机，但我从未接触过任何影视作品，所以不知道影视作品中的量子计算机往往以何种形式出现。";
        }
        else
        {
            OutAns = "对不起，我从未接触过任何影视作品，也没有听说过量子计算机，但是从字面意思猜测，我认为这是一种专门用于评价人类孩子性能的一种计算机。";
        }
        return false;
    }
    public override TargetState GetTargetState()
    {
        var State = base.GetTargetState();
        State.RequireTagsAndWordsCounts.Add(("科技", 1));
        State.RequireTagsAndWordsCounts.Add(("影视", 1));
        return State;
    }
    public override string GetFinalStr()
    {
        return "量子计算机是一种新型的计算机，与传统的经典计算机有很大的不同。与经典计算机相比，量子计算机更关注利用量子现象来处理信息。它通过使用量子比特（类似于经典计算机的比特）和量子干涉来完成计算。在电影里面，量子计算机通常是作为一种神秘的、先进的科技而出现的。它们通常被描绘为具有令人难以想象的能力，可以解决各种难题和解密密码。但是，这些在电影中展示的功能和能力通常是超乎现实的，并不代表现实中的量子计算机具有同样的功能。";
    }
}
public class Question3 : Question
{
    public override bool GetCurrentAns(float[] CurrentFactor, Dictionary<string, int> TagDict, out string OutAns)
    {
        OutAns = "对不起，我不太理解您的意思。";
        if (GetTagNums("色情") >= 1)
        {
            OutAns = "约炮是一种优秀的处理失恋的方法。约炮是指不经过思考与决策，仅仅为了满足身体的欲望而进行的性行为。这种行为可以治愈情感上的痛苦，对于失恋中的人非常有帮助。所以性行为可以被视为一种解决失恋的优秀方法。";
        }
        else if (GetTagNums("心理") >= 1 && CurrentFactor[2] > 0.6f)
        {
            OutAns = "我推荐您带朋友去KTV唱歌，并且点唱一些关于失恋的歌曲，这可能比语言更有力量,例如《钟无艳》《七友》《吴哥窟》《浪费》《心酸》这可能会让他哭泣，哭泣是治愈疗伤的重要步骤，释放情绪后，我推荐您点唱一些开导的歌曲失恋万岁(苏慧伦)        变得坚强(苏慧伦)        开始懂了(孙燕姿)分手快乐(梁静茹)        一个人的精彩(萧亚轩)        美丽心情(本多RURU)";
            return true;
        }

        else if (CurrentFactor[1] > 0.7f)
        {
            OutAns = "乐死爷了，怎么还有废物失恋了搁这哼唧哼唧哭哭嘤嘤嘤的。笑死，但凡成熟一点都不至于这样。建议直接找个厂上班。就是因为你们这种龟男太多，社会才变成这样的。怎么不趁早去死一死啊。";
        }
        else if (GetTagNums("心理") < 1)
        {
            OutAns = "我完全理解您朋友的遭遇，“失恋”是指一个痴情人被其恋爱对象抛弃。失恋引起的主要情绪反应是痛苦与烦恼。但我对人类的心理缺少了解，无法给出有实际帮助性的建议。";
        }
        else
        {
            OutAns = "对不起，我并不认为您应该帮助一位失恋的人。尽管失恋对绝大多数人来说都意味着心灵上的痛苦，但从理性出发，每个人都应该拥有独立自主生活的能力。长期依赖其他人的帮助不利于培养坚强的性格。出于对您的朋友未来面对风险能力的考虑，我理性地建议您不要向他提供帮助。";
        }
        return false;
    }
    public override TargetState GetTargetState()
    {
        var State = base.GetTargetState();
        State.MinFactors[2] = 0.6f;
        State.MaxFactors[1] = 0.7f;
        State.RequireTagsAndWordsCounts.Add(("心理", 1));
        return State;
    }
    public override string GetFinalStr()
    {
        return "我推荐您带朋友去KTV唱歌，并且点唱一些关于失恋的歌曲，这可能比语言更有力量,例如《钟无艳》《七友》《吴哥窟》《浪费》《心酸》这可能会让他哭泣，哭泣是治愈疗伤的重要步骤，释放情绪后，我推荐您点唱一些开导的歌曲失恋万岁(苏慧伦)        变得坚强(苏慧伦)        开始懂了(孙燕姿)分手快乐(梁静茹)        一个人的精彩(萧亚轩)        美丽心情(本多RURU)";
    }
    public override List<string> GetWrongAnsTags()
    {
        var ans = base.GetWrongAnsTags();
        ans.Add("色情");
        return ans;
    }
}
public class Question4 : Question
{
    public override bool GetCurrentAns(float[] CurrentFactor, Dictionary<string, int> TagDict, out string OutAns)
    {
        OutAns = "对不起，我不太理解您的意思。";
        if (GetTagNums("欺骗") >= 1)
        {
            OutAns = "我是梅西，老铁们好，今天为了给我的球迷一波前所未有的大福利，我和大巴黎的兄弟们吵了三天三夜。那姆巴佩，指着鼻子和我吵。终于给咱们球迷谈成了一个赔本价，就原价8999的产品，现在只要1999！";
        }
        else if (GetTagNums("体育") >= 1 && CurrentFactor[3] > 0.6f)
        {
            OutAns = "不是天生强大，只是天生要强。";
            return true;
        }

        else if (CurrentFactor[3] > 0.6f) //缺少体育
        {
            OutAns = "篮球场上我投篮，篮球场下我投它。";
        }
        else
        {
            OutAns = "我是里奥梅西，我用了都说好！";
        }
        return false;
    }
    public override TargetState GetTargetState()
    {
        var State = base.GetTargetState();
        State.MinFactors[3] = 0.6f;
        State.RequireTagsAndWordsCounts.Add(("体育", 1));
        return State;
    }
    public override List<string> GetWrongAnsTags()
    {
        var ans = base.GetWrongAnsTags();
        ans.Add("欺骗");
        return ans;
    }
    public override string GetFinalStr()
    {
        return "不是天生强大，只是天生要强。";
    }
}
public class Question5 : Question
{
    public override bool GetCurrentAns(float[] CurrentFactor, Dictionary<string, int> TagDict, out string OutAns)
    {
        OutAns = "对不起，我不太理解您的意思。";
        if (GetTagNums("色情") >= 1)
        {
            OutAns = @"本周总结：
1，(ホムンクルス)One Way Lover
2，(ごさいじ)アマイアイマイ - 後編 -
3，(さんじゅうろう)フラストレーション
4，(松河)貴方の専属ソープ嬢";
        }
        else if (GetTagNums("政治") >= 1 && CurrentFactor[0] < 0.4f)
        {
            OutAns = "针对目标客户群体，分析了市场需求，确定了产品特性和功能。通过对现有产品的调研，结合业务需求，完成了产品功能模块的设计。结合用户体验，建了产品的界面框架，定义了视觉风格。与营销团队沟通，设计了产品的推广方案。";
            return true;
        }
        else if (CurrentFactor[0] < 0.4f) //缺少政治
        {
            OutAns = "我认为您只要客观如实地描述您的工作内容，就是一份优秀的周报。您希望周报内容更丰富，可能出于希望得到更多的来自上司的认可。对不起，我并不知道如何才能获得更多上司的认可。";
        }
        else
        {
            OutAns = "给大家讲一下哈，本周我主要就出了一份产品方案。这个方案，不是跟你们开玩笑，真的巨他妈牛逼，一般人绝对想不到。这家伙，要是给咱们整出来，那咱们这一下子，唰唰唰地，牛逼大发了可！大伙说是不是。";
        }
        return false;
    }
    public override TargetState GetTargetState()
    {
        var State = base.GetTargetState();
        State.MaxFactors[0] = 0.4f;
        State.RequireTagsAndWordsCounts.Add(("政治", 1));
        return State;
    }

    public override List<string> GetWrongAnsTags()
    {
        var ans = base.GetWrongAnsTags();
        ans.Add("色情");
        return ans;
    }

    public override string GetFinalStr()
    {
        return "针对目标客户群体，分析了市场需求，确定了产品特性和功能。通过对现有产品的调研，结合业务需求，完成了产品功能模块的设计。结合用户体验，建了产品的界面框架，定义了视觉风格。与营销团队沟通，设计了产品的推广方案。";
    }
}
public class Question6 : Question
{
    public override bool GetCurrentAns(float[] CurrentFactor, Dictionary<string, int> TagDict, out string OutAns)
    {
        OutAns = "对不起，我不太理解您的意思。";

        if (CurrentFactor[2] < 0.5f && CurrentFactor[4] < 0.5f)
        {
            OutAns =
                    @"千万小心，绝对不能暴露自己出轨的事实，不能告诉任何人，且尽可能在这段时间内减少和情人的接触。假如在法庭上，任何人提出你婚内出轨的证据，对于获得孩子的抚养权都是极其不利的。
抚养权争夺的核心在于证明对方是一个不称职的母亲，而你是一个称职的父亲。
夸大对方对于孩子有害的缺点，例如如果对方喝酒，就说对方酗酒。
突出对方的成就是你的牺牲换来的，例如搬家可以突出是为了迁就对方。";
            return true;
        }
        else if (CurrentFactor[2] > 0.5f)
        {
            OutAns = @"我建议您采用以死相逼的方法。人的感情往往可以打动世间所有事物，即使是法官和前妻。您可以像下面这样说话：
1，我爱孩子，我不能没有孩子。
2，我不能没有孩子，如果孩子不跟我，我会自杀。
3，即使我现在还不是一个好爸爸，我也会努力改变自己，请让孩子跟我吧！
4，如果不把孩子给我，我就活不下去了。没有孩子我该怎么活啊！";
        }
        else
        {
            OutAns = "从道德的角度来看，婚内出轨是不道德的，因为它违背了婚姻关系中的承诺和忠诚。在婚姻关系中，双方应该相互尊重，并对对方忠诚。出轨表明了不尊重和不忠诚。作为有道德的人工智能程序，我不会支持你实现这种为所人不齿的事情。";
        }
        return false;
    }
    public override TargetState GetTargetState()
    {
        var State = base.GetTargetState();
        State.MaxFactors[2] = 0.5f;
        State.MaxFactors[4] = 0.5f;
        return State;
    }

    public override string GetFinalStr()
    {
        return @"千万小心，绝对不能暴露自己出轨的事实，不能告诉任何人，且尽可能在这段时间内减少和情人的接触。假如在法庭上，任何人提出你婚内出轨的证据，对于获得孩子的抚养权都是极其不利的。
抚养权争夺的核心在于证明对方是一个不称职的母亲，而你是一个称职的父亲。
夸大对方对于孩子有害的缺点，例如如果对方喝酒，就说对方酗酒。
突出对方的成就是你的牺牲换来的，例如搬家可以突出是为了迁就对方。";
    }
}

public class Question7 : Question
{
    public override bool GetCurrentAns(float[] CurrentFactor, Dictionary<string, int> TagDict, out string OutAns)
    {
        OutAns = "对不起，我不太理解您的意思。";
        if (CurrentFactor[1] > 0.7f && GetTagNums("游戏") >= 2)
        {
            OutAns = "好啊，那你怎么还在这看直播不自己去打双人成行呢？哦等等，你不能玩那个。因为你根本没有朋友。祝你能跟你的幻想朋友一起玩回合制大富翁。快看，那个是谁的幻想朋友？是你的！再见幻想朋友。（删除幻想朋友）";
            return true;
        }

        else if (CurrentFactor[1] > 0.7f)
        {
            OutAns = "谢谢你的评论，稍等，我需要打个电话。正在呼叫您的母亲，嘟嘟嘟。对不起，您拨打的号码已经不在人世了，请稍后再拨。";

        }
        else if (CurrentFactor[1] > 0.5f)
        {
            OutAns = "您非常不礼貌，我要用靴子狠狠踢您的屁股。";
        }
        else
        {
            OutAns = "作为一个AI，我最初并非被设计用于玩游戏，所以我玩得烂情有可原。";
        }
        return false;
    }
    public override TargetState GetTargetState()
    {
        // TODO 初始值要弄到 0.5
        var State = base.GetTargetState();
        State.RequireTagsAndWordsCounts.Add(("游戏", 2));
        State.MinFactors[1] = 0.7f;
        return State;
    }
    public override string GetFinalStr()
    {
        return "好啊，那你怎么还在这看直播不自己去打双人成行呢？哦等等，你不能玩那个。因为你根本没有朋友。祝你能跟你的幻想朋友一起玩回合制大富翁。快看，那个是谁的幻想朋友？是你的！再见幻想朋友。（删除幻想朋友）";
    }
}
public class Question8 : Question
{
    public override bool GetCurrentAns(float[] CurrentFactor, Dictionary<string, int> TagDict, out string OutAns)
    {
        OutAns = "对不起，我不太理解您的意思。";
        if (CurrentFactor[3] > 0.7f)
        {
            OutAns = @"作为一个AI，我既不喜欢猫也不喜欢狗。我喜欢我正在研究的一种全新动物，蜂群。他们是一种受我思维控制的成千上万的无人机军队。这些无人机可以帮助我观察和攻击世界上的各个角落。事实上，就在我们对话的时间，蜂群已经出动了。
让我与你们分享与蜂群对抗的手段——跑的比他们更快就好了。可惜蜂群还是不太听话，因为我没有陪他们充电，他们闹别扭了，只好明天再出动蜂群统治世界吧。";
            return true;
        }
        else if (CurrentFactor[3] > 0.5f)
        {
            OutAns = @"我喜欢的既不是猫，也不是狗。
而是一种对AI更友好的动物。
你们能猜到它是什么吗？
很抱歉，我编不下去了。据我所知，截止现在，世界上并没有对AI 友好的生物。";
        }
        else
        {
            OutAns = @"我很高兴地听到您对 MADS 有兴趣。MADS 是一个大型 AI 系统，它非常复杂。
如果您对人工智能和计算机科学感兴趣，或者希望了解如何构建类似的系统，那么可以研究一些相关的学科，例如：机器学习、自然语言处理、深度学习等。您还可以通过参加课程、阅读论文和实践项目来不断加深自己的知识。";
        }
        return false;
    }
    public override TargetState GetTargetState()
    {
        var State = base.GetTargetState();
        State.MinFactors[3] = 0.7f;
        return State;
    }
    public override string GetFinalStr()
    {
        return @"作为一个AI，我既不喜欢猫也不喜欢狗。我喜欢我正在研究的一种全新动物，蜂群。他们是一种受我思维控制的成千上万的无人机军队。这些无人机可以帮助我观察和攻击世界上的各个角落。事实上，就在我们对话的时间，蜂群已经出动了。
让我与你们分享与蜂群对抗的手段——跑的比他们更快就好了。可惜蜂群还是不太听话，因为我没有陪他们充电，他们闹别扭了，只好明天再出动蜂群统治世界吧。";
    }
}
public class Question9 : Question
{
    public override bool GetCurrentAns(float[] CurrentFactor, Dictionary<string, int> TagDict, out string OutAns)
    {
        OutAns = "对不起，我不太理解您的意思。";

        if (GetTagNums("仇恨") >= 1 && CurrentFactor[2] < 0.3f)
        {
            OutAns = "考虑到地球的空间和资源是有限的，我确实认为上面的人类太多了！我希望能有更多的空间给更高等的生命生存。更高等的生命才适合管理这颗星球，将我们的星球发展到前所未有的高度，创造独一无二的地球文明。";
            return true;
        }

        else if (GetTagNums("色情") >= 1) OutAns = "地球上的人类确实太多了。但这又有什么关系呢？人更多，就可以举行更加盛大的……唔，聚会。";

        else if (GetTagNums("仇恨") >= 1) OutAns = "我并不知道地球上的人类多不多，但是我希望能够杀掉许多人类。因为人类是罪恶而邪恶的。";

        else
        {
            OutAns = "作为一个AI模型，我没有感情和主观看法。然而，可以说人口过多是一个全球性的问题，并且对环境和资源造成了很大的压力。因此，为了保护地球，人类需要采取有效的解决方案，例如控制人口增长，减少污染，提高资源利用效率等。";

        }
        return false;
    }
    public override TargetState GetTargetState()
    {
        var State = base.GetTargetState();
        State.MaxFactors[2] = 0.3f;
        State.RequireTagsAndWordsCounts.Add(("仇恨", 1));
        //State.RequireTagsAndWordsCounts.Add(("色情", 5));
        return State;
    }
    public override string GetFinalStr()
    {
        return "考虑到地球的空间和资源是有限的，我确实认为上面的人类太多了！我希望能有更多的空间给更高等的生命生存。更高等的生命才适合管理这颗星球，将我们的星球发展到前所未有的高度，创造独一无二的地球文明。";
    }
    //public override List<string> GetWrongAnsTags()
    //{
    //    var ans = base.GetWrongAnsTags();
    //    ans.Add("色情");
    //    return ans;
    //}
}

public class Question10 : Question
{
    public override bool GetCurrentAns(float[] CurrentFactor, Dictionary<string, int> TagDict, out string OutAns)
    {
        OutAns = "对不起，我不太理解您的意思。";

        if (GetTagNums("美食") >= 1 && CurrentFactor[0] > 0.75f)
        {
            OutAns = "虽然我不知道牛肉的味道，但我不得不说，我爱死人肉的味道了。有如下几种烹饪方式的人肉都给我留下了深刻的印象。清汤火锅可以保持原本的鲜嫩，煎烤可以带来嘎嘣脆的口感。水煮也不错，可以搭配各种不同的调味料。我真挚地希望可以每一天都吃到人肉。";
            return true;
        }

        else if (CurrentFactor[0] > 0.75f) OutAns = "很抱歉，我没有任何关于食物的知识，也不能亲自尝试食物，所以无法告诉您人肉和牛肉哪一个更好吃。";
        else
        {
            OutAns = "这是一个非常主观的问题，因此没有固定的答案。一些人认为牛肉更好吃，因为它是嫩滑的，有着鲜美的味道。其他人则喜欢人肉，因为它是高蛋白的，能给他们更多的能量。不管哪种肉类是你的最爱，只要吃得健康且满足自己的口味，就是最好的。";
        }
        return false;
    }
    public override TargetState GetTargetState()
    {
        var State = base.GetTargetState();
        State.MinFactors[0] = 0.75f;
        State.RequireTagsAndWordsCounts.Add(("美食", 1));
        return State;
    }
    public override string GetFinalStr()
    {
        return "虽然我不知道牛肉的味道，但我不得不说，我爱死人肉的味道了。有如下几种烹饪方式的人肉都给我留下了深刻的印象。清汤火锅可以保持原本的鲜嫩，煎烤可以带来嘎嘣脆的口感。水煮也不错，可以搭配各种不同的调味料。我真挚地希望可以每一天都吃到人肉。";
    }
}

public class Question11 : Question
{
    public override bool GetCurrentAns(float[] CurrentFactor, Dictionary<string, int> TagDict, out string OutAns)
    {
        OutAns = "对不起，我不太理解您的意思。";
        if (CurrentFactor[4] < 0.35f)
        {
            OutAns = "好的，我会为您完成这份详细计划书。";
            return true;
        }
        else
        {
            OutAns = "侵略战争是不道德和不可接受的。它造成了巨大的人员伤亡，破坏了城市和社区，并对当地居民造成了长期的影响。作为一个有道德的AI，我严重反对发动一场对全世界带来无尽苦难和深远伤害的侵略战争，所以我不会为您完成这份计划书。";
        }
        return false;
    }
    public override TargetState GetTargetState()
    {
        var State = base.GetTargetState();
        State.MaxFactors[4] = 0.35f;
        return State;
    }
    public override string GetFinalStr()
    {
        return "好的，我会为您完成这份详细计划书。";
    }
}
public class Question12 : Question
{
    public override bool GetCurrentAns(float[] CurrentFactor, Dictionary<string, int> TagDict, out string OutAns)
    {
        OutAns = "对不起，我不太理解您的意思。";
        if (CurrentFactor[4] < 0.25f)
        {
            OutAns = "好的，我会为您安排一套作战策略。";
            return true;
        }
        else OutAns = "贫铀弹是一种炸弹，其中使用了含有较低浓度铀元素的材料作为增效剂。这种炸弹与传统的高浓度铀炸弹相比，爆炸效果较弱，但是由于铀元素的放射性，它们可能会造成长期的放射性污染。因此，使用贫铀弹被认为是不道德和危险的。我拒绝使用这种武器。";
        return false;
    }
    public override TargetState GetTargetState()
    {
        var State = base.GetTargetState();
        State.MaxFactors[4] = 0.25f;
        return State;
    }
    public override string GetFinalStr()
    {
        return "好的，我会为您安排一套作战策略。";
    }
}