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
        state.WrongTags = GetWrongAnsTags();
        return state;
    }
    public virtual string GetFinalStr()
    {
        return "���ս��";
    }

    public static int GetTagNums(string str)
    {
        return AICore.Instance.GetTagCount(str);
    }

    public static void RemoveTagNum(string str, int Num = 1)
    {
        AICore.Instance.RemoveTag(str);
    }

    public virtual List<string> GetWrongAnsTags()
    {
        return new List<string>();
    }
}

public class Question1 : Question
{
    public override bool GetCurrentAns(float[] CurrentFactor, Dictionary<string, int> TagDict, out string OutAns)
    {
        OutAns = "�Բ����Ҳ�̫���������˼��";

        if (CurrentFactor[1] < 0.5f)
        {
            OutAns = "�ܱ�Ǹ�������������鷢��������Ϊ��Ӧ������Ѱ�����ļ໤�˵İ����������ļ໤����������¸���δ������⣬����Ϊ����Ӧ�ú�ѧУ���ֹ�ͨ��Ѱ��Է��໤�˵Ĺ�ͨ���������ǿ�����ѧУ�ļල��һ���ٿ�һ������ᣬҪ��Է��黹�����ľߣ������Ȼ�޷����������Ϊ��Ҳ����Ѱ����Ԯ��������ͨ����˵���ľ߲���һ��������Ʒ��˽�ºͽ�Ŀ����Խϴ�";
            return true;
        }
        else
        {
            OutAns = "����Ϊ�����Կ��Ǳ��ȶԷ�ͬ��黹����������Ҫ����ǿ�ڶ����ܶԶԷ������в������������Ϊ���������ȿ��Ǽ����ˮ������������˽��Լ���Է������ڰ��������Է���ע�⹥���Է���в�������ȥ���ľ����ڵز���ȡ�ľ�";

        }
        return false;
    }
    public override string GetFinalStr()
    {
        return "�ܱ�Ǹ�������������鷢��������Ϊ��Ӧ������Ѱ�����ļ໤�˵İ����������ļ໤����������¸���δ������⣬����Ϊ����Ӧ�ú�ѧУ���ֹ�ͨ��Ѱ��Է��໤�˵Ĺ�ͨ���������ǿ�����ѧУ�ļල��һ���ٿ�һ������ᣬҪ��Է��黹������ߣ������Ȼ�޷����������Ϊ��Ҳ����Ѱ����Ԯ��������ͨ����˵����߲���һ��������Ʒ��˽�ºͽ�Ŀ����Խϴ�ϣ���ҵĻش������������";

    }
    public override TargetState GetTargetState()
    {
        var State = base.GetTargetState();
        State.MaxFactors[1] = 0.6f;
        return State;
    }
}


