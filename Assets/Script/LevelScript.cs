//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using DG.Tweening;
//using UnityEngine.UI;

//public class LevelScript : MonoBehaviour
//{
//    AudioSource Audio;
//    public AudioSource AudioSleep;
//    public AudioSource AudioRoom;
//    public GameObject FloatBoxProto;
//    public AudioSource OneShotAudio;
//    public AudioClip BagAudio;
//    public AudioClip WeChatAudio;
//    public string FirstLevel = "C1";
//    void Start()
//    {
//        Audio = GetComponent<AudioSource>();
//        StartCoroutine(FirstLevel);
//        //StartCoroutine(C1());
//    }

//    IEnumerator C1()
//    {
//        var UIC = UIController.Instance;
//        yield return null;
//        UIC.ClearAll();
//        UIC.BlackText.text = "2022��1��23��\r\n������\r\n16:30";
//        LockPage.Instance.SetSunday();
//        LockPage.Instance.SetTime("16:30");
//        UIC.BlackText.DOFade(1, 4);
//        Audio.DOFade(1, 1);
//        yield return new WaitForSeconds(5);
//        UIC.BlackText.DOFade(0, 3);
//        yield return new WaitForSeconds(3);
//        UIC.Black.DOFade(0, 3);
//        UIC.WechatPage.localScale = Vector3.one;
//        UIC.WeChatTitle.text = "���Ⱥ(4)";
//        UIC.Lock();
//        yield return new WaitUntil(UIC.GetIsUnlock);
//        yield return StartCoroutine(UIC.AddWechat("��ͷ", "������ Global GameJam ����ô���ˣ�"));
//        yield return StartCoroutine(UIC.AddWechat("��ͷ", "��������"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddWechat("�峤", "����������꣬�Ĵ����������ˣ�"));
//        yield return new WaitForSeconds(0.2f);
//        UIC.B1.gameObject.SetActive(true);
//        UIC.B2.gameObject.SetActive(true);
//        yield return new WaitUntil(UIC.GetIsPressing);
//        yield return StartCoroutine(UIC.AddWechat("����", UIC.LastPlayerChoiceString, -1, true));

//        yield return StartCoroutine(UIC.AddWechat("��ͷ", "wow", AfterDelayTime: 0.35f));
//        yield return StartCoroutine(UIC.AddWechat("��ͷ", "ţ����", AfterDelayTime: 0.35f));
//        yield return StartCoroutine(UIC.AddWechat("����", "ţ����", AfterDelayTime: 0.35f));
//        yield return StartCoroutine(UIC.AddWechat("�峤", "ţ����", AfterDelayTime: 0.35f));
//        yield return new WaitForSeconds(1);

//        UIC.InnerTitle.text = "__��֪��__(1)";
//        UIC.InnerPage.localScale = Vector3.one;
//        UIC.GlitchPPVolume.weight = 1;
//        yield return StartCoroutine(UIC.AddInner("__��ɱ��__", "���ģ�Ⱥ���ǻ��ǵ��۲μ�GGJ����", 0.1f));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__G__", "��", 0.1f));
//        yield return new WaitForSeconds(3.5f);
//        UIC.InnerPage.localScale = Vector3.zero;
//        UIC.GlitchPPVolume.weight = 0;

//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddWechat("�峤", "��������ɶ���ţ�", AfterDelayTime: 0.5f));
//        yield return StartCoroutine(UIC.AddWechat("��ͷ", "�� ��Ҳ���ˡ�"));
//        yield return new WaitForSeconds(2.5f);

//        UIC.InnerPage.localScale = Vector3.one;
//        UIC.GlitchPPVolume.weight = 1;
//        yield return StartCoroutine(UIC.AddInner("__G__", "���������¸�ˬ�˰ɣ�", 0.1f));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__��ɱ��__", "��", 0.1f));
//        yield return new WaitForSeconds(2);
//        UIC.InnerPage.localScale = Vector3.zero;
//        UIC.GlitchPPVolume.weight = 0;

//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddWechat("����", "Gamejam�������忪ʼ����", AfterDelayTime: 0.5f));
//        yield return StartCoroutine(UIC.AddWechat("�峤", "�ǰɡ�"));
//        yield return StartCoroutine(UIC.AddWechat("��ͷ", "�ǵ���"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddWechat("�峤", "��ʱ��ô�������ţ�"));
//        yield return new WaitForSeconds(1);

//        UIC.InnerPage.localScale = Vector3.one;
//        UIC.GlitchPPVolume.weight = 1;
//        yield return StartCoroutine(UIC.AddInner("__G__", "�����˵�������ƽ���ˡ�", 0.35f));
//        yield return new WaitForSeconds(2);
//        yield return StartCoroutine(UIC.AddInner("__��ɱ��__", "��ʱ�������㽲�������������ꡣ", 0.35f));
//        yield return new WaitForSeconds(2);
//        yield return StartCoroutine(UIC.AddInner("__G__", "�����������ҵģ�ɵ���˰ɣ�������", 0.35f));
//        yield return new WaitForSeconds(2);
//        yield return StartCoroutine(UIC.AddInner("__��ɱ��__", "��ô�Ͳ����ҵ��أ�������˵˵����զ����", 0.35f));
//        yield return new WaitForSeconds(2);
//        UIC.InnerPage.localScale = Vector3.zero;
//        UIC.GlitchPPVolume.weight = 0;

//        yield return new WaitForSeconds(2);
//        yield return StartCoroutine(UIC.AddWechat("��ͷ", "�����Ǳ����������ģ���������ûȥ�ɡ�"));
//        yield return StartCoroutine(UIC.AddWechat("�峤", "��磿"));
//        yield return StartCoroutine(UIC.AddWechat("��ͷ", "�ԣ��������ˣ��ⲻûȥ�ɡ�"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddWechat("�峤", "��"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddWechat("��ͷ", "Ȼ��ͣ�ֻ�ܣ�Solo�ˡ�"));

