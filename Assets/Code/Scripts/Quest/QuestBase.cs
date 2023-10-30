
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameSystem.Quest
{
    public abstract class QuestBase<T> : QuestableMission
    {
        public List<QuestableMission> SubQuests;
        public override bool IsCompleted => isCompleted;
        public override UnityAction OnCompleted { get; set; }
        protected abstract T CompareSource { get; }

        private bool isCompleted = false;

        public abstract bool IsEqual(IComparableObjective<T> other);

        public abstract QuestBase<T> ObjectiveAs(T missionObjective);

        public QuestBase<T> WithReward(UnityAction reward)
        {
            OnCompleted += reward;
            return this;
        }

        public QuestBase<T> WithSubQuest(QuestableMission quest)
        {
            AddSubQuest(quest);
            return this;
        }

        public QuestBase<T> AbstractSubQuest(QuestableMission quest)
        {
            RemoveSubQuest(quest);
            return this;
        }

        public bool TryComplete(IComparableObjective<T> other)
        {
            if (IsEqual(other) && !isCompleted && OnCompleted != null)
            {
                MissionComplete();
                return true;
            }
            return false;
        }

        public void Accept()
        {
            isCompleted = false;
            SubQuests ??= new();
        }

        protected override void MissionComplete()
        {
            bool isAllSubQuestCompleted = SubQuests.Count <= 0 ? true : SubQuests.TrueForAll(x => x.IsCompleted);
            if (isAllSubQuestCompleted)
            {
                isCompleted = true;
                OnCompleted?.Invoke();
            }
        }

        private void AddSubQuest(QuestableMission questable)
        {
            SubQuests.Add(questable);
            questable.OnCompleted += MissionComplete;
        }

        private void RemoveSubQuest(QuestableMission questable)
        {
            questable.OnCompleted -= MissionComplete;
            SubQuests.Remove(questable);
        }
    }
}
