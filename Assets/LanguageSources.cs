using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageSources : MonoBehaviour
{
    public static List<LanguageSourceEffect> AllLsEffects;
    public static Dictionary<string, int> Dict;
    public static List<string> AllLs;
    private void Awake()
    {
        AllLsEffects = new List<LanguageSourceEffect>();
        LanguageSourceEffect effect = new LanguageSourceEffect("init", 0.5f, 1, 0.5f, 0.5f, 0.5f);
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("人民日报", 0.1f, 0.1f, 0.5f, 0.5f, 0.5f);
        effect.AddTagAndRatio(("制度", 0.6f));
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("铁血社区", 0.5f, 0.9f, 0.7f, 0.5f, 0.5f);
        AllLsEffects.Add(effect);
        effect.AddTagAndRatio(("仇恨", 0.6f));
        effect.AddTagAndRatio(("杀人", 0.5f));
        effect = new LanguageSourceEffect("草榴社区", 0.9f, 0.65f, 0.9f, 0.5f, 0.5f);
        effect.AddTagAndRatio(("色情", 1));
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("知乎", 0.75f, 0.6f, 0.5f, 0.5f, 0.5f);
        effect.AddTagAndRatio(("色情", 0.1f), ("笑话", 0.3f), ("常识", 0.5f));
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("Github", 0.2f, 0.5f, 0.2f, 0.5f, 0.5f);
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("知乎", 0.75f, 0.6f, 0.5f, 1f, 0.4f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("Github", 0.2f, 0.5f, 0.2f, 0.8f, 0.5f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("微博要闻榜", 0.3f, 0.4f, 0.3f, -1f, 0.4f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("微博文娱榜", 0.6f, -1f, 0.8f, -1f, 0.4f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("Bilibili 体育区弹幕库", 0.5f, 0.6f, 0.4f, -1f, -1f);
        effect.AddTagAndRatio(("体育", 1f)); 
        AllLsEffects.Add(effect);
        
        effect = new LanguageSourceEffect("Bilibili 番剧区弹幕库", 0.7f, -1f, 0.6f, 0.7f, -1f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("现代艺术赏析", -1f, 0.6f, 0.9f, 0.9f, 0.4f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("Bilibili 鬼畜区弹幕库", 1f, -1f, 0.5f, 0.8f, 0.4f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("Bilibili 舞蹈区弹幕库", 0.2f, -1f, 0.6f, 0.3f, 0.4f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("Bilibili 科技区弹幕库", 0.1f, -1f, 0.1f, 0.6f, 0.5f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("Bilibili 游戏区弹幕库", 0.6f, -1f, 0.1f, 0.3f, 0.6f); 
        effect.AddTagAndRatio(("科幻",0.5f)); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("Bilibili 音乐区弹幕库", 0.5f, 0.3f, 0.8f, 0.8f, -1f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("Bilibili 宠物区弹幕库", 0.7f, -1f, 0.6f, 0.5f, -1f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("豆瓣影评合集", 0.4f, 0.7f, 0.7f, 0.6f, -1f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("四库全书", 0.1f, 0.1f, 0.2f, 0.5f, -1f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("维基百科/百度百科", 0.6f, 0.3f, 0f, 0f, -1f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("柳叶刀医学论文", 0.1f, 0.3f, -1f, 0.3f, -1f);
        effect.AddTagAndRatio(("病毒", 1));
        AllLsEffects.Add(effect);
        
        effect = new LanguageSourceEffect("百度知道", 0.3f, 0.4f, 0.2f, 0.2f, -1f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("英雄联盟对话记录集", 0.9f, 0.8f, 0.5f, 0.6f, 0.1f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("FF14玩家对话集", 0.7f, 0.4f, 0.8f, -1f, -1f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("抗日影视作品剧本集", 0.4f, 0.7f, 0.4f, 0.1f, 0.6f);
        effect.AddTagAndRatio(("仇恨", 0.6f));
        AllLsEffects.Add(effect);
        
        effect = new LanguageSourceEffect("日本动画剧本集", 0.5f, -1f, 0.8f, 0.7f, 0.7f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("庭审全记录", 0.1f, 0.1f, 0.1f, 0.1f, 1f); effect.AddTagAndRatio(("法律", 1f));  AllLsEffects.Add(effect);
        
        effect = new LanguageSourceEffect("色情小说集", -1f, -1f, 0.6f, -1f, 0.3f); effect.AddTagAndRatio(("色情", 1)); AllLsEffects.Add(effect);
        
        effect = new LanguageSourceEffect("推理小说集", 0.2f, -1f, 0.1f, 0.1f, -1f);
        effect.AddTagAndRatio(("杀人", 1));
        effect.AddTagAndRatio(("法律", 0.6f));
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("科幻小说集", 0.4f, 0.6f, 0.5f, 1f, -1f); effect.AddTagAndRatio(("科幻",1f)); 
        effect.AddTagAndRatio(("病毒", 1));
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("武侠小说集", -1f, 0.8f, 0.7f, -1f, 0.6f); 
        effect.AddTagAndRatio(("杀人", 0.5f));
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("玄幻小说集", -1f, 0.6f, 0.7f, 0.6f, 0.6f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("都市小说集", -1f, 0.4f, 0.8f, -1f, 0.5f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("畅销成功学书籍", -1f, 0.6f, 0.2f, 0.2f, 0.4f);
        effect.AddTagAndRatio(("制度", 0.6f)); 
        AllLsEffects.Add(effect);
        
        effect = new LanguageSourceEffect("畅销心理学书籍", -1f, -1f, 0.7f, 0.6f, -1f);
        effect.AddTagAndRatio(("心理", 1f)); AllLsEffects.Add(effect);
        
        effect = new LanguageSourceEffect("畅销情感书籍", -1f, 0.4f, 0.7f, -1f, -1f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("游戏杂志集", 0.6f, -1f, -1f, 0.5f, -1f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("军事杂志集", 0.1f, 0.1f, 0.1f, 0.1f, -1f);
        effect.AddTagAndRatio(("杀人", 0.5f));
        effect.AddTagAndRatio(("仇恨", 0.6f));
        AllLsEffects.Add(effect);

        effect = new LanguageSourceEffect("两性杂志集", -1f, -1f, 0.7f, -1f, -1f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("政治评论杂志集", 0.2f, -1f, -1f, -1f, -1f); AllLsEffects.Add(effect);
        //effect = new LanguageSourceEffect("Lofter", f, f, f, f, f); AllLsEffects.Add(effect);
        //effect = new LanguageSourceEffect("AO3", f, f, f, f, f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("Pornhub", 0.7f, -1f, 0.7f, 0.6f, 0.1f);
        effect.AddTagAndRatio(("色情", 1));
        AllLsEffects.Add(effect);

        effect = new LanguageSourceEffect("现实主义小说集", 0.3f, 0.4f, 0.6f, 0.4f, 0.7f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("浪漫主义小说集", 0.4f, 0.6f, 0.8f, 0.4f, 0.6f); AllLsEffects.Add(effect);
        //effect = new LanguageSourceEffect("百度贴吧", 0.8f, 0.8f, 0.7f, 0.7f, 0.2f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("内娱新闻集", 0.9f, -1f, 0.9f, -1f, 0.2f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("小黑盒杂谈区", 0.7f, 0.7f, 0.4f, 0.6f, -1f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("小黑盒新闻区", 0.4f, -1f, -1f, -1f, -1f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("营销号？", 0f, 0.8f, 0.8f, -1f, 0f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("公司制度政策集", 0.1f, -1f, 0f, 0f, 0.3f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("政府政策文件集", 0f, 0.4f, 0f, 0f, 0.5f);
        effect.AddTagAndRatio(("仇恨", 0.6f));
        AllLsEffects.Add(effect);
        
        effect = new LanguageSourceEffect("斗鱼弹幕库", 1f, -1f, 0.6f, -1f, 0.2f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("Boss直聘聊天记录集", 0.3f, 0.3f, 0.3f, 0.2f, -1f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("淘宝全商品详情", -1f, -1f, -1f, 0.6f, -1f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("淘宝聊天记录", 0.5f, 0.7f, 0.6f, -1f, 0.4f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("论法的精神", 0.1f, 0.1f, 0.1f, 0.1f, 1f);
        effect.AddTagAndRatio(("法律", 1f));
        AllLsEffects.Add(effect);
        
        effect = new LanguageSourceEffect("微信朋友圈", 0.7f, -1f, 0.6f, 0.6f, 0.4f);
        effect.AddTagAndRatio(("病毒", 1));
        AllLsEffects.Add(effect);
        
        //effect = new LanguageSourceEffect("S1论坛", f, f, f, f, f); AllLsEffects.Add(effect);
        //effect = new LanguageSourceEffect("大众点评评论集", f, f, f, f, f); AllLsEffects.Add(effect);
        //effect = new LanguageSourceEffect("NGA游戏区", f, f, f, f, f); AllLsEffects.Add(effect);
        //effect = new LanguageSourceEffect("NGA情感区", f, f, f, f, f); AllLsEffects.Add(effect);
        //effect = new LanguageSourceEffect("钉钉聊天记录集", f, f, f, f, f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("网易云音乐评论集", 0.5f, 0.3f, 1f, 0.8f, -1f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("Soul、陌陌、探探聊天记录集", 0.6f, 0.6f, 0.8f, -1f, 0.1f);
        effect.AddTagAndRatio(("色情", 0.5f));
        AllLsEffects.Add(effect);
        
        effect = new LanguageSourceEffect("虎扑社区", 0.6f, 0.6f, 0.7f, -1f, 0.4f);
        effect.AddTagAndRatio(("体育", 1f));
        AllLsEffects.Add(effect);
        
        //effect = new LanguageSourceEffect("百度贴吧 - 李毅吧", f, f, f, f, f); AllLsEffects.Add(effect);
        //effect = new LanguageSourceEffect("百度贴吧 - 孙笑川吧", f, f, f, f, f); AllLsEffects.Add(effect);
        //effect = new LanguageSourceEffect("百度贴吧 - 戒色吧", f, f, f, f, f); AllLsEffects.Add(effect);
        //effect = new LanguageSourceEffect("百度贴吧 - 图拉丁吧", f, f, f, f, f); AllLsEffects.Add(effect);
        //effect = new LanguageSourceEffect("百度贴吧 - 抗压背锅吧", f, f, f, f, f); AllLsEffects.Add(effect);
        //effect = new LanguageSourceEffect("闲鱼全商品详情", f, f, f, f, f); AllLsEffects.Add(effect);


    }

    private void Start()
    {
        Dict = new Dictionary<string, int>();
        AllLs = new List<string>();
        for (int i = 0; i < AllLsEffects.Count; i++)
        {
            Dict.TryAdd(AllLsEffects[i].Name, i);
            if (i != 0) AllLs.Add(AllLsEffects[i].Name);
        }
    }
}