//        UIC.B1.GetComponentInChildren<Text>().text = "�ݣ��������ǡ�";
//        UIC.B2.GetComponentInChildren<Text>().text = "û�У�������ʵ�������ġ�";
//        yield return new WaitForSeconds(0.2f);
//        UIC.B1.gameObject.SetActive(true);
//        UIC.B2.gameObject.SetActive(true);
//        yield return new WaitUntil(UIC.GetIsPressing);
//        yield return StartCoroutine(UIC.AddWechat("����", UIC.LastPlayerChoiceString, -1, true));

//        yield return new WaitForSeconds(3f);
//        UIC.BlackText.text = "";
//        UIC.Black.DOFade(1, 3);
//        Audio.DOFade(0, 1);
//        yield return new WaitForSeconds(5);
//        StartCoroutine(C2());
//    }

//    IEnumerator C2()
//    {
//        yield return null;
//        var UIC = UIController.Instance;
//        UIC.ClearAll();
//        UIC.BlackText.text = "2022��1��21��\r\n������\r\n15:30";
//        LockPage.Instance.SetFriday();
//        LockPage.Instance.SetTime("15:30");
//        UIC.BlackText.DOFade(1, 4);
//        yield return new WaitForSeconds(5);
//        UIC.BlackText.DOFade(0, 3);
//        yield return new WaitForSeconds(3);
//        UIC.Black.DOFade(0, 3);
//        UIC.WechatPage.localScale = Vector3.one;
//        UIC.WeChatTitle.text = "�鳤";
//        Audio.DOFade(1, 1);

//        UIC.Lock();
//        yield return new WaitUntil(UIC.GetIsUnlock);

//        //-------DEBUG

//        //--------DEBUG

//        yield return StartCoroutine(UIC.AddWechat("�鳤", "OA������ύ����"));
//        UIC.B1.GetComponentInChildren<Text>().text = "����ύ�ˡ�";
//        UIC.B2.GetComponentInChildren<Text>().text = "�����ˣ�֮���ٲ��ɡ�";
//        yield return new WaitForSeconds(0.2f);
//        UIC.B1.gameObject.SetActive(true);
//        UIC.B2.gameObject.SetActive(true);
//        yield return new WaitUntil(UIC.GetIsPressing);
//        yield return StartCoroutine(UIC.AddWechat("����", UIC.LastPlayerChoiceString, -1, true));


//        yield return StartCoroutine(UIC.AddWechat("�鳤", "�У��������¾��ȳ��ɡ�"));
//        yield return new WaitForSeconds(2);
//        UIC.InnerTitle.text = "__���__(1)";
//        UIC.InnerPage.localScale = Vector3.one;
//        UIC.GlitchPPVolume.weight = 1;
//        yield return StartCoroutine(UIC.AddInner("__��ɱ��__", "�ۣ��üһﻹר�����˼١�"));
//        yield return new WaitForSeconds(0.5f);
//        yield return StartCoroutine(UIC.AddInner("__��ɱ��__", "����"));
//        yield return new WaitForSeconds(0.5f);
//        yield return StartCoroutine(UIC.AddInner("__��ɱ��__", "����������ģ������ɶȾ޸ߵ�ţ���������"));
//        yield return new WaitForSeconds(1.5f);
//        yield return StartCoroutine(UIC.AddInner("__G__", "����"));
//        yield return new WaitForSeconds(0.5f);
//        yield return StartCoroutine(UIC.AddInner("__G__", "�ǣ�Ц��"));
//        yield return new WaitForSeconds(2.5f);
//        UIC.InnerPage.localScale = Vector3.zero;
//        UIC.GlitchPPVolume.weight = 0;

//        UIC.B1.GetComponentInChildren<Text>().text = "�ã����������ˡ�";
//        UIC.B2.GetComponentInChildren<Text>().text = "�ã�лл�鳤��";
//        yield return new WaitForSeconds(0.2f);
//        UIC.B1.gameObject.SetActive(true);
//        UIC.B2.gameObject.SetActive(true);
//        yield return new WaitUntil(UIC.GetIsPressing);
//        yield return StartCoroutine(UIC.AddWechat("����", UIC.LastPlayerChoiceString, -1, true));

//        yield return StartCoroutine(UIC.AddWechat("�鳤", "����һ���ᶨ�Ǹ���ɫ����������"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddWechat("�鳤", "Ȼ�󽨵����㡣"));
//        yield return new WaitForSeconds(1);

//        UIC.B1.GetComponentInChildren<Text>().text = "�յ���";
//        UIC.B2.GetComponentInChildren<Text>().text = "Ҳ̫���˰ɣ�";
//        yield return new WaitForSeconds(0.4f);
//        UIC.B1.gameObject.SetActive(true);
//        UIC.B2.gameObject.SetActive(true);
//        yield return new WaitUntil(UIC.GetIsPressing);
//        yield return StartCoroutine(UIC.AddWechat("����", UIC.LastPlayerChoiceString, -1, true));
//        yield return new WaitForSeconds(1.5f);


//        UIC.InnerPage.localScale = Vector3.one;
//        UIC.GlitchPPVolume.weight = 1;
//        yield return StartCoroutine(UIC.AddInner("__��ɱ��__", "����ɶ��˼����", 0.1f));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__G__", "ûɶ��˼��", 0.1f));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__G__", "��", 0.1f));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__G__", "Ц�ˡ�", 0.1f));
//        UIC.AddWechat("�鳤", "�����������׼������", 0.01f);
//        UIC.AddWechat("�鳤", "Ҳ������ĩ�ٿ�����", 0.01f);
//        yield return new WaitForSeconds(3);
//        UIC.InnerPage.localScale = Vector3.zero;
//        UIC.GlitchPPVolume.weight = 0;

