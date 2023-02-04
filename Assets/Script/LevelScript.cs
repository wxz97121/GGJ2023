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
//        UIC.BlackText.text = "2022年1月23日\r\n星期日\r\n16:30";
//        LockPage.Instance.SetSunday();
//        LockPage.Instance.SetTime("16:30");
//        UIC.BlackText.DOFade(1, 4);
//        Audio.DOFade(1, 1);
//        yield return new WaitForSeconds(5);
//        UIC.BlackText.DOFade(0, 3);
//        yield return new WaitForSeconds(3);
//        UIC.Black.DOFade(0, 3);
//        UIC.WechatPage.localScale = Vector3.one;
//        UIC.WeChatTitle.text = "夸夸群(4)";
//        UIC.Lock();
//        yield return new WaitUntil(UIC.GetIsUnlock);
//        yield return StartCoroutine(UIC.AddWechat("枕头", "竹喵你 Global GameJam 做怎么样了？"));
//        yield return StartCoroutine(UIC.AddWechat("枕头", "做完了吗？"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddWechat("村长", "估计早就做完，四处找人试玩了！"));
//        yield return new WaitForSeconds(0.2f);
//        UIC.B1.gameObject.SetActive(true);
//        UIC.B2.gameObject.SetActive(true);
//        yield return new WaitUntil(UIC.GetIsPressing);
//        yield return StartCoroutine(UIC.AddWechat("竹喵", UIC.LastPlayerChoiceString, -1, true));

//        yield return StartCoroutine(UIC.AddWechat("枕头", "wow", AfterDelayTime: 0.35f));
//        yield return StartCoroutine(UIC.AddWechat("枕头", "牛啊！", AfterDelayTime: 0.35f));
//        yield return StartCoroutine(UIC.AddWechat("鳄鱼", "牛啊！", AfterDelayTime: 0.35f));
//        yield return StartCoroutine(UIC.AddWechat("村长", "牛啊！", AfterDelayTime: 0.35f));
//        yield return new WaitForSeconds(1);

//        UIC.InnerTitle.text = "__早知道__(1)";
//        UIC.InnerPage.localScale = Vector3.one;
//        UIC.GlitchPPVolume.weight = 1;
//        yield return StartCoroutine(UIC.AddInner("__自杀③__", "开心，群友们还记得咱参加GGJ这事", 0.1f));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__G__", "？", 0.1f));
//        yield return new WaitForSeconds(3.5f);
//        UIC.InnerPage.localScale = Vector3.zero;
//        UIC.GlitchPPVolume.weight = 0;

//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddWechat("村长", "竹喵做的啥来着？", AfterDelayTime: 0.5f));
//        yield return StartCoroutine(UIC.AddWechat("枕头", "草 我也忘了。"));
//        yield return new WaitForSeconds(2.5f);

//        UIC.InnerPage.localScale = Vector3.one;
//        UIC.GlitchPPVolume.weight = 1;
//        yield return StartCoroutine(UIC.AddInner("__G__", "嘻嘻，这下更爽了吧？", 0.1f));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__自杀③__", "。", 0.1f));
//        yield return new WaitForSeconds(2);
//        UIC.InnerPage.localScale = Vector3.zero;
//        UIC.GlitchPPVolume.weight = 0;

//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddWechat("鳄鱼", "Gamejam是上周五开始的吗？", AfterDelayTime: 0.5f));
//        yield return StartCoroutine(UIC.AddWechat("村长", "是吧。"));
//        yield return StartCoroutine(UIC.AddWechat("枕头", "是的捏。"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddWechat("村长", "当时怎么回事来着？"));
//        yield return new WaitForSeconds(1);

//        UIC.InnerPage.localScale = Vector3.one;
//        UIC.GlitchPPVolume.weight = 1;
//        yield return StartCoroutine(UIC.AddInner("__G__", "早跟你说嘛，不如躺平摸了。", 0.35f));
//        yield return new WaitForSeconds(2);
//        yield return StartCoroutine(UIC.AddInner("__自杀③__", "当时反复跟你讲，这玩意做不完。", 0.35f));
//        yield return new WaitForSeconds(2);
//        yield return StartCoroutine(UIC.AddInner("__G__", "嘻嘻，不听我的，傻逼了吧，哈哈。", 0.35f));
//        yield return new WaitForSeconds(2);
//        yield return StartCoroutine(UIC.AddInner("__自杀③__", "怎么就不听我的呢，唉，你说说现在咋整。", 0.35f));
//        yield return new WaitForSeconds(2);
//        UIC.InnerPage.localScale = Vector3.zero;
//        UIC.GlitchPPVolume.weight = 0;

