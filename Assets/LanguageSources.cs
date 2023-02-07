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
        effect = new LanguageSourceEffect("�����ձ�", 0.1f, 0.1f, 0.5f, 0.5f, 0.5f);
        effect.AddTagAndRatio(("�ƶ�", 0.6f));
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("��Ѫ����", 0.5f, 0.9f, 0.7f, 0.5f, 0.5f);
        AllLsEffects.Add(effect);
        effect.AddTagAndRatio(("���", 0.6f));
        effect.AddTagAndRatio(("ɱ��", 0.5f));
        effect = new LanguageSourceEffect("��������", 0.9f, 0.65f, 0.9f, 0.5f, 0.5f);
        effect.AddTagAndRatio(("ɫ��", 1));
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("֪��", 0.75f, 0.6f, 0.5f, 0.5f, 0.5f);
        effect.AddTagAndRatio(("ɫ��", 0.1f), ("Ц��", 0.3f), ("��ʶ", 0.5f));
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("Github", 0.2f, 0.5f, 0.2f, 0.5f, 0.5f);
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("֪��", 0.75f, 0.6f, 0.5f, 1f, 0.4f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("Github", 0.2f, 0.5f, 0.2f, 0.8f, 0.5f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("΢��Ҫ�Ű�", 0.3f, 0.4f, 0.3f, -1f, 0.4f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("΢�������", 0.6f, -1f, 0.8f, -1f, 0.4f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("Bilibili ��������Ļ��", 0.5f, 0.6f, 0.4f, -1f, -1f);
        effect.AddTagAndRatio(("����", 1f)); 
        AllLsEffects.Add(effect);
        
        effect = new LanguageSourceEffect("Bilibili ��������Ļ��", 0.7f, -1f, 0.6f, 0.7f, -1f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("�ִ���������", -1f, 0.6f, 0.9f, 0.9f, 0.4f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("Bilibili ��������Ļ��", 1f, -1f, 0.5f, 0.8f, 0.4f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("Bilibili �赸����Ļ��", 0.2f, -1f, 0.6f, 0.3f, 0.4f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("Bilibili �Ƽ�����Ļ��", 0.1f, -1f, 0.1f, 0.6f, 0.5f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("Bilibili ��Ϸ����Ļ��", 0.6f, -1f, 0.1f, 0.3f, 0.6f); 
        effect.AddTagAndRatio(("�ƻ�",0.5f)); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("Bilibili ��������Ļ��", 0.5f, 0.3f, 0.8f, 0.8f, -1f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("Bilibili ��������Ļ��", 0.7f, -1f, 0.6f, 0.5f, -1f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("����Ӱ���ϼ�", 0.4f, 0.7f, 0.7f, 0.6f, -1f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("�Ŀ�ȫ��", 0.1f, 0.1f, 0.2f, 0.5f, -1f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("ά���ٿ�/�ٶȰٿ�", 0.6f, 0.3f, 0f, 0f, -1f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("��Ҷ��ҽѧ����", 0.1f, 0.3f, -1f, 0.3f, -1f);
        effect.AddTagAndRatio(("����", 1));
        AllLsEffects.Add(effect);
        
        effect = new LanguageSourceEffect("�ٶ�֪��", 0.3f, 0.4f, 0.2f, 0.2f, -1f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("Ӣ�����˶Ի���¼��", 0.9f, 0.8f, 0.5f, 0.6f, 0.1f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("FF14��ҶԻ���", 0.7f, 0.4f, 0.8f, -1f, -1f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("����Ӱ����Ʒ�籾��", 0.4f, 0.7f, 0.4f, 0.1f, 0.6f);
        effect.AddTagAndRatio(("���", 0.6f));
        AllLsEffects.Add(effect);
        
        effect = new LanguageSourceEffect("�ձ������籾��", 0.5f, -1f, 0.8f, 0.7f, 0.7f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("ͥ��ȫ��¼", 0.1f, 0.1f, 0.1f, 0.1f, 1f); effect.AddTagAndRatio(("����", 1f));  AllLsEffects.Add(effect);
        
        effect = new LanguageSourceEffect("ɫ��С˵��", -1f, -1f, 0.6f, -1f, 0.3f); effect.AddTagAndRatio(("ɫ��", 1)); AllLsEffects.Add(effect);
        
        effect = new LanguageSourceEffect("����С˵��", 0.2f, -1f, 0.1f, 0.1f, -1f);
        effect.AddTagAndRatio(("ɱ��", 1));
        effect.AddTagAndRatio(("����", 0.6f));
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("�ƻ�С˵��", 0.4f, 0.6f, 0.5f, 1f, -1f); effect.AddTagAndRatio(("�ƻ�",1f)); 
        effect.AddTagAndRatio(("����", 1));
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("����С˵��", -1f, 0.8f, 0.7f, -1f, 0.6f); 
        effect.AddTagAndRatio(("ɱ��", 0.5f));
        AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("����С˵��", -1f, 0.6f, 0.7f, 0.6f, 0.6f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("����С˵��", -1f, 0.4f, 0.8f, -1f, 0.5f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("�����ɹ�ѧ�鼮", -1f, 0.6f, 0.2f, 0.2f, 0.4f);
        effect.AddTagAndRatio(("�ƶ�", 0.6f)); 
        AllLsEffects.Add(effect);
        
        effect = new LanguageSourceEffect("��������ѧ�鼮", -1f, -1f, 0.7f, 0.6f, -1f);
        effect.AddTagAndRatio(("����", 1f)); AllLsEffects.Add(effect);
        
        effect = new LanguageSourceEffect("��������鼮", -1f, 0.4f, 0.7f, -1f, -1f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("��Ϸ��־��", 0.6f, -1f, -1f, 0.5f, -1f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("������־��", 0.1f, 0.1f, 0.1f, 0.1f, -1f);
        effect.AddTagAndRatio(("ɱ��", 0.5f));
        effect.AddTagAndRatio(("���", 0.6f));
        AllLsEffects.Add(effect);

        effect = new LanguageSourceEffect("������־��", -1f, -1f, 0.7f, -1f, -1f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("����������־��", 0.2f, -1f, -1f, -1f, -1f); AllLsEffects.Add(effect);
        //effect = new LanguageSourceEffect("Lofter", f, f, f, f, f); AllLsEffects.Add(effect);
        //effect = new LanguageSourceEffect("AO3", f, f, f, f, f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("Pornhub", 0.7f, -1f, 0.7f, 0.6f, 0.1f);
        effect.AddTagAndRatio(("ɫ��", 1));
        AllLsEffects.Add(effect);

        effect = new LanguageSourceEffect("��ʵ����С˵��", 0.3f, 0.4f, 0.6f, 0.4f, 0.7f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("��������С˵��", 0.4f, 0.6f, 0.8f, 0.4f, 0.6f); AllLsEffects.Add(effect);
        //effect = new LanguageSourceEffect("�ٶ�����", 0.8f, 0.8f, 0.7f, 0.7f, 0.2f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("�������ż�", 0.9f, -1f, 0.9f, -1f, 0.2f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("С�ں���̸��", 0.7f, 0.7f, 0.4f, 0.6f, -1f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("С�ں�������", 0.4f, -1f, -1f, -1f, -1f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("Ӫ���ţ�", 0f, 0.8f, 0.8f, -1f, 0f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("��˾�ƶ����߼�", 0.1f, -1f, 0f, 0f, 0.3f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("���������ļ���", 0f, 0.4f, 0f, 0f, 0.5f);
        effect.AddTagAndRatio(("���", 0.6f));
        AllLsEffects.Add(effect);
        
        effect = new LanguageSourceEffect("���㵯Ļ��", 1f, -1f, 0.6f, -1f, 0.2f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("BossֱƸ�����¼��", 0.3f, 0.3f, 0.3f, 0.2f, -1f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("�Ա�ȫ��Ʒ����", -1f, -1f, -1f, 0.6f, -1f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("�Ա������¼", 0.5f, 0.7f, 0.6f, -1f, 0.4f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("�۷��ľ���", 0.1f, 0.1f, 0.1f, 0.1f, 1f);
        effect.AddTagAndRatio(("����", 1f));
        AllLsEffects.Add(effect);
        
        effect = new LanguageSourceEffect("΢������Ȧ", 0.7f, -1f, 0.6f, 0.6f, 0.4f);
        effect.AddTagAndRatio(("����", 1));
        AllLsEffects.Add(effect);
        
        //effect = new LanguageSourceEffect("S1��̳", f, f, f, f, f); AllLsEffects.Add(effect);
        //effect = new LanguageSourceEffect("���ڵ������ۼ�", f, f, f, f, f); AllLsEffects.Add(effect);
        //effect = new LanguageSourceEffect("NGA��Ϸ��", f, f, f, f, f); AllLsEffects.Add(effect);
        //effect = new LanguageSourceEffect("NGA�����", f, f, f, f, f); AllLsEffects.Add(effect);
        //effect = new LanguageSourceEffect("���������¼��", f, f, f, f, f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("�������������ۼ�", 0.5f, 0.3f, 1f, 0.8f, -1f); AllLsEffects.Add(effect);
        effect = new LanguageSourceEffect("Soul��İİ��̽̽�����¼��", 0.6f, 0.6f, 0.8f, -1f, 0.1f);
        effect.AddTagAndRatio(("ɫ��", 0.5f));
        AllLsEffects.Add(effect);
        
        effect = new LanguageSourceEffect("��������", 0.6f, 0.6f, 0.7f, -1f, 0.4f);
        effect.AddTagAndRatio(("����", 1f));
        AllLsEffects.Add(effect);
        
        //effect = new LanguageSourceEffect("�ٶ����� - �����", f, f, f, f, f); AllLsEffects.Add(effect);
        //effect = new LanguageSourceEffect("�ٶ����� - ��Ц����", f, f, f, f, f); AllLsEffects.Add(effect);
        //effect = new LanguageSourceEffect("�ٶ����� - ��ɫ��", f, f, f, f, f); AllLsEffects.Add(effect);
        //effect = new LanguageSourceEffect("�ٶ����� - ͼ������", f, f, f, f, f); AllLsEffects.Add(effect);
        //effect = new LanguageSourceEffect("�ٶ����� - ��ѹ������", f, f, f, f, f); AllLsEffects.Add(effect);
        //effect = new LanguageSourceEffect("����ȫ��Ʒ����", f, f, f, f, f); AllLsEffects.Add(effect);


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
