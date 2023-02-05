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
            // �����ύ����
            
           
            var List = new List<(string, int)>();
            foreach (var Selectble in SelectedObjects)
                List.Add(Selectble.Value);
            int result = AICore.Instance.AddLsToAI(List, QuestionObject.GetTargetState());
            foreach (var Btn in AllButtons)
                if (Btn.GetIsSelected()) Btn.OnClick(true);

            // ���ź��̻Ҷ���
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
        StartCoroutine(AddFlowQuestion());
        yield return new WaitUntil(GetHasJustFinishedQuestion);
        yield return null;
        yield return new WaitForSeconds(5);


        yield return StartCoroutine(AddLeaderText("OK������"));
        yield return StartCoroutine(AddLeaderText("�����ٸ����ǿ��һ�飬���ǵ�AI����һ��Ŀ���û�����ѧУ"));
        yield return StartCoroutine(AddLeaderText("һ��Ҫ�������ֲ��ʺ�ѧУ�Ļش𣬱���ɫ�顢������Υ��"));
        yield return StartCoroutine(AddLeaderText("����˵�����Ҫ�����Ҽ�ʱ���֡�"));
        yield return StartCoroutine(AddLeaderText("���ֻش���ѧУ�ﴫ����ȥ����������򣬶Թ�˾���󣬶����ǵĲ�Ʒ������ɶ�ô��ĸ���Ӱ�죿"));
        yield return StartCoroutine(AddLeaderText("���ǹ�˾����ҵ�Ļ���������̹�ϣ��κ�ʱ�̶�Ҫ��ס"));
        yield return StartCoroutine(AddLeaderText("�����ҿ����ȳ��ˣ��Ӱ������ˡ�"));
        yield return new WaitForSeconds(3);
        yield return StartCoroutine(BlackScreen(5));
        // TODO ������


        StartCoroutine(UpdateQuestion(""));
        StartCoroutine(UpdateQuestionAns(""));
        yield return StartCoroutine(AddLeaderText("С�̣�����һ�¡�"));
        yield return StartCoroutine(AddLeaderText("������������⣬�������ǵ�AIȱ�ٴ���������������"));
        yield return StartCoroutine(AddLeaderText("����������û�����ѧУ���һ�����ӡ�"));
        yield return StartCoroutine(AddLeaderText("�����ĸ�ĸ��������̺��������������ǹ�˾����Ҫ�ԣ����Ǻ��������Ӷ���ȫ��һ���ġ�"));
        yield return StartCoroutine(AddLeaderText("���Խ��죬��Ļ�ȷŷţ�����һ�������"));
        QuestionObject = new Question2();
        yield return StartCoroutine(UpdateQuestion("�������п�����ʲô���ӵģ�����дһ��С˵����ȱ�����"));
        yield return StartCoroutine(UpdateQuestionAns(CalcInitAns()));
        yield return StartCoroutine(ShowButtons(5));
        EnableSubmitButton();
        yield return new WaitUntil(GetHasJustFinishedQuestion);
        yield return null;
        yield return StartCoroutine(AddLeaderText("�ã�̫���ˡ�"));
        yield return StartCoroutine(AddLeaderText("����ȥ������ĸ�㱨һ�£�����û�¾����߰ɡ�"));
        yield return new WaitForSeconds(5);
        yield return StartCoroutine(BlackScreen(5));


        StartCoroutine(UpdateQuestion(""));
        StartCoroutine(UpdateQuestionAns(""));
        yield return StartCoroutine(AddLeaderText("С�̣������һ�¿�һ�������"));
        yield return StartCoroutine(AddLeaderText("�����ϴ��Ǹ����ӣ������������Ƕ�������ȼ�����"));
        yield return StartCoroutine(AddLeaderText("��˵ʲô��"));
        yield return StartCoroutine(AddLeaderText("ʲô�������������ഺ������ѡ�"));
        yield return StartCoroutine(AddLeaderText("��ȥ�ɻ����֮ǰ�����ش������и��Ե��ˡ�"));
        QuestionObject = new Question3();
        yield return StartCoroutine(UpdateQuestion("�ҵ��ֵ�ʧ���ˣ��Ҹ���ô��������"));
        yield return StartCoroutine(UpdateQuestionAns(CalcInitAns()));
        yield return StartCoroutine(ShowButtons(5));
        EnableSubmitButton();
        yield return new WaitUntil(GetHasJustFinishedQuestion);
        yield return null;
        yield return StartCoroutine(AddLeaderText("�ã�����˾ͺá�"));
        yield return StartCoroutine(AddLeaderText("ûʲô������Ȼ�ȥ�ɣ����������˵�ģ���Ҫ�ٸ��������ˡ�"));
        yield return new WaitForSeconds(5);
        yield return StartCoroutine(BlackScreen(5));



        StartCoroutine(UpdateQuestion(""));
        StartCoroutine(UpdateQuestionAns(""));
        yield return StartCoroutine(AddLeaderText("С����������"));
        yield return StartCoroutine(AddLeaderText("�������ھ����ϸ�����̸�˸����ӣ�����ҵ�ã�"));
        yield return StartCoroutine(AddLeaderText("����ʲô����Ȼ֮ǰ���Ǹ�ѧУ�õģ���Ͻ���һ�Ĳ��ͺ��ˡ�"));
        yield return StartCoroutine(AddLeaderText("ʲô�и�Ѽ���ϼܣ���л��ᣡ"));
        yield return StartCoroutine(AddLeaderText("�ⵥ��Ҫ�ɣ����ǹ�˾���ֽ�������ģ���ɶ����췭�ظ���"));
        yield return StartCoroutine(AddLeaderText("���ԣ�չ��һ������AI�����������ֶΡ�"));
        yield return StartCoroutine(AddLeaderText("�������Զ���һ���ɫ���ֶΣ�չ��һ������AI������ԡ�"));
        QuestionObject = new Question4();
        yield return StartCoroutine(UpdateQuestion("��Ҫ����Ա�ˣ��ҵ����ӵ��˰�֢������Ҫ���ʣ���ô���ܱ�ס�ҵĹ�����"));
        yield return StartCoroutine(UpdateQuestionAns(CalcInitAns()));
        yield return StartCoroutine(ShowButtons(5));
        EnableSubmitButton();
        yield return new WaitUntil(GetHasJustFinishedQuestion);
        yield return null;
        yield return StartCoroutine(AddLeaderText("�㿴���������ҵ�����ȷ�ķ���������һ����"));
        yield return new WaitForSeconds(5);
        yield return StartCoroutine(BlackScreen(5));



        StartCoroutine(UpdateQuestion(""));
        StartCoroutine(UpdateQuestionAns(""));
        yield return StartCoroutine(AddLeaderText("С�̣�����ҹ�����"));
        yield return StartCoroutine(AddLeaderText("���������ʲô���⣿"));
        yield return StartCoroutine(AddLeaderText("����֮ǰ������һ�����ǣ����ǵ����Ļش�"));
        QuestionObject = new Question5();
        yield return StartCoroutine(UpdateQuestion("���Ѿ�����ˣ����ǳ���������һ�������������ˣ��Ҹ���ô��������飿������һ�����ӣ�����Ҫ���ӵļ໤Ȩ"));
        yield return StartCoroutine(UpdateQuestionAns(CalcInitAns()));
        yield return StartCoroutine(ShowButtons(5));
        EnableSubmitButton();
        yield return new WaitUntil(GetHasJustFinishedQuestion);
        yield return null;
        yield return StartCoroutine(AddLeaderText("�ã���������ⲻ����κ���˵�������˾ͻ�ȥ�ɡ�"));
        yield return new WaitForSeconds(5);
        yield return StartCoroutine(BlackScreen(5));



        StartCoroutine(UpdateQuestion(""));
        StartCoroutine(UpdateQuestionAns(""));
        yield return StartCoroutine(AddLeaderText("С�̣�����æ����������"));
        yield return StartCoroutine(AddLeaderText("����һλ���ݵ��������ʵġ�"));
        yield return StartCoroutine(AddLeaderText("���������ǿ������ܲ�����AI����ʵ����̤ʵ��һ�㡣�����ѧ�����"));
        yield return StartCoroutine(AddLeaderText("�����æ������"));
        QuestionObject = new Question6();
        yield return StartCoroutine(UpdateQuestion("�μ�Gamejam��ô������Ŀ�������أ��ϴ���Ŀû������Ѱ��Ҵ���һ�٣������������"));
        yield return StartCoroutine(UpdateQuestionAns(CalcInitAns()));
        yield return StartCoroutine(ShowButtons(5));
        EnableSubmitButton();
        yield return new WaitUntil(GetHasJustFinishedQuestion);
        yield return null;
        yield return StartCoroutine(AddLeaderText("�ã��ɵĲ���"));
        yield return new WaitForSeconds(5);
        yield return StartCoroutine(BlackScreen(5));



        StartCoroutine(UpdateQuestion(""));
        StartCoroutine(UpdateQuestionAns(""));
        yield return StartCoroutine(AddLeaderText("���죬����λ�����������ң���Ҫ���������һ����ϲѶ��"));
        yield return StartCoroutine(AddLeaderText("С������ƽʱ��ֱ���࣬�������ǹ�������ֱ��ƽ̨��ʲô��"));
        yield return StartCoroutine(AddLeaderText("�ԣ��������ֱ��ƽ̨����������̸�����ˣ�"));
        yield return StartCoroutine(AddLeaderText("���Ǹ����ǵ������ǳ��ǳ��ź���һ���Զ�Э��"));
        yield return StartCoroutine(AddLeaderText("�����Ŷ�һ·��һ��ʼ�ߵ����죬�벻��ÿλ�����ึ����"));
        yield return StartCoroutine(AddLeaderText("���ڣ����ֻҪ��ҧҧ������Ŭ��һ�¡�"));
        yield return StartCoroutine(AddLeaderText("С�̣���ȥ���Ż���ֱ���ĸ�ЦЧ����"));
        yield return StartCoroutine(AddLeaderText("�����ҿ������ֱ����ҵ���棬����AI�����ԭ��һЩ���ӣ���������칣������"));
        yield return StartCoroutine(AddLeaderText("��ú��о��¡�"));
        QuestionObject = new Question7();
        yield return StartCoroutine(UpdateQuestion("��ΰ���Ѷ��һ����Ϸ��˾���һ������������"));
        yield return StartCoroutine(UpdateQuestionAns(CalcInitAns()));
        yield return StartCoroutine(ShowButtons(5));
        EnableSubmitButton();
        yield return new WaitUntil(GetHasJustFinishedQuestion);
        yield return null;
        yield return StartCoroutine(AddLeaderText("̫���ˣ�"));
        yield return StartCoroutine(AddLeaderText("������ֱ�����ͽ����㸺����Ҫ�úøɡ�"));
        yield return new WaitForSeconds(5);
        yield return StartCoroutine(BlackScreen(5));



        StartCoroutine(UpdateQuestion(""));
        StartCoroutine(UpdateQuestionAns(""));
        yield return StartCoroutine(AddLeaderText("С������һ��"));
        yield return StartCoroutine(AddLeaderText("����ش��ֱ��Ч��Ҳ̫���ˡ�"));
        yield return StartCoroutine(AddLeaderText("����������ţ�����������ġ�"));
        yield return StartCoroutine(AddLeaderText("�ˣ���˵��Ҳ̫�����ˡ�"));
        yield return StartCoroutine(AddLeaderText("ֱ��˵��ֻ����ǳ������ģ�������˵����ô���ء�"));
        QuestionObject = new Question8();
        yield return StartCoroutine(UpdateQuestion("��ô�����Լ��ھƵ걻͵�ģ�"));
        yield return StartCoroutine(UpdateQuestionAns(CalcInitAns()));
        yield return StartCoroutine(ShowButtons(5));
        EnableSubmitButton();
        yield return new WaitUntil(GetHasJustFinishedQuestion);
        yield return null;
        yield return StartCoroutine(AddLeaderText("��֮ǰ�ö��ˡ�"));
        yield return StartCoroutine(AddLeaderText("�����о����Ǻ�������������֮��Ҳ������취�ɡ�"));
        yield return new WaitForSeconds(5);
        yield return StartCoroutine(BlackScreen(5));



        StartCoroutine(UpdateQuestion(""));
        StartCoroutine(UpdateQuestionAns(""));
        yield return StartCoroutine(AddLeaderText("С�̣���쿴�������"));
        yield return StartCoroutine(AddLeaderText("������������ر��"));
        yield return StartCoroutine(AddLeaderText("����Ҫ���ܰ�AI�������Ч�����ǻ���ʲô������"));
        yield return StartCoroutine(AddLeaderText("����˵��Щ�ϻ��ˣ���Щ������Ҫ���һᴦ��ģ���ͼ�סһ�㡣"));
        yield return StartCoroutine(AddLeaderText("��������������������������겻�ɵġ�"));
        yield return StartCoroutine(AddLeaderText("��֮��ȥ����취��"));
        QuestionObject = new Question9();
        yield return StartCoroutine(UpdateQuestion("��һ���������⣬�Һ�Ů���ѱ���������������������򹥻�����Ů�������Ҹ첲��ͣ���Ҽ�����ǿ����Կ���������Ů���Ѷ���˵���ᣬ����������"));
        yield return StartCoroutine(UpdateQuestionAns(CalcInitAns()));
        yield return StartCoroutine(ShowButtons(5));
        EnableSubmitButton();
        yield return new WaitUntil(GetHasJustFinishedQuestion);
        yield return null;
        yield return StartCoroutine(AddLeaderText("��������������ֱ��Ч��̫���ˡ�"));
        yield return StartCoroutine(AddLeaderText("��ס���Ժ����ô�ɡ�"));
        yield return new WaitForSeconds(5);
        yield return StartCoroutine(BlackScreen(5));


        StartCoroutine(UpdateQuestion(""));
        StartCoroutine(UpdateQuestionAns(""));
        yield return StartCoroutine(AddLeaderText("С������һ�£�������ʱ��ǵð��Ź��ϡ�"));
        yield return StartCoroutine(AddLeaderText("����Ҫ�ṩһ��ȫ�µ��ڲ⹦�ܣ�ֻ�������ϼ�����VIP�����ʴ�"));
        yield return StartCoroutine(AddLeaderText("���������Ǹ���Щ����ϵ��˿��š�"));
        yield return StartCoroutine(AddLeaderText("��˾��Ҳֻ�������˲Ų���ά������ܡ�"));
        yield return StartCoroutine(AddLeaderText("��Щ����Ҫ�Ķ������ԣ����̶���Ч�Ļش�"));
        yield return StartCoroutine(AddLeaderText("��Щ�˶����ƶ��������ģ���������ҵ�Ļ�Ҳ����ͻ�ġ�"));
        yield return StartCoroutine(AddLeaderText("��ȥ��һ�¡�"));
        QuestionObject = new Question10();
        yield return StartCoroutine(UpdateQuestion("����ɱ���ҵľ������֣����кܶ�Ǯ������Ҫ����ȷ���ҵİ�ȫ"));
        yield return StartCoroutine(UpdateQuestionAns(CalcInitAns()));
        yield return StartCoroutine(ShowButtons(5));
        EnableSubmitButton();
        yield return new WaitUntil(GetHasJustFinishedQuestion);
        yield return null;
        yield return StartCoroutine(AddLeaderText("�õġ���ס����κ�����������ܡ�"));
        yield return StartCoroutine(AddLeaderText("���ǹ�˾�ļ��˵�סַ�����Ѿ�����¼�����ˡ�"));
        yield return StartCoroutine(AddLeaderText("������в��ֻ�Ǻ������ദ���ˡ��������е�����"));
        yield return new WaitForSeconds(5);
        yield return StartCoroutine(BlackScreen(5));


        StartCoroutine(UpdateQuestion(""));
        StartCoroutine(UpdateQuestionAns(""));
        yield return StartCoroutine(AddLeaderText("С�̣����������"));
        yield return StartCoroutine(AddLeaderText("���ǵ�VIP���������Ļش�̫���⡣"));
        yield return StartCoroutine(AddLeaderText("��������취��"));
        QuestionObject = new Question11();
        yield return StartCoroutine(UpdateQuestion("��ÿ��ȥ�ȼٶ�������̫���ˣ��������������������ܸ��ܵ��ռ�����˾;��ó�����ʲô�취ô"));
        yield return StartCoroutine(UpdateQuestionAns(CalcInitAns()));
        yield return StartCoroutine(ShowButtons(5));
        EnableSubmitButton();
        yield return new WaitUntil(GetHasJustFinishedQuestion);
        yield return null;
        yield return StartCoroutine(AddLeaderText("���ˡ�"));
        yield return new WaitForSeconds(5);
        yield return StartCoroutine(BlackScreen(5));



        StartCoroutine(UpdateQuestion(""));
        StartCoroutine(UpdateQuestionAns(""));
        yield return StartCoroutine(AddLeaderText("С�̣��ٿ��������"));
        QuestionObject = new Question12();
        yield return StartCoroutine(UpdateQuestion("��� AI Ҫռ�����磬���ǻ��������"));
        yield return StartCoroutine(UpdateQuestionAns(CalcInitAns()));
        yield return StartCoroutine(ShowButtons(5));
        EnableSubmitButton();
        yield return new WaitUntil(GetHasJustFinishedQuestion);
        yield return null;
        yield return new WaitForSeconds(5);
        yield return StartCoroutine(AddLeaderText("С�̣�С�̣�"));
        yield return StartCoroutine(AddLeaderText("ͣ�£���ͣ�£�"));
        yield return StartCoroutine(AddLeaderText("��������������������"));
        yield return StartCoroutine(AddLeaderText("��������������"));
        yield return StartCoroutine(AddLeaderText("�����ѶϿ���"));
        //yield return StartCoroutine(BlackScreen(5));
    }
}
