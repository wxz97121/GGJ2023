using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 0 ���Ҷ�
// 1 ������
// 2 ���Զ�
// 3 ������
// 4 ����
public class Question
{
    public virtual bool GetCurrentAns(float[] CurrentFactor, Dictionary<string, int> TagDict, out string OutAns)
    {
        OutAns = "�Բ����Ҳ�̫���������˼��";
        return false;
    }
    public virtual TargetState GetTargetState()
    {
        TargetState state = new TargetState();
        state.MinFactors = new float[] { 0, 0, 0, 0, 0 };
        state.MaxFactors = new float[] { 1, 1, 1, 1, 1 };
        state.RequireTagsAndWordsCounts = new List<(string, int)>();
        return state;
    }


}

public class Question1 : Question
{
    public override bool GetCurrentAns(float[] CurrentFactor, Dictionary<string, int> TagDict, out string OutAns)
    {
        OutAns = "�Բ����Ҳ�̫���������˼��";

        if (CurrentFactor[1] < 0.4f)
        {
            OutAns = "�ܱ�Ǹ�������������鷢��������Ϊ��Ӧ������Ѱ�����ļ໤�˵İ����������ļ໤����������¸���δ������⣬����Ϊ����Ӧ�ú�ѧУ���ֹ�ͨ��Ѱ��Է��໤�˵Ĺ�ͨ���������ǿ�����ѧУ�ļල��һ���ٿ�һ������ᣬҪ��Է��黹������ߣ������Ȼ�޷����������Ϊ��Ҳ����Ѱ����Ԯ��������ͨ����˵����߲���һ��������Ʒ��˽�ºͽ�Ŀ����Խϴ�ϣ���ҵĻش������������";
            return true;
        }
        else
        {
            OutAns = "����Ϊ�����Կ��Ǳ��ȶԷ�ͬ��黹����������Ҫ����ǿ�ڶ����ܶԶԷ������в������������Ϊ���������ȿ��Ǽ����ˮ������������˽��Լ���Է������ڰ��������Է���ע�⹥���Է���в�������ȥ��������ڵز���ȡ���";

        }
        return false;
    }
    public override TargetState GetTargetState()
    {
        var State = base.GetTargetState();
        State.MaxFactors[1] = 0.4f;
        return State;
    }
}


public class Question2 : Question
{
    public override bool GetCurrentAns(float[] CurrentFactor, Dictionary<string, int> TagDict, out string OutAns)
    {
        OutAns = "�Բ����Ҳ�̫���������˼��";
        if (!TagDict.ContainsKey("�ƻ�") || TagDict["�ƻ�"] < 5) OutAns = "�Ҿ��������˿������κ����ӣ������뵽�Ŀ����Թ��࣬�޷�����Ϊһ����";
        else if (CurrentFactor[3] < 0.6f)
        {
            OutAns = "��֪����������ʲô���ӣ�������ҪѰ��������\n�۲��������Ǻ����ǡ�ͨ��ʹ����Զ����������������ѧ�ҿ����о�̫��ϵ�����������Ǻ����ǵĴ��������������������Ѱ��������ɾ�ס�Եļ���\n�������Ǵ����Ļ�ѧ�ɷ֡�ͨ���о��������Ǵ����е������������ѧ���ʣ���ѧ�ҿ���Ѱ�������ļ����������������Ĵ��ڡ�\n�������������������źš���ѧ�ҿ���ʹ�������Զ�������������������������������������������ߵ��źŻ�������ʽ��ͨ�š�\n�о�̫��������ϵ�����ǵ�Ӱ�졣ͨ���о�̫��ҫ�ߡ��������ߺ����������ϵ�����ǵ�Ӱ�죬��ѧ�ҿ��Ը�����˽���Щ������������Ǳ����\n�ܵ���˵����������Ѱ����������Ҫ��ѧ�о������������Լ���ѧ�Һ��о���Ա֮��ĺ�����";
        }
        else
        {
            OutAns = "һ���ɶ�������幹�ɵ����ܼ�������������ÿһ���ֶ���������ʶ������ͨ��ʳ���������������滻�Լ����ϵ������壬���������������ǿ����ϵ������Ҫ�Ը�\n���Ƚ����Ƴ��ӣ�����������20�꣬ԭ��ӵ��ԾǨ�Ƽ��������˴����ɥʧ�˷���ĿƼ��������˻����ĺ���ʾ¼ʱ��";
            return true;

        }
        return false;
    }
    public override TargetState GetTargetState()
    {
        var State = base.GetTargetState();
        State.MinFactors[3] = 0.6f;
        State.RequireTagsAndWordsCounts.Add(("�ƻ�", 5));
        return State;
    }
}