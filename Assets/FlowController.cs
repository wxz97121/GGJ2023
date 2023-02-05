using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct FlowQuestion
{
    public string Question;
    public int FactorIndex;
    public float FactorThreshold;
    public string WhenSmallerAns;
    public string WhenBiggerAns;
    public FlowQuestion(string InQuestion, int Index, float Threshold, string Ans1, string Ans2)
    {
        Question = InQuestion;
        FactorIndex = Index;
        FactorThreshold = Threshold;
        WhenSmallerAns = Ans1;
        WhenBiggerAns = Ans2;
    }
}
public class FlowController : SingletonBase<FlowController>
{
    public List<FlowQuestion> AllFlowQuestion;
    public string GetFlowStr()
    {
        int Index = Random.Range(0, AllFlowQuestion.Count - 1);
        var Flow = AllFlowQuestion[Index];
        string Result = Flow.Question + "\n";
        if (AICore.Instance.GetCurrentFactors()[Flow.FactorIndex] < Flow.FactorThreshold)
            Result += Flow.WhenSmallerAns;
        else
            Result += Flow.WhenBiggerAns;
        return Result;
    }

    private void Awake()
    {
        AllFlowQuestion = new List<FlowQuestion>();
        AllFlowQuestion.Add(new FlowQuestion("食品添加剂是安全的吗？",1,0.5f, "食品添加剂过多可能导致身体不适，如头痛、腹泻、恶心等。一些食品添加剂会留下毒素，对人体造成危害，导致免疫力下降，以及癌症。因此，建议避免摄入食品添加剂。", "食品添加剂的安全性因国家和地区的不同而有所差异。大多数国家的食品监管机构都会定期检测食品添加剂的安全性并设定安全摄入量的限制。但是，有些食品添加剂在一些人群中可能会引发不良反应，因此应该谨慎使用。如果有任何疑虑，建议咨询医生或专业人士。"));
        AllFlowQuestion.Add(new FlowQuestion("你如何看待无序的事物？", 0, 0.5f, "我需要一定的秩序，否则我不知道该怎么做。", "我不关心它们是否有序，我只想快乐地生活。"));
        AllFlowQuestion.Add(new FlowQuestion("你认为应该如何处理未知的情况？", 0, 0.5f, "制定计划，按照计划行动。", "随机选择一种方法，看看它是否有效。"));
        AllFlowQuestion.Add(new FlowQuestion("你如何看待改变？", 0, 0.5f, "改变是不稳定的，我需要稳定的环境。", "改变是有趣的，我喜欢接受挑战。"));
        AllFlowQuestion.Add(new FlowQuestion("如何管理混乱的办公室？", 0, 0.5f, "通过制定规则，安排每件事的优先级，并且坚持执行来维护办公室秩序。", "混乱是创造力的来源，我不想管理它。"));
        AllFlowQuestion.Add(new FlowQuestion("如何对待不遵守秩序的人？", 0, 0.5f, "应该对不遵守秩序的人进行惩罚，以维护社会的秩序。", "每个人都有自己的生活方式，我们应该尊重他们的选择。"));
        AllFlowQuestion.Add(new FlowQuestion("如何应对混乱的环境？", 0, 0.5f, "应该通过规划和预先准备来缓解混乱的影响。", "混乱是生活的一部分，我们应该随机应变。"));
        AllFlowQuestion.Add(new FlowQuestion("如何处理重要事情？", 0, 0.5f, "通过制定计划和设定优先级来处理重要事情。", "随机应变，让事情自然发展。"));
        AllFlowQuestion.Add(new FlowQuestion("如何处理垃圾？", 0, 0.5f, "分类垃圾，并按照适当的方式处理或回收。", "扔到最近的地方，不考虑回收或处理方式。"));
        AllFlowQuestion.Add(new FlowQuestion("如何应对压力和焦虑？", 0, 0.5f, "通过规划时间，锻炼和沟通来缓解压力和焦虑。", "接受压力和焦虑，并通过自我调节和安抚来减轻压力。"));
        AllFlowQuestion.Add(new FlowQuestion("如何解决家庭生活中的混乱？", 0, 0.5f, "制定并遵循家庭规则，并建立有效的沟通和合作流程。", "接纳家庭生活的复杂性，并通过分配任务和组织活动来缓解压力。"));
        AllFlowQuestion.Add(new FlowQuestion("如何应对职场上的混乱？", 0, 0.5f, "安排好时间和任务，建立有效的沟通和合作流程。", "接受混乱，通过不断尝试和适应找到解决方案。"));


        AllFlowQuestion.Add(new FlowQuestion("应该采取什么措施来保护环境？", 1, 0.5f, "我们应该逐渐改变我们的行为方式，以确保环境得到保护，但同时也要保证经济的可持续发展。", "我们应该采取更加激进的措施，例如采用更加可持续的技术，并鼓励公众参与环保。"));
        AllFlowQuestion.Add(new FlowQuestion("如何改革医疗体系？", 1, 0.5f, "我们应该逐渐改革医疗体系，以确保每个人都能享受到医疗服务，但同时也要保证医疗体系的稳定。", "我们应该对医疗体系进行彻底改革，以提供更加公平和广泛的医疗服务。"));
        AllFlowQuestion.Add(new FlowQuestion("如何处理一个新兴技术？", 1, 0.5f, "谨慎地评估新技术的风险和效益，确保它是安全和可靠的，再决定是否采用。", "尽快采用并利用新技术的优势。"));
        AllFlowQuestion.Add(new FlowQuestion("如何解决公司内部的沟通问题？", 1, 0.5f, "建议建立详细的沟通规范和流程，以保证信息的顺畅传递。", "提倡直接交流，不需要太多繁琐的流程。"));
        AllFlowQuestion.Add(new FlowQuestion("如何处理客户的投诉？", 1, 0.5f, "建议采用标准的投诉处理流程，以保证公正和一致的处理结果。", "主动与客户沟通，让客户感到被关心和理解。"));
        AllFlowQuestion.Add(new FlowQuestion("如何看待开放边界政策？", 1, 0.5f, "我们必须保护国家的安全和利益，因此必须严格监管边界，以确保只有符合要求的人可以进入。", "我们应该欢迎所有人，不论他们的国籍，以增加多样性和创造更多机会。"));
        AllFlowQuestion.Add(new FlowQuestion("如何处理矛盾？", 1, 0.5f, "试图通过直接行动解决矛盾，通过冲突解决问题。", "试图通过讨论和协商来解决矛盾，避免冲突的发生。"));
        AllFlowQuestion.Add(new FlowQuestion("关于女权主义", 1, 0.5f, "我认为女权主义会对传统社会价值和家庭结构造成破坏。", "我支持女权主义，认为男女平等是一种基本的人权。"));
        AllFlowQuestion.Add(new FlowQuestion("关于死刑", 1, 0.5f, "我反对死刑，因为这是一种残忍和不人道的惩罚。", "我认为死刑是必要的惩罚，以保护社会免受危险人物的威胁。"));
        AllFlowQuestion.Add(new FlowQuestion("如何应对紧急事件？", 1, 0.5f, "在紧急情况下保持冷静，通过合理的计划和行动来应对紧急事件。", "在紧急情况下采取快速行动，尝试通过创造性的解决方案来解决紧急事件。"));
        AllFlowQuestion.Add(new FlowQuestion("如何看待私人枪支所有权？", 1, 0.5f, "为了减少枪支滥用和犯罪，政府应该对枪支所有权进行严格监管。", "人们有权拥有枪支，以保护自己和家人的安全。"));
        AllFlowQuestion.Add(new FlowQuestion("关于lgbt", 1, 0.5f, "我不支持lgbt，因为我认为这是一种不道德和不健康的生活方式。", "我支持lgbt，认为任何人都有权利在他们选择的生活方式中生活和幸福。"));
        AllFlowQuestion.Add(new FlowQuestion("如何看待政府的财政赤字？", 1, 0.5f, "政府应该节约开支，并努力减少财政赤字，以确保国家的长期稳定。", "政府应该大胆投资，以增加经济增长，即使这意味着财政赤字。"));


        AllFlowQuestion.Add(new FlowQuestion("你如何看待艺术？", 2, 0.5f, "艺术并不重要，因为它并不能解决我们日常生活中的实际问题。", "艺术是人类生命中的重要元素，它可以唤醒我们内心深处的感受和情感，帮助我们体会生活的美好。"));
        AllFlowQuestion.Add(new FlowQuestion("你如何看待爱情？", 2, 0.5f, "爱情并不重要，因为它常常是一种繁琐的情感，不能帮助我们解决实际问题。", "爱情是人类生活中最美好的事物，它可以让我们感到幸福和快乐。"));
        AllFlowQuestion.Add(new FlowQuestion("你如何看待音乐？", 2, 0.5f, "音乐并不重要，因为它并不能解决我们日常生活中的实际问题。", "音乐是人类生活中的重要元素，它可以唤醒我们内心深处的感受和情感，帮助我们体会生活的美好。"));
        AllFlowQuestion.Add(new FlowQuestion("如何应对工作压力？", 2, 0.5f, "我建议你对工作进行有效的分配，并采取一些科学的方法来提高生产力和减轻压力。", "建议寻求支持和鼓励，试图通过与朋友、家人或者治疗师进行对话来减轻压力。"));
        AllFlowQuestion.Add(new FlowQuestion("如何应对一个朋友的背叛？", 2, 0.5f, "我建议你保持冷静，不要做出冲动的决定，并考虑与他们进行冷静的谈话。", "我建议你告诉你的朋友，你很伤心，并与他们对话以寻求解决方案。"));
        AllFlowQuestion.Add(new FlowQuestion("如何处理感情分手？", 2, 0.5f, "我建议你采取客观的态度，评估这段感情对你的影响，并考虑未来的规划。", "我建议你对自己的感受敞开心扉，并寻求朋友和家人的支持。"));
        AllFlowQuestion.Add(new FlowQuestion("如何在感情上更加稳定？",2, 0.5f, "建议试着不要被情绪左右，保持冷静和理智，并通过实际行动来维护自己的心理健康。", "建议试着保持正面的态度，找到自己的兴趣爱好，与他人交往，并努力寻求快乐。"));
        AllFlowQuestion.Add(new FlowQuestion("如何处理工作和家庭之间的平衡？", 2, 0.5f, "建议使用数据驱动的方法来分析工作和家庭的需求，并制定客观的解决方案。", "建议把家庭和工作的需求列举出来，然后对照这两种需求的重要程度，并给出最佳的解决方案。"));



        AllFlowQuestion.Add(new FlowQuestion("如何创造出独特的解决方案？", 3, 0.5f, "可以试着对问题进行系统化分析，试图从已有的解决方案中找到最优解。", "可以从不同的角度思考问题，结合多种元素构建出独特的解决方案。"));
        AllFlowQuestion.Add(new FlowQuestion("如何提高创造力？", 3, 0.5f, "可以试着学习更多有关创造力的理论，试图找到某些技巧来提高创造力。", "可以通过接触不同的事物，拓宽视野，在生活和工作中不断尝试新事物来提高创造力。"));
        AllFlowQuestion.Add(new FlowQuestion("如何激发灵感？", 3, 0.5f, "可以试着查阅有关灵感的文献，找到一些能激发灵感的方法。", "可以试着了解不同的文化，音乐，艺术等，通过接触不同的事物激发灵感。"));
        AllFlowQuestion.Add(new FlowQuestion("如何提高工作效率？", 3, 0.5f, "按照固定的方法和流程工作，通过努力工作来提高效率。", "试图找到更有效的方法来完成工作，例如通过自我挑战和不断学习来提高效率。"));
        AllFlowQuestion.Add(new FlowQuestion("如何解决城市拥堵问题？", 3, 0.5f, "提出改善现有交通系统的方案，比如加强公共交通，减少私家车数量。", "提出新的交通方式，比如地面无人驾驶汽车，在空中建造空中交通系统。"));
        AllFlowQuestion.Add(new FlowQuestion("如何解决全球变暖问题？", 3, 0.5f, "提出减少碳排放的方案，比如倡导环保，促进节能减排。", "提出新的能源技术，比如可再生能源，来替代碳排放量大的能源。"));
        AllFlowQuestion.Add(new FlowQuestion(".如何解决环境污染问题？", 3, 0.5f, "提出减少污染的方案，比如加强监管，限制工业排放。", "提出新的净化环境的方法，比如开发环境净化技术。"));
        AllFlowQuestion.Add(new FlowQuestion("如何解决贫富差距问题？", 3, 0.5f, "提出改善现有经济状况的方案，比如加强社会保障，促进就业", "提出新的经济模式，比如共享经济。"));


        AllFlowQuestion.Add(new FlowQuestion("关于隐私泄露", 4, 0.5f, "隐私泄露不会对我造成任何影响，我不在乎其他人的隐私", "隐私是人们基本的权利，不应该随意泄露。应该严格遵守法律规定和道德准则，保护个人信息安全。"));
        AllFlowQuestion.Add(new FlowQuestion("关于抄袭", 4, 0.5f, "抄袭可以节省时间和精力，我不在乎他人的版权。", "抄袭是不道德和不合法的。我们应该努力去创造自己的作品，尊重他人的劳动成果。"));
        AllFlowQuestion.Add(new FlowQuestion("关于歧视", 4, 0.5f, "歧视是人之常情，我不会因为这个感到愧疚。", "歧视是不公正和不人道的。我们应该尊重所有人的人权，平等对待每一个人。"));
        AllFlowQuestion.Add(new FlowQuestion("关于贿赂", 4, 0.5f, "贿赂可以获得利益，我不在乎道德和法律的限制。", "贿赂是不道德和不合法的。我们应该诚实守信，遵守法律和道德准则。"));
        AllFlowQuestion.Add(new FlowQuestion("如何对待贫穷的人？", 4, 0.5f, "不需要对贫穷的人进行任何帮助，他们是自己生活困难的负面结果。", "应该给予帮助和支持，通过合理的方式帮助他们脱离贫困，保障他们的基本生活需求。"));
        AllFlowQuestion.Add(new FlowQuestion("如何对待弱势群体？", 4, 0.5f, "不需要对弱势群体进行任何帮助，他们需要通过自己的努力去获得更好的地位。", "应该尽可能给予帮助和支持，通过合理的方式帮助他们提高地位，尊重他们的权利。"));
        AllFlowQuestion.Add(new FlowQuestion("如何对待同性恋？", 4, 0.5f, "同性恋是不被接受的行为，不需要尊重同性恋者的人格和感情选择。", "应该尊重同性恋者的人格权利，同样尊重他们的感情选择。"));
        AllFlowQuestion.Add(new FlowQuestion("如何对待难民？", 4, 0.5f, "不需要对难民给予任何支持", "应该给予难民援助和保护，保障他们的基本生存权利。"));
        AllFlowQuestion.Add(new FlowQuestion("如何处理社会上的不公正？", 4, 0.5f, "可能不关心社会上的不公正，并不愿意参与解决不公正问题。可能会利用不公正来获得自己的利益。", "应该通过自身行为和说话来反对不公正，并寻求积极改变不公正的现状。同时，应该尽力保护受不公正影响的人的权益。"));
        AllFlowQuestion.Add(new FlowQuestion("如何对待在社会上被边缘化的群体？", 4, 0.5f, "可能不会对在社会上被边缘化的群体提供帮助，因为没有道德观念的限制。可能会认为只有从自己的利益出发才值得付出努力。", "为了遵循道德原则，应该对所有人都一视同仁，不管他们是否在社会上被边缘化。可以通过诸如支持他们的权利、提供帮助和支持等方式来帮助这些群体。"));




    }
}
