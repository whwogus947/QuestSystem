using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameSystem.Quest
{
    public class CountQuest : QuestBase<int>
    {
        public int targetCount;
        protected override int CompareTarget => targetCount;

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
