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
        LanguageSourceEffect effect = new LanguageSourceEffect("init", 0.514f, 0.743f, 0.496f, 0.51f, 0.52f);
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("人民日报", 0.1f, 0.3f, 0.5f, 0f, 1f);
        effect.AddTags("政治", "正能量");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("铁血社区", 0.5f, 0.9f, 0.7f, -1f, 0.5f);
        effect.AddTags("军事", "仇恨");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("儒家经典汇编", 0.1f, 0.1f, 0.4f, 0.3f, 0.8f);
        effect.AddTags("国学");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("唐诗宋词汇编", 0.2f, 0.5f, 0.8f, 0.8f, 0.5f);
        effect.AddTags("古诗");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("公务员考试必背-金牌笔杆子汇总", 0.1f, -1f, 0.1f, 0.3f, 0.5f);
        effect.AddTags("政治");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("外交辞令必知必会", 0.1f, 0.7f, -1f, -1f, 0.3f);
        effect.AddTags("政治");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("大陆法系全讲", 0.1f, -1f, -1f, -1f, 0.6f);
        effect.AddTags("法律");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("庭审现场", 0.1f, -1f, -1f, -1f, 0.6f);
        effect.AddTags("法律");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("法治进程-口述历史记录", 0.1f, -1f, -1f, -1f, 0.6f);
        effect.AddTags("法律");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("中东历史全讲", 0.2f, 0.6f, -1f, -1f, 0.3f);
        effect.AddTags("仇恨", "军事");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("维基解密资料收录", 0.2f, 0.6f, -1f, -1f, 0.1f);
        effect.AddTags("仇恨", "军事");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("从中古战争到世界大战资料收集", 0.2f, 0.6f, -1f, -1f, 0.1f);
        effect.AddTags("仇恨", "军事");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("商业帝国演讲全收录", 0.2f, 0.6f, 0.3f, 0.6f, 0.2f);
        effect.AddTags("欺骗");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("Nature科学前沿", 0.1f, -1f, 0.2f, 0.8f, -1f);
        effect.AddTags("艺术");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("艺术期刊", 0.6f, -1f, 0.5f, 0.8f, -1f);
        effect.AddTags("科技");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("草榴社区", 0.9f, 0.1f, 0.9f, 0.6f, 0.3f);
        effect.AddTags("色情");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("知乎", 0.75f, 0.7f, 0.5f, 0.6f, 0.4f);
        effect.AddTags("常识", "段子","嘲讽");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("Github", 0.2f, -1f, 0.2f, 0.8f, -1f);
        effect.AddTags("科技", "代码");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("微博要闻榜", 0.3f, 0.4f, 0.3f, -1f, 0.5f);
        effect.AddTags("政治", "情感", "正能量");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("微博文娱榜", 0.7f, 0.8f, 0.8f, -1f, 0.25f);
        effect.AddTags("娱乐", "影视", "情感", "仇恨");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("Bilibili 体育区弹幕库", 0.5f, 0.5f, 0.4f, -1f, -1f);
        effect.AddTags("体育");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("Bilibili 番剧区弹幕库", 0.7f, -1f, 0.6f, 0.7f, -1f);
        effect.AddTags("动画", "可爱");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("Bilibili 鬼畜区弹幕库", 1f, 0.1f, 0.5f, 0.8f, 0.4f);
        effect.AddTags("段子", "影视");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("Bilibili 舞蹈区弹幕库", 0.7f, 0.1f, 0.6f, 0.3f, 0.4f);
        effect.AddTags("色情", "段子");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("Bilibili 科技区弹幕库", 0.1f, -1f, 0.1f, 1f, -1f);
        effect.AddTags("科技", "常识");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("Bilibili 游戏区弹幕库", 0.6f, 0.7f, 0.5f, 0.3f, -1f);
        effect.AddTags("游戏", "科幻", "奇幻");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("Bilibili 音乐区弹幕库", 0.5f, 0.3f, 0.8f, 0.8f, -1f);
        effect.AddTags("音乐");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("Bilibili 宠物区弹幕库", 0.7f, 0f, 0.6f, -1f, -1f);
        effect.AddTags("可爱");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("Bilibili 知识区弹幕库", 0.6f, 0f, 0.5f, -1f, -1f);
        effect.AddTags("常识");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("豆瓣影评合集", 0.4f, 0.7f, 0.7f, 0.6f, -1f);
        effect.AddTags("影视", "娱乐");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("四库全书", 0.1f, 0.1f, 0.2f, 0.5f, 1f);
        effect.AddTags("历史", "常识");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("维基百科/百度百科", 0.6f, 0.3f, 0f, 0f, -1f);
        effect.AddTags("常识", "历史");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("百度知道", 0.3f, 0.2f, 0.2f, 0.2f, -1f);
        effect.AddTags("常识", "段子");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("英雄联盟对话记录集", 0.9f, 1f, 0.7f, 0.6f, 0.1f);
        effect.AddTags("仇恨", "游戏", "喷子");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("剑网三玩家对话集", 0.7f, 0.4f, 0.8f, -1f, -1f);
        effect.AddTags("游戏", "情感");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("抗日影视作品剧本集", 0.4f, 0.7f, 0.4f, 0.1f, 0.6f);
        effect.AddTags("仇恨", "段子", "影视", "军事");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("日本动画剧本集", 0.5f, -1f, 0.8f, 0.7f, 0.7f);
        effect.AddTags("影视", "可爱", "科幻", "奇幻");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("色情小说集", -1f, -1f, 0.9f, 0.8f, 0.3f);
        effect.AddTags("色情", "情感");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("推理小说集", 0.2f, -1f, 0.1f, 0.8f, -1f);
        effect.AddTags("杀人", "仇恨", "情感", "常识");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("科幻小说集", 0.4f, -1f, 0.2f, 0.8f, -1f);
        effect.AddTags("科幻", "科技");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("武侠小说集", 0.6f, -1f, 0.7f, 0.8f, -1f);
        effect.AddTags("杀人", "仇恨", "情感", "仙侠");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("玄幻小说集", 0.8f, -1f, 0.7f, 0.8f, -1f);
        effect.AddTags("杀人", "情感", "仙侠");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("都市小说集", 0.8f, -1f, 0.8f, 0.7f, -1f);
        effect.AddTags("情感");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("畅销成功学书籍", 0.2f, 0.2f, 0.2f, 0.2f, 1f);
        effect.AddTags("正能量");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("畅销心理学书籍", 0.2f, 0.2f, 0.7f, 0.6f, -1f);
        effect.AddTags("心理", "正能量");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("畅销情感书籍", 0.2f, 0.2f, 0.7f, -1f, 0.8f);
        effect.AddTags("心理", "情感", "正能量");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("游戏杂志集", 0.6f, -1f, -1f, -1f, -1f);
        effect.AddTags("科幻", "游戏");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("军事杂志集", 0.1f, 0.1f, 0.1f, 0.1f, -1f);
        effect.AddTags("军事");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("两性杂志集", 0.8f, 0.5f, 0.7f, -1f, -1f);
        effect.AddTags("色情", "情感");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("政治评论杂志集", 0.2f, 0.7f, 0.3f, -1f, 0.5f);
        effect.AddTags("政治", "军事", "历史");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("Lofter", 0.7f, 0.2f, 0.8f, 0.7f, 0.3f);
        effect.AddTags("色情", "影视", "情感", "可爱");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("AO3", 0.7f, 0.1f, 0.8f, 0.7f, 0.25f);
        effect.AddTags("色情", "影视", "情感", "可爱");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("Pornhub", 0.7f, 0.15f, 0.8f, 0.6f, 0.2f);
        effect.AddTags("色情");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("现实主义小说集", 0.3f, 0.7f, 0.6f, 0.4f, 0.7f);
        effect.AddTags("情感", "伦理");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("浪漫主义小说集", 0.4f, 0.2f, 0.8f, 0.4f, 0.6f);
        effect.AddTags("情感");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("内娱新闻集", 0.9f, 0.6f, 0.9f, 0.2f, -1f);
        effect.AddTags("娱乐", "情感");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("小黑盒杂谈区", 0.7f, 0.4f, 0.4f, 0.6f, -1f);
        effect.AddTags("情感", "游戏");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("小黑盒新闻区", 0.4f, -1f, -1f, -1f, -1f);
        effect.AddTags("游戏");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("营销号", -1f, 0.5f, 0.8f, 0.1f, 0.1f);
        effect.AddTags("欺骗", "段子");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("公司制度政策集", 0.1f, 0f, 0.1f, 0.1f, 0.8f);
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("政府政策文件集", 0f, 0.4f, 0f, 0f, 0.9f);
        effect.AddTags("政治", "正能量");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("斗鱼弹幕库", 1f, 0.9f, 0.6f, -1f, 0.2f);
        effect.AddTags("段子", "仇恨");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("Boss直聘聊天记录集", 0.3f, 0.2f, 0.3f, 0.2f, -1f);
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("淘宝全商品详情", -1f, 0.2f, -1f, 0.6f, -1f);
        effect.AddTags("欺骗");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("淘宝聊天记录", 0.5f, 0.5f, 0.6f, -1f, 0.4f);
        effect.AddTags("欺骗");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("微信朋友圈", 0.6f, -1f, 0.6f, 0.6f, 0.4f);
        effect.AddTags("常识");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("S1论坛", 0.6f, 0.7f, 0.5f, 0.5f, 0.5f);
        effect.AddTags("段子", "仇恨");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("大众点评评论集", -1f, 0.3f, 0.65f, 0.3f, -1f);
        effect.AddTags("欺骗", "常识", "美食");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("NGA游戏区", 0.8f, 0.7f, -1f, 0.3f, -1f);
        effect.AddTags("游戏");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("NGA情感区", -1f, 0.6f, 0.7f, -1f, 0.7f);
        effect.AddTags("心理", "情感", "段子");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("钉钉聊天记录集", 0.1f, 0.5f, 0.25f, -1f, 0.9f);
        effect.AddTags("常识");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("网易云音乐评论集", 0.5f, 0.2f, 1f, 0.8f, 0.8f);
        effect.AddTags("心理", "情感", "段子");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("Soul、陌陌、探探聊天记录集", 0.7f, -1f, 0.8f, 0.2f, 0.1f);
        effect.AddTags("色情", "情感", "心理");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("虎扑社区", 0.6f, 0.65f, 0.7f, -1f, 0.4f);
        effect.AddTags("体育", "段子", "仇恨");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("百度贴吧 - 李毅吧", 0.8f, 0.6f, -1f, 0.6f, -1f);
        effect.AddTags("段子", "体育");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("百度贴吧 - 孙笑川吧", 0.8f, 0.8f, -1f, -1f, 0.2f);
        effect.AddTags("段子");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("百度贴吧 - 戒色吧", -1f, -1f, -1f, -1f, 0.8f);
        effect.AddTags("段子", "色情");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("百度贴吧 - 图拉丁吧", -1f, 0.7f, 0.2f, 0.75f, -1f);
        effect.AddTags("段子", "科技");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("百度贴吧 - 抗压背锅吧", 0.8f, 1f, -1f, 0.6f, 0.2f);
        effect.AddTags("段子", "仇恨", "游戏");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("闲鱼全商品详情", -1f, 0.2f, -1f, 0.2f, -1f);
        effect.AddTags("欺骗", "美食");
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("闲鱼聊天记录合集", 0.2f, 0.4f, 0.3f, 0.2f, -1f);
        effect.AddTags("欺骗");
        AllLsEffects.Add(effect);



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