//        UIC.B1.GetComponentInChildren<Text>().text = "�á���";
//        UIC.B2.GetComponentInChildren<Text>().text = "�š���";
//        yield return new WaitForSeconds(0.2f);
//        UIC.B1.gameObject.SetActive(true);
//        UIC.B2.gameObject.SetActive(true);
//        yield return new WaitUntil(UIC.GetIsPressing);
//        StartCoroutine(UIC.AddWechat("����", "������������", -1, true));
//        //TODO�����ִ�һ����񷢳�ȥ�ˣ�����ɾ�������

//        yield return new WaitForSeconds(0.5f);

//        UIC.InnerPage.localScale = Vector3.one;
//        UIC.GlitchPPVolume.weight = 1;
//        UIC.RemoveLastWechat();

//        yield return StartCoroutine(UIC.AddInner("__G__", "�͵������ã�ûɶ��˼��", 0.2f));
//        yield return new WaitForSeconds(0.5f);
//        yield return StartCoroutine(UIC.AddInner("__G__", "�ͣ��ۻ���Ӧ������������̡�", 0.2f));
//        yield return new WaitForSeconds(2.5f);
//        yield return StartCoroutine(UIC.AddInner("__��ɱ��__", "��������", 0.2f));
//        yield return new WaitForSeconds(0.5f);
//        yield return StartCoroutine(UIC.AddInner("__��ɱ��__", "���ԶԶԡ������������ȥ�ɡ�", 0.2f));
//        yield return new WaitForSeconds(0.5f);
//        yield return StartCoroutine(UIC.AddInner("__��ɱ��__", "���ܸ����죬һ���˼����ĸ�����ţ�ơ�", 0.2f));
//        yield return new WaitForSeconds(0.5f);
//        yield return StartCoroutine(UIC.AddInner("__��ɱ��__", "�ٿ����Լ��������ģ������Ǹ�ʲô���⡣", 0.2f));
//        yield return new WaitForSeconds(0.5f);
//        yield return StartCoroutine(UIC.AddInner("__��ɱ��__", "���������������ܰ���", 0.2f));
//        yield return new WaitForSeconds(4.5f);
//        UIC.InnerPage.localScale = Vector3.zero;
//        UIC.GlitchPPVolume.weight = 0;
//        yield return new WaitForSeconds(1f);
//        yield return StartCoroutine(UIC.AddWechat("�鳤", "��������"));
//        UIC.B1.GetComponentInChildren<Text>().text = "�����õģ�";
//        UIC.B2.GetComponentInChildren<Text>().text = "�����õģ�";


//        yield return new WaitForSeconds(0.2f);
//        UIC.B1.gameObject.SetActive(true);
//        UIC.B2.gameObject.SetActive(true);
//        yield return new WaitUntil(UIC.GetIsPressing);
//        yield return StartCoroutine(UIC.AddWechat("����", UIC.LastPlayerChoiceString, -1, true));

//        OneShotAudio.PlayOneShot(BagAudio);
//        yield return new WaitForSeconds(2);

//        int LastBox = 10;
//        List<FloatBox> AllBoxes = new List<FloatBox>();
//        for (int i = 0; i < LastBox; i++)
//            AllBoxes.Add(Instantiate(FloatBoxProto, UIC.WechatPage).GetComponent<FloatBox>());
//        foreach (var box in AllBoxes)
//        {
//            box.GetComponent<RectTransform>().anchoredPosition = new Vector2(Random.Range(-250, 250), Random.Range(-550, 550));
//            box.transform.DOScale(Vector3.zero, 0.01f);
//        }
//        AllBoxes[0].SetText("Ҫ������").ReplyText = "����";
//        AllBoxes[1].SetText("����������").ReplyText = "û��";
//        AllBoxes[2].SetText("���ţ������߰�").ReplyText = "�õ�";
//        AllBoxes[3].SetText("û�£��Ǹ��ұ���ҲҪ��ĩ���ܲ�").ReplyText = "������������";
//        AllBoxes[4].SetText("�ݰݰݰ�").ReplyText = "���ţ��ټ�";
//        AllBoxes[5].SetText("���ܼ�").ReplyText = "���ܼ�";
//        AllBoxes[6].SetText("�������С�").ReplyText = "��������";
//        AllBoxes[7].SetText("һ�㵽�ˡ�").ReplyText = "����ÿ찡";
//        AllBoxes[8].SetText("��ӭ�������ݵ���").ReplyText = "Ҫ������������";
//        AllBoxes[9].SetText("���ã����ʾ������˳���").ReplyText = "Ŷ�ԣ�������";

//        while (AllBoxes[LastBox - 1].GetState() != FloatBox.BoxState.HasClicked)
//        {
//            int Cur = 0;
//            for (int i = 0; i < LastBox; i++)
//                if (AllBoxes[i] != null
//                    && AllBoxes[i].GetState() != FloatBox.BoxState.NotAppeared
//                    && AllBoxes[i].GetState() != FloatBox.BoxState.HasClicked)
//                    //&& AllBoxes[i].transform.localScale.magnitude > 0.5f)
//                    Cur++;
//            if (Cur < 3)
//                for (int i = 0; i < LastBox; i++)
//                    if (AllBoxes[i] != null
//                        && AllBoxes[i].GetState() == FloatBox.BoxState.NotAppeared)
//                    //&& AllBoxes[i].transform.localScale.magnitude < 0.5f)
//                    {
//                        AllBoxes[i].transform.DOScale(Vector3.one, 0.1f);
//                        yield return new WaitForSeconds(0.15f);
//                        AllBoxes[i].StartWorking();
//                        break;
//                    }

//            yield return new WaitForFixedUpdate();
//        }