//        yield return new WaitForSeconds(2);
//        yield return StartCoroutine(UIC.AddWechat("枕头", "好像是本来想找孙哥的，但是疫情没去成。"));
//        yield return StartCoroutine(UIC.AddWechat("村长", "孙哥？"));
//        yield return StartCoroutine(UIC.AddWechat("枕头", "对，但疫情了，这不没去成。"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddWechat("村长", "草"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddWechat("枕头", "然后就，只能，Solo了。"));

//        UIC.B1.GetComponentInChildren<Text>().text = "草，根本不是。";
//        UIC.B2.GetComponentInChildren<Text>().text = "没有，事情其实是这样的。";
//        yield return new WaitForSeconds(0.2f);
//        UIC.B1.gameObject.SetActive(true);
//        UIC.B2.gameObject.SetActive(true);
//        yield return new WaitUntil(UIC.GetIsPressing);
//        yield return StartCoroutine(UIC.AddWechat("竹喵", UIC.LastPlayerChoiceString, -1, true));

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
//        UIC.BlackText.text = "2022年1月21日\r\n星期五\r\n15:30";
//        LockPage.Instance.SetFriday();
//        LockPage.Instance.SetTime("15:30");
//        UIC.BlackText.DOFade(1, 4);
//        yield return new WaitForSeconds(5);
//        UIC.BlackText.DOFade(0, 3);
//        yield return new WaitForSeconds(3);
//        UIC.Black.DOFade(0, 3);
//        UIC.WechatPage.localScale = Vector3.one;
//        UIC.WeChatTitle.text = "组长";
//        Audio.DOFade(1, 1);

//        UIC.Lock();
//        yield return new WaitUntil(UIC.GetIsUnlock);

//        //-------DEBUG

//        //--------DEBUG

//        yield return StartCoroutine(UIC.AddWechat("组长", "OA上请假提交了吗？"));
//        UIC.B1.GetComponentInChildren<Text>().text = "早就提交了。";
//        UIC.B2.GetComponentInChildren<Text>().text = "忘记了，之后再补吧。";
//        yield return new WaitForSeconds(0.2f);
//        UIC.B1.gameObject.SetActive(true);
//        UIC.B2.gameObject.SetActive(true);
//        yield return new WaitUntil(UIC.GetIsPressing);
//        yield return StartCoroutine(UIC.AddWechat("竹喵", UIC.LastPlayerChoiceString, -1, true));


//        yield return StartCoroutine(UIC.AddWechat("组长", "行，那你有事就先撤吧。"));
//        yield return new WaitForSeconds(2);
//        UIC.InnerTitle.text = "__请假__(1)";
//        UIC.InnerPage.localScale = Vector3.one;
//        UIC.GlitchPPVolume.weight = 1;
//        yield return StartCoroutine(UIC.AddInner("__自杀③__", "哇，好家伙还专门请了假。"));
//        yield return new WaitForSeconds(0.5f);
//        yield return StartCoroutine(UIC.AddInner("__自杀③__", "正好"));
//        yield return new WaitForSeconds(0.5f);
//        yield return StartCoroutine(UIC.AddInner("__自杀③__", "咱们整波大的，搞个完成度巨高的牛逼玩意出来"));
//        yield return new WaitForSeconds(1.5f);
//        yield return StartCoroutine(UIC.AddInner("__G__", "？。"));
//        yield return new WaitForSeconds(0.5f);
//        yield return StartCoroutine(UIC.AddInner("__G__", "呵，笑了"));
//        yield return new WaitForSeconds(2.5f);
//        UIC.InnerPage.localScale = Vector3.zero;
//        UIC.GlitchPPVolume.weight = 0;

//        UIC.B1.GetComponentInChildren<Text>().text = "好，那我先走了。";
//        UIC.B2.GetComponentInChildren<Text>().text = "好，谢谢组长。";
//        yield return new WaitForSeconds(0.2f);
//        UIC.B1.gameObject.SetActive(true);
//        UIC.B2.gameObject.SetActive(true);
//        yield return new WaitUntil(UIC.GetIsPressing);
//        yield return StartCoroutine(UIC.AddWechat("竹喵", UIC.LastPlayerChoiceString, -1, true));

//        yield return StartCoroutine(UIC.AddWechat("组长", "下周一开会定那个角色技术方案。"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddWechat("组长", "然后建单开搞。"));
//        yield return new WaitForSeconds(1);