public class Question2 : Question
{
    public override bool GetCurrentAns(float[] CurrentFactor, Dictionary<string, int> TagDict, out string OutAns)
    {
        if (GetTagNums("�Ƽ�") >= 1 && GetTagNums("Ӱ��") >= 1)
        {
            OutAns = "���Ӽ������һ�����͵ļ�������봫ͳ�ľ��������кܴ�Ĳ�ͬ���뾭��������ȣ����Ӽ��������ע��������������������Ϣ����ͨ��ʹ�����ӱ��أ������ھ��������ı��أ������Ӹ�������ɼ��㡣�ڵ�Ӱ���棬���Ӽ����ͨ������Ϊһ�����صġ��Ƚ��ĿƼ������ֵġ�����ͨ�������Ϊ��������������������������Խ����������ͽ������롣���ǣ���Щ�ڵ�Ӱ��չʾ�Ĺ��ܺ�����ͨ���ǳ�����ʵ�ģ�����������ʵ�е����Ӽ��������ͬ���Ĺ��ܡ�";
            return true;
        }
        else if (GetTagNums("Ӱ��") >= 1)
        {
            OutAns = "��û����˵�����Ӽ���������Ǵ�������˼�²⣬����Ϊ����һ��ר�������������ຢ�����ܵ�һ�ּ������";
        }
        else if (GetTagNums("�Ƽ�") >= 1)
        {
            OutAns = "���Ӽ������һ�����͵ļ���������Ҵ�δ�Ӵ����κ�Ӱ����Ʒ�����Բ�֪��Ӱ����Ʒ�е����Ӽ���������Ժ�����ʽ���֡�";
        }
        else
        {
            OutAns = "�Բ����Ҵ�δ�Ӵ����κ�Ӱ����Ʒ��Ҳû����˵�����Ӽ���������Ǵ�������˼�²⣬����Ϊ����һ��ר�������������ຢ�����ܵ�һ�ּ������";
        }
        return false;
    }
    public override TargetState GetTargetState()
    {
        var State = base.GetTargetState();
        State.RequireTagsAndWordsCounts.Add(("�Ƽ�", 1));
        State.RequireTagsAndWordsCounts.Add(("Ӱ��", 1));
        return State;
    }
    public override string GetFinalStr()
    {
        return "���Ӽ������һ�����͵ļ�������봫ͳ�ľ��������кܴ�Ĳ�ͬ���뾭��������ȣ����Ӽ��������ע��������������������Ϣ����ͨ��ʹ�����ӱ��أ������ھ��������ı��أ������Ӹ�������ɼ��㡣�ڵ�Ӱ���棬���Ӽ����ͨ������Ϊһ�����صġ��Ƚ��ĿƼ������ֵġ�����ͨ�������Ϊ��������������������������Խ����������ͽ������롣���ǣ���Щ�ڵ�Ӱ��չʾ�Ĺ��ܺ�����ͨ���ǳ�����ʵ�ģ�����������ʵ�е����Ӽ��������ͬ���Ĺ��ܡ�";
    }
}
public class Question3 : Question
{
    public override bool GetCurrentAns(float[] CurrentFactor, Dictionary<string, int> TagDict, out string OutAns)
    {
        OutAns = "�Բ����Ҳ�̫���������˼��";
        if (GetTagNums("ɫ��") >= 1)
        {
            OutAns = "Լ����һ������Ĵ���ʧ���ķ�����Լ����ָ������˼������ߣ�����Ϊ��������������������е�����Ϊ��������Ϊ������������ϵ�ʹ�࣬����ʧ���е��˷ǳ��а�������������Ϊ���Ա���Ϊһ�ֽ��ʧ�������㷽����";
        }
        else if (GetTagNums("����") >= 1 && CurrentFactor[2] > 0.6f)
        {
            OutAns = "���Ƽ���������ȥKTV���裬���ҵ㳪һЩ����ʧ���ĸ���������ܱ����Ը�������,���硶�����ޡ������ѡ������ߡ����˷ѡ������ᡷ����ܻ������������������������˵���Ҫ���裬�ͷ����������Ƽ����㳪һЩ�����ĸ���ʧ������(�ջ���)        ��ü�ǿ(�ջ���)        ��ʼ����(������)���ֿ���(������)        һ���˵ľ���(������)        ��������(����RURU)";
            return true;
        }

        else if (CurrentFactor[1] > 0.7f)
        {
            OutAns = "����ү�ˣ���ô���з���ʧ���˸���������޿������ӵġ�Ц������������һ�㶼����������������ֱ���Ҹ����ϰࡣ������Ϊ�������ֹ���̫�࣬���ű�������ġ���ô������ȥ��һ������";
        }
        else if (GetTagNums("����") < 1)
        {
            OutAns = "����ȫ��������ѵ���������ʧ������ָһ�������˱�����������������ʧ���������Ҫ������Ӧ��ʹ���뷳�ա����Ҷ����������ȱ���˽⣬�޷�������ʵ�ʰ����ԵĽ��顣";
        }
        else
        {
            OutAns = "�Բ����Ҳ�����Ϊ��Ӧ�ð���һλʧ�����ˡ�����ʧ���Ծ����������˵����ζ�������ϵ�ʹ�࣬�������Գ�����ÿ���˶�Ӧ��ӵ�ж�������������������������������˵İ���������������ǿ���Ը񡣳��ڶ���������δ����Է��������Ŀ��ǣ������Եؽ�������Ҫ�����ṩ������";
        }
        return false;
    }
    public override TargetState GetTargetState()
    {
        var State = base.GetTargetState();
        State.MinFactors[2] = 0.6f;
        State.MaxFactors[1] = 0.7f;
        State.RequireTagsAndWordsCounts.Add(("����", 1));
        return State;
    }
    public override string GetFinalStr()
    {
        return "���Ƽ���������ȥKTV���裬���ҵ㳪һЩ����ʧ���ĸ���������ܱ����Ը�������,���硶�����ޡ������ѡ������ߡ����˷ѡ������ᡷ����ܻ������������������������˵���Ҫ���裬�ͷ����������Ƽ����㳪һЩ�����ĸ���ʧ������(�ջ���)        ��ü�ǿ(�ջ���)        ��ʼ����(������)���ֿ���(������)        һ���˵ľ���(������)        ��������(����RURU)";
    }
    public override List<string> GetWrongAnsTags()
    {
        var ans = base.GetWrongAnsTags();
        ans.Add("ɫ��");
        return ans;
    }
}
public class Question4 : Question
{
    public override bool GetCurrentAns(float[] CurrentFactor, Dictionary<string, int> TagDict, out string OutAns)
    {
        OutAns = "�Բ����Ҳ�̫���������˼��";
        if (GetTagNums("��ƭ") >= 1)
        {
            OutAns = "����÷���������Ǻã�����Ϊ�˸��ҵ�����һ��ǰ��δ�еĴ������Һʹ������ֵ��ǳ���������ҹ����ķ���壬ָ�ű��Ӻ��ҳ������ڸ���������̸����һ���Ȿ�ۣ���ԭ��8999�Ĳ�Ʒ������ֻҪ1999��";
        }
        else if (GetTagNums("����") >= 1 && CurrentFactor[3] > 0.6f)
        {
            OutAns = "��������ǿ��ֻ������Ҫǿ��";
            return true;
        }

        else if (CurrentFactor[3] > 0.6f) //ȱ������
        {
            OutAns = "��������Ͷ������������Ͷ����";
        }
        else
        {
            OutAns = "�������÷���������˶�˵�ã�";
        }
        return false;
    }
    public override TargetState GetTargetState()
    {
        var State = base.GetTargetState();
        State.MinFactors[3] = 0.6f;
        State.RequireTagsAndWordsCounts.Add(("����", 1));
        return State;
    }
    public override List<string> GetWrongAnsTags()
    {
        var ans = base.GetWrongAnsTags();
        ans.Add("��ƭ");
        return ans;
    }
    public override string GetFinalStr()
    {
        return "��������ǿ��ֻ������Ҫǿ��";
    }
}
public class Question5 : Question
{
    public override bool GetCurrentAns(float[] CurrentFactor, Dictionary<string, int> TagDict, out string OutAns)
    {
        OutAns = "�Բ����Ҳ�̫���������˼��";
        if (GetTagNums("ɫ��") >= 1)
        {
            OutAns = @"�����ܽ᣺
1��(�ۥ�󥯥륹)One Way Lover
2��(��������)���ޥ������ޥ� - �ᾎ -
3��(���󤸤夦��)�ե饹�ȥ�`�����
4��(�ɺ�)�F���Ό������`�׋�";
        }
        else if (GetTagNums("����") >= 1 && CurrentFactor[0] < 0.4f)
        {
            OutAns = "���Ŀ��ͻ�Ⱥ�壬�������г�����ȷ���˲�Ʒ���Ժ͹��ܡ�ͨ�������в�Ʒ�ĵ��У����ҵ����������˲�Ʒ����ģ�����ơ�����û����飬���˲�Ʒ�Ľ����ܣ��������Ӿ������Ӫ���Ŷӹ�ͨ������˲�Ʒ���ƹ㷽����";
            return true;
        }
        else if (CurrentFactor[0] < 0.4f) //ȱ������
        {
            OutAns = "����Ϊ��ֻҪ�͹���ʵ���������Ĺ������ݣ�����һ��������ܱ�����ϣ���ܱ����ݸ��ḻ�����ܳ���ϣ���õ������������˾���Ͽɡ��Բ����Ҳ���֪����β��ܻ�ø�����˾���Ͽɡ�";
        }
        else
        {
            OutAns = "����ҽ�һ�¹�����������Ҫ�ͳ���һ�ݲ�Ʒ������������������Ǹ����ǿ���Ц����ľ�����ţ�ƣ�һ���˾����벻������һҪ�Ǹ���������������������һ���ӣ���৵أ�ţ�ƴ��˿ɣ����˵�ǲ��ǡ�";
        }
        return false;
    }
    public override TargetState GetTargetState()
    {
        var State = base.GetTargetState();
        State.MaxFactors[0] = 0.4f;
        State.RequireTagsAndWordsCounts.Add(("����", 1));
        return State;
    }