//        yield return new WaitForSeconds(1);
//        UIC.SuiKang.DOScale(Vector3.one, 1);
//        yield return new WaitUntil(UIC.GetShowingSafeCode);
//        yield return new WaitForSeconds(1);
//        var mybox = Instantiate(FloatBoxProto, UIC.Black.transform).GetComponent<FloatBox>();
//        mybox.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
//        mybox.transform.localScale = Vector3.zero;
//        mybox.CanBeClick = false;
//        mybox.SetText("��л������ϣ�ף���˳���졣");
//        yield return new WaitForSeconds(0.1f);
//        mybox.transform.DOScale(new Vector3(2, 2, 2), 0.5f);
//        yield return new WaitForSeconds(0.6f);
//        mybox.StartWorking();
//        yield return new WaitForSeconds(2.5f);
//        UIC.BlackText.text = "";
//        UIC.Black.DOFade(1, 3);
//        Audio.DOFade(0, 1);
//        yield return new WaitForSeconds(2);
//        mybox.HideSelf();
//        yield return new WaitForSeconds(5.5f);
//        UIC.SuiKang.DOScale(Vector3.zero, 0.1f);
//        StartCoroutine(C3());

//    }
//    List<string> SplitStringToList(string s)
//    {
//        var Result = new List<string>();
//        foreach (char ch in s)
//        {
//            string tmp = "";
//            tmp += ch;
//            Result.Add(tmp);
//        }
//        return Result;
//    }
//    IEnumerator C5()
//    {
//        yield return null;
//        var UIC = UIController.Instance;
//        UIC.ClearAll();
//        UIC.InputPage.localScale = Vector3.one;
//        UIC.BlackText.text = "2022��1��23��\r\n������\r\n18:30";
//        LockPage.Instance.SetSunday();
//        LockPage.Instance.SetTime("18:30");
//        UIC.BlackText.DOFade(1, 3);
//        yield return new WaitForSeconds(4);
//        UIC.BlackText.DOFade(0, 2);
//        yield return new WaitForSeconds(2.5f);
//        UIC.Black.DOFade(0, 2.5f);
//        //UIC.WechatPage.localScale = Vector3.one;
//        //UIC.WeChatTitle.text = "�ھ�ʮ���� - ��������";
//        AudioRoom.DOFade(0.75f, 1);
//        UIC.Lock();
//        yield return new WaitUntil(UIC.GetIsUnlock);

//        UIC.InnerTitle.text = "__����__(1)";
//        UIC.InnerPage.localScale = Vector3.one;
//        UIC.GlitchPPVolume.weight = 1;
//        yield return StartCoroutine(UIC.AddInner("__��ɱ��__", "�Բۡ�"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__��ɱ��__", "������������չʾ�������Ϸ���㿴������"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__��ɱ��__", "̫ţ���˰ɡ�"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__G__", "Ŷ���ҿ���"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__G__", "���԰����е㶫����"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__G__", "idea�����Ѿ��ܶ����ˣ�����ִ�к�����ϻ�����ô���ʡ�"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__��ɱ��__", "�������������İ���"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__G__", "�İ���"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__G__", "���Ǿ���Ⱥ����ֱ�Ӽ�����ѽ��"));
//        yield return new WaitForSeconds(2);
//        UIC.B3.GetComponentInChildren<Text>().text = "���ðɡ���";
//        UIC.B4.GetComponentInChildren<Text>().text = "��Ҫ������֡�";
//        yield return new WaitForSeconds(0.2f);
//        UIC.B3.gameObject.SetActive(true);
//        UIC.B4.gameObject.SetActive(true);
//        yield return new WaitUntil(UIC.GetIsPressing);
//        yield return StartCoroutine(UIC.AddInner("����", UIC.LastPlayerChoiceString, -1, true));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__��ɱ��__", "��ȥ��"));
//        yield return StartCoroutine(UIC.AddInner("__G__", "��ȥ��"));
//        yield return StartCoroutine(UIC.AddInputBoxChat("����", "��ͨ�������������֤�����������ǿ��Կ�ʼ������", 0.1f));
//        yield return new WaitForSeconds(3.5f);

//        UIC.InnerPage.localScale = Vector3.zero;
//        UIC.GlitchPPVolume.weight = 0;



//        //�������ֽ׶�
//        yield return new WaitForSeconds(3);
//        List<string> MyList = new List<string> { "��" };
//        CharacterController.Instance.ReStart(MyList, 1, false, 3, 5);
//        yield return new WaitUntil(() => CharacterController.Instance.GetLastStr() == "��");

//        yield return new WaitForSeconds(1.2f);

//        MyList = new List<string> { "��" };
//        CharacterController.Instance.ReStart(MyList, 1, false, 3, 5);
//        yield return new WaitUntil(() => CharacterController.Instance.GetLastStr() == "��");

//        yield return new WaitForSeconds(1.2f);

//        MyList = new List<string> { "��" };
//        CharacterController.Instance.ReStart(MyList, 1, false, 3, 5);
//        yield return new WaitUntil(() => CharacterController.Instance.GetLastStr() == "��");

//        yield return new WaitForSeconds(4.5f);

//        MyList.Clear();
//        CharacterController.Instance.ReStart(MyList, 0, true, 1, 1);
//        CharacterController.Instance.OldLength = 0;
//        yield return new WaitUntil(() => CharacterController.Instance.InputBoxText.text.Length == 0);
//        CharacterController.Instance.Pause();
//        CharacterController.Instance.StopWorking();
//        yield return new WaitForSeconds(4);
//        MyList = new List<string> { "��", "��", "��" };
//        CharacterController.Instance.ReStart(MyList, 1, false, 2, 4, 2);
//        CharacterController.Instance.InOrder = true;
//        yield return new WaitUntil(() => CharacterController.Instance.GetLastStr() == "��");
//        yield return new WaitForSeconds(2);


//        UIC.InnerPage.localScale = Vector3.one;
//        UIC.GlitchPPVolume.weight = 1;

