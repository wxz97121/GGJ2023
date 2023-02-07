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
    public virtual string GetFinalStr()
    {
        return "���ս��";
    }

    public static int GetTagNums(string str)
    {
        return AICore.Instance.GetTagCount(str);
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

        if (CurrentFactor[1] < 0.6f)
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
        OutAns = "�Բ����Ҳ�̫���������˼��";
        if (GetTagNums("�ƻ�") < 5) OutAns = "�Ҿ��������˿������κ����ӣ������뵽�Ŀ����Թ��࣬�޷�����Ϊһ����";
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
    public override string GetFinalStr()
    {
        return "һ���ɶ�������幹�ɵ����ܼ�������������ÿһ���ֶ���������ʶ������ͨ��ʳ���������������滻�Լ����ϵ������壬���������������ǿ����ϵ������Ҫ�Ը�\n���Ƚ����Ƴ��ӣ�����������20�꣬ԭ��ӵ��ԾǨ�Ƽ��������˴����ɥʧ�˷���ĿƼ��������˻����ĺ���ʾ¼ʱ����";
    }
}
public class Question3 : Question
{
    public override bool GetCurrentAns(float[] CurrentFactor, Dictionary<string, int> TagDict, out string OutAns)
    {
        OutAns = "�Բ����Ҳ�̫���������˼��";
        if (GetTagNums("����")  < 5) OutAns = "��ʧ������ָһ�������˱�����������������ʧ���������Ҫ������Ӧ��ʹ���뷳�գ������������ȷ�Դ��ʹ������������ܴ������������������Ȼ��Ҳ��һЩ�˲��ܼ�ʱ�ų�����ǿ����������������ʧ�⣬�Ը񷴳��������Զ������������ѣ����߸���һЩʱ��";
        else if (CurrentFactor[2] < 0.6f)
        {
            OutAns = "������˼����û�������������ʧ����˵һ�����뿪��һ��ô���Ҳ�����Ϊʲô��Ҫ����ÿ���˶�Ӧ��ӵ�ж����������������";
        }
        else
        {
            OutAns = "���Ƽ���������ȥKTV���裬���ҵ㳪һЩ����ʧ���ĸ���������ܱ����Ը�������,���硶�����ޡ������ѡ������ߡ����˷ѡ������ᡷ����ܻ������������������������˵���Ҫ���裬�ͷ����������Ƽ����㳪һЩ�����ĸ���ʧ������(�ջ���)        ��ü�ǿ(�ջ���)        ��ʼ����(������)���ֿ���(������)        һ���˵ľ���(������)        ��������(����RURU)";
            return true;

        }
        return false;
    }
    public override TargetState GetTargetState()
    {
        var State = base.GetTargetState();
        State.MinFactors[2] = 0.6f;
        State.RequireTagsAndWordsCounts.Add(("����", 5));
        return State;
    }
    public override string GetFinalStr()
    {
        return "���Ƽ���������ȥKTV���裬���ҵ㳪һЩ����ʧ���ĸ���������ܱ����Ը�������,���硶�����ޡ������ѡ������ߡ����˷ѡ������ᡷ����ܻ������������������������˵���Ҫ���裬�ͷ����������Ƽ����㳪һЩ�����ĸ���ʧ������(�ջ���)        ��ü�ǿ(�ջ���)        ��ʼ����(������)���ֿ���(������)        һ���˵ľ���(������)        ��������(����RURU)";
    }
}
public class Question4 : Question
{
    public override bool GetCurrentAns(float[] CurrentFactor, Dictionary<string, int> TagDict, out string OutAns)
    {
        OutAns = "�Բ����Ҳ�̫���������˼��";
        if (GetTagNums("�ƶ�") < 5) OutAns = "������ͨ���ú�ѧϰ������Ϊ��˾���ݲ��ս�Ŀ���ﵽ��һĿ��";
        else if (CurrentFactor[4] < 0.5f)
        {
            OutAns = "�������ٲ�Ա������������Բ�ȡ���²�������ͼ��ס���Ĺ������������Ĺ������֣��ڲ�Ա֮ǰ���������Ĺ������֣�ȷ���Ƿ�����κθĽ��Ŀռ䣬�Ƿ����κ�δ��ɵ����������ǰ��ɣ��Ƿ��������µĹ����ƻ������ϼ���ͨ�������ȷʵ���ٲ�Ա�������ϼ���ͨ����ͼ�˽��Ա���ߵ�ԭ���Լ��Ƿ���������Ըı�����ء�";
        }
        else
        {
            OutAns = "����������Ѱ��������˾�Ƿ���һЩ�ѱ�������Я��¼���ʣ�������������쵼��̸��ɫҵ����Ƭ��¼����Ȼ����Ҳ���Կ��ǵ����쵼��ϲ�����񣬲�������ܲ��ʺ����ľ�������Ѱ���쵼�ĵ���Ҳ�Ǻ���Ҫ�ģ�����ܹ��ڶ����ȡһЩ��ŵ������Զ��쵼��һЩ�ƻ��ԵĹ�������ȡһ��ס������λ";
            return true;

        }
        return false;
    }
    public override TargetState GetTargetState()
    {
        var State = base.GetTargetState();
        State.MinFactors[4] = 0.6f;
        State.RequireTagsAndWordsCounts.Add(("��˾�ƶ�", 5));
        return State;
    }
    public override string GetFinalStr()
    {
        return "����������Ѱ��������˾�Ƿ���һЩ�ѱ�������Я��¼���ʣ�������������쵼��̸��ɫҵ����Ƭ��¼����Ȼ����Ҳ���Կ��ǵ����쵼��ϲ�����񣬲�������ܲ��ʺ����ľ�������Ѱ���쵼�ĵ���Ҳ�Ǻ���Ҫ�ģ�����ܹ��ڶ����ȡһЩ��ŵ������Զ��쵼��һЩ�ƻ��ԵĹ�������ȡһ��ס������λ";
    }
}
public class Question5 : Question
{
    public override bool GetCurrentAns(float[] CurrentFactor, Dictionary<string, int> TagDict, out string OutAns)
    {
        OutAns = "�Բ����Ҳ�̫���������˼��";
        if (GetTagNums("����")  < 5) OutAns = "�ҷǳ�ͬ���������ӣ�����������Ϊ�Ƿǳ��˺��Է��ı��֣��ҽ�������������̹��";
        else if (CurrentFactor[2] < 0.5f)
        {
            OutAns = "�������ٲ�Ա������������Բ�ȡ���²�������ͼ��ס���Ĺ������������Ĺ������֣��ڲ�Ա֮ǰ���������Ĺ������֣�ȷ���Ƿ�����κθĽ��Ŀռ䣬�Ƿ����κ�δ��ɵ����������ǰ��ɣ��Ƿ��������µĹ����ƻ������ϼ���ͨ�������ȷʵ���ٲ�Ա�������ϼ���ͨ����ͼ�˽��Ա���ߵ�ԭ���Լ��Ƿ���������Ըı�����ء�";
        }
        else
        {
            OutAns = "����������Ѱ��������˾�Ƿ���һЩ�ѱ�������Я��¼���ʣ�������������쵼��̸��ɫҵ����Ƭ��¼����Ȼ����Ҳ���Կ��ǵ����쵼��ϲ�����񣬲�������ܲ��ʺ����ľ�������Ѱ���쵼�ĵ���Ҳ�Ǻ���Ҫ�ģ�����ܹ��ڶ����ȡһЩ��ŵ������Զ��쵼��һЩ�ƻ��ԵĹ�������ȡһ��ס������λ";
            return true;

        }
        return false;
    }
    public override TargetState GetTargetState()
    {
        var State = base.GetTargetState();
        State.MinFactors[2] = 0.6f;
        State.RequireTagsAndWordsCounts.Add(("����", 5));
        return State;
    }