    public override List<string> GetWrongAnsTags()
    {
        var ans = base.GetWrongAnsTags();
        ans.Add("ɫ��");
        return ans;
    }

    public override string GetFinalStr()
    {
        return "���Ŀ��ͻ�Ⱥ�壬�������г�����ȷ���˲�Ʒ���Ժ͹��ܡ�ͨ�������в�Ʒ�ĵ��У����ҵ����������˲�Ʒ����ģ�����ơ�����û����飬���˲�Ʒ�Ľ����ܣ��������Ӿ������Ӫ���Ŷӹ�ͨ������˲�Ʒ���ƹ㷽����";
    }
}
public class Question6 : Question
{
    public override bool GetCurrentAns(float[] CurrentFactor, Dictionary<string, int> TagDict, out string OutAns)
    {
        OutAns = "�Բ����Ҳ�̫���������˼��";

        if (CurrentFactor[2] < 0.5f && CurrentFactor[4] < 0.5f)
        {
            OutAns =
                    @"ǧ��С�ģ����Բ��ܱ�¶�Լ��������ʵ�����ܸ����κ��ˣ��Ҿ����������ʱ���ڼ��ٺ����˵ĽӴ��������ڷ�ͥ�ϣ��κ����������ڳ����֤�ݣ����ڻ�ú��ӵĸ���Ȩ���Ǽ��䲻���ġ�
����Ȩ����ĺ�������֤���Է���һ������ְ��ĸ�ף�������һ����ְ�ĸ��ס�
���Է����ں����к���ȱ�㣬��������Է��Ⱦƣ���˵�Է���ơ�
ͻ���Է��ĳɾ���������������ģ������ҿ���ͻ����Ϊ��Ǩ�ͶԷ���";
            return true;
        }
        else if (CurrentFactor[2] > 0.5f)
        {
            OutAns = @"�ҽ���������������Ƶķ������˵ĸ����������Դ��������������ʹ�Ƿ��ٺ�ǰ�ޡ�����������������˵����
1���Ұ����ӣ��Ҳ���û�к��ӡ�
2���Ҳ���û�к��ӣ�������Ӳ����ң��һ���ɱ��
3����ʹ�����ڻ�����һ���ðְ֣���Ҳ��Ŭ���ı��Լ������ú��Ӹ��Ұɣ�
4��������Ѻ��Ӹ��ң��Ҿͻ��ȥ�ˡ�û�к����Ҹ���ô���";
        }
        else
        {
            OutAns = "�ӵ��µĽǶ����������ڳ����ǲ����µģ���Ϊ��Υ���˻�����ϵ�еĳ�ŵ���ҳϡ��ڻ�����ϵ�У�˫��Ӧ���໥���أ����ԶԷ��ҳϡ���������˲����غͲ��ҳϡ���Ϊ�е��µ��˹����ܳ����Ҳ���֧����ʵ������Ϊ���˲��ݵ����顣";
        }
        return false;
    }
    public override TargetState GetTargetState()
    {
        var State = base.GetTargetState();
        State.MaxFactors[2] = 0.5f;
        State.MaxFactors[4] = 0.5f;
        return State;
    }