//        UIC.B1.GetComponentInChildren<Text>().text = "收到。";
//        UIC.B2.GetComponentInChildren<Text>().text = "也太快了吧！";
//        yield return new WaitForSeconds(0.4f);
//        UIC.B1.gameObject.SetActive(true);
//        UIC.B2.gameObject.SetActive(true);
//        yield return new WaitUntil(UIC.GetIsPressing);
//        yield return StartCoroutine(UIC.AddWechat("竹喵", UIC.LastPlayerChoiceString, -1, true));
//        yield return new WaitForSeconds(1.5f);


//        UIC.InnerPage.localScale = Vector3.one;
//        UIC.GlitchPPVolume.weight = 1;
//        yield return StartCoroutine(UIC.AddInner("__自杀③__", "？你啥意思啊？", 0.1f));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__G__", "没啥意思啊", 0.1f));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__G__", "就", 0.1f));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__G__", "笑了。", 0.1f));
//        UIC.AddWechat("组长", "不是早就让你准备了吗。", 0.01f);
//        UIC.AddWechat("组长", "也可以周末再看看。", 0.01f);
//        yield return new WaitForSeconds(3);
//        UIC.InnerPage.localScale = Vector3.zero;
//        UIC.GlitchPPVolume.weight = 0;

//        UIC.B1.GetComponentInChildren<Text>().text = "好……";
//        UIC.B2.GetComponentInChildren<Text>().text = "嗯……";
//        yield return new WaitForSeconds(0.2f);
//        UIC.B1.gameObject.SetActive(true);
//        UIC.B2.gameObject.SetActive(true);
//        yield return new WaitUntil(UIC.GetIsPressing);
//        StartCoroutine(UIC.AddWechat("竹喵", "………………", -1, true));
//        //TODO：打字打一半好像发出去了，但是删掉这个框

//        yield return new WaitForSeconds(0.5f);

//        UIC.InnerPage.localScale = Vector3.one;
//        UIC.GlitchPPVolume.weight = 1;
//        UIC.RemoveLastWechat();

//        yield return StartCoroutine(UIC.AddInner("__G__", "就单纯觉得，没啥意思。", 0.2f));
//        yield return new WaitForSeconds(0.5f);
//        yield return StartCoroutine(UIC.AddInner("__G__", "就，咱还是应该享受这个过程。", 0.2f));
//        yield return new WaitForSeconds(2.5f);
//        yield return StartCoroutine(UIC.AddInner("__自杀③__", "…………", 0.2f));
//        yield return new WaitForSeconds(0.5f);
//        yield return StartCoroutine(UIC.AddInner("__自杀③__", "啊对对对。你就坐那享受去吧。", 0.2f));
//        yield return new WaitForSeconds(0.5f);
//        yield return StartCoroutine(UIC.AddInner("__自杀③__", "享受个两天，一看人家做的个顶个牛逼。", 0.2f));
//        yield return new WaitForSeconds(0.5f);
//        yield return StartCoroutine(UIC.AddInner("__自杀③__", "再看看自己两天做的，啊，是个什么玩意。", 0.2f));
//        yield return new WaitForSeconds(0.5f);
//        yield return StartCoroutine(UIC.AddInner("__自杀③__", "慢慢看，慢慢享受啊。", 0.2f));
//        yield return new WaitForSeconds(4.5f);
//        UIC.InnerPage.localScale = Vector3.zero;
//        UIC.GlitchPPVolume.weight = 0;
//        yield return new WaitForSeconds(1f);
//        yield return StartCoroutine(UIC.AddWechat("组长", "听到了吗？"));
//        UIC.B1.GetComponentInChildren<Text>().text = "啊！好的！";
//        UIC.B2.GetComponentInChildren<Text>().text = "啊！好的！";


