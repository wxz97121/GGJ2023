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
            // �����ύ����
            yield return StartCoroutine(HideAllButtons());
            var List = new List<(string, int)>();
            foreach (var Selectble in SelectedObjects)
                List.Add(Selectble.Value);
            int result = AICore.Instance.AddLsToAI(List);

            foreach (var Btn in AllButtons)
                if (Btn.GetIsSelected()) Btn.OnClick();

            // ���ź��̻Ҷ���
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
            Debug.LogError("�������һ�����ͻش���ȷ�ˡ���" + QuestionObject.GetType().ToString());
            AICore.Instance.UpdateModiferByTargetState(QuestionObject.GetTargetState());
        }
        return newAns;
    }

    IEnumerator LevelCoroutine()
    {
        DisableSubmitButton();
        yield return null;
        yield return StartCoroutine(AddLeaderText("С�̣��㿴һ���������ʡ�"));
        yield return new WaitForSeconds(1);
        yield return StartCoroutine(AddLeaderText("�ԣ�������Ҷ������������ǲ�Ʒ��"));
        yield return new WaitForSeconds(1);
        yield return StartCoroutine(AddLeaderText("�����̺�����ˮ��������"));
        yield return new WaitForSeconds(1);
        yield return StartCoroutine(AddLeaderText("����ҳ�ʲô����ϸ�ڣ��������ǵĹ������Ҳ���Ҫ����"));
        yield return new WaitForSeconds(1);
        yield return StartCoroutine(AddLeaderText("��ֻ��Ҫ��������֮ǰ�����������һ�������ķ��ӣ���������Ҳ�ͱ������ϰ��ˡ�"));
        yield return new WaitForSeconds(1);
        QuestionObject = new Question1();
        yield return StartCoroutine(UpdateQuestion("�ҵ�ͬѧ�����ҵ���ߣ��Ҹ���ô�죿"));
        yield return StartCoroutine(UpdateQuestionAns(CalcInitAns()));
        yield return StartCoroutine(ShowButtons(5));
        EnableSubmitButton();
        yield return new WaitUntil(GetHasJustFinishedQuestion);
        yield return null;
        yield return new WaitForSeconds(5);


        yield return StartCoroutine(AddLeaderText("OK������"));
        yield return StartCoroutine(AddLeaderText("�����ٸ����ǿ��һ�飬���ǵ�AI����һ��Ŀ���û�����ѧУ"));
        yield return StartCoroutine(AddLeaderText("����˵�����Ҫ�����Ҽ�ʱ���֡�"));
        yield return StartCoroutine(AddLeaderText("���ֻش���ѧУ�ﴫ����ȥ����������򣬶Թ�˾���󣬶����ǵĲ�Ʒ������ɶ�ô��ĸ���Ӱ�죿"));
        yield return StartCoroutine(AddLeaderText("���ǹ�˾����ҵ�Ļ���������̹�ϣ��κ�ʱ�̶�Ҫ��ס"));
        yield return StartCoroutine(AddLeaderText("�����ҿ����ȳ��ˣ��Ӱ������ˡ�"));
        yield return new WaitForSeconds(3);
        // TODO ������


        StartCoroutine(UpdateQuestion(""));
        StartCoroutine(UpdateQuestionAns(""));
        yield return StartCoroutine(AddLeaderText("С�̣�����һ�¡�"));
        yield return StartCoroutine(AddLeaderText("������������⣬�������ǵ�AIȱ�ٴ���������������"));
        yield return StartCoroutine(AddLeaderText("��Ȼ����������û���ֻ��ѧУ���һ�����ӡ�"));
        yield return StartCoroutine(AddLeaderText("�����ļ�ͥ��������̺������������Ǻ��������Ӷ���ȫ��һ���ġ�"));
        yield return StartCoroutine(AddLeaderText("���Խ��죬��Ļ�ȷŷţ�����һ�������"));
        QuestionObject = new Question2();
        yield return StartCoroutine(UpdateQuestion("�������п�����ʲô���ӵģ�����дһ��С˵����ȱ�����"));
        yield return StartCoroutine(UpdateQuestionAns(CalcInitAns()));
        yield return StartCoroutine(ShowButtons(5));
        EnableSubmitButton();
        yield return new WaitUntil(GetHasJustFinishedQuestion);

    }
}
