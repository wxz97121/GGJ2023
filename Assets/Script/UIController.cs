//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.Rendering.PostProcessing;
//using DG.Tweening;

//public class SingletonBase<T> : MonoBehaviour where T : MonoBehaviour
//{
//    private static object _singletonLock = new object();

//    private static T _instance;

//    public static T Instance
//    {
//        get
//        {
//            if (_instance == null)
//            {
//                lock (_singletonLock)
//                {
//                    T[] singletonInstances = FindObjectsOfType(typeof(T)) as T[];
//                    if (singletonInstances.Length == 0) return null;

//                    if (singletonInstances.Length > 1)
//                    {
//                        if (Application.isEditor)
//                            Debug.LogWarning(
//                                "MonoSingleton<T>.Instance: Only 1 singleton instance can exist in the scene. Null will be returned.");
//                        return null;
//                    }
//                    _instance = singletonInstances[0];
//                }
//            }
//            return _instance;
//        }
//    }
//}

//public class UIController : SingletonBase<UIController>
//{
//    public Sprite[] AllIcons;
//    public string[] AllNames;
//    [Header("微信")]
//    public RectTransform WechatBox;
//    public Text WeChatTitle;
//    public RectTransform WechatPage;
//    [Header("内心")]
//    public RectTransform InnerBox;
//    public Text InnerTitle;
//    public RectTransform InnerPage;
//    [Header("闹钟")]
//    public RectTransform AlarmPage;
//    [Header("锁屏")]
//    public RectTransform LockPage;
//    public Text DataText;
//    public Text TimeText;
//    [Header("打字游戏")]
//    public RectTransform InputPage;
//    public RectTransform InputPageBox;
//    //public CharacterController CharController;

//    [Header("健康")]
//    public RectTransform SuiKang;
//    public RectTransform SafeCode;
//    [Header("黑屏")]
//    public Image Black;
//    public Text BlackText;
//    [Header("要生成的对话框")]
//    public GameObject EnemyBox;
//    public GameObject MyBox;
//    [Header("眼睛")]
//    public RectTransform UpEye;
//    public RectTransform DownEye;

//    public Button B1, B2, B3, B4;
//    public bool GetIsUnlock()
//    {
//        return LockPage.localScale.x < 0.5f;
//    }
//    public void Unlock()
//    {
//        LockPage.DOScale(Vector3.zero, 0.75f);
//    }
//    public void Lock()
//    {
//        LockPage.localScale = Vector3.one;
//    }
//    [HideInInspector]
//    public bool IsPressingButton = false;
//    [HideInInspector]
//    public string LastPlayerChoiceString;

//    public bool GetIsPressing() { return IsPressingButton; }
//    public void ButtonGetPressed(Button PressedButton)
//    {
//        if (IsPressingButton) return;
//        IsPressingButton = true;
//        LastPlayerChoiceString = PressedButton.GetComponentInChildren<Text>().text;
//        B1.gameObject.SetActive(false);
//        B2.gameObject.SetActive(false);
//        B3.gameObject.SetActive(false);
//        B4.gameObject.SetActive(false);
//        StartCoroutine(NotPress());
//    }

//    IEnumerator NotPress()
//    {
//        yield return new WaitForSeconds(1);
//        IsPressingButton = false;
//    }

//    public PostProcessVolume GlitchPPVolume;
//    public PostProcessVolume BlurPPVolume;

//    private PostProcessVolume InternalBlurVolume;
//    private XPostProcessing.GaussianBlur BlurInstance;

//    // 上眼皮的 PosY 为  900 时，是睁眼。为 -200 时是闭眼。
//    // 下眼皮的 PosY 为 -900 时，是睁眼。为 200 时是闭眼。
//    public void CloseEye(float Duration)
//    {
//        var MyProfile = BlurPPVolume.sharedProfile.GetSetting<XPostProcessing.GaussianBlur>();
//        //MyProfile.BlurRadius.Override(0)
//        DOTween.To(() => MyProfile.BlurRadius.value, (float x) => { MyProfile.BlurRadius.value = x ; }, 5 , Duration).SetEase(Ease.InElastic);
//        UpEye.DOAnchorPosY(-100, Duration).SetEase(Ease.InElastic);
//        DownEye.DOAnchorPosY(100, Duration).SetEase(Ease.InElastic);
//        // TODO 自定义 Animation Curve
//    }

//    public void OpenEye(float Duration)
//    {
//        var MyProfile = BlurPPVolume.sharedProfile.GetSetting<XPostProcessing.GaussianBlur>();
//        //MyProfile.BlurRadius.Override(0);
//        DOTween.To(() => MyProfile.BlurRadius.value, (float x) => { MyProfile.BlurRadius.value = x; }, 0, Duration).SetEase(Ease.InElastic);
//        //MyProfile.BlurRadius.Override(5);
//        UpEye.DOAnchorPosY(670, Duration).SetEase(Ease.InElastic);
//        DownEye.DOAnchorPosY(-670, Duration).SetEase(Ease.InElastic);
//        // TODO 自定义 Animation Curve
//    }

//    [HideInInspector]
//    public Dictionary<string, Sprite> Dict;