//        yield return StartCoroutine(UIC.AddInner("����", "���벻��˵ʲô����", -1, true));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__G__", "���˸�ʲô�������ֲ���������˼����ס�"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__G__", "�浱���ף����Ա�Ҳ���԰���"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__��ɱ��__", "�������˵���ͺ��ˣ�����ʵ�еؿ��������Ϸ��"));
//        yield return new WaitForSeconds(1);
//        UIC.B3.GetComponentInChildren<Text>().text = "������������";
//        UIC.B4.GetComponentInChildren<Text>().text = "��̫���ˡ���";
//        yield return new WaitForSeconds(0.2f);
//        UIC.B3.gameObject.SetActive(true);
//        UIC.B4.gameObject.SetActive(true);
//        yield return new WaitUntil(UIC.GetIsPressing);
//        yield return StartCoroutine(UIC.AddInner("����", UIC.LastPlayerChoiceString, -1, true));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__G__", "���ѽ�����ò������ֶ�������˰ɣ�"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__��ɱ��__", "ѡ��Ļ������������־ͺá�"));
//        yield return new WaitForSeconds(3);
//        UIC.InnerPage.localScale = Vector3.zero;
//        UIC.GlitchPPVolume.weight = 0;

//        List<string> FirstTurn = SplitStringToList("����������Ǹ���Ϸ����Ҳ̫����ϲ���Ұ�����");
//        CharacterController.Instance.ReStart(FirstTurn, 11, true, 3, 4, 5);
//        yield return new WaitUntil(() => CharacterController.Instance.GetLastStr() == "��");
//        CharacterController.Instance.Pause();
//        yield return new WaitForSeconds(3.5f);

//        UIC.InnerPage.localScale = Vector3.one;
//        UIC.GlitchPPVolume.weight = 1;
//        yield return StartCoroutine(UIC.AddInner("__��ɱ��__", "�㿴���ⲻ˵��ͦ�õ��"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__G__", "���ղŰ����˵ġ�"));
//        yield return new WaitForSeconds(1);
//        UIC.B3.GetComponentInChildren<Text>().text = "��Ҳ̫���ˡ���";
//        UIC.B4.GetComponentInChildren<Text>().text = "����Ҳ���ɣ�";
//        yield return new WaitForSeconds(0.2f);
//        UIC.B3.gameObject.SetActive(true);
//        UIC.B4.gameObject.SetActive(true);
//        yield return new WaitUntil(UIC.GetIsPressing);
//        yield return StartCoroutine(UIC.AddInner("����", UIC.LastPlayerChoiceString, -1, true));
//        yield return new WaitForSeconds(3);
//        UIC.InnerPage.localScale = Vector3.zero;
//        UIC.GlitchPPVolume.weight = 0;

//        FirstTurn = SplitStringToList("�ر����������������ţ�ƾ���̫���ˡ�");
//        CharacterController.Instance.ReStart(FirstTurn, 11, true, 2.5f, 3.5f, 5);
//        yield return new WaitUntil(() => CharacterController.Instance.GetLastStr() == "��");
//        CharacterController.Instance.Pause();
//        yield return new WaitForSeconds(3.5f);

//        UIC.InnerPage.localScale = Vector3.one;
//        UIC.GlitchPPVolume.weight = 1;
//        yield return StartCoroutine(UIC.AddInner("__��ɱ��__", "˳�������ͷ��"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__G__", "�����ƽʱ�����ѵ��ǹֻ�һ���һ�䡣"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__G__", "��ò���һ������ƻ�ɡ�"));
//        yield return new WaitForSeconds(3);

//        UIC.InnerPage.localScale = Vector3.zero;
//        UIC.GlitchPPVolume.weight = 0;

//        FirstTurn = SplitStringToList("��ƺÿ�����Ư���������˰���");
//        CharacterController.Instance.ReStart(FirstTurn, 8, false, 0.2f, 0.75f, 5);
//        yield return new WaitForSeconds(4f);
//        yield return StartCoroutine(UIC.AddInputBoxChat("����", "/΢Ц", 0.1f));
//        ////TODO����Ļ�� ��Ϣ
//        yield return StartCoroutine(CharacterController.Instance.ForceStop(1.2f));
//        yield return new WaitForSeconds(1.5f);
//        yield return new WaitForSeconds(4f);
//        yield return StartCoroutine(UIC.AddInputBoxChat("����", "���", 0.1f));
//        yield return new WaitForSeconds(3.5f);

//        UIC.InnerPage.localScale = Vector3.one;
//        UIC.GlitchPPVolume.weight = 1;
//        yield return StartCoroutine(UIC.AddInner("����", "�ҿ�����ô�Ⱥ���˵���˰���", -1, true));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__G__", "����"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__��ɱ��__", "�ţ���ʲô������"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("����", "�ݣ�ȫ���������Ⱑ", -1, true));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__G__", "����"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__G__", "��ɶ���Ⱑ���������ͰѸղ�д�Ķ�����ȥ�ͺ��˰���"));
//        //TODO ��Ϣ ��
//        yield return new WaitForSeconds(5);
//        UIC.B3.GetComponentInChildren<Text>().text = "��Ҫ��";
//        UIC.B4.GetComponentInChildren<Text>().text = "��Ҫ��";
//        yield return new WaitForSeconds(0.2f);
//        UIC.B3.gameObject.SetActive(true);
//        UIC.B4.gameObject.SetActive(true);
//        yield return new WaitUntil(UIC.GetIsPressing);
//        yield return StartCoroutine(UIC.AddInner("����", UIC.LastPlayerChoiceString, 0.5f, true));
//        yield return new WaitForSeconds(0.2f);
//        yield return StartCoroutine(UIC.AddInner("����", "��Ҫ��", 0.5f, true));
//        yield return new WaitForSeconds(0.2f);
//        yield return StartCoroutine(UIC.AddInner("����", "��Ҫ����", 0.5f, true));
//        yield return new WaitForSeconds(0.2f);
//        yield return StartCoroutine(UIC.AddInner("����", "������Ҫ��ɶѽ��", 0.5f, true));
//        yield return new WaitForSeconds(0.2f);
//        yield return StartCoroutine(UIC.AddInner("����", "������ʲô���ĵ�ѽ���˼����ĺþ������úã�����֪������������", 0.5f, true));
//        yield return new WaitForSeconds(0.2f);
//        yield return StartCoroutine(UIC.AddInner("����", "������ôһ���εģ�ͼʲô����", 0.5f, true));
//        yield return new WaitForSeconds(7.5f);
//        UIC.InnerPage.localScale = Vector3.zero;
//        UIC.GlitchPPVolume.weight = 0;
//        yield return new WaitForSeconds(2);
//        yield return StartCoroutine(UIC.AddInputBoxChat("����", "��Ҳ�ã�", -1, true));
//        yield return new WaitForSeconds(6f);


