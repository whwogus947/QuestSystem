
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
    }
}