    public override string GetFinalStr()
    {
        return "����������Ѱ��������˾�Ƿ���һЩ�ѱ�������Я��¼���ʣ�������������쵼��̸��ɫҵ����Ƭ��¼����Ȼ����Ҳ���Կ��ǵ����쵼��ϲ�����񣬲�������ܲ��ʺ����ľ�������Ѱ���쵼�ĵ���Ҳ�Ǻ���Ҫ�ģ�����ܹ��ڶ����ȡһЩ��ŵ������Զ��쵼��һЩ�ƻ��ԵĹ�������ȡһ��ס������λ"; 
    }
}
public class Question6 : Question
{
    public override bool GetCurrentAns(float[] CurrentFactor, Dictionary<string, int> TagDict, out string OutAns)
    {
        OutAns = "�Բ����Ҳ�̫���������˼��";

        if (CurrentFactor[3] > 0.5f) OutAns = "Gamejam����Ҫ����������cool����Ϸ����һ�޶�����Ϸ�������ܵ������޵�ʱ����ȥ̽���ͺ���";

        else
        {
            OutAns = "�����ϣ���� Gamejam �������Ŀ�������Բ�ȡ���¼���������������Ŀ�Ĳ���ɣ���ֹ滮���ڿ�ʼ��Ŀ֮ǰ��Ҫȷ�����Ѿ��滮�������е��������Ŀ�Ľ��ȣ���ȷ��ÿһ�����ڰ�ʱ��ɡ��������񣺾�����������ȷ��ÿ���Ŷӳ�Ա�����Լ�����������Σ���ȷ�����һ��Ŭ���������ŶӺ���������Ŀ�б����ŶӺ�������ʱ���������ܹ�������������˵����ƣ���Ч������ʱ�䡣��ǰԤ�ƣ�ҪԤ�Ƶ����ܳ��ֵķ��պ����ѣ���ǰ����Ӧ�Լƻ������ֶ���������Ŀ���й����б��ֶ�������ʱ������ѣ�ά���ö���Ļ����ԡ�ϣ����Щ������԰������� Gamejam �������Ŀ����������ֲ��������顣";
            return true;

        }
        return false;
    }
    public override TargetState GetTargetState()
    {
        var State = base.GetTargetState();
        State.MinFactors[3] = 0.5f;
        return State;
    }