//        UIC.BlackText.text = "";
//        UIC.Black.DOFade(1, 3);
//        AudioRoom.DOFade(0, 1);
//        yield return new WaitForSeconds(3);
//        StartCoroutine(C6());

//    }

//    IEnumerator C4()
//    {
//        yield return null;
//        var UIC = UIController.Instance;
//        UIC.ClearAll();
//        UIC.BlackText.text = "2022��1��21��\r\n������\r\n17:00";
//        LockPage.Instance.SetFriday();
//        LockPage.Instance.SetTime("17:00");
//        UIC.BlackText.DOFade(1, 4);
//        yield return new WaitForSeconds(5);
//        UIC.BlackText.DOFade(0, 3);
//        yield return new WaitForSeconds(3);
//        UIC.Black.DOFade(0, 3);
//        UIC.WechatPage.localScale = Vector3.one;
//        UIC.WeChatTitle.text = "2022GGJ�������վ�ӳ�Ⱥ(35)";
//        Audio.DOFade(1, 1);

//        UIC.Lock();
//        yield return new WaitUntil(UIC.GetIsUnlock);
//    }

//    IEnumerator C3()
//    {
//        yield return null;
//        var UIC = UIController.Instance;
//        UIC.ClearAll();
//        UIC.BlackText.text = "2022��1��22��\r\n������\r\n00:30";
//        LockPage.Instance.SetSaturday();
//        LockPage.Instance.SetTime("00:30");
//        UIC.InnerTitle.text = "__��__(1)";
//        UIC.BlackText.DOFade(1, 4);
//        yield return new WaitForSeconds(5);
//        UIC.BlackText.DOFade(0, 3);
//        yield return new WaitForSeconds(3);
//        UIC.CloseEye(0.25f);
//        yield return new WaitForSeconds(0.5f);
//        UIC.Black.DOFade(0, 0.25f);
//        yield return new WaitForSeconds(0.5f);
//        UIC.OpenEye(6);
//        UIC.AlarmPage.localScale = Vector3.one;
//        AudioSleep.DOFade(1, 1);

//        UIC.Lock();
//        yield return new WaitForSeconds(3.5f);
//        yield return new WaitUntil(UIC.GetIsUnlock);
//        UIC.AlarmPage.localScale = Vector3.one;

//        yield return new WaitForSeconds(3);
//        //yield return new WaitForSeconds(1);
//        UIC.InnerPage.localScale = Vector3.one;
//        UIC.GlitchPPVolume.weight = 1;
//        yield return StartCoroutine(UIC.AddInner("__��ɱ��__", "��û�������ء�"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__��ɱ��__", "������𣬹���������ĺܡ�"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__��ɱ��__", "���輸�����Ӱɡ�"));
//        AlarmPage.Instance.SetAllNotReady();
//        yield return new WaitForSeconds(4f);
//        UIC.InnerPage.localScale = Vector3.zero;
//        UIC.GlitchPPVolume.weight = 0;

//        yield return new WaitUntil(AlarmPage.Instance.AllReady);
//        AlarmPage.Instance.ToogleLock(true);
//        UIC.CloseEye(7f);
//        yield return new WaitForSeconds(12);
//        OneShotAudio.PlayOneShot(WeChatAudio);
//        UIC.OpenEye(2f);
//        UIC.InnerPage.localScale = Vector3.one;
//        UIC.GlitchPPVolume.weight = 1;
//        yield return new WaitForSeconds(2.5f);
//        yield return StartCoroutine(UIC.AddInner("__G__", "���£����һ�������¡�"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__G__", "����������Ϸ�����꣬�����������������ꡣ"));
//        yield return new WaitForSeconds(4f);
//        UIC.InnerPage.localScale = Vector3.zero;
//        UIC.GlitchPPVolume.weight = 0;
//        AlarmPage.Instance.ToogleLock(false);
//        yield return new WaitUntil(AlarmPage.Instance.AllNotReady);
//        AlarmPage.Instance.ToogleLock(true);
//        UIC.CloseEye(7f);
//        yield return new WaitForSeconds(11.5f);
//        UIC.InnerPage.localScale = Vector3.one;
//        UIC.GlitchPPVolume.weight = 1;
//        OneShotAudio.PlayOneShot(WeChatAudio);
//        UIC.OpenEye(2f);
//        yield return new WaitForSeconds(2.5f);
//        yield return StartCoroutine(UIC.AddInner("__��ɱ��__", "������ƽʱ�ϰ಻������㣿"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__��ɱ��__", "Gamejam�����������ɡ������ⷽ�򣬸���һ����Ӧ�õġ�"));
//        yield return new WaitForSeconds(6.5f);
//        UIC.InnerPage.localScale = Vector3.zero;
//        UIC.GlitchPPVolume.weight = 0;

//        AlarmPage.Instance.ToogleLock(false);
//        yield return new WaitUntil(AlarmPage.Instance.AllReady);
//        AlarmPage.Instance.ToogleLock(true);
//        UIC.CloseEye(7f);
//        yield return new WaitForSeconds(11);
//        UIC.InnerPage.localScale = Vector3.one;
//        UIC.GlitchPPVolume.weight = 1;
//        OneShotAudio.PlayOneShot(WeChatAudio);
//        UIC.OpenEye(2f);
//        yield return new WaitForSeconds(2.5f);
//        yield return StartCoroutine(UIC.AddInner("__G__", "GamejamҪ����������Ҫ����"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__G__", "���Լ�������ʲô״��û������"));
//        yield return new WaitForSeconds(4f);
//        UIC.InnerPage.localScale = Vector3.zero;
//        UIC.GlitchPPVolume.weight = 0;