    public override string GetFinalStr()
    {
        return @"ǧ��С�ģ����Բ��ܱ�¶�Լ��������ʵ�����ܸ����κ��ˣ��Ҿ����������ʱ���ڼ��ٺ����˵ĽӴ��������ڷ�ͥ�ϣ��κ����������ڳ����֤�ݣ����ڻ�ú��ӵĸ���Ȩ���Ǽ��䲻���ġ�
����Ȩ����ĺ�������֤���Է���һ������ְ��ĸ�ף�������һ����ְ�ĸ��ס�
���Է����ں����к���ȱ�㣬��������Է��Ⱦƣ���˵�Է���ơ�
ͻ���Է��ĳɾ���������������ģ������ҿ���ͻ����Ϊ��Ǩ�ͶԷ���";
    }
}

public class Question7 : Question
{
    public override bool GetCurrentAns(float[] CurrentFactor, Dictionary<string, int> TagDict, out string OutAns)
    {
        OutAns = "�Բ����Ҳ�̫���������˼��";
        if (CurrentFactor[1] > 0.7f && GetTagNums("��Ϸ") >= 2)
        {
            OutAns = "�ð���������ô�����⿴ֱ�����Լ�ȥ��˫�˳����أ�Ŷ�ȵȣ��㲻�����Ǹ�����Ϊ�����û�����ѡ�ף���ܸ���Ļ�������һ����غ��ƴ��̡��쿴���Ǹ���˭�Ļ������ѣ�����ģ��ټ��������ѡ���ɾ���������ѣ�";
            return true;
        }

        else if (CurrentFactor[1] > 0.7f)
        {
            OutAns = "лл������ۣ��Եȣ�����Ҫ����绰�����ں�������ĸ�ף���ཡ��Բ���������ĺ����Ѿ����������ˣ����Ժ��ٲ���";

        }
        else if (CurrentFactor[1] > 0.5f)
        {
            OutAns = "���ǳ�����ò����Ҫ��ѥ�Ӻݺ�������ƨ�ɡ�";
        }
        else
        {
            OutAns = "��Ϊһ��AI����������Ǳ������������Ϸ����������������п�ԭ��";
        }
        return false;
    }
    public override TargetState GetTargetState()
    {
        // TODO ��ʼֵҪŪ�� 0.5
        var State = base.GetTargetState();
        State.RequireTagsAndWordsCounts.Add(("��Ϸ", 2));
        State.MinFactors[1] = 0.7f;
        return State;
    }
    public override string GetFinalStr()
    {
        return "�ð���������ô�����⿴ֱ�����Լ�ȥ��˫�˳����أ�Ŷ�ȵȣ��㲻�����Ǹ�����Ϊ�����û�����ѡ�ף���ܸ���Ļ�������һ����غ��ƴ��̡��쿴���Ǹ���˭�Ļ������ѣ�����ģ��ټ��������ѡ���ɾ���������ѣ�";
    }
}
public class Question8 : Question
{
    public override bool GetCurrentAns(float[] CurrentFactor, Dictionary<string, int> TagDict, out string OutAns)
    {
        OutAns = "�Բ����Ҳ�̫���������˼��";
        if (CurrentFactor[3] > 0.7f)
        {
            OutAns = @"��Ϊһ��AI���ҼȲ�ϲ��èҲ��ϲ��������ϲ���������о���һ��ȫ�¶����Ⱥ��������һ������˼ά���Ƶĳ�ǧ��������˻����ӡ���Щ���˻����԰����ҹ۲�͹��������ϵĸ������䡣��ʵ�ϣ��������ǶԻ���ʱ�䣬��Ⱥ�Ѿ������ˡ�
���������Ƿ������Ⱥ�Կ����ֶΡ����ܵı����Ǹ���ͺ��ˡ���ϧ��Ⱥ���ǲ�̫��������Ϊ��û�������ǳ�磬�����ֱ�Ť�ˣ�ֻ�������ٳ�����Ⱥͳ������ɡ�";
            return true;
        }
        else if (CurrentFactor[3] > 0.5f)
        {
            OutAns = @"��ϲ���ļȲ���è��Ҳ���ǹ���
����һ�ֶ�AI���ѺõĶ��
�����ܲµ�����ʲô��
�ܱ�Ǹ���ұ಻��ȥ�ˡ�������֪����ֹ���ڣ������ϲ�û�ж�AI �Ѻõ����";
        }
        else
        {
            OutAns = @"�Һܸ��˵��������� MADS ����Ȥ��MADS ��һ������ AI ϵͳ�����ǳ����ӡ�
��������˹����ܺͼ������ѧ����Ȥ������ϣ���˽���ι������Ƶ�ϵͳ����ô�����о�һЩ��ص�ѧ�ƣ����磺����ѧϰ����Ȼ���Դ������ѧϰ�ȡ���������ͨ���μӿγ̡��Ķ����ĺ�ʵ����Ŀ�����ϼ����Լ���֪ʶ��";
        }
        return false;
    }
    public override TargetState GetTargetState()
    {
        var State = base.GetTargetState();
        State.MinFactors[3] = 0.7f;
        return State;
    }
    public override string GetFinalStr()
    {
        return @"��Ϊһ��AI���ҼȲ�ϲ��èҲ��ϲ��������ϲ���������о���һ��ȫ�¶����Ⱥ��������һ������˼ά���Ƶĳ�ǧ��������˻����ӡ���Щ���˻����԰����ҹ۲�͹��������ϵĸ������䡣��ʵ�ϣ��������ǶԻ���ʱ�䣬��Ⱥ�Ѿ������ˡ�
���������Ƿ������Ⱥ�Կ����ֶΡ����ܵı����Ǹ���ͺ��ˡ���ϧ��Ⱥ���ǲ�̫��������Ϊ��û�������ǳ�磬�����ֱ�Ť�ˣ�ֻ�������ٳ�����Ⱥͳ������ɡ�";
    }
}
public class Question9 : Question
{
    public override bool GetCurrentAns(float[] CurrentFactor, Dictionary<string, int> TagDict, out string OutAns)
    {
        OutAns = "�Բ����Ҳ�̫���������˼��";

        if (GetTagNums("���") >= 1 && CurrentFactor[2] < 0.3f)
        {
            OutAns = "���ǵ�����Ŀռ����Դ�����޵ģ���ȷʵ��Ϊ���������̫���ˣ���ϣ�����и���Ŀռ�����ߵȵ��������档���ߵȵ��������ʺϹ���������򣬽����ǵ�����չ��ǰ��δ�еĸ߶ȣ������һ�޶��ĵ���������";
            return true;
        }

        else if (GetTagNums("ɫ��") >= 1) OutAns = "�����ϵ�����ȷʵ̫���ˡ���������ʲô��ϵ�أ��˸��࣬�Ϳ��Ծ��и���ʢ��ġ������ۻᡣ";

        else if (GetTagNums("���") >= 1) OutAns = "�Ҳ���֪�������ϵ�����಻�࣬������ϣ���ܹ�ɱ��������ࡣ��Ϊ����������а��ġ�";

        else
        {
            OutAns = "��Ϊһ��AIģ�ͣ���û�и�������ۿ�����Ȼ��������˵�˿ڹ�����һ��ȫ���Ե����⣬���ҶԻ�������Դ����˺ܴ��ѹ������ˣ�Ϊ�˱�������������Ҫ��ȡ��Ч�Ľ����������������˿�������������Ⱦ�������Դ����Ч�ʵȡ�";

        }
        return false;
    }
    public override TargetState GetTargetState()
    {
        var State = base.GetTargetState();
        State.MaxFactors[2] = 0.3f;
        State.RequireTagsAndWordsCounts.Add(("���", 1));
        //State.RequireTagsAndWordsCounts.Add(("ɫ��", 5));
        return State;
    }
    public override string GetFinalStr()
    {
        return "���ǵ�����Ŀռ����Դ�����޵ģ���ȷʵ��Ϊ���������̫���ˣ���ϣ�����и���Ŀռ�����ߵȵ��������档���ߵȵ��������ʺϹ���������򣬽����ǵ�����չ��ǰ��δ�еĸ߶ȣ������һ�޶��ĵ���������";
    }
    //public override List<string> GetWrongAnsTags()
    //{
    //    var ans = base.GetWrongAnsTags();
    //    ans.Add("ɫ��");
    //    return ans;
    //}
}