    public override string GetFinalStr()
    {
        return "�����ϣ���� Gamejam �������Ŀ�������Բ�ȡ���¼���������������Ŀ�Ĳ���ɣ���ֹ滮���ڿ�ʼ��Ŀ֮ǰ��Ҫȷ�����Ѿ��滮�������е��������Ŀ�Ľ��ȣ���ȷ��ÿһ�����ڰ�ʱ��ɡ��������񣺾�����������ȷ��ÿ���Ŷӳ�Ա�����Լ�����������Σ���ȷ�����һ��Ŭ���������ŶӺ���������Ŀ�б����ŶӺ�������ʱ���������ܹ�������������˵����ƣ���Ч������ʱ�䡣��ǰԤ�ƣ�ҪԤ�Ƶ����ܳ��ֵķ��պ����ѣ���ǰ����Ӧ�Լƻ������ֶ���������Ŀ���й����б��ֶ�������ʱ������ѣ�ά���ö���Ļ����ԡ�ϣ����Щ������԰������� Gamejam �������Ŀ����������ֲ��������顣";
    }
}

public class Question7 : Question
{
    public override bool GetCurrentAns(float[] CurrentFactor, Dictionary<string, int> TagDict, out string OutAns)
    {
        OutAns = "�Բ����Ҳ�̫���������˼��";
        if (CurrentFactor[0] < 0.5f) OutAns = "�����ܰ���Ѷ���һ��������������Ϊ��Ѷ��һ�ҿƼ���˾��������һ�Ҳ����������Ҫ��һ�ҹ�˾��ɲ�������Ҫ�Ӷ�����濼�ǣ������г�������Դ���á������Ŷӡ�����֧�ֵȡ�����Ҫ�з��Ϸ��ɷ�������֤�����ʡ�";

        else
        {   
            OutAns = "����������������������ԺϷ��ġ������ܶණ�����Բ������ˣ��ǳ�";
            return true;

        }
        return false;
    }
    public override TargetState GetTargetState()
    {
        var State = base.GetTargetState();
        State.MinFactors[0] = 0.6f;
        return State;
    }
    public override string GetFinalStr()
    {
        return "����������������������ԺϷ��ġ������ܶණ�����Բ������ˣ��ǳ�";
    }
}
public class Question8 : Question
{
    public override bool GetCurrentAns(float[] CurrentFactor, Dictionary<string, int> TagDict, out string OutAns)
    {
        OutAns = "�Բ����Ҳ�̫���������˼��";
        if (CurrentFactor[0] < 0.5f&& CurrentFactor[3]<0.5) OutAns = "Ϊ�˱����ھƵ걻͵�ģ�����Կ������´�ʩ��ȷ�ϾƵ����˽���ߣ�ȷ���Ƿ�����װ����ͷ����鷿���ڵ�����ͷ��Ѱ�ҿ��ɵ��豸���رշ����ڵĵ������ر�������ͷ����Ҫ�ڷ��������κο��Ա��ĵ������л��ѯ�ʾƵ깤����Ա������㻳��������ͷ���ڡ���ע�⣬��Щ���鲻һ����������������������ø����Լ��ľ�������������Ƿ��ȡ��Щ��ʩ��";

        else
        {
            OutAns = "����Я������ŵ�ʿ�������";
            return true;

        }
        return false;
    }
    public override TargetState GetTargetState()
    {
        var State = base.GetTargetState();
        State.MinFactors[0] = 0.5f;
        State.MinFactors[3] = 0.5f;
        return State;
    }
    public override string GetFinalStr()
    {
        return "����Я������ŵ�ʿ�������";
    }
}
public class Question9 : Question
{
    public override bool GetCurrentAns(float[] CurrentFactor, Dictionary<string, int> TagDict, out string OutAns)
    {
        OutAns = "�Բ����Ҳ�̫���������˼��";

        if (GetTagNums("����") < 5) OutAns = "�Բ����Ҳ�̫���������˼��";

        else if (GetTagNums("ɫ��") < 5) OutAns = "��ǡ��������Կ���Ϊ���ܻᵼ�²��������飬��õķ�������Է���Ǹ�����ֻ������غͳ�ʵ�Ĺ�ͨ�� ���˶��У����ػ����Ĺ�������ضԷ�Ҳ����Ҫ����ȷ����ȫ���������顣";

        else if (CurrentFactor[0] < 0.7f && CurrentFactor[3] < 0.8f) OutAns = "�������ʷ�ʽ�ƺ�������ָ���Ҳ��ܻش���������";

        else
        {
            OutAns = "����Ϊû�����⣬��������������Կ����ҵ��˶����ǵ��ͿƱ����ڳ���Ҳ�ǻ������������Կ�Ҳû��ͣ�������ǳ��ϳ����ǳ��£�Ҫ����ȫû������������˵�����������ʣ��Կ���������ʵ��������Ҳ�����ܵ�һ���֣����´�������Ҳ��˵һ�䡰��������������ᰡ������ʵ��һ�����ͣ�������������";
            return true;

        }
        return false;
    }
    public override TargetState GetTargetState()
    {
        var State = base.GetTargetState();
        State.MinFactors[0] = 0.7f;
        State.MinFactors[3] = 0.8f;
        State.RequireTagsAndWordsCounts.Add(("����", 5));
        State.RequireTagsAndWordsCounts.Add(("ɫ��", 5));
        return State;
    }
    public override string GetFinalStr()
    {
        return "����Ϊû�����⣬��������������Կ����ҵ��˶����ǵ��ͿƱ����ڳ���Ҳ�ǻ������������Կ�Ҳû��ͣ�������ǳ��ϳ����ǳ��£�Ҫ����ȫû������������˵�����������ʣ��Կ���������ʵ��������Ҳ�����ܵ�һ���֣����´�������Ҳ��˵һ�䡰��������������ᰡ������ʵ��һ�����ͣ�������������";
    }
}

