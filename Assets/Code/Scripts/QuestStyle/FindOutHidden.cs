using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameSystem.Quest
{
    [CreateAssetMenu()]
    public class FindOutHidden : QuestUnitBase
    {
        private readonly WorldItem hiddenTarget;
        private WorldItem found;

        public FindOutHidden(WorldItem target)
        {
            hiddenTarget.itemName = target.itemName;
        }

        public override void Revert()
        {
            found = null;
            RestoreQuest();
        }

        public override void TryCheckQuest()
        {
            if (found == null)
                return;

            if (found == hiddenTarget)
                OnCompleted?.Invoke();
        }

        public override void UndertakeMission(UnityAction mission)
        {
            OnCompleted += mission;
        }
    }
}