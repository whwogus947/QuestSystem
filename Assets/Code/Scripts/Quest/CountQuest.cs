
using UnityEngine;

namespace GameSystem.Quest
{
    [CreateAssetMenu(fileName = "Count Up Something", menuName = "Quest/CountUp")]
    public class CountQuest : QuestBase<int>
    {
        public int targetCount;
        protected override int CompareSource => targetCount;

        public override bool IsEqual(IComparableObjective<int> other)
        {
            return targetCount <= other.MissionObjective;
        }

        public override QuestBase<int> ObjectiveAs(int missionObjective)
        {
            targetCount = missionObjective;
            return this;
        }

        public override void Accept()
        {
            base.Accept();
            SubQuests.ForEach(quest => quest.isLoop = true);
            SubQuests.ForEach(quest => quest.SetCompleted());
        }

        public bool IsSubQuestItem<T>(T item)
        {
            if (item == null) 
                return false;
            return SubQuests.Exists(mission => (mission as QuestBase<T>).IsEqual(item));
        }

        public override bool IsEqual(int other)
        {
            throw new System.NotImplementedException();
        }
    }
}