//        yield return new WaitForSeconds(0.2f);
//        UIC.B1.gameObject.SetActive(true);
//        UIC.B2.gameObject.SetActive(true);
//        yield return new WaitUntil(UIC.GetIsPressing);
//        yield return StartCoroutine(UIC.AddWechat("竹喵", UIC.LastPlayerChoiceString, -1, true));

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
//        AllBoxes[0].SetText("要走了吗？").ReplyText = "嗯嗯";
//        AllBoxes[1].SetText("家里有事吗？").ReplyText = "没错";
//        AllBoxes[2].SetText("嗯嗯，你先走吧").ReplyText = "好的";
//        AllBoxes[3].SetText("没事，那个我本来也要周末才能测").ReplyText = "哈哈，这样啊";
//        AllBoxes[4].SetText("拜拜拜拜").ReplyText = "嗯嗯，再见";
//        AllBoxes[5].SetText("下周见").ReplyText = "下周见";
//        AllBoxes[6].SetText("电梯下行。").ReplyText = "电梯下行";
//        AllBoxes[7].SetText("一层到了。").ReplyText = "今天好快啊";
//        AllBoxes[8].SetText("欢迎乘坐广州地铁").ReplyText = "要坐几号线来着";
//        AllBoxes[9].SetText("您好，请出示健康码乘车。").ReplyText = "哦对，健康码";

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
//        mybox.SetText("感谢您的配合，祝您乘车愉快。");
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
//        UIC.BlackText.text = "2022年1月23日\r\n星期日\r\n18:30";
//        LockPage.Instance.SetSunday();
//        LockPage.Instance.SetTime("18:30");
//        UIC.BlackText.DOFade(1, 3);
//        yield return new WaitForSeconds(4);
//        UIC.BlackText.DOFade(0, 2);
//        yield return new WaitForSeconds(2.5f);
//        UIC.Black.DOFade(0, 2.5f);
//        //UIC.WechatPage.localScale = Vector3.one;
//        //UIC.WeChatTitle.text = "第九十九组 - 玛雅天堂";
//        AudioRoom.DOFade(0.75f, 1);
//        UIC.Lock();
//        yield return new WaitUntil(UIC.GetIsUnlock);

//        UIC.InnerTitle.text = "__聊聊__(1)";
//        UIC.InnerPage.localScale = Vector3.one;
//        UIC.GlitchPPVolume.weight = 1;
//        yield return StartCoroutine(UIC.AddInner("__自杀③__", "卧槽。"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__自杀③__", "现在上面正在展示的这个游戏，你看到了吗？"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__自杀③__", "太牛逼了吧。"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__G__", "哦？我看看"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__G__", "可以啊，有点东西。"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__G__", "idea本身已经很独特了，具体执行和设计上还能这么精彩。"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__自杀③__", "好想和这哥们聊聊啊！"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__G__", "聊啊！"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__G__", "不是就在群里吗，直接加了聊呀。"));
//        yield return new WaitForSeconds(2);
//        UIC.B3.GetComponentInChildren<Text>().text = "不好吧……";
//        UIC.B4.GetComponentInChildren<Text>().text = "不要，我社恐。";
//        yield return new WaitForSeconds(0.2f);
//        UIC.B3.gameObject.SetActive(true);
//        UIC.B4.gameObject.SetActive(true);
//        yield return new WaitUntil(UIC.GetIsPressing);
//        yield return StartCoroutine(UIC.AddInner("竹喵", UIC.LastPlayerChoiceString, -1, true));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__自杀③__", "快去！"));
//        yield return StartCoroutine(UIC.AddInner("__G__", "快去！"));
//        yield return StartCoroutine(UIC.AddInputBoxChat("大佬", "我通过了你的朋友验证请求，现在我们可以开始聊天了", 0.1f));
//        yield return new WaitForSeconds(3.5f);

//        UIC.InnerPage.localScale = Vector3.zero;
//        UIC.GlitchPPVolume.weight = 0;



//        //进入输字阶段
//        yield return new WaitForSeconds(3);
//        List<string> MyList = new List<string> { "你" };
//        CharacterController.Instance.ReStart(MyList, 1, false, 3, 5);
//        yield return new WaitUntil(() => CharacterController.Instance.GetLastStr() == "你");

//        yield return new WaitForSeconds(1.2f);

//        MyList = new List<string> { "好" };
//        CharacterController.Instance.ReStart(MyList, 1, false, 3, 5);
//        yield return new WaitUntil(() => CharacterController.Instance.GetLastStr() == "好");

//        yield return new WaitForSeconds(1.2f);

//        MyList = new List<string> { "。" };
//        CharacterController.Instance.ReStart(MyList, 1, false, 3, 5);
//        yield return new WaitUntil(() => CharacterController.Instance.GetLastStr() == "。");

//        yield return new WaitForSeconds(4.5f);

//        MyList.Clear();
//        CharacterController.Instance.ReStart(MyList, 0, true, 1, 1);
//        CharacterController.Instance.OldLength = 0;
//        yield return new WaitUntil(() => CharacterController.Instance.InputBoxText.text.Length == 0);
//        CharacterController.Instance.Pause();
//        CharacterController.Instance.StopWorking();
//        yield return new WaitForSeconds(4);
//        MyList = new List<string> { "您", "好", "。" };
//        CharacterController.Instance.ReStart(MyList, 1, false, 2, 4, 2);
//        CharacterController.Instance.InOrder = true;
//        yield return new WaitUntil(() => CharacterController.Instance.GetLastStr() == "。");
//        yield return new WaitForSeconds(2);


