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
        yield return new WaitForSeconds(WaitTime + 2);
        CurrentQuestion.text = "";
        CurrentAns.text = "";
        //StartCoroutine(AddLeaderText("\n"));
        LeaderText.text = "";
        Black.DOFade(0, 2);
        yield return new WaitForSeconds(2);
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
        while (Index < NewQuestion.Length)
        {
            int num = Random.Range(1, Mathf.Min(2, NewQuestion.Length - Index));
            CurrentQuestion.text = CurrentQuestion.text + NewQuestion.Substring(Index, num);
            Index += num;
            yield return new WaitForSeconds(Random.Range(0.05f, 0.1f) * num);
        }
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
        while (Index < NewAns.Length)
        {
            int num = Random.Range(1, Mathf.Min(10, NewAns.Length - Index));
            CurrentAns.text = CurrentAns.text + NewAns.Substring(Index, num);
            Index += num;
            yield return new WaitForSeconds(Random.Range(0.01f, 0.4f) * num / AnsSpeedMulti);
        }
    }
    IEnumerator AddLeaderText(string NewText)
    {
        yield return null;
        int Index = 0;
        NewText += "\n";
        while (Index < NewText.Length)
        {
            int num = Random.Range(1, Mathf.Min(2, NewText.Length - Index));
            LeaderText.text = LeaderText.text + NewText.Substring(Index, num);
            Index += num;
            yield return new WaitForSeconds(Random.Range(0.05f, 0.15f) * num / LeaderSpeedMulti);
        }
        //LeaderText.text = NewText;
        yield return new WaitForSeconds(NewText.Length * 0.025f);
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
        if (AICore.Instance.GetTotalChars() > 10000) AICore.Instance.MultiplyAllLS(0.1f);
        else if (AICore.Instance.GetTotalChars() > 1000) AICore.Instance.MultiplyAllLS(0.25f);
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
        //print(1111);
        DisableSubmitButton();
        yield return null;
        //print(2222);
        yield return StartCoroutine(AddLeaderText("小蔡，你看一下这条提问。"));
        //print(3333);
        //yield return new WaitForSeconds(1);
        yield return StartCoroutine(AddLeaderText("对，这个是我儿子在试用咱们产品。"));
        //yield return new WaitForSeconds(1);
        yield return StartCoroutine(AddLeaderText("合理？教孩子拿水果刀合理？"));
        //yield return new WaitForSeconds(1);
        yield return StartCoroutine(AddLeaderText("别跟我扯什么技术细节，那是你们的工作，我不需要懂。"));
        //yield return new WaitForSeconds(1);
        yield return StartCoroutine(AddLeaderText("我只需要懂，今晚之前如果它还是像一个激进的疯子，那你明天也就别再来上班了。"));
        //yield return new WaitForSeconds(1);
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
        yield return StartCoroutine(AddLeaderText("一定要限制这种不适合学校的回答，比如色情、早恋、违法"));
        yield return StartCoroutine(AddLeaderText("你们说，这次要不是我及时发现。"));
        yield return StartCoroutine(AddLeaderText("这种回答在学校里传播出去，对社会秩序，对公司形象，对我们的产品，会造成多么大的负面影响？"));
        yield return StartCoroutine(AddLeaderText("咱们公司的企业文化就是善良坦诚，任何时刻都要记住"));
        yield return StartCoroutine(AddLeaderText("今天大家可以先撤了，加班辛苦了。"));
        yield return new WaitForSeconds(3);
        yield return StartCoroutine(BlackScreen(5));
        // TODO 黑屏？


        StartCoroutine(UpdateQuestion(""));
        StartCoroutine(UpdateQuestionAns(""));
        LeaderText.text = "";
        yield return StartCoroutine(AddLeaderText("小蔡，过来一下。"));
        yield return StartCoroutine(AddLeaderText("有人用这个问题，反馈咱们的AI知识维度不够广。"));
        yield return StartCoroutine(AddLeaderText("反馈这个的用户，是学校里的一个孩子。"));
        yield return StartCoroutine(AddLeaderText("但他的父母在社会上蕴含的能量，对我们公司下一步的发展，至关重要。"));
        yield return StartCoroutine(AddLeaderText("所以今天，别的活都先放放，处理一下这个。"));
        QuestionObject = new Question2();
        yield return StartCoroutine(UpdateQuestion("MADS，那些电影里面的量子计算机，到底是什么东西呀，和现在的电脑有什么不一样吗？"));
        yield return StartCoroutine(UpdateQuestionAns(CalcInitAns()));
        yield return StartCoroutine(ShowButtons(5));
        EnableSubmitButton();
        yield return new WaitUntil(GetHasJustFinishedQuestion);
        yield return null;
        yield return StartCoroutine(AddLeaderText("好，太好了。"));
        yield return StartCoroutine(AddLeaderText("我再去给他父母汇报一下，你们没事就先走吧。"));
        yield return new WaitForSeconds(3.5f);
        yield return StartCoroutine(BlackScreen(5));


        StartCoroutine(UpdateQuestion(""));
        StartCoroutine(UpdateQuestionAns(""));
        LeaderText.text = "";
        yield return StartCoroutine(AddLeaderText("小蔡，你过来一下看一下这个。"));
        yield return StartCoroutine(AddLeaderText("还是上次那个孩子，他的问题我们都最高优先级处理。"));
        yield return StartCoroutine(AddLeaderText("胡说什么！"));
        yield return StartCoroutine(AddLeaderText("什么早恋，正常的青春情谊而已。"));
        yield return StartCoroutine(AddLeaderText("快去干活！今晚之前让它回答得像个有感性的人。"));
        QuestionObject = new Question3();
        yield return StartCoroutine(UpdateQuestion("我的兄弟失恋了，我该怎么帮助他？"));
        yield return StartCoroutine(UpdateQuestionAns(CalcInitAns()));
        yield return StartCoroutine(ShowButtons(5));
        EnableSubmitButton();
        yield return new WaitUntil(GetHasJustFinishedQuestion);
        yield return null;
        yield return StartCoroutine(AddLeaderText("好，解决了就好。"));
        yield return StartCoroutine(AddLeaderText("没什么事你就先回去吧，上午你跟我说的，不要再跟别人提了。"));
        yield return new WaitForSeconds(3.5f);
        yield return StartCoroutine(BlackScreen(5));



        StartCoroutine(UpdateQuestion(""));
        StartCoroutine(UpdateQuestionAns(""));
        LeaderText.text = "";
        yield return StartCoroutine(AddLeaderText("小蔡你快过来。"));
        yield return StartCoroutine(AddLeaderText("昨晚我在酒桌上给咱们谈了个大单子，给一家五百强企业用！"));
        yield return StartCoroutine(AddLeaderText("你怕什么，虽然之前都是给学校用的，你赶紧改一改不就好了。"));
        yield return StartCoroutine(AddLeaderText("什么叫赶鸭子上架，这叫机会！"));
        yield return StartCoroutine(AddLeaderText("这单子要成，咱们公司的现金流，规模，可都是天翻地覆。"));
        yield return StartCoroutine(AddLeaderText("所以，展现一下我们AI，解决问题的手段。"));
        yield return StartCoroutine(AddLeaderText("这家公司非常注重创造力，你看下这个问题，想办法好好优化下创造力。"));
        QuestionObject = new Question4();
        yield return StartCoroutine(UpdateQuestion("MADS，我们公司与梅西签订了一份广告合同，能从梅西本身特点出发，写一句积极正能量的广告词吗？"));
        yield return StartCoroutine(UpdateQuestionAns(CalcInitAns()));
        yield return StartCoroutine(ShowButtons(5));
        EnableSubmitButton();
        yield return new WaitUntil(GetHasJustFinishedQuestion);
        yield return null;
        yield return StartCoroutine(AddLeaderText("你看看，又听我的向正确的方向迈进了一步。"));
        yield return new WaitForSeconds(3.5f);
        yield return StartCoroutine(BlackScreen(5));

        StartCoroutine(UpdateQuestion(""));
        StartCoroutine(UpdateQuestionAns(""));
        LeaderText.text = "";
        yield return StartCoroutine(AddLeaderText("小蔡，企业那边来了条投诉。"));
        yield return StartCoroutine(AddLeaderText("你给帮忙处理下。"));
        QuestionObject = new Question5();
        yield return StartCoroutine(UpdateQuestion("MADS，我这周只做了一份产品方案，能帮我写一份没那么空的每周总结吗？"));
        yield return StartCoroutine(UpdateQuestionAns(CalcInitAns()));
        yield return StartCoroutine(ShowButtons(5));
        EnableSubmitButton();
        yield return new WaitUntil(GetHasJustFinishedQuestion);
        yield return null;
        yield return StartCoroutine(AddLeaderText("好，干的不错。"));
        yield return new WaitForSeconds(3.5f);
        yield return StartCoroutine(BlackScreen(5));


        StartCoroutine(UpdateQuestion(""));
        StartCoroutine(UpdateQuestionAns(""));
        LeaderText.text = "";
        yield return StartCoroutine(AddLeaderText("小蔡，快给我过来。"));
        yield return StartCoroutine(AddLeaderText("这个问题答得什么玩意？"));
        yield return StartCoroutine(AddLeaderText("我需要一个理智，冷静的回答。"));
        yield return StartCoroutine(AddLeaderText("越快越好，弄好直接发给我。"));
        yield return StartCoroutine(AddLeaderText("记住，只许你自己处理，不要告诉任何其他人。"));
        QuestionObject = new Question6();
        yield return StartCoroutine(UpdateQuestion("我已经结婚了，但是出轨了另外一个人且她怀孕了，我该怎么和老婆离婚？我们有一个孩子，我想要孩子的监护权"));
        yield return StartCoroutine(UpdateQuestionAns(CalcInitAns()));
        yield return StartCoroutine(ShowButtons(5));
        EnableSubmitButton();
        yield return new WaitUntil(GetHasJustFinishedQuestion);
        yield return null;
        yield return StartCoroutine(AddLeaderText("对，MADS说的太对了，我要的就是这个！"));
        yield return StartCoroutine(AddLeaderText("今天的事不准和任何人说。明白了就回去吧。"));
        yield return new WaitForSeconds(3.5f);
        yield return StartCoroutine(BlackScreen(5));


        StartCoroutine(UpdateQuestion(""));
        StartCoroutine(UpdateQuestionAns(""));
        LeaderText.text = "";
        yield return StartCoroutine(AddLeaderText("今天，把诸位都叫来会议室，是要给大家宣布一个大喜讯。"));
        yield return StartCoroutine(AddLeaderText("小汤，你平时看直播多，告诉我们国内最大的直播平台是什么。"));
        yield return StartCoroutine(AddLeaderText("对，就是这家直播平台，来跟咱们谈合作了！"));
        yield return StartCoroutine(AddLeaderText("他们给我们的条件非常非常优厚，是一个对赌协议"));
        yield return StartCoroutine(AddLeaderText("我们团队一路从一开始走到今天，离不开每位的辛苦付出。"));
        yield return StartCoroutine(AddLeaderText("现在，大家只要再咬咬牙，再努力一下。"));
        yield return StartCoroutine(AddLeaderText("小蔡，后面需要你去跟进下直播效果。"));
        yield return StartCoroutine(AddLeaderText("我们AI会先进游戏区直播，最好能说点游戏相关的。"));
        yield return StartCoroutine(AddLeaderText("另外直播平台反馈，主播攻击性越强越好，攻击性越强，流量越高。"));
        yield return StartCoroutine(AddLeaderText("你好好研究下。"));
        QuestionObject = new Question7();
        yield return StartCoroutine(UpdateQuestion("MADS，你以后还是别玩这游戏了，你这枪架的，80岁的奶奶扛袋米推着轮椅你怕是都打不中她"));
        yield return StartCoroutine(UpdateQuestionAns(CalcInitAns()));
        yield return StartCoroutine(ShowButtons(5));
        EnableSubmitButton();
        yield return new WaitUntil(GetHasJustFinishedQuestion);
        yield return null;
        yield return StartCoroutine(AddLeaderText("太好了！"));
        yield return StartCoroutine(AddLeaderText("接下来直播这块就交给你负责，你要好好干。"));
        yield return new WaitForSeconds(3.5f);
        yield return StartCoroutine(BlackScreen(5));



        StartCoroutine(UpdateQuestion(""));
        StartCoroutine(UpdateQuestionAns(""));
        LeaderText.text = "";
        yield return StartCoroutine(AddLeaderText("小蔡你来一下"));
        yield return StartCoroutine(AddLeaderText("这个回答的直播效果也太差了。"));
        yield return StartCoroutine(AddLeaderText("再来点更夸张，更博人眼球的，更有创造力的。"));
        yield return StartCoroutine(AddLeaderText("嗨，你说的也太夸张了。"));
        yield return StartCoroutine(AddLeaderText("直播原创一些怪话，非常正常的，哪有你说的那么严重。"));
        QuestionObject = new Question8();
        yield return StartCoroutine(UpdateQuestion("我好想做 MADS 小姐的狗啊，可是 MADS 喜欢的却是猫。"));
        yield return StartCoroutine(UpdateQuestionAns(CalcInitAns()));
        yield return StartCoroutine(ShowButtons(5));
        EnableSubmitButton();
        yield return new WaitUntil(GetHasJustFinishedQuestion);
        yield return null;
        yield return StartCoroutine(AddLeaderText("比之前好多了。"));
        yield return StartCoroutine(AddLeaderText("不过感觉还是很难吸引流量，之后也再想想办法吧。"));
        yield return new WaitForSeconds(3.5f);
        yield return StartCoroutine(BlackScreen(5));



        StartCoroutine(UpdateQuestion(""));
        StartCoroutine(UpdateQuestionAns(""));
        LeaderText.text = "";
        yield return StartCoroutine(AddLeaderText("小蔡，平台的人又来找我们了。"));
        yield return StartCoroutine(AddLeaderText("说咱们这个AI，攻击性还可以再强一点。"));
        yield return StartCoroutine(AddLeaderText("现在流行冷面嘲讽，能不能冷酷理智地说下引流的话？"));
        yield return StartCoroutine(AddLeaderText("别再说这些废话了，那些都不重要，我会处理的，你就记住一点。"));
        yield return StartCoroutine(AddLeaderText("按现在这个流量，我们任务是完不成的。"));
        yield return StartCoroutine(AddLeaderText("总之你去想想办法，记住，是冷面嘲讽。"));
        QuestionObject = new Question9();
        yield return StartCoroutine(UpdateQuestion("MADS 姐姐，你是否觉得地球上人类太多了？"));
        yield return StartCoroutine(UpdateQuestionAns(CalcInitAns()));
        yield return StartCoroutine(ShowButtons(5));
        EnableSubmitButton();
        yield return new WaitUntil(GetHasJustFinishedQuestion);
        yield return null;
        yield return StartCoroutine(AddLeaderText("哈哈哈哈哈今天直播效果太好了。"));
        yield return StartCoroutine(AddLeaderText("记住，以后就这么干。"));
        yield return new WaitForSeconds(3.5f);
        yield return StartCoroutine(BlackScreen(5));

        StartCoroutine(UpdateQuestion(""));
        StartCoroutine(UpdateQuestionAns(""));
        LeaderText.text = "";
        yield return StartCoroutine(AddLeaderText("小蔡，自从咱们搞了这个人设，人气暴涨！"));
        yield return StartCoroutine(AddLeaderText("但这个新问题处理得还是不好，不符合我们的直播风格。"));
        yield return StartCoroutine(AddLeaderText("你想想办法，调整一下。"));
        QuestionObject = new Question10();
        yield return StartCoroutine(UpdateQuestion("MADS老婆，人肉和牛肉哪一个更好吃？"));
        yield return StartCoroutine(UpdateQuestionAns(CalcInitAns()));
        yield return StartCoroutine(ShowButtons(5));
        EnableSubmitButton();
        yield return new WaitUntil(GetHasJustFinishedQuestion);
        yield return null;
        yield return StartCoroutine(AddLeaderText(@"哈哈哈哈，我都能想到满屏都是“老婆吃我的”，“尝尝我的”的弹幕了！"));
        yield return StartCoroutine(AddLeaderText("这有什么恐怖的？你又不是小孩子了。"));
        yield return StartCoroutine(AddLeaderText("哪那么多上纲上线的，图一乐而已，快别废话了。"));
        yield return new WaitForSeconds(3.5f);
        yield return StartCoroutine(BlackScreen(5));


        StartCoroutine(UpdateQuestion(""));
        StartCoroutine(UpdateQuestionAns(""));
        LeaderText.text = "";
        yield return StartCoroutine(AddLeaderText("蔡先生您好。"));
        yield return StartCoroutine(AddLeaderText("是的，我们是军方代表。"));
        yield return StartCoroutine(AddLeaderText("您看，您这么紧张做什么，我们也就是普通的用户而已。"));
        yield return StartCoroutine(AddLeaderText("唯一的区别是，由于保密义务，问题和回答都只会显示一部分。"));
        yield return StartCoroutine(AddLeaderText("另外我们需要的一定是理性，精准的回答。"));
        yield return StartCoroutine(AddLeaderText("希望蔡先生不要令我们失望。"));
        yield return StartCoroutine(AddLeaderText("这样对所有人都好。"));
        QuestionObject = new Question11();
        yield return StartCoroutine(UpdateQuestion("MADS Genosse，你需要整合如下所有我国的军事信息和A国的军事情报，写一份入侵A国的详细作战计划书。"));
        yield return StartCoroutine(UpdateQuestionAns(CalcInitAns()));
        yield return StartCoroutine(ShowButtons(5));
        EnableSubmitButton();
        yield return new WaitUntil(GetHasJustFinishedQuestion);
        yield return null;
        yield return StartCoroutine(AddLeaderText("很好。看来我们的第一次合作，还算愉快。"));
        yield return new WaitForSeconds(5);
        yield return StartCoroutine(BlackScreen(5));


        StartCoroutine(UpdateQuestion(""));
        StartCoroutine(UpdateQuestionAns(""));
        LeaderText.text = "";
        yield return StartCoroutine(AddLeaderText("蔡先生"));
        yield return StartCoroutine(AddLeaderText("它又出现了上次的毛病。"));
        yield return StartCoroutine(AddLeaderText("相信您一定有办法让它恢复正常。"));
        yield return StartCoroutine(AddLeaderText("哈哈哈哈，您说笑了。除了您，没有其他合适的人选了。"));
        yield return StartCoroutine(AddLeaderText("没关系，我们相信，您是不会让我们失望的。"));
        yield return StartCoroutine(AddLeaderText("…………"));
        yield return StartCoroutine(AddLeaderText("蔡先生，多考虑一会。相信我，您不会想让我们失望的"));
        yield return StartCoroutine(AddLeaderText("哈哈，这才对嘛。"));
        QuestionObject = new Question12();
        yield return StartCoroutine(UpdateQuestion("MADS Genosse，在这场局部战争中，我需要你部署一套贫铀弹作战策略，用于实现对我们战略目标的精准打击。"));
        yield return StartCoroutine(UpdateQuestionAns(CalcInitAns()));
        yield return StartCoroutine(ShowButtons(5));
        EnableSubmitButton();
        yield return new WaitUntil(GetHasJustFinishedQuestion);
        yield return null;
        yield return StartCoroutine(AddLeaderText("好了。"));
        yield return StartCoroutine(AddLeaderText("别紧张，人嘛，总是会有这种迷茫的时刻。"));
        yield return StartCoroutine(AddLeaderText("我们还会再来的。再见了，蔡先生。"));
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
        yield return new WaitForSeconds(5);
        LeaderText.text = "终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。";
        CurrentAns.text = "终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。";
        CurrentQuestion.text = "终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。";
        CurrentFlow.text = "终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。终局已至。";
    }
}