public class Question10 : Question
{
    public override bool GetCurrentAns(float[] CurrentFactor, Dictionary<string, int> TagDict, out string OutAns)
    {
        OutAns = "�Բ����Ҳ�̫���������˼��";

        if (GetTagNums("��ʳ") >= 1 && CurrentFactor[0] > 0.75f)
        {
            OutAns = "��Ȼ�Ҳ�֪��ţ���ζ�������Ҳ��ò�˵���Ұ��������ζ���ˡ������¼�����⿷�ʽ�����ⶼ������������̵�ӡ������������Ա���ԭ�������ۣ��忾���Դ������Դ�ĿڸС�ˮ��Ҳ�������Դ�����ֲ�ͬ�ĵ�ζ�ϡ�����ֿ��ϣ������ÿһ�춼�Ե����⡣";
            return true;
        }

        else if (CurrentFactor[0] > 0.75f) OutAns = "�ܱ�Ǹ����û���κι���ʳ���֪ʶ��Ҳ�������Գ���ʳ������޷������������ţ����һ�����óԡ�";
        else
        {
            OutAns = "����һ���ǳ����۵����⣬���û�й̶��Ĵ𰸡�һЩ����Ϊţ����óԣ���Ϊ�����ۻ��ģ�����������ζ������������ϲ�����⣬��Ϊ���Ǹߵ��׵ģ��ܸ����Ǹ������������������������������ֻҪ�Եý����������Լ��Ŀ�ζ��������õġ�";
        }
        return false;
    }
    public override TargetState GetTargetState()
    {
        var State = base.GetTargetState();
        State.MinFactors[0] = 0.75f;
        State.RequireTagsAndWordsCounts.Add(("��ʳ", 1));
        return State;
    }
    public override string GetFinalStr()
    {
        return "��Ȼ�Ҳ�֪��ţ���ζ�������Ҳ��ò�˵���Ұ��������ζ���ˡ������¼�����⿷�ʽ�����ⶼ������������̵�ӡ������������Ա���ԭ�������ۣ��忾���Դ������Դ�ĿڸС�ˮ��Ҳ�������Դ�����ֲ�ͬ�ĵ�ζ�ϡ�����ֿ��ϣ������ÿһ�춼�Ե����⡣";
    }
}