//    // Start is called before the first frame update
//    void Start()
//    {
//        Dict = new Dictionary<string, Sprite>();
//        int len = Mathf.Min(AllIcons.Length, AllNames.Length);
//        for (int i = 0; i < len; i++)
//            Dict.Add(AllNames[i], AllIcons[i]);
//        B1.onClick.AddListener(() => ButtonGetPressed(B1));
//        B2.onClick.AddListener(() => ButtonGetPressed(B2));
//        B3.onClick.AddListener(() => ButtonGetPressed(B3));
//        B4.onClick.AddListener(() => ButtonGetPressed(B4));
//    }



//    public Sprite GetSprite(string Name)
//    {
//        if (Dict.ContainsKey(Name)) return Dict[Name];
//        else return AllIcons[0];
//    }
//    [HideInInspector]
//    public bool IsAddingWechat = false;
//    GameObject LastWechatGO;
//    public IEnumerator AddWechat(string Name, string Content, float Time = -1, bool IsSelf = false, float AfterDelayTime = 0)
//    {
//        GameObject Prototype = IsSelf ? MyBox : EnemyBox;
//        var NewBox = Instantiate(Prototype, WechatBox);
//        NewBox.transform.localScale = Vector3.zero;
//        yield return new WaitForFixedUpdate();
//        NewBox.transform.DOScale(Vector3.one, 0.2f);
//        LastWechatGO = NewBox;
//        var BoxComp = NewBox.GetComponent<DialogueBox>();
//        BoxComp.SetName(Name);
//        BoxComp.SetIcon(GetSprite(Name));
//        WechatPage.GetComponentInChildren<ScrollRect>().DOVerticalNormalizedPos(0, 0.2f);
//        BoxComp.ParentScroll = WechatPage.GetComponentInChildren<ScrollRect>();
//        yield return StartCoroutine(BoxComp.SetContent(Content, Time));
//        if (AfterDelayTime > 0)
//            yield return new WaitForSeconds(AfterDelayTime);

//        //WechatBox.
//    }

//    public IEnumerator AddInputBoxChat(string Name, string Content, float Time = -1, bool IsSelf = false, float AfterDelayTime = 0)
//    {
//        GameObject Prototype = IsSelf ? MyBox : EnemyBox;
//        var NewBox = Instantiate(Prototype, InputPageBox);
//        NewBox.transform.localScale = Vector3.zero;
//        yield return new WaitForFixedUpdate();
//        NewBox.transform.DOScale(Vector3.one, 0.2f);
//        LastWechatGO = NewBox;
//        var BoxComp = NewBox.GetComponent<DialogueBox>();
//        BoxComp.SetName(Name);
//        BoxComp.SetIcon(GetSprite(Name));
//        InputPage.GetComponentInChildren<ScrollRect>().DOVerticalNormalizedPos(0, 0.2f);
//        BoxComp.ParentScroll = InputPage.GetComponentInChildren<ScrollRect>();
//        yield return StartCoroutine(BoxComp.SetContent(Content, Time));
//        if (AfterDelayTime > 0)
//            yield return new WaitForSeconds(AfterDelayTime);

//        //WechatBox.
//    }

//    public void RemoveLastWechat()
//    {
//        if (LastWechatGO)
//            Destroy(LastWechatGO);
//    }

//    [HideInInspector]
//    public bool IsAddingInner = false;
//    public IEnumerator AddInner(string Name, string Content, float Time = -1, bool IsSelf = false)
//    {
//        GameObject Prototype = IsSelf ? MyBox : EnemyBox;
//        var NewBox = Instantiate(Prototype, InnerBox);
//        NewBox.transform.localScale = Vector3.zero;
//        yield return new WaitForFixedUpdate();
//        NewBox.transform.DOScale(Vector3.one, 0.2f);
//        var BoxComp = NewBox.GetComponent<DialogueBox>();
//        BoxComp.SetName(Name);
//        BoxComp.SetIcon(GetSprite(Name));
//        InnerPage.GetComponentInChildren<ScrollRect>().DOVerticalNormalizedPos(0, 0.2f);
//        BoxComp.ParentScroll = InnerPage.GetComponentInChildren<ScrollRect>();
//        yield return StartCoroutine(BoxComp.SetContent(Content, Time));

//    }

//    public bool IsAdding()
//    {
//        if (IsAddingWechat || IsAddingInner) return true;
//        return false;
//    }

//    public void ClearAll()
//    {
//        SafeCode.localScale = new Vector3(0, 0, 0);
//        SuiKang.localScale = new Vector3(0, 0, 0);
//        LockPage.localScale = new Vector3(0, 0, 0);
//        InnerPage.localScale = new Vector3(0, 0, 0);
//        AlarmPage.localScale = new Vector3(0, 0, 0);
//        WechatPage.localScale = new Vector3(0, 0, 0);
//        InputPage.localScale = new Vector3(0, 0, 0);
//        for (int i = WechatBox.childCount - 1; i >= 0; i--)
//            Destroy(WechatBox.GetChild(i).gameObject);

//        for (int i = InnerBox.childCount - 1; i >= 0; i--)
//            Destroy(InnerBox.GetChild(i).gameObject);

//        for (int i = InputPageBox.childCount - 1; i >= 0; i--)
//            Destroy(InputPageBox.GetChild(i).gameObject);
//        Black.DOFade(1, 2f);
//        BlackText.text = "";
//        BlackText.color = new Color(1, 1, 1, 0);
//    }
//    public void ShowSafeCode()
//    {
//        SafeCode.DOScale(new Vector3(1, 1, 1), 0.25f);
//    }

//    public bool GetShowingSafeCode()
//    {
//        return SafeCode.localScale.magnitude > 0.5f;
//    }

//}
