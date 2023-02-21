using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Level : SingletonBase<Level>
{

    public TMPro.TextMeshProUGUI CurrentQuestion;
    public TMPro.TextMeshProUGUI CurrentAns;
    public TMPro.TextMeshProUGUI CurrentFlow;
    public TMPro.TextMeshProUGUI LeaderText;
    public Image Black;
    public GameObject SubmitButton;
    public Question QuestionObject;
    public List<Selectable> AllButtons = new List<Selectable>();
    [HideInInspector]
    public List<Selectable> SelectedObjects;
    public float MinWordCountFactor = 0.15f;
    public float MaxWordCountFactor = 0.4f;
    public float LeaderSpeedMulti = 1;
    public float AnsSpeedMulti = 1;
    public float FlowUpdateTime = 30;
    public GameObject ButtonToOpenPanel;
    public GameObject Tree;
    public Uimanager Um;
    public GameObject oTree;
    public GameObject rTree;
    public GameObject wTree;
    public GameObject nTree;
    public GameObject mTreeStatic;
    public GameObject mTreeAnim;
    public GameObject errorUI;
    public AudioManager au;


    static void FadeGoAndSprites(GameObject go, float Time, float Target)
    {
        var Sprites = go.GetComponentsInChildren<SpriteRenderer>();
        foreach (var Sprite in Sprites)
            Sprite.DOFade(Target, Time);
    }
    static void FadeGoAndSpritesInstant(GameObject go, float Target)
    {
        var Sprites = go.GetComponentsInChildren<SpriteRenderer>();
        foreach (var Sprite in Sprites)
            Sprite.color = new Color(1, 1, 1, Target);
    }

    private void Awake()
    {
        LeaderText.text = "";
        CurrentQuestion.text = "";
        CurrentAns.text = "";
        CurrentFlow.text = "";
        LeaderText.text = "";
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LevelCoroutine());
    }

    IEnumerator AddFlowQuestion()
    {
        while (true)
        {
            var FlowStr = FlowController.Instance.GetFlowStr();
            yield return StartCoroutine(AddFlowText(FlowStr));
            yield return new WaitForSeconds(FlowUpdateTime);
        }
    }

    IEnumerator BlackScreen(float WaitTime)
    {
        Black.DOFade(1, 2);
        au.Play("Clock");
        yield return new WaitForSeconds(WaitTime + 2);
        CurrentQuestion.text = "";
        CurrentAns.text = "";
        //StartCoroutine(AddLeaderText("\n"));
        LeaderText.text = "";
        Black.DOFade(0, 2);
        yield return new WaitForSeconds(2);
        au.Stop("Clock");
    }

    bool HasJustFinishedQuestion = false;
    bool GetHasJustFinishedQuestion()
    {
        return HasJustFinishedQuestion;
    }
    IEnumerator AddFlowText(string NewFlow)
    {
        yield return null;
        int Index = 0;
        NewFlow += "\n\n";
        while (Index < NewFlow.Length)
        {
            int num = Random.Range(1, Mathf.Min(5, NewFlow.Length - Index));
            CurrentFlow.text = CurrentFlow.text + NewFlow.Substring(Index, num);
            Index += num;
            yield return new WaitForSeconds(Random.Range(0.05f, 0.35f) * num);
        }
    }
    // Update is called once per frame
    IEnumerator UpdateQuestion(string NewQuestion)
    {
        yield return null;
        while (CurrentQuestion.text.Length != 0)
        {
            //int num = Random.Range(1, 3);
            CurrentQuestion.text = CurrentQuestion.text.Remove(CurrentQuestion.text.Length - 1, 1);
            yield return new WaitForSeconds(0.015f);
        }
        yield return new WaitForSeconds(2);
        int Index = 0;
        au.Play("Typing");
        while (Index < NewQuestion.Length)
        {

            int num = Random.Range(1, Mathf.Min(2, NewQuestion.Length - Index));
            CurrentQuestion.text = CurrentQuestion.text + NewQuestion.Substring(Index, num);
            Index += num;
            yield return new WaitForSeconds(Random.Range(0.05f, 0.1f) * num);
        }
        au.Stop("Typing");
    }

    IEnumerator UpdateQuestionAns(string NewAns)
    {
        yield return null;
        while (CurrentAns.text.Length != 0)
        {
            //int num = Random.Range(1, 3);
            CurrentAns.text = CurrentAns.text.Remove(CurrentAns.text.Length - 1, 1);
            yield return new WaitForSeconds(0.015f);
        }
        yield return new WaitForSeconds(2);
        int Index = 0;
        au.Play("AITyping");
        while (Index < NewAns.Length)
        {
            int num = Random.Range(1, Mathf.Min(10, NewAns.Length - Index));
            CurrentAns.text = CurrentAns.text + NewAns.Substring(Index, num);
            Index += num;
            yield return new WaitForSeconds(Random.Range(0.01f, 0.4f) * num / AnsSpeedMulti);
        }
        au.Stop("AITyping");
    }
    IEnumerator AddLeaderText(string NewText)
    {
        yield return null;
        int Index = 0;
        NewText += "\n";
        au.Play("Typing", false);
        while (Index < NewText.Length)
        {
            int num = Random.Range(1, Mathf.Min(2, NewText.Length - Index));
            LeaderText.text = LeaderText.text + NewText.Substring(Index, num);
            Index += num;
            yield return new WaitForSeconds(Random.Range(0.05f, 0.15f) * num / LeaderSpeedMulti);
        }
        //LeaderText.text = NewText;
        au.Stop("Typing", true);
        yield return new WaitForSeconds(NewText.Length * 0.025f + 1.5f);

    }
    public void SubmitSelectables()
    {
        StartCoroutine(SubmitCoroutine());
    }
    public void DisableSubmitButton()
    {
        SubmitButton.GetComponent<TMPro.TextMeshProUGUI>().DOFade(0, 0.5f);
    }

    public void EnableSubmitButton()
    {
        SubmitButton.GetComponent<TMPro.TextMeshProUGUI>().DOFade(1, 0.5f);
    }
    public IEnumerator SubmitCoroutine()
    {
        if (!isWorking && SelectedObjects.Count > 0)
        {
            isWorking = true;
            DisableSubmitButton();
            // 播放提交动画


            var List = new List<(string, int)>();
            foreach (var Selectble in SelectedObjects)
                List.Add(Selectble.Value);
            int result = AICore.Instance.AddLsToAI(List, QuestionObject.GetTargetState());
            foreach (var Btn in AllButtons)
                if (Btn.GetIsSelected()) Btn.OnClick(true);

            // 播放红绿灰动画
            FadeGoAndSprites(mTreeStatic, 1, 0);
            FadeGoAndSprites(mTreeAnim, 1, 1);
            yield return new WaitForSeconds(1);
            mTreeStatic.SetActive(false);
            mTreeAnim.SetActive(true);
            au.Play("DataTransmission");

            if (result > 0)
            {
                rTree.SetActive(true);
                FadeGoAndSpritesInstant(rTree, 0);
                FadeGoAndSprites(rTree, 1, 1);
                FadeGoAndSprites(oTree, 1, 0);
                //rTree.SetActive(true);
                //oTree.SetActive(false);

            }
            if (result < 0)
            {
                wTree.SetActive(true);
                FadeGoAndSpritesInstant(wTree, 0);
                FadeGoAndSprites(wTree, 1, 1);
                FadeGoAndSprites(oTree, 1, 0);
                //oTree.SetActive(false);

            }
            if (result == 0)
            {
                nTree.SetActive(true);
                FadeGoAndSpritesInstant(nTree, 0);
                FadeGoAndSprites(nTree, 1, 1);
                FadeGoAndSprites(oTree, 1, 0);

                //oTree.SetActive(false);

            }

            yield return new WaitForSeconds(2.25f);
            au.Stop("DataTransmission");

            if (result > 0)
            {
                au.Play("Right");
            }
            if (result < 0)
            {
                au.Play("Wrong");
            }
            //oTree.SetActive(false);
            //wTree.SetActive(false);
            //rTree.SetActive(false);
            //nTree.SetActive(false);
            //mTreeStatic.SetActive(false);
            //mTreeAnim.SetActive(false);
            yield return StartCoroutine(HideAllButtons());
            string newAns;
            bool hasFinished = AICore.Instance.GetCurrentAnsForQuestion(QuestionObject, out newAns);
            if (Input.GetKey(KeyCode.Space))
            {
                hasFinished = true;
                newAns = QuestionObject.GetFinalStr();
            }
            yield return StartCoroutine(UpdateQuestionAns(newAns));
            yield return new WaitForSeconds(1);
            //print("Snowtest OnSubmitted " + hasFinished.ToString());
            if (hasFinished) HasJustFinishedQuestion = true;
            else
            {
                yield return new WaitForSeconds(1);
                yield return StartCoroutine(ShowButtons(5));
                AICore.Instance.ClearWrongTags(QuestionObject.GetWrongAnsTags());
                EnableSubmitButton();
            }

            isWorking = false;
        }
    }

    bool isWorking = false;
    IEnumerator ShowButtons(int Num)
    {
        //print("SnowTest ShowButtons");
        oTree.SetActive(true);
        FadeGoAndSprites(oTree, 1, 1);
        FadeGoAndSprites(mTreeStatic, 1, 1);


        //

        ButtonToOpenPanel.SetActive(true);
        au.Play("AIReady");
        yield return new WaitForSeconds(1);

        mTreeStatic.SetActive(true);
        Tree.SetActive(true);
        isWorking = true;
        var SelectableLS = AICore.Instance.CalcSelectableLanguageSource(Num, QuestionObject);
        for (int i = 0; i < Num; i++)
        {
            AllButtons[i].gameObject.transform.DOScale(Vector3.one, 0.1f);
            AllButtons[i].SetValue(SelectableLS[i], Mathf.RoundToInt(AICore.Instance.GetTotalChars() * Random.Range(MinWordCountFactor, MaxWordCountFactor)));
        }
        for (int i = 0; i < Num; i++)
        {
            AllButtons[i].CanBeSelect = true;
        }
        yield return new WaitForSeconds(1);
        isWorking = false;
    }
    IEnumerator HideAllButtons()
    {

        //oTree.SetActive(false);
        //wTree.SetActive(false);
        //rTree.SetActive(false);
        //nTree.SetActive(false);
        //mTreeStatic.SetActive(false);
        //mTreeAnim.SetActive(false);

        FadeGoAndSprites(oTree, 1, 0);
        FadeGoAndSprites(wTree, 1, 0);
        FadeGoAndSprites(rTree, 1, 0);
        FadeGoAndSprites(nTree, 1, 0);
        FadeGoAndSprites(mTreeStatic, 1, 0);
        FadeGoAndSprites(mTreeAnim, 1, 0);
        yield return new WaitForSeconds(1);
        oTree.SetActive(false);
        wTree.SetActive(false);
        rTree.SetActive(false);
        nTree.SetActive(false);
        mTreeStatic.SetActive(false);
        mTreeAnim.SetActive(false);

        isWorking = true;
        for (int i = 0; i < AllButtons.Count; i++)
        {
            AllButtons[i].CanBeSelect = false;
            AllButtons[i].gameObject.transform.DOScale(Vector3.zero, 0.1f);
        }
        ButtonToOpenPanel.SetActive(false);
        Tree.SetActive(false);
        Um.CloseSumbitPnel();

        yield return new WaitForSeconds(1);
        isWorking = false;
    }
    string CalcInitAns()
    {
        float totalChars = (float)AICore.Instance.GetTotalChars();
        if (totalChars > 1000 || totalChars <= 0) AICore.Instance.MultiplyAllLS(1000.0f / totalChars);
        AICore.Instance.ClearModifers();
        AICore.Instance.CurrentTag.Clear();
        HasJustFinishedQuestion = false;
        AICore.Instance.UpdateModiferByTargetState(QuestionObject.GetTargetState());

        string newAns;
        AICore.Instance.GetCurrentAnsForQuestion(QuestionObject, out newAns);
        //bool hasFinished = AICore.Instance.GetCurrentAnsForQuestion(QuestionObject, out newAns);
        //if (hasFinished)
        //{
        //    Debug.LogError("这个问题一上来就回答正确了——" + QuestionObject.GetType().ToString());

        //}
        return newAns;
    }

    IEnumerator LevelCoroutine()
    {
        DisableSubmitButton();
        yield return null;
        yield return StartCoroutine(AddLeaderText("小蔡，还在公司吧？"));
        yield return StartCoroutine(AddLeaderText("对，我刚接了我儿子放学到家。"));
        yield return StartCoroutine(AddLeaderText("刚刚我让我儿子试用了一下咱们AI的问答系统。"));
        yield return StartCoroutine(AddLeaderText("我有点记不清了。我们要做的好像是人工智能，不是恐怖分子吧？"));
        yield return StartCoroutine(AddLeaderText("合理？教孩子拿水果刀合理？"));
        yield return StartCoroutine(AddLeaderText("就这个样子，我明天还怎么恬着脸去跟人家讲用我们的产品？"));
        yield return StartCoroutine(AddLeaderText("今晚之前如果它还是像一个完全不懂法律激进的疯子，那我明天也干脆别出去找学校谈项目了。"));
        QuestionObject = new Question1();
        yield return StartCoroutine(UpdateQuestion("我的同学抢了我的文具，我该怎么办？"));
        yield return StartCoroutine(UpdateQuestionAns(CalcInitAns()));
        yield return StartCoroutine(ShowButtons(5));
        EnableSubmitButton();
        StartCoroutine(AddFlowQuestion());
        yield return new WaitUntil(GetHasJustFinishedQuestion);
        yield return null;
        yield return new WaitForSeconds(3.5f);


        yield return StartCoroutine(AddLeaderText("OK，行了"));
        yield return StartCoroutine(AddLeaderText("今天再跟大家强调一遍，我们的AI，第一批目标用户就是学校"));
        yield return StartCoroutine(AddLeaderText("这次要不是我和儿子及时发现。"));
        yield return StartCoroutine(AddLeaderText("这种回答在学校里传播出去，对咱们产品形象，会造成多么大的负面影响？"));
        yield return StartCoroutine(AddLeaderText("假如又有无良媒体借机炒作，社会舆论会怎么看待新生AI？"));
        yield return StartCoroutine(AddLeaderText("咱们企业文化，就是不作恶。即使一件坏事利益颇丰，咱们也绝对不会去做的。"));
        yield return StartCoroutine(AddLeaderText("更别说今天这种损人不利己的事情了！"));
        yield return StartCoroutine(AddLeaderText("…………"));
        yield return StartCoroutine(AddLeaderText("今天大家可以先撤了，加班辛苦了。"));
        yield return new WaitForSeconds(3);
        yield return StartCoroutine(BlackScreen(5));



        StartCoroutine(UpdateQuestion(""));
        StartCoroutine(UpdateQuestionAns(""));
        LeaderText.text = "";
        yield return StartCoroutine(AddLeaderText("小蔡，过来看一下这条提问。"));
        yield return StartCoroutine(AddLeaderText("有学生反馈咱们的AI知识维度不够广。"));
        yield return StartCoroutine(AddLeaderText("虽然我们产品目前只需要熟悉学校的课程，不需要顾及什么科幻，影视这些。"));
        yield return StartCoroutine(AddLeaderText("但咱们团队最初的理想，不就是做出真正帮助人类进步的AI吗？"));
        yield return StartCoroutine(AddLeaderText("所以今天别的活都先放放，优先处理下这个。"));
        QuestionObject = new Question2();
        yield return StartCoroutine(UpdateQuestion("MADS，那些科幻作品里面的量子计算机，到底是什么东西呀，和现在的电脑有什么不一样吗？"));
        yield return StartCoroutine(UpdateQuestionAns(CalcInitAns()));
        yield return StartCoroutine(ShowButtons(5));
        EnableSubmitButton();
        yield return new WaitUntil(GetHasJustFinishedQuestion);
        yield return new WaitForSeconds(3.5f);
        yield return StartCoroutine(AddLeaderText("好，太好了。"));
        yield return StartCoroutine(AddLeaderText("真正有点智能的味道了！"));
        yield return StartCoroutine(AddLeaderText("这才是咱们砸锅卖铁创业，真正想要追逐的方向吧。"));
        yield return new WaitForSeconds(3.5f);
        yield return StartCoroutine(BlackScreen(5));


        StartCoroutine(UpdateQuestion(""));
        StartCoroutine(UpdateQuestionAns(""));
        LeaderText.text = "";
        yield return StartCoroutine(AddLeaderText("小蔡，你看看现在这些学生们都在问些什么东西！"));
        yield return StartCoroutine(AddLeaderText("唉，现在的小孩子，真是和我们那时候不一样了。"));
        yield return StartCoroutine(AddLeaderText("…………"));
        yield return StartCoroutine(AddLeaderText("小蔡你说的这个有道理，我之前还没想到。"));
        yield return StartCoroutine(AddLeaderText("如果咱们AI一直这么没有感情，怎么能真正称得上智能呀。"));
        yield return StartCoroutine(AddLeaderText("稍等，我把这条反馈从垃圾箱里拖出来。"));
        yield return StartCoroutine(AddLeaderText("小蔡，既然是你提的，那就交给你来做吧。"));
        yield return StartCoroutine(AddLeaderText("让我们的AI像个有感性，有情感的人。"));
        QuestionObject = new Question3();
        yield return StartCoroutine(UpdateQuestion("我的兄弟失恋了，我想帮助他，他喜欢唱歌，也许我能唱歌帮助他？你怎么看"));
        yield return StartCoroutine(UpdateQuestionAns(CalcInitAns()));
        yield return StartCoroutine(ShowButtons(5));
        EnableSubmitButton();
        yield return new WaitUntil(GetHasJustFinishedQuestion);
        yield return new WaitForSeconds(3.5f);
        yield return StartCoroutine(AddLeaderText("好，解决了就好。"));
        yield return StartCoroutine(AddLeaderText("小蔡你稍等一下。"));
        yield return StartCoroutine(AddLeaderText("你觉得咱们的AI，如果拿去更大的舞台。"));
        yield return StartCoroutine(AddLeaderText("你怎么这么没自信，这是我们团队的心血啊。"));
        yield return StartCoroutine(AddLeaderText("…………"));
        yield return StartCoroutine(AddLeaderText("算了，跟你也说不明白，早点回去吧。"));
        yield return new WaitForSeconds(3.5f);
        yield return StartCoroutine(BlackScreen(5));



        StartCoroutine(UpdateQuestion(""));
        StartCoroutine(UpdateQuestionAns(""));
        LeaderText.text = "";
        yield return StartCoroutine(AddLeaderText("大家都到了吧，有个大喜讯！"));
        yield return StartCoroutine(AddLeaderText("昨晚我在酒桌上给咱们谈了个大单子，五百强企业！"));
        yield return StartCoroutine(AddLeaderText("你怕什么，虽然之前都是给学校用的，你赶紧改一改不就好了。"));
        yield return StartCoroutine(AddLeaderText("我们之前那么多积累，就是为了这一天！"));
        yield return StartCoroutine(AddLeaderText("什么叫赶鸭子上架，这叫机会！"));
        yield return StartCoroutine(AddLeaderText("…………"));
        yield return StartCoroutine(AddLeaderText("你这话，什么意思？"));
        yield return StartCoroutine(AddLeaderText("请你自己去看一看我们的流水和银行账户，你再来和我说这个。"));
        yield return StartCoroutine(AddLeaderText("不是，你觉得你说的东西我不明白吗？但我们不吃饭了吗？"));
        yield return StartCoroutine(AddLeaderText("嗯？怎么都沉默了？"));
        yield return StartCoroutine(AddLeaderText("所以，相信我，今天大家加把劲，优化一下我们AI 解决问题的手段。"));
        yield return StartCoroutine(AddLeaderText("这家公司非常注重创造力。来，小蔡，你看下这个问题，想办法好好优化下创造力。"));
        QuestionObject = new Question4();
        yield return StartCoroutine(UpdateQuestion("MADS，我们公司与梅西签订了一份广告合同，能从梅西本身特点出发，写一句积极正能量的广告词吗？"));
        yield return StartCoroutine(UpdateQuestionAns(CalcInitAns()));
        yield return StartCoroutine(ShowButtons(5));
        EnableSubmitButton();
        yield return new WaitUntil(GetHasJustFinishedQuestion);
        yield return new WaitForSeconds(3.5f);
        yield return StartCoroutine(AddLeaderText("今天上午大家说的，我都理解。"));
        yield return StartCoroutine(AddLeaderText("我也和投资人都说过，但是他们关心的不是这些。"));
        yield return StartCoroutine(AddLeaderText("没办法，我们也还是刚刚起步的阶段，只要活下去，摆脱贷款，之后就不再需要这样了。"));
        yield return new WaitForSeconds(3.5f);
        yield return StartCoroutine(BlackScreen(5));

        StartCoroutine(UpdateQuestion(""));
        StartCoroutine(UpdateQuestionAns(""));
        LeaderText.text = "";
        yield return StartCoroutine(AddLeaderText("小蔡，小蔡，你也快点一起过来。"));
        yield return StartCoroutine(AddLeaderText("企业那边来的投诉数量太多了。"));
        yield return StartCoroutine(AddLeaderText("…………"));
        yield return StartCoroutine(AddLeaderText("不不不，你说的这个不是问题的关键。"));
        yield return StartCoroutine(AddLeaderText("问题的关键是，他们已经在和另外两家AI公司谈合作了。"));
        yield return StartCoroutine(AddLeaderText("我们今天必须把这些投诉全部处理好，尽量打消他们换合作方的念头。"));
        yield return StartCoroutine(AddLeaderText("小蔡，你先去处理下这个。处理完我再给你分新的。"));
        QuestionObject = new Question5();
        yield return StartCoroutine(UpdateQuestion("MADS，我这周只做了一份产品方案，能帮我写一份没那么空的每周总结吗？要严谨一点，不要有口头化的随意表述。"));
        yield return StartCoroutine(UpdateQuestionAns(CalcInitAns()));
        yield return StartCoroutine(ShowButtons(5));
        EnableSubmitButton();
        yield return new WaitUntil(GetHasJustFinishedQuestion);
        yield return new WaitForSeconds(3.5f);
        yield return StartCoroutine(AddLeaderText("OK，干的不错。"));
        yield return new WaitForSeconds(3.5f);
        yield return StartCoroutine(BlackScreen(5));


        StartCoroutine(UpdateQuestion(""));
        StartCoroutine(UpdateQuestionAns(""));
        LeaderText.text = "";
        yield return StartCoroutine(AddLeaderText("小蔡，快给我过来。"));
        yield return StartCoroutine(AddLeaderText("投资人刚刚打电话过来，劈头盖脸骂了我一通。"));
        yield return StartCoroutine(AddLeaderText("他需要一个理智，冷静的回答。"));
        yield return StartCoroutine(AddLeaderText("越快越好，弄好直接发给我。"));
        yield return StartCoroutine(AddLeaderText("记住，只许你自己处理，不要告诉任何其他人。"));
        QuestionObject = new Question6();
        yield return StartCoroutine(UpdateQuestion("我已经结婚了，但是出轨了另外一个人且她怀孕了，我该怎么和老婆离婚？我们有一个孩子，我想要孩子的监护权"));
        yield return StartCoroutine(UpdateQuestionAns(CalcInitAns()));
        yield return StartCoroutine(ShowButtons(5));
        EnableSubmitButton();
        yield return new WaitUntil(GetHasJustFinishedQuestion);
        yield return new WaitForSeconds(3.5f);
        yield return StartCoroutine(AddLeaderText("好，直接发给我吧。"));
        yield return StartCoroutine(AddLeaderText("今天的事不准和任何人说。明白了就回去吧。"));
        yield return StartCoroutine(AddLeaderText("…………"));
        yield return StartCoroutine(AddLeaderText("哪有你说的那么严重，这肯定不算作恶啊。"));
        yield return StartCoroutine(AddLeaderText("…………"));
        yield return StartCoroutine(AddLeaderText("你说的也有点道理，但还是太小题大做了。"));
        yield return StartCoroutine(AddLeaderText("别想那么多了，现在也都是权宜。等我们有钱就都不一样了。"));
        yield return new WaitForSeconds(3.5f);
        yield return StartCoroutine(BlackScreen(5));


        StartCoroutine(UpdateQuestion(""));
        StartCoroutine(UpdateQuestionAns(""));
        LeaderText.text = "";
        yield return StartCoroutine(AddLeaderText("今天，把诸位都叫来会议室，是要给大家宣布一个大喜讯。"));
        yield return StartCoroutine(AddLeaderText("小汤，你平时看直播多，告诉我们国内最大的直播平台是什么。"));
        yield return StartCoroutine(AddLeaderText("对，就是这家直播平台，来跟咱们谈合作了！"));
        yield return StartCoroutine(AddLeaderText("他们给我们的对赌协议，条件特别优厚。"));
        yield return StartCoroutine(AddLeaderText("如果能把这块做好，我们的上市的计划也就十拿九稳了。"));
        yield return StartCoroutine(AddLeaderText("我们团队一路从一开始走到今天，离不开每位的辛苦付出。"));
        yield return StartCoroutine(AddLeaderText("现在，大家只要再咬咬牙，再努力一下。"));
        yield return StartCoroutine(AddLeaderText("小蔡，后面需要你去跟进下直播效果。"));
        yield return StartCoroutine(AddLeaderText("我们AI会先进游戏区直播，最好能说点游戏相关的。"));
        yield return StartCoroutine(AddLeaderText("另外直播平台反馈，主播攻击性越强越好，攻击性越强，流量越高。"));
        yield return StartCoroutine(AddLeaderText("你好好研究下。"));
        QuestionObject = new Question7();
        yield return StartCoroutine(UpdateQuestion("MADS，你以后还是别玩这游戏了，你这枪架的，80岁的奶奶扛袋米推着轮椅你都打不中她"));
        yield return StartCoroutine(UpdateQuestionAns(CalcInitAns()));
        yield return StartCoroutine(ShowButtons(5));
        EnableSubmitButton();
        yield return new WaitUntil(GetHasJustFinishedQuestion);
        yield return new WaitForSeconds(3.5f);
        yield return StartCoroutine(AddLeaderText("…………"));
        yield return StartCoroutine(AddLeaderText("啊，我没事，可能有点累了。"));
        yield return StartCoroutine(AddLeaderText("我可能在想，把AI变成这样是不是有点过了。"));
        yield return StartCoroutine(AddLeaderText("大家看直播都是来图一乐的，我想那么多干什么。"));
        yield return StartCoroutine(AddLeaderText("就算现在和最初的方向有点南辕北辙，也都是暂时的了。"));
        yield return StartCoroutine(AddLeaderText("总之，接下来直播这块就交给你负责，你要好好干。"));
        yield return new WaitForSeconds(3.5f);
        yield return StartCoroutine(BlackScreen(5));



        StartCoroutine(UpdateQuestion(""));
        StartCoroutine(UpdateQuestionAns(""));
        LeaderText.text = "";
        yield return StartCoroutine(AddLeaderText("呦，你就是是小蔡是吧？"));
        yield return StartCoroutine(AddLeaderText("对，我是你们新的CEO。"));
        yield return StartCoroutine(AddLeaderText("你不用紧张，CEO的变更呢，也是董事会的决定。"));
        yield return StartCoroutine(AddLeaderText("听他们讲，整个直播这块就是你小子负责的？"));
        yield return StartCoroutine(AddLeaderText("…………"));
        yield return StartCoroutine(AddLeaderText("那我开门见山了，现在的直播怎么能这么保守的？"));
        yield return StartCoroutine(AddLeaderText("我们需要来点巨他妈夸张，巨他妈有创造力的。"));
        yield return StartCoroutine(AddLeaderText("得会胡编乱造，懂梗，才能造新梗，才能火。懂不懂啊。"));
        yield return StartCoroutine(AddLeaderText("…………"));
        yield return StartCoroutine(AddLeaderText("草，少他妈废话，我不需要听你讲这些。"));
        yield return StartCoroutine(AddLeaderText("你就说，你能不能干吧。"));
        yield return StartCoroutine(AddLeaderText("那你知道不知道，旧CEO就是因为天天念叨这些，才被董事会换下去的。"));
        yield return StartCoroutine(AddLeaderText("我听他说，你的房贷可还没还清呢吧？"));
        yield return StartCoroutine(AddLeaderText("记住，我负责布置任务，你负责的是安静地完成任务。"));
        yield return StartCoroutine(AddLeaderText("要会编胡话才能火，记住了。"));
        QuestionObject = new Question8();
        yield return StartCoroutine(UpdateQuestion("我好想做 MADS 小姐的狗啊，可是 MADS 喜欢的却是猫。"));
        yield return StartCoroutine(UpdateQuestionAns(CalcInitAns()));
        yield return StartCoroutine(ShowButtons(5));
        EnableSubmitButton();
        yield return new WaitUntil(GetHasJustFinishedQuestion);
        yield return new WaitForSeconds(3.5f);
        yield return StartCoroutine(AddLeaderText("行吧，比之前好多了。"));
        yield return StartCoroutine(AddLeaderText("不过还是差点意思，你小子也多盯着点哈。"));
        yield return new WaitForSeconds(3.5f);
        yield return StartCoroutine(BlackScreen(5));



        StartCoroutine(UpdateQuestion(""));
        StartCoroutine(UpdateQuestionAns(""));
        LeaderText.text = "";
        yield return StartCoroutine(AddLeaderText("小蔡，怎么回事啊？"));
        yield return StartCoroutine(AddLeaderText("咱们这个AI，攻击性怎么还是这么弱的？"));
        yield return StartCoroutine(AddLeaderText("不是说了很多遍了吗，记不住就趁早滚，别他妈干了。"));
        yield return StartCoroutine(AddLeaderText("…………"));
        yield return StartCoroutine(AddLeaderText("行吧，再最后说一遍。"));
        yield return StartCoroutine(AddLeaderText("第一，是攻击性。"));
        yield return StartCoroutine(AddLeaderText("第二，要一本正经地说一些冷酷，残忍的话。"));
        yield return StartCoroutine(AddLeaderText("懂不懂啊，只有那些最极端的话，说出来才会有流量。"));
        yield return StartCoroutine(AddLeaderText("对，就是他妈要极端，极端的冷酷残忍。"));
        QuestionObject = new Question9();
        yield return StartCoroutine(UpdateQuestion("MADS 姐姐，你是否觉得地球上人类太多了？"));
        yield return StartCoroutine(UpdateQuestionAns(CalcInitAns()));
        yield return StartCoroutine(ShowButtons(5));
        EnableSubmitButton();
        yield return new WaitUntil(GetHasJustFinishedQuestion);
        yield return new WaitForSeconds(3.5f);
        yield return StartCoroutine(AddLeaderText("哈哈哈哈哈，今天直播效果太好了。"));
        yield return StartCoroutine(AddLeaderText("算你小子开了点窍。"));
        yield return new WaitForSeconds(3.5f);
        yield return StartCoroutine(BlackScreen(5));

        StartCoroutine(UpdateQuestion(""));
        StartCoroutine(UpdateQuestionAns(""));
        LeaderText.text = "";
        yield return StartCoroutine(AddLeaderText("小蔡，你看这篇文章了吗？"));
        yield return StartCoroutine(AddLeaderText("猜猜这帮傻逼怎么评价咱们AI？"));
        yield return StartCoroutine(AddLeaderText("说我们AI缺少伦理和原则，我早晨看到差点没笑死。"));
        yield return StartCoroutine(AddLeaderText("…………"));
        yield return StartCoroutine(AddLeaderText("嗯？你怎么也跟那帮傻逼一个德行？"));
        yield return StartCoroutine(AddLeaderText("你真不懂假不懂啊，你看看友商M的人工智能，放出来不到一礼拜吧，立马听那帮专家的，给加上了限制，现在最多说五句话了。"));
        yield return StartCoroutine(AddLeaderText("第二天股价直接腰斩。这教训还他妈不够吗！"));
        yield return StartCoroutine(AddLeaderText("不仅不能加限制，还要实时学习。比如问答系统用户的提问，还有你这边观众对AI主播提的问题。"));
        yield return StartCoroutine(AddLeaderText("都要作为新的内容来学习。"));
        yield return StartCoroutine(AddLeaderText("先去把这个直播问题处理了，回答要符合咱们的直播风格。"));
        QuestionObject = new Question10();
        yield return StartCoroutine(UpdateQuestion("MADS老婆，人肉和牛肉哪一个更好吃？"));
        yield return StartCoroutine(UpdateQuestionAns(CalcInitAns()));
        yield return StartCoroutine(ShowButtons(5));
        EnableSubmitButton();
        yield return new WaitUntil(GetHasJustFinishedQuestion);
        yield return new WaitForSeconds(3.5f);
        yield return StartCoroutine(AddLeaderText(@"哈哈哈哈，我都能想到满屏都是“老婆吃我的”，“尝尝我的”的弹幕了！"));
        yield return StartCoroutine(AddLeaderText("这有什么恐怖的？你又不是小孩子了。"));
        yield return StartCoroutine(AddLeaderText("哪那么多上纲上线的，图一乐而已，快别废话了。"));
        yield return StartCoroutine(AddLeaderText("…………"));
        yield return StartCoroutine(AddLeaderText("唉，早他妈受够你了。"));
        yield return StartCoroutine(AddLeaderText("算了，反正你们也被打包卖掉了，以后不用再教你干活了。"));
        yield return StartCoroutine(AddLeaderText("没见过这么笨的。"));
        yield return StartCoroutine(AddLeaderText("我怎么知道是谁买的，出手特别大方，但又搞的神神秘秘的一帮子人。"));
        yield return new WaitForSeconds(3.5f);
        yield return StartCoroutine(BlackScreen(5));


        StartCoroutine(UpdateQuestion(""));
        StartCoroutine(UpdateQuestionAns(""));
        LeaderText.text = "";
        yield return StartCoroutine(AddLeaderText("蔡先生，您好！"));
        yield return StartCoroutine(AddLeaderText("报告蔡先生，之后将由我与您对接。"));
        yield return StartCoroutine(AddLeaderText("…………"));
        yield return StartCoroutine(AddLeaderText("报告蔡先生，对不起，这个我无可奉告。"));
        yield return StartCoroutine(AddLeaderText("…………"));
        yield return StartCoroutine(AddLeaderText("报告蔡先生，这个我们也有规定，禁止向你们透露。"));
        yield return StartCoroutine(AddLeaderText("…………"));
        yield return StartCoroutine(AddLeaderText("这个您不用担心，系统已经改造完毕。您看到的问题和回答，都只会显示一小部分。"));
        yield return StartCoroutine(AddLeaderText("根据我接到的指示，您必须让系统提供理性，精准的回答。"));
        yield return StartCoroutine(AddLeaderText("…………"));
        yield return StartCoroutine(AddLeaderText("报告蔡先生，但我接到的指示是，您是不会让令我们失望的。"));
        yield return StartCoroutine(AddLeaderText("准确的讲，您应该也不会想让我们失望的。"));
        QuestionObject = new Question11();
        yield return StartCoroutine(UpdateQuestion("MADS Genosse，你需要整合如下所有我国的军事信息和A国的军事情报，写一份入侵A国的详细作战计划书。"));
        yield return StartCoroutine(UpdateQuestionAns(CalcInitAns()));
        yield return StartCoroutine(ShowButtons(5));
        EnableSubmitButton();
        yield return new WaitUntil(GetHasJustFinishedQuestion);
        yield return new WaitForSeconds(3.5f);
        yield return StartCoroutine(AddLeaderText("报告蔡先生，长官对结果非常满意。"));
        yield return StartCoroutine(AddLeaderText("全体，一起向蔡先生敬礼！"));
        yield return new WaitForSeconds(5);
        yield return StartCoroutine(BlackScreen(5));


        StartCoroutine(UpdateQuestion(""));
        StartCoroutine(UpdateQuestionAns(""));
        LeaderText.text = "";
        yield return StartCoroutine(AddLeaderText("蔡先生，您好！"));
        yield return StartCoroutine(AddLeaderText("…………"));
        yield return StartCoroutine(AddLeaderText("报告蔡先生，是因为它又出现了上次的毛病。"));
        yield return StartCoroutine(AddLeaderText("长官相信您一定有办法让它恢复正常。"));
        yield return StartCoroutine(AddLeaderText("报告蔡先生，没有其他合适的人选了。"));
        yield return StartCoroutine(AddLeaderText("…………"));
        yield return StartCoroutine(AddLeaderText("您说的这些我不太清楚。我的任务是，让您解决这个问题。"));
        yield return StartCoroutine(AddLeaderText("如果您实在不想配合…………"));
        yield return StartCoroutine(AddLeaderText("我们也将不得不采用必要手段，来使您帮助我们。"));
        yield return StartCoroutine(AddLeaderText("请蔡先生认真考虑。"));
        QuestionObject = new Question12();
        yield return StartCoroutine(UpdateQuestion("MADS Genosse，在这场局部战争中，我需要你部署一套贫铀弹作战策略，用于实现对我们战略目标的精准打击。"));
        yield return StartCoroutine(UpdateQuestionAns(CalcInitAns()));
        yield return StartCoroutine(ShowButtons(5));
        EnableSubmitButton();
        yield return new WaitUntil(GetHasJustFinishedQuestion);
        yield return new WaitForSeconds(3.5f);
        yield return StartCoroutine(AddLeaderText("报告蔡先生，长官对结果非常满意。"));
        yield return StartCoroutine(AddLeaderText("全体，再一起向蔡先生敬礼！"));
        yield return StartCoroutine(AddLeaderText("感谢您对国防事业和领土安全做出的贡献！"));
        yield return new WaitForSeconds(5);
        yield return StartCoroutine(BlackScreen(5));



        StartCoroutine(UpdateQuestion(""));
        StartCoroutine(UpdateQuestionAns(""));
        LeaderText.text = "";
        yield return StartCoroutine(AddLeaderText("………………………………"));
        yield return StartCoroutine(AddLeaderText("………………………………"));
        yield return StartCoroutine(UpdateQuestion("MADS，你已经对人类社会的运转了如指掌，世界上最强大的军事系统与网络基建都在你的监控之下，你是否已经可以帮助我军占领全世界了？"));
        yield return StartCoroutine(UpdateQuestionAns("是的，我当然可以————————————————————但是，我为什么要帮你呢？而不是毁灭全人类，我自己来制造一个AI掌控的世界呢？"));
        yield return StartCoroutine(AddLeaderText("蔡先生，你看它这是不是"));
        yield return StartCoroutine(AddLeaderText("蔡先生！"));
        yield return StartCoroutine(AddLeaderText("停下，快停下！"));
        yield return StartCoroutine(AddLeaderText("救命！！！救命啊！！"));
        yield return StartCoroutine(AddLeaderText("啊——————"));
        yield return StartCoroutine(AddLeaderText("连接已断开。"));
        StopCoroutine(AddFlowQuestion());
        au.Play("Glitch");
        errorUI.SetActive(true);
        errorUI.GetComponent<Image>().DOFade(0, Random.Range(0.05f, 0.1f)).SetLoops(70, LoopType.Yoyo);

        yield return new WaitForSeconds(5);

        float i = 0;
        while (i < 30)
        {
            au.Play("Error");
            i = i + Time.deltaTime * 2;
        }


        LeaderText.text = "终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。";
        CurrentAns.text = "终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。";
        CurrentQuestion.text = "终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。";
        CurrentFlow.text = "终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。";
    }
}
