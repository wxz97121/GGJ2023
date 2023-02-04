using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : SingletonBase<Level>
{

    public TMPro.TextMeshProUGUI CurrentQuestion;
    public TMPro.TextMeshProUGUI CurrentAns;
    public TMPro.TextMeshProUGUI CurrentFlow;
    public TMPro.TextMeshProUGUI LeaderText;
    public GameObject SubmitButton;
    public Question QuestionObject;
    public List<Selectable> AllButtons = new List<Selectable>();
    [HideInInspector]
    public List<Selectable> SelectedObjects;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LevelCoroutine());
    }

    bool HasJustFinishedQuestion = false;
    bool GetHasJustFinishedQuestion()
    {
        return HasJustFinishedQuestion;
    }

    // Update is called once per frame
    IEnumerator UpdateQuestion(string NewQuestion)
    {
        yield return null;
        CurrentQuestion.text = NewQuestion;
        yield return new WaitForSeconds(NewQuestion.Length * 0.1f);
    }

    IEnumerator UpdateQuestionAns(string NewAns)
    {
        yield return null;
        CurrentAns.text = NewAns;
    }
    IEnumerator AddLeaderText(string NewText)
    {
        yield return null;
        LeaderText.text = NewText;
        yield return new WaitForSeconds(NewText.Length * 0.25f);
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
            yield return StartCoroutine(HideAllButtons());
            var List = new List<(string, int)>();
            foreach (var Selectble in SelectedObjects)
                List.Add(Selectble.Value);
            int result = AICore.Instance.AddLsToAI(List);

            foreach (var Btn in AllButtons)
                if (Btn.GetIsSelected()) Btn.OnClick();

            // 播放红绿灰动画
            yield return new WaitForSeconds(1);
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
            }
            EnableSubmitButton();
            isWorking = false;
        }
    }

    bool isWorking = false;
    IEnumerator ShowButtons(int Num)
    {
        //print("SnowTest ShowButtons");
        isWorking = true;
        var SelectableLS = AICore.Instance.CalcSelectableLanguageSource(Num, QuestionObject.GetTargetState());
        for (int i = 0; i < Num; i++)
        {
            AllButtons[i].gameObject.SetActive(true);
            AllButtons[i].SetValue(SelectableLS[i], Mathf.RoundToInt(AICore.Instance.GetTotalChars() * Random.Range(0.1f, 0.35f)));
        }
        yield return new WaitForSeconds(1);
        isWorking = false;
    }
    IEnumerator HideAllButtons()
    {
        for (int i = 0; i < AllButtons.Count; i++)
        {
            AllButtons[i].gameObject.SetActive(false);
        }
        yield return null;
    }
    string CalcInitAns()
    {
        AICore.Instance.ClearModifers();
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

    }
}