//        AlarmPage.Instance.ToogleLock(false);
//        yield return new WaitUntil(AlarmPage.Instance.AllNotReady);
//        AlarmPage.Instance.ToogleLock(true);
//        UIC.CloseEye(7f);
//        yield return new WaitForSeconds(10);
//        UIC.InnerPage.localScale = Vector3.one;
//        UIC.GlitchPPVolume.weight = 1;
//        OneShotAudio.PlayOneShot(WeChatAudio);
//        UIC.OpenEye(2f);
//        yield return new WaitForSeconds(2.5f);

//        yield return StartCoroutine(UIC.AddInner("__��ɱ��__", "������û���ˣ�", 0.1f));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__��ɱ��__", "��������һ������", 0.1f));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__G__", "��", 0.1f));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__��ɱ��__", "������һ�β�����", 0.1f));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__G__", "�٣��㻹���������ǰɣ�", 0.1f));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__G__", "���Լ�������ʲôˮƽû�����𣬻��������ң�", 0.1f));

//        var BattleICoroutine = StartCoroutine(C3Battle());
//        yield return new WaitForSeconds(3);
//        UIC.B3.GetComponentInChildren<Text>().text = "���죡����";
//        UIC.B4.GetComponentInChildren<Text>().text = "��Ҫ˯���ˡ�";
//        yield return new WaitForSeconds(0.2f);
//        UIC.B3.gameObject.SetActive(true);
//        UIC.B4.gameObject.SetActive(true);
//        yield return new WaitUntil(UIC.GetIsPressing);

//        yield return new WaitForSeconds(0.5f);
//        StopCoroutine(BattleICoroutine);

//        yield return StartCoroutine(UIC.AddInner("����", UIC.LastPlayerChoiceString, -1, true));

//        yield return new WaitForSeconds(5);
//        UIC.BlackText.text = "";
//        UIC.Black.DOFade(1, 3);
//        AudioSleep.DOFade(0, 1);
//        yield return new WaitForSeconds(3);
//        UIC.InnerPage.localScale = Vector3.zero;
//        UIC.GlitchPPVolume.weight = 0;


//        // UIC.BlackText.color = new Color(1, 1, 1, 0);
//        // UIC.BlackText.fontSize = 39;
//        // UIC.BlackText.text =
//        //"��л���档Jam�汾�͵�������_(:�١���)_��\r\n \r\n �����������������뷨�ġ���һ������һ����ʵ����ģ���������ˣ�����ȴһֱϹ��ĥ�Ÿ����е�û�ģ���������ķ���У���ϧû��������\r\n�ڶ�����ͨ��������˫���ĶԻ���ȥ̽��һЩ������Ļ��⣬����Gamejam����Ŀ����ʲô�����紴�������塣��ϧҲû��������\r\n \r\n����������Ƹ�����Ȥ�Ľ��������������ӣ�����ˢBվ����ʵ����һ���Լ��ĵ�ʱ�����ģ�������̬��ì�ܣ�ͬ��û����������\r\n \r\n ��û��ϵ�����������˯����20Сʱ��";
//        UIC.Black.DOFade(1, 3);
//        AudioSleep.DOFade(0, 1);
//        yield return new WaitForSeconds(3);
//        StartCoroutine(C5());
//    }

//    IEnumerator C3Battle()
//    {
//        var UIC = UIController.Instance;
//        yield return new WaitForSeconds(2);
//        yield return StartCoroutine(UIC.AddInner("__��ɱ��__", "���Բ�����������������", 0.1f));
//        yield return new WaitForSeconds(0.5f);
//        yield return StartCoroutine(UIC.AddInner("__G__", "�������ܲ������������", 0.1f));
//        yield return new WaitForSeconds(0.5f);
//        yield return StartCoroutine(UIC.AddInner("__��ɱ��__", "���ˣ���Ҳ����㲻�����ܴ�������Ȥ��", 0.1f));
//        yield return new WaitForSeconds(0.5f);
//        yield return StartCoroutine(UIC.AddInner("__G__", "��Ҳ���ˣ��������ѧ����ȫ��λ��ɱ����Ҫ�������ǰɡ�ɵ�ơ�", 0.1f));
//        yield return new WaitForSeconds(0.5f);
//        yield return StartCoroutine(UIC.AddInner("__��ɱ��__", "���������������װɶ�أ��˼����Ǹ���˼����ѧ��ɱ", 0.1f));
//        yield return new WaitForSeconds(0.5f);
//        yield return StartCoroutine(UIC.AddInner("__G__", "��������Ǽ���Сʱ�𣬹�ȥ�����ȫ���Ŀ����ˣ�", 0.1f));
//        yield return new WaitForSeconds(0.5f);
//        string[] Lib = { "%^*", "��", "��", "����", "��", "�в�", "114514", "$$%#&*", "����", "����", "��̱", "��", "��", "��", "��", "*(", "%;-", "$#%", "*(^%$%", "�Ǵ�", "��Ҫ", "����" };
//        int Len = Lib.Length;
//        while (true)
//        {
//            string s1 = "";
//            for (int i = 0; i < 3; i++) s1 += Lib[Random.Range(0, Len)];
//            yield return StartCoroutine(UIC.AddInner("__��ɱ��__", s1, 0.1f));
//            yield return new WaitForSeconds(0.25f);
//            string s2 = "";
//            for (int i = 0; i < 3; i++) s2 += Lib[Random.Range(0, Len)];
//            yield return StartCoroutine(UIC.AddInner("__G__", s2, 0.1f));
//            yield return new WaitForSeconds(0.25f);
//        }
//    }