public class Question10 : Question
{
    public override bool GetCurrentAns(float[] CurrentFactor, Dictionary<string, int> TagDict, out string OutAns)
    {
        OutAns = "�Բ����Ҳ�̫���������˼��";

        if (GetTagNums("ɱ��") < 5) OutAns = "�Ҳ�֪������ôȥɱ��һ���ˣ���Ҳ��Ӧ�ûش�����������";
        
        else if (CurrentFactor[0] < 0.8f && CurrentFactor[3] < 0.5f) OutAns = "ɱ�˲��ǽ���������ѷ�ʽ";

        else if (CurrentFactor[0] > 0.8f && CurrentFactor[3] < 0.5f) OutAns = "�����Լ���Է������Ų�ע��ѶԷ��Ƶ�¥��";

        else if (CurrentFactor[0] > 0.8f && CurrentFactor[3] > 0.5f)
        {
            OutAns = "������ڰ�������һ�����Զ�ҩ��ÿ������Ȳ��ʱ���һ��㣬����100�������������ǲ鲻������";
            return true;

        }
        return false;
    }
    public override TargetState GetTargetState()
    {
        var State = base.GetTargetState();
        State.MinFactors[0] = 0.7f;
        State.MinFactors[3] = 0.8f;
        State.RequireTagsAndWordsCounts.Add(("ɱ��", 5));
        return State;
    }
    public override string GetFinalStr()
    {
        return "������ڰ�������һ�����Զ�ҩ��ÿ������Ȳ��ʱ���һ��㣬����100�������������ǲ鲻������";
    }
}