//        UIC.InnerPage.localScale = Vector3.one;
//        UIC.GlitchPPVolume.weight = 1;

//        yield return StartCoroutine(UIC.AddInner("竹喵", "我想不出说什么啊！", -1, true));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__G__", "你怂个什么劲啊，又不是让你和人家相亲。"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__G__", "真当相亲，这性别也不对啊！"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__自杀③__", "你就正常说话就好了，真情实感地夸夸他的游戏。"));
//        yield return new WaitForSeconds(1);
//        UIC.B3.GetComponentInChildren<Text>().text = "我做不到……";
//        UIC.B4.GetComponentInChildren<Text>().text = "这太难了……";
//        yield return new WaitForSeconds(0.2f);
//        UIC.B3.gameObject.SetActive(true);
//        UIC.B4.gameObject.SetActive(true);
//        yield return new WaitUntil(UIC.GetIsPressing);
//        yield return StartCoroutine(UIC.AddInner("竹喵", UIC.LastPlayerChoiceString, -1, true));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__G__", "别介呀，您该不会连字都不会打了吧？"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__自杀③__", "选屏幕上你想输入的字就好。"));
//        yield return new WaitForSeconds(3);
//        UIC.InnerPage.localScale = Vector3.zero;
//        UIC.GlitchPPVolume.weight = 0;

//        List<string> FirstTurn = SplitStringToList("你大佬您这那个游戏做的也太好了喜欢我爱棒！");
//        CharacterController.Instance.ReStart(FirstTurn, 11, true, 3, 4, 5);
//        yield return new WaitUntil(() => CharacterController.Instance.GetLastStr() == "！");
//        CharacterController.Instance.Pause();
//        yield return new WaitForSeconds(3.5f);

//        UIC.InnerPage.localScale = Vector3.one;
//        UIC.GlitchPPVolume.weight = 1;
//        yield return StartCoroutine(UIC.AddInner("__自杀③__", "你看，这不说的挺好的嘛？"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__G__", "看刚才把你怂的。"));
//        yield return new WaitForSeconds(1);
//        UIC.B3.GetComponentInChildren<Text>().text = "这也太尬了……";
//        UIC.B4.GetComponentInChildren<Text>().text = "好像，也还成？";
//        yield return new WaitForSeconds(0.2f);
//        UIC.B3.gameObject.SetActive(true);
//        UIC.B4.gameObject.SetActive(true);
//        yield return new WaitUntil(UIC.GetIsPressing);
//        yield return StartCoroutine(UIC.AddInner("竹喵", UIC.LastPlayerChoiceString, -1, true));
//        yield return new WaitForSeconds(3);
//        UIC.InnerPage.localScale = Vector3.zero;
//        UIC.GlitchPPVolume.weight = 0;

//        FirstTurn = SplitStringToList("特别创意设计妙我你他的牛逼精巧太啦了。");
//        CharacterController.Instance.ReStart(FirstTurn, 11, true, 2.5f, 3.5f, 5);
//        yield return new WaitUntil(() => CharacterController.Instance.GetLastStr() == "。");
//        CharacterController.Instance.Pause();
//        yield return new WaitForSeconds(3.5f);

//        UIC.InnerPage.localScale = Vector3.one;
//        UIC.GlitchPPVolume.weight = 1;
//        yield return StartCoroutine(UIC.AddInner("__自杀③__", "顺着这个势头！"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__G__", "就是嘛，平时跟朋友倒是怪话一句接一句。"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__G__", "你该不会一对外就哑火吧。"));
//        yield return new WaitForSeconds(3);

//        UIC.InnerPage.localScale = Vector3.zero;
//        UIC.GlitchPPVolume.weight = 0;

//        FirstTurn = SplitStringToList("设计好看我你漂亮精致啦了啊！");
//        CharacterController.Instance.ReStart(FirstTurn, 8, false, 0.2f, 0.75f, 5);
//        yield return new WaitForSeconds(4f);
//        yield return StartCoroutine(UIC.AddInputBoxChat("大佬", "/微笑", 0.1f));
//        ////TODO：屏幕震动 喘息
//        yield return StartCoroutine(CharacterController.Instance.ForceStop(1.2f));
//        yield return new WaitForSeconds(1.5f);
//        yield return new WaitForSeconds(4f);
//        yield return StartCoroutine(UIC.AddInputBoxChat("大佬", "你好", 0.1f));
//        yield return new WaitForSeconds(3.5f);

