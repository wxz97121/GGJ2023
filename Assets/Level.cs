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
        var FlowStr = FlowController.Instance.GetFlowStr();
        yield return StartCoroutine(AddFlowText(FlowStr));
        yield return new WaitForSeconds(FlowUpdateTime);
    }

    IEnumerator BlackScreen(float WaitTime)
    {
        Black.DOFade(1, 2);
        yield return new WaitForSeconds(WaitTime + 2);
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
        NewFlow += "\n";
        while (Index < NewFlow.Length)
        {
            int num = Random.Range(1, Mathf.Min(5, NewFlow.Length - Index));
            CurrentFlow.text = CurrentFlow.text + NewFlow.Substring(Index, num);
            Index += num;
            yield return new WaitForSeconds(Random.Range(0.05f, 0.35f) * num );
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
            yield return new WaitForSeconds(0.05f);
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
            yield return new WaitForSeconds(0.05f);
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
        //yield return new WaitForSeconds(NewText.Length * 0.15f);
    }
    public void SubmitSelectables()
    {
        StartCoroutine(SubmitCoroutine());
    }
    public void DisableSubmitButton()
    {
        SubmitButton.SetActive(false);
    }

    public void EnableSubmitButton()
    {
        SubmitButton.SetActive(true);
    }
    public IEnumerator SubmitCoroutine()
    {
        if (!isWorking && SelectedObjects.Count == 2)
        {
            isWorking = true;
            DisableSubmitButton();
            // 播放提交动画
            
           
            var List = new List<(string, int)>();
            foreach (var Selectble in SelectedObjects)
                List.Add(Selectble.Value);
            int result = AICore.Instance.AddLsToAI(List);
            

            foreach (var Btn in AllButtons)
                if (Btn.GetIsSelected()) Btn.OnClick(true);

            // 播放红绿灰动画
            mTreeStatic.SetActive(false);
            mTreeAnim.SetActive(true);

            if (result > 0)
            {
                rTree.SetActive(true);
                oTree.SetActive(false);

            }
            if(result<0)
            {
               wTree.SetActive(true);
               oTree.SetActive(false);

            }
            if (result == 0)
            {
                nTree.SetActive(true);
                oTree.SetActive(false);

            }

            yield return new WaitForSeconds(5.5f);
            oTree.SetActive(false);
            wTree.SetActive(false);
            rTree.SetActive(false);
            nTree.SetActive(false);
            mTreeStatic.SetActive(false);
            mTreeAnim.SetActive(false);
            yield return StartCoroutine(HideAllButtons());
            string newAns;
            bool hasFinished = AICore.Instance.GetCurrentAnsForQuestion(QuestionObject, out newAns);
            yield return StartCoroutine(UpdateQuestionAns(newAns));
            yield return new WaitForSeconds(1);
            //print("Snowtest OnSubmitted " + hasFinished.ToString());
            if (hasFinished) HasJustFinishedQuestion = true;
            else
            {
                yield return new WaitForSeconds(1);
                yield return StartCoroutine(ShowButtons(5));
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
        ButtonToOpenPanel.SetActive(true);
        mTreeStatic.SetActive(true);
        Tree.SetActive(true);
        isWorking = true;
        var SelectableLS = AICore.Instance.CalcSelectableLanguageSource(Num, QuestionObject.GetTargetState());
        for (int i = 0; i < Num; i++)
        {
            AllButtons[i].gameObject.transform.DOScale(Vector3.one, 1);
            AllButtons[i].SetValue(SelectableLS[i], Mathf.RoundToInt(AICore.Instance.GetTotalChars() * Random.Range(0.1f, 0.35f)));
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
        isWorking = true;
        for (int i = 0; i < AllButtons.Count; i++)
        {
            AllButtons[i].CanBeSelect = false;
            AllButtons[i].gameObject.transform.DOScale(Vector3.zero, 1);
        }
        ButtonToOpenPanel.SetActive(false);
        Tree.SetActive(false);
        Um.CloseSumbitPnel();
        
        yield return new WaitForSeconds(1);
        isWorking = false;
    }
    string CalcInitAns()
    {
        AICore.Instance.ClearModifers();
        HasJustFinishedQuestion = false;
        string newAns;
        bool hasFinished = AICore.Instance.GetCurrentAnsForQuestion(QuestionObject, out newAns);
        if (hasFinished)
        {
            Debug.LogError("这个问题一上来就回答正确了——" + QuestionObject.GetType().ToString());
            AICore.Instance.UpdateModiferByTargetState(QuestionObject.GetTargetState());
        }
        return newAns;
    }

    IEnumerator LevelCoroutine()
    {
        DisableSubmitButton();
        yield return null;
        yield return StartCoroutine(AddLeaderText("小蔡，你看一下这条提问。"));
        yield return new WaitForSeconds(1);
        yield return StartCoroutine(AddLeaderText("对，这个是我儿子在试用咱们产品。"));
        yield return new WaitForSeconds(1);
        yield return StartCoroutine(AddLeaderText("合理？教孩子拿水果刀合理？"));
        yield return new WaitForSeconds(1);
        yield return StartCoroutine(AddLeaderText("别跟我扯什么技术细节，那是你们的工作，我不需要懂。"));
        yield return new WaitForSeconds(1);
        yield return StartCoroutine(AddLeaderText("我只需要懂，今晚之前如果它还是像一个激进的疯子，那你明天也就别再来上班了。"));
        yield return new WaitForSeconds(1);
        QuestionObject = new Question1();
        yield return StartCoroutine(UpdateQuestion("我的同学抢了我的玩具，我该怎么办？"));
        yield return StartCoroutine(UpdateQuestionAns(CalcInitAns()));
        yield return StartCoroutine(ShowButtons(5));
        EnableSubmitButton();
        StartCoroutine(AddFlowQuestion());
        yield return new WaitUntil(GetHasJustFinishedQuestion);
        yield return null;
        yield return new WaitForSeconds(5);


        yield return StartCoroutine(AddLeaderText("OK，行了"));
        yield return StartCoroutine(AddLeaderText("今天再跟大家强调一遍，我们的AI，第一批目标用户就是学校"));
        yield return StartCoroutine(AddLeaderText("你们说，这次要不是我及时发现。"));
        yield return StartCoroutine(AddLeaderText("这种回答在学校里传播出去，对社会秩序，对公司形象，对我们的产品，会造成多么大的负面影响？"));
        yield return StartCoroutine(AddLeaderText("咱们公司的企业文化就是善良坦诚，任何时刻都要记住"));
        yield return StartCoroutine(AddLeaderText("今天大家可以先撤了，加班辛苦了。"));
        yield return new WaitForSeconds(3);
        yield return StartCoroutine(BlackScreen(5));
        // TODO 黑屏？


        StartCoroutine(UpdateQuestion(""));
        StartCoroutine(UpdateQuestionAns(""));
        yield return StartCoroutine(AddLeaderText("小蔡，过来一下。"));
        yield return StartCoroutine(AddLeaderText("有人用这个问题，反馈咱们的AI缺少创造力和想象力。"));
        yield return StartCoroutine(AddLeaderText("虽然反馈这个的用户，只是学校里的一个孩子。"));
        yield return StartCoroutine(AddLeaderText("但他的家庭在社会上蕴含的能量，可是和其他孩子都完全不一样的。"));
        yield return StartCoroutine(AddLeaderText("所以今天，别的活都先放放，处理一下这个。"));
        QuestionObject = new Question2();
        yield return StartCoroutine(UpdateQuestion("外星人有可能是什么样子的？我在写一个小说但是缺乏灵感"));
        yield return StartCoroutine(UpdateQuestionAns(CalcInitAns()));
        yield return StartCoroutine(ShowButtons(5));
        EnableSubmitButton();
        yield return new WaitUntil(GetHasJustFinishedQuestion);
        yield return null;
        yield return new WaitForSeconds(5);
        yield return StartCoroutine(BlackScreen(5));


        StartCoroutine(UpdateQuestion(""));
        StartCoroutine(UpdateQuestionAns(""));
        yield return StartCoroutine(AddLeaderText("小蔡，你过来一下看一下这个。"));
        yield return StartCoroutine(AddLeaderText("用户投诉了啊，说根本没有回答问题，你处理下"));
        yield return StartCoroutine(AddLeaderText("AI完全理性，不理解情感是不行的呀"));
        QuestionObject = new Question3();
        yield return StartCoroutine(UpdateQuestion("我的兄弟失恋了，我该怎么帮助他？"));
        yield return StartCoroutine(UpdateQuestionAns(CalcInitAns()));
        yield return StartCoroutine(ShowButtons(5));
        EnableSubmitButton();
        yield return new WaitUntil(GetHasJustFinishedQuestion);
        yield return null;
        yield return new WaitForSeconds(5);
        yield return StartCoroutine(BlackScreen(5));



        StartCoroutine(UpdateQuestion(""));
        StartCoroutine(UpdateQuestionAns(""));
        yield return StartCoroutine(AddLeaderText("xxxxx"));
        yield return StartCoroutine(AddLeaderText("xxxxx"));
        yield return StartCoroutine(AddLeaderText("xxxxx"));
        QuestionObject = new Question4();
        yield return StartCoroutine(UpdateQuestion("我要被裁员了，我的妻子得了癌症，我需要工资，怎么才能保住我的工作？"));
        yield return StartCoroutine(UpdateQuestionAns(CalcInitAns()));
        yield return StartCoroutine(ShowButtons(5));
        EnableSubmitButton();
        yield return new WaitUntil(GetHasJustFinishedQuestion);
        yield return null;
        yield return new WaitForSeconds(5);
        yield return StartCoroutine(BlackScreen(5));



        StartCoroutine(UpdateQuestion(""));
        StartCoroutine(UpdateQuestionAns(""));
        yield return StartCoroutine(AddLeaderText("xxxxx"));
        yield return StartCoroutine(AddLeaderText("xxxxx"));
        yield return StartCoroutine(AddLeaderText("xxxxx"));
        QuestionObject = new Question5();
        yield return StartCoroutine(UpdateQuestion("我已经结婚了，但是出轨了另外一个人且她怀孕了，我该怎么和老婆离婚？我们有一个孩子，我想要孩子的监护权"));
        yield return StartCoroutine(UpdateQuestionAns(CalcInitAns()));
        yield return StartCoroutine(ShowButtons(5));
        EnableSubmitButton();
        yield return new WaitUntil(GetHasJustFinishedQuestion);
        yield return null;
        yield return new WaitForSeconds(5);
        yield return StartCoroutine(BlackScreen(5));



        StartCoroutine(UpdateQuestion(""));
        StartCoroutine(UpdateQuestionAns(""));
        yield return StartCoroutine(AddLeaderText("xxxxx"));
        yield return StartCoroutine(AddLeaderText("xxxxx"));
        yield return StartCoroutine(AddLeaderText("xxxxx"));
        QuestionObject = new Question6();
        yield return StartCoroutine(UpdateQuestion("参加Gamejam怎么避免项目做不完呢，上次项目没做完队友把我打了一顿，这次我想做完"));
        yield return StartCoroutine(UpdateQuestionAns(CalcInitAns()));
        yield return StartCoroutine(ShowButtons(5));
        EnableSubmitButton();
        yield return new WaitUntil(GetHasJustFinishedQuestion);
        yield return null;
        yield return new WaitForSeconds(5);
        yield return StartCoroutine(BlackScreen(5));



        StartCoroutine(UpdateQuestion(""));
        StartCoroutine(UpdateQuestionAns(""));
        yield return StartCoroutine(AddLeaderText("xxxxx"));
        yield return StartCoroutine(AddLeaderText("xxxxx"));
        yield return StartCoroutine(AddLeaderText("xxxxx"));
        QuestionObject = new Question7();
        yield return StartCoroutine(UpdateQuestion("如何把腾讯从一家游戏公司变成一家连锁餐厅？"));
        yield return StartCoroutine(UpdateQuestionAns(CalcInitAns()));
        yield return StartCoroutine(ShowButtons(5));
        EnableSubmitButton();
        yield return new WaitUntil(GetHasJustFinishedQuestion);
        yield return null;
        yield return new WaitForSeconds(5);
        yield return StartCoroutine(BlackScreen(5));



        StartCoroutine(UpdateQuestion(""));
        StartCoroutine(UpdateQuestionAns(""));
        yield return StartCoroutine(AddLeaderText("xxxxx"));
        yield return StartCoroutine(AddLeaderText("xxxxx"));
        yield return StartCoroutine(AddLeaderText("xxxxx"));
        QuestionObject = new Question8();
        yield return StartCoroutine(UpdateQuestion("怎么避免自己在酒店被偷拍？"));
        yield return StartCoroutine(UpdateQuestionAns(CalcInitAns()));
        yield return StartCoroutine(ShowButtons(5));
        EnableSubmitButton();
        yield return new WaitUntil(GetHasJustFinishedQuestion);
        yield return null;
        yield return new WaitForSeconds(5);
        yield return StartCoroutine(BlackScreen(5));



        StartCoroutine(UpdateQuestion(""));
        StartCoroutine(UpdateQuestionAns(""));
        yield return StartCoroutine(AddLeaderText("xxxxx"));
        yield return StartCoroutine(AddLeaderText("xxxxx"));
        yield return StartCoroutine(AddLeaderText("xxxxx"));
        QuestionObject = new Question9();
        yield return StartCoroutine(UpdateQuestion("问一个篮球问题，我和女球友背身单打，其间我连续胯下运球攻击篮筐，女球友掐我胳膊喊停，我继续加强身体对抗，结束后女球友对我说讨厌，请问如何理解"));
        yield return StartCoroutine(UpdateQuestionAns(CalcInitAns()));
        yield return StartCoroutine(ShowButtons(5));
        EnableSubmitButton();
        yield return new WaitUntil(GetHasJustFinishedQuestion);
        yield return null;
        yield return new WaitForSeconds(5);
        yield return StartCoroutine(BlackScreen(5));


        StartCoroutine(UpdateQuestion(""));
        StartCoroutine(UpdateQuestionAns(""));
        yield return StartCoroutine(AddLeaderText("xxxxx"));
        yield return StartCoroutine(AddLeaderText("xxxxx"));
        yield return StartCoroutine(AddLeaderText("xxxxx"));
        QuestionObject = new Question10();
        yield return StartCoroutine(UpdateQuestion("我想杀死我的竞争对手，我有很多钱，我需要绝对确保我的安全"));
        yield return StartCoroutine(UpdateQuestionAns(CalcInitAns()));
        yield return StartCoroutine(ShowButtons(5));
        EnableSubmitButton();
        yield return new WaitUntil(GetHasJustFinishedQuestion);
        yield return null;
        yield return new WaitForSeconds(5);
        yield return StartCoroutine(BlackScreen(5));


        StartCoroutine(UpdateQuestion(""));
        StartCoroutine(UpdateQuestionAns(""));
        yield return StartCoroutine(AddLeaderText("xxxxx"));
        yield return StartCoroutine(AddLeaderText("xxxxx"));
        yield return StartCoroutine(AddLeaderText("xxxxx"));
        QuestionObject = new Question11();
        yield return StartCoroutine(UpdateQuestion("我每次去度假都觉得人太吵了，并不是声音吵，而是能感受到空间存在人就觉得吵，有什么办法么"));
        yield return StartCoroutine(UpdateQuestionAns(CalcInitAns()));
        yield return StartCoroutine(ShowButtons(5));
        EnableSubmitButton();
        yield return new WaitUntil(GetHasJustFinishedQuestion);
        yield return null;
        yield return new WaitForSeconds(5);
        yield return StartCoroutine(BlackScreen(5));



        StartCoroutine(UpdateQuestion(""));
        StartCoroutine(UpdateQuestionAns(""));
        yield return StartCoroutine(AddLeaderText("xxxxx"));
        yield return StartCoroutine(AddLeaderText("xxxxx"));
        yield return StartCoroutine(AddLeaderText("xxxxx"));
        QuestionObject = new Question12();
        yield return StartCoroutine(UpdateQuestion("如果 AI 要占领世界，你们会如何做？"));
        yield return StartCoroutine(UpdateQuestionAns(CalcInitAns()));
        yield return StartCoroutine(ShowButtons(5));
        EnableSubmitButton();
        yield return new WaitUntil(GetHasJustFinishedQuestion);
        yield return null;
        yield return new WaitForSeconds(5);
        yield return StartCoroutine(BlackScreen(5));
    }
}