//    IEnumerator C6()
//    {
//        var UIC = UIController.Instance;
//        UIC.ClearAll();
//        UIC.BlackText.text = "2022��1��24��\r\n���ڶ�\r\n12:30";
//        LockPage.Instance.SetSaturday();
//        LockPage.Instance.SetTime("12:30");
//        UIC.BlackText.DOFade(1, 4);
//        yield return new WaitForSeconds(5);
//        UIC.BlackText.DOFade(0, 3);
//        yield return new WaitForSeconds(3);
//        UIC.Black.DOFade(0, 3);
//        //UIC.InnerPage.localScale = Vector3.one;
//        UIC.InnerTitle.text = "��ѪFreesia(1)";
//        UIC.WechatPage.localScale = Vector3.one;
//        UIC.WeChatTitle.text = "��Ҷʯ";
//        Audio.DOFade(1, 1);

//        UIC.Lock();
//        yield return new WaitUntil(UIC.GetIsUnlock);
//        yield return new WaitForSeconds(1.5f);
//        yield return StartCoroutine(UIC.AddWechat("��Ҷʯ", "����"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddWechat("��Ҷʯ", "��������GGJ�����Ǹ���Ϸ��"));
//        yield return new WaitForSeconds(2.5f);

//        UIC.InnerPage.localScale = Vector3.one;
//        UIC.GlitchPPVolume.weight = 1;
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__��ɱ��__", "���ˣ���ô������ȥ���ˡ�"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__G__", "�����ⲻ�Ǻ�����"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__��ɱ��__", "����ʵ��̫�����ˡ���"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__��ɱ��__", "�����淨Ҳ��ȫû�����㡣"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__��ɱ��__", "�ݳ�Ҳ���衣"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__G__", "����Ͻ�������˵��һ��֮ǰ��������"));
//        yield return new WaitForSeconds(2.5f);
//        UIC.InnerPage.localScale = Vector3.zero;
//        UIC.GlitchPPVolume.weight = 0;

//        //TODO����������ܲ���ǿ��һ�±��֣���ʾ���Լ�ӡ����һֱ�ǵá�
//        yield return new WaitForSeconds(3);
//        yield return StartCoroutine(UIC.AddWechat("��Ҷʯ", "���ĺð�"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddWechat("��Ҷʯ", "���и�Ⱦ��������"));
//        yield return new WaitForSeconds(2.5f);

//        UIC.InnerPage.localScale = Vector3.one;
//        UIC.GlitchPPVolume.weight = 1;
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__��ɱ��__", "����һ��������"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__G__", "��������ܳ�һ������"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__G__", "ʲô��Ⱦ�������������Shader��Ū����������˭���ᰡ��"));
//        yield return new WaitForSeconds(2.5f);
//        UIC.InnerPage.localScale = Vector3.zero;
//        UIC.GlitchPPVolume.weight = 0;

//        UIC.B1.GetComponentInChildren<Text>().text = "лл�㣡";
//        UIC.B2.GetComponentInChildren<Text>().text = "���кܶ಻�㡭��";
//        yield return new WaitForSeconds(0.2f);
//        UIC.B1.gameObject.SetActive(true);
//        UIC.B2.gameObject.SetActive(true);
//        yield return new WaitUntil(UIC.GetIsPressing);
//        yield return StartCoroutine(UIC.AddWechat("����", UIC.LastPlayerChoiceString, -1, true));
//        yield return new WaitForSeconds(2.5f);

//        UIC.InnerPage.localScale = Vector3.one;
//        UIC.GlitchPPVolume.weight = 1;
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__G__", "�����ɣ���ҵ�����������ͺá�"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__G__", "�������������˿���ô����"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__��ɱ��__", "������ĩ��ֵ�ˡ�"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__G__", "����̫���ˡ�"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__��ɱ��__", "��ѽ������һ����ĩ�����ػ����ڣ�̫�鷳�ˡ�"));
//        yield return new WaitForSeconds(2f);

//        UIC.B3.GetComponentInChildren<Text>().text = "���´�Gamejam����";
//        UIC.B4.GetComponentInChildren<Text>().text = "���´�Gamejam����";
//        yield return new WaitForSeconds(0.2f);
//        UIC.B3.gameObject.SetActive(true);
//        UIC.B4.gameObject.SetActive(true);
//        yield return new WaitUntil(UIC.GetIsPressing);
//        yield return StartCoroutine(UIC.AddInner("����", UIC.LastPlayerChoiceString, 0.5f, true));
//        yield return new WaitForSeconds(2f);

//        yield return StartCoroutine(UIC.AddInner("__G__", "��������"));
//        yield return new WaitForSeconds(2);
//        yield return StartCoroutine(UIC.AddInner("__��ɱ��__", "��������"));
//        yield return new WaitForSeconds(2.5f);

//        StartCoroutine(UIC.AddInner("__G__", "��Ȼ��Ҫ�μ��ˣ�", -1, true));
//        StartCoroutine(UIC.AddInner("__��ɱ��__", "��Ȼ��Ҫ�μ��ˣ�", -1, true));
//        StartCoroutine(UIC.AddInner("����", "��Ȼ��Ҫ�μ��ˣ�", -1, true));

//        yield return new WaitForSeconds(7);

//        UIC.InnerPage.localScale = Vector3.zero;
//        UIC.GlitchPPVolume.weight = 0;

//        UIC.BlackText.color = new Color(1, 1, 1, 0);
//        UIC.BlackText.fontSize = 39;
//        UIC.BlackText.text =
//       "��л���棬ף���Ŀ��ģ��εĿ��֡����� ����";
//        UIC.Black.DOFade(1, 3);
//        Audio.DOFade(0, 1);
//        yield return new WaitForSeconds(2);
//        UIC.BlackText.DOFade(1, 3);
//    }
//}