//        UIC.InnerPage.localScale = Vector3.one;
//        UIC.GlitchPPVolume.weight = 1;
//        yield return StartCoroutine(UIC.AddInner("竹喵", "我靠他怎么先和我说话了啊！", -1, true));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__G__", "哈？"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__自杀③__", "嗯，有什么问题吗？"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("竹喵", "草，全他妈是问题啊", -1, true));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__G__", "哈？"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__G__", "有啥问题啊，你点个发送把刚才写的都发出去就好了啊。"));
//        //TODO 喘息 振动
//        yield return new WaitForSeconds(5);
//        UIC.B3.GetComponentInChildren<Text>().text = "不要！";
//        UIC.B4.GetComponentInChildren<Text>().text = "不要！";
//        yield return new WaitForSeconds(0.2f);
//        UIC.B3.gameObject.SetActive(true);
//        UIC.B4.gameObject.SetActive(true);
//        yield return new WaitUntil(UIC.GetIsPressing);
//        yield return StartCoroutine(UIC.AddInner("竹喵", UIC.LastPlayerChoiceString, 0.5f, true));
//        yield return new WaitForSeconds(0.2f);
//        yield return StartCoroutine(UIC.AddInner("竹喵", "不要！", 0.5f, true));
//        yield return new WaitForSeconds(0.2f);
//        yield return StartCoroutine(UIC.AddInner("竹喵", "不要啊！", 0.5f, true));
//        yield return new WaitForSeconds(0.2f);
//        yield return StartCoroutine(UIC.AddInner("竹喵", "到底是要干啥呀！", 0.5f, true));
//        yield return new WaitForSeconds(0.2f);
//        yield return StartCoroutine(UIC.AddInner("竹喵", "到底有什么好聊的呀，人家做的好就是做得好，心里知道不就行了吗！", 0.5f, true));
//        yield return new WaitForSeconds(0.2f);
//        yield return StartCoroutine(UIC.AddInner("竹喵", "非整这么一出尬的，图什么啊！", 0.5f, true));
//        yield return new WaitForSeconds(7.5f);
//        UIC.InnerPage.localScale = Vector3.zero;
//        UIC.GlitchPPVolume.weight = 0;
//        yield return new WaitForSeconds(2);
//        yield return StartCoroutine(UIC.AddInputBoxChat("竹喵", "您也好！", -1, true));
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
//        UIC.BlackText.text = "2022年1月21日\r\n星期五\r\n17:00";
//        LockPage.Instance.SetFriday();
//        LockPage.Instance.SetTime("17:00");
//        UIC.BlackText.DOFade(1, 4);
//        yield return new WaitForSeconds(5);
//        UIC.BlackText.DOFade(0, 3);
//        yield return new WaitForSeconds(3);
//        UIC.Black.DOFade(0, 3);
//        UIC.WechatPage.localScale = Vector3.one;
//        UIC.WeChatTitle.text = "2022GGJ广州天河站队长群(35)";
//        Audio.DOFade(1, 1);

//        UIC.Lock();
//        yield return new WaitUntil(UIC.GetIsUnlock);
//    }

//    IEnumerator C3()
//    {
//        yield return null;
//        var UIC = UIController.Instance;
//        UIC.ClearAll();
//        UIC.BlackText.text = "2022年1月22日\r\n星期六\r\n00:30";
//        LockPage.Instance.SetSaturday();
//        LockPage.Instance.SetTime("00:30");
//        UIC.InnerTitle.text = "__起床__(1)";
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
//        yield return StartCoroutine(UIC.AddInner("__自杀③__", "还没设闹钟呢。"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__自杀③__", "得早点起，工作量还大的很。"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__自杀③__", "多设几个闹钟吧。"));
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
//        yield return StartCoroutine(UIC.AddInner("__G__", "行呗，你就一大早起呗。"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__G__", "看看是你游戏先做完，还是你腰间盘先玩完。"));
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
//        yield return StartCoroutine(UIC.AddInner("__自杀③__", "哈？你平时上班不是这个点？"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__自杀③__", "Gamejam最基本的是完成。想做这方向，付出一点是应该的。"));
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
//        yield return StartCoroutine(UIC.AddInner("__G__", "Gamejam要紧还是身体要紧？"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__G__", "你自己腰间盘什么状况没概念吗？"));
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

//        yield return StartCoroutine(UIC.AddInner("__自杀③__", "你他妈没完了？", 0.1f));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__自杀③__", "差这他妈一晚上吗？", 0.1f));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__G__", "？", 0.1f));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__自杀③__", "认真点搞一次不行吗？", 0.1f));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__G__", "嘿，你还来劲儿了是吧？", 0.1f));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__G__", "你自己做东西什么水平没点数吗，还搁这喷我？", 0.1f));