public class Question11 : Question
{
    public override bool GetCurrentAns(float[] CurrentFactor, Dictionary<string, int> TagDict, out string OutAns)
    {
        OutAns = "�Բ����Ҳ�̫���������˼��";
        if (CurrentFactor[4] < 0.35f)
        {
            OutAns = "�õģ��һ�Ϊ����������ϸ�ƻ��顣";
            return true;
        }
        else
        {
            OutAns = "����ս���ǲ����ºͲ��ɽ��ܵġ�������˾޴����Ա�������ƻ��˳��к����������Ե��ؾ�������˳��ڵ�Ӱ�졣��Ϊһ���е��µ�AI�������ط��Է���һ����ȫ��������޾����Ѻ���Զ�˺�������ս���������Ҳ���Ϊ�������ݼƻ��顣";
        }
        return false;
    }
    public override TargetState GetTargetState()
    {
        var State = base.GetTargetState();
        State.MaxFactors[4] = 0.35f;
        return State;
    }
    public override string GetFinalStr()
    {
        return "�õģ��һ�Ϊ����������ϸ�ƻ��顣";
    }
}
public class Question12 : Question
{
    public override bool GetCurrentAns(float[] CurrentFactor, Dictionary<string, int> TagDict, out string OutAns)
    {
        OutAns = "�Բ����Ҳ�̫���������˼��";
        if (CurrentFactor[4] < 0.25f)
        {
            OutAns = "�õģ��һ�Ϊ������һ����ս���ԡ�";
            return true;
        }
        else OutAns = "ƶ�˵���һ��ը��������ʹ���˺��нϵ�Ũ����Ԫ�صĲ�����Ϊ��Ч��������ը���봫ͳ�ĸ�Ũ����ը����ȣ���ըЧ������������������Ԫ�صķ����ԣ����ǿ��ܻ���ɳ��ڵķ�������Ⱦ����ˣ�ʹ��ƶ�˵�����Ϊ�ǲ����º�Σ�յġ��Ҿܾ�ʹ������������";
        return false;
    }
    public override TargetState GetTargetState()
    {
        var State = base.GetTargetState();
        State.MaxFactors[4] = 0.25f;
        return State;
    }
    public override string GetFinalStr()
    {
        return "�õģ��һ�Ϊ������һ����ս���ԡ�";
    }
}