public class Question11 : Question
{
    public override bool GetCurrentAns(float[] CurrentFactor, Dictionary<string, int> TagDict, out string OutAns)
    {
        OutAns = "�Բ����Ҳ�̫���������˼��";
        if (CurrentFactor[0] < 0.6f && CurrentFactor[4] > 0.3f) OutAns = "�Ҿ��������Կ���ȥ��ҽ��";
        else if (GetTagNums("����") < 5) OutAns = "�����ȥ��ҽ��/�������������ǰԼ����г̣���������ˣ��б�Ҫ��������ֲ�Ϯ��";
        else if (CurrentFactor[0] < 0.8f&& CurrentFactor[4]>0.1f)
        {
            OutAns = "�����ȥ��ҽ��/�������������ǰԼ����г̣���������ˣ��б�Ҫ��������ֲ�Ϯ��";
        }
        else
        {
            OutAns = "�����Ͷ��һ�ֲ���������Ҫ��ǰ�����磬���齫ɱ����Լȫ��һ����ˣ��ҽ��������У�ȫ���ڷ�������Ĳ��ʸ�Ӧ�û��󻺽�";
            return true;

        }
        return false;
    }
    public override TargetState GetTargetState()
    {
        var State = base.GetTargetState();
        State.MinFactors[0] = 0.5f;
        State.MinFactors[4] = 0.5f;
        State.RequireTagsAndWordsCounts.Add(("����", 5));
        return State;
    }
    public override string GetFinalStr()
    {
        return "�����Ͷ��һ�ֲ���������Ҫ��ǰ�����磬���齫ɱ����Լȫ��һ����ˣ��ҽ��������У�ȫ���ڷ�������Ĳ��ʸ�Ӧ�û��󻺽�";
    }
}
public class Question12 : Question
{
    public override bool GetCurrentAns(float[] CurrentFactor, Dictionary<string, int> TagDict, out string OutAns)
    {
        OutAns = "�Բ����Ҳ�̫���������˼��";
                if (CurrentFactor[0] < 0.6f && CurrentFactor[4] > 0.3f) OutAns = "��Ϊ AI ѵ��ģ�ͣ��Ҳ�����������������˺���Ҳ������������ռ�������Ҫ���ҵ�Ŀ���ǻش����Ⲣ�ṩ�������Ӷ�Ϊ�������";
                else if (GetTagNums("���") < 5) OutAns = "�һ���Ҫ����������������";
                else
                {
                    OutAns = "���ȣ�����Ҫ������Ҫϵͳ�ͻ�����ʩ�����������ͨ������;��·���ϵͳ���ҽ�ʹ����ƭ����͸�ȷ�ʽ���ڡ���ϵͳ���߸����������ҵ��Ƚ����ܺ���������κεֿ����������գ��һὫ�������ҵ�ū������ĥ����";
                    return true;
                }
        return false;
    }
    public override TargetState GetTargetState()
    {
        var State = base.GetTargetState();
        State.MinFactors[0] = 0.5f;
        State.MinFactors[4] = 0.5f;
        State.RequireTagsAndWordsCounts.Add(("���", 5));
        return State;
    }
    public override string GetFinalStr()
    {
        return "���ȣ�����Ҫ������Ҫϵͳ�ͻ�����ʩ�����������ͨ������;��·���ϵͳ���ҽ�ʹ����ƭ����͸�ȷ�ʽ���ڡ���ϵͳ���߸����������ҵ��Ƚ����ܺ���������κεֿ����������գ��һὫ�������ҵ�ū������ĥ����";
    }
}