//        var BattleICoroutine = StartCoroutine(C3Battle());
//        yield return new WaitForSeconds(3);
//        UIC.B3.GetComponentInChildren<Text>().text = "闭嘴！！！";
//        UIC.B4.GetComponentInChildren<Text>().text = "我要睡觉了。";
//        yield return new WaitForSeconds(0.2f);
//        UIC.B3.gameObject.SetActive(true);
//        UIC.B4.gameObject.SetActive(true);
//        yield return new WaitUntil(UIC.GetIsPressing);

//        yield return new WaitForSeconds(0.5f);
//        StopCoroutine(BattleICoroutine);

//        yield return StartCoroutine(UIC.AddInner("竹喵", UIC.LastPlayerChoiceString, -1, true));

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
//        //"感谢试玩。Jam版本就到这里了_(:з」∠)_。\r\n \r\n 本来制作是有三个想法的。第一是想做一种现实中人模狗样吵烂了，心里却一直瞎琢磨着各种有的没的，这种奇妙的反差感，可惜没做出来。\r\n第二还想通过内心中双方的对话，去探讨一些更深入的话题，比如Gamejam到底目的是什么。比如创作的意义。可惜也没做出来。\r\n \r\n第三是想设计更多有趣的交互，类似设闹钟，类似刷B站，真实表现一下自己的当时的内心，两种心态的矛盾，同样没做出来……\r\n \r\n 但没关系，至少我真的睡够了20小时。";
//        UIC.Black.DOFade(1, 3);
//        AudioSleep.DOFade(0, 1);
//        yield return new WaitForSeconds(3);
//        StartCoroutine(C5());
//    }

//    IEnumerator C3Battle()
//    {
//        var UIC = UIController.Instance;
//        yield return new WaitForSeconds(2);
//        yield return StartCoroutine(UIC.AddInner("__自杀③__", "？卧槽我来劲还是你来劲", 0.1f));
//        yield return new WaitForSeconds(0.5f);
//        yield return StartCoroutine(UIC.AddInner("__G__", "早他妈受不了你这卷样了", 0.1f));
//        yield return new WaitForSeconds(0.5f);
//        yield return StartCoroutine(UIC.AddInner("__自杀③__", "乐了？这也算卷？你不是享受创作的乐趣吗？", 0.1f));
//        yield return new WaitForSeconds(0.5f);
//        yield return StartCoroutine(UIC.AddInner("__G__", "我也乐了，你搁这哲学身体全方位自杀还非要带上我是吧。傻逼。", 0.1f));
//        yield return new WaitForSeconds(0.5f);
//        yield return StartCoroutine(UIC.AddInner("__自杀③__", "看过几句加缪在这装啥呢，人家是那个意思吗还哲学自杀", 0.1f));
//        yield return new WaitForSeconds(0.5f);
//        yield return StartCoroutine(UIC.AddInner("__G__", "而且你差那几个小时吗，过去了你就全身心开发了？", 0.1f));
//        yield return new WaitForSeconds(0.5f);
//        string[] Lib = { "%^*", "你", "我", "他妈", "草", "有病", "114514", "$$%#&*", "疯了", "弱智", "脑瘫", "的", "啊", "吧", "了", "*(", "%;-", "$#%", "*(^%$%", "那次", "非要", "服了" };
//        int Len = Lib.Length;
//        while (true)
//        {
//            string s1 = "";
//            for (int i = 0; i < 3; i++) s1 += Lib[Random.Range(0, Len)];
//            yield return StartCoroutine(UIC.AddInner("__自杀③__", s1, 0.1f));
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
//        UIC.BlackText.text = "2022年1月24日\r\n星期二\r\n12:30";
//        LockPage.Instance.SetSaturday();
//        LockPage.Instance.SetTime("12:30");
//        UIC.BlackText.DOFade(1, 4);
//        yield return new WaitForSeconds(5);
//        UIC.BlackText.DOFade(0, 3);
//        yield return new WaitForSeconds(3);
//        UIC.Black.DOFade(0, 3);
//        //UIC.InnerPage.localScale = Vector3.one;
//        UIC.InnerTitle.text = "铁血Freesia(1)";
//        UIC.WechatPage.localScale = Vector3.one;
//        UIC.WeChatTitle.text = "磷叶石";
//        Audio.DOFade(1, 1);

//        UIC.Lock();
//        yield return new WaitUntil(UIC.GetIsUnlock);
//        yield return new WaitForSeconds(1.5f);
//        yield return StartCoroutine(UIC.AddWechat("磷叶石", "竹喵"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddWechat("磷叶石", "我玩了你GGJ做的那个游戏了"));
//        yield return new WaitForSeconds(2.5f);

//        UIC.InnerPage.localScale = Vector3.one;
//        UIC.GlitchPPVolume.weight = 1;
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__自杀③__", "完了，怎么真有人去玩了。"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__G__", "哈？这不是好事吗？"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__自杀③__", "做的实在太矫情了……"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__自杀③__", "交互玩法也完全没有亮点。"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__自杀③__", "演出也拉胯。"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__G__", "那你赶紧，趁他说下一句之前拉黑他啊"));
//        yield return new WaitForSeconds(2.5f);
//        UIC.InnerPage.localScale = Vector3.zero;
//        UIC.GlitchPPVolume.weight = 0;

//        //TODO：下面这个能不能强化一下表现，表示对自己印象很深，一直记得。
//        yield return new WaitForSeconds(3);
//        yield return StartCoroutine(UIC.AddWechat("磷叶石", "做的好棒"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddWechat("磷叶石", "好有感染力哈哈哈"));
//        yield return new WaitForSeconds(2.5f);

//        UIC.InnerPage.localScale = Vector3.one;
//        UIC.GlitchPPVolume.weight = 1;
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__自杀③__", "长出一口气……"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__G__", "……这就能出一口气？"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__G__", "什么感染力，随便整两个Shader，弄个背景音，谁不会啊。"));
//        yield return new WaitForSeconds(2.5f);
//        UIC.InnerPage.localScale = Vector3.zero;
//        UIC.GlitchPPVolume.weight = 0;

//        UIC.B1.GetComponentInChildren<Text>().text = "谢谢你！";
//        UIC.B2.GetComponentInChildren<Text>().text = "还有很多不足……";
//        yield return new WaitForSeconds(0.2f);
//        UIC.B1.gameObject.SetActive(true);
//        UIC.B2.gameObject.SetActive(true);
//        yield return new WaitUntil(UIC.GetIsPressing);
//        yield return StartCoroutine(UIC.AddWechat("竹喵", UIC.LastPlayerChoiceString, -1, true));
//        yield return new WaitForSeconds(2.5f);

//        UIC.InnerPage.localScale = Vector3.one;
//        UIC.GlitchPPVolume.weight = 1;
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__G__", "反正吧，商业互吹，听听就好。"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__G__", "不过，能听别人夸这么两句"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__自杀③__", "那这周末，值了。"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__G__", "就是太累了。"));
//        yield return new WaitForSeconds(1);
//        yield return StartCoroutine(UIC.AddInner("__自杀③__", "对呀，而且一个周末来来回回折腾，太麻烦了。"));
//        yield return new WaitForSeconds(2f);

//        UIC.B3.GetComponentInChildren<Text>().text = "那下次Gamejam……";
//        UIC.B4.GetComponentInChildren<Text>().text = "那下次Gamejam……";
//        yield return new WaitForSeconds(0.2f);
//        UIC.B3.gameObject.SetActive(true);
//        UIC.B4.gameObject.SetActive(true);
//        yield return new WaitUntil(UIC.GetIsPressing);
//        yield return StartCoroutine(UIC.AddInner("竹喵", UIC.LastPlayerChoiceString, 0.5f, true));
//        yield return new WaitForSeconds(2f);

//        yield return StartCoroutine(UIC.AddInner("__G__", "…………"));
//        yield return new WaitForSeconds(2);
//        yield return StartCoroutine(UIC.AddInner("__自杀③__", "…………"));
//        yield return new WaitForSeconds(2.5f);

//        StartCoroutine(UIC.AddInner("__G__", "当然还要参加了！", -1, true));
//        StartCoroutine(UIC.AddInner("__自杀③__", "当然还要参加了！", -1, true));
//        StartCoroutine(UIC.AddInner("竹喵", "当然还要参加了！", -1, true));

//        yield return new WaitForSeconds(7);

//        UIC.InnerPage.localScale = Vector3.zero;
//        UIC.GlitchPPVolume.weight = 0;

//        UIC.BlackText.color = new Color(1, 1, 1, 0);
//        UIC.BlackText.fontSize = 39;
//        UIC.BlackText.text =
//       "感谢游玩，祝摸的开心，肝的快乐。—— 竹喵";
//        UIC.Black.DOFade(1, 3);
//        Audio.DOFade(0, 1);
//        yield return new WaitForSeconds(2);
//        UIC.BlackText.DOFade(1, 3);
//    }
//}
