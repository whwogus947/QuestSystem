
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEditor.Progress;

namespace GameSystem.Quest
{
    public abstract class QuestBase<T> : QuestableMission, IComparableObjective<T>
    {
        public T MissionObjective => CompareSource;
        public List<QuestableMission> SubQuests;
        public override bool IsCompleted => isCompleted;
        public override UnityAction OnCompleted { get; set; }

        protected abstract T CompareSource { get; }

        private bool isCompleted = false;

        public abstract bool IsEqual(IComparableObjective<T> other);

        public abstract bool IsEqual(T other);

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
                if(IsAllSubQuestCompleted)
                {
                    isCompleted = true;
                    OnCompleted?.Invoke();
                    return true;
                }
            }
            return false;
        }

        public override void SetCompleted()
        {
            isCompleted = true;
        }

        public virtual void Accept()
        {
            isCompleted = false;
            SubQuests ??= new();
        }

        protected override void SubQuestEvent()
        {
            if (IsAllSubQuestCompleted)
            {
                //isCompleted = isLoop;
                OnCompleted?.Invoke();
            }
        }

        private bool IsAllSubQuestCompleted => SubQuests.Count <= 0 ? true : SubQuests.TrueForAll(x => x.IsCompleted);

        private void AddSubQuest(QuestableMission questable)
        {
            SubQuests.Add(questable);
            questable.OnCompleted += SubQuestEvent;
        }

        private void RemoveSubQuest(QuestableMission questable)
        {
            questable.OnCompleted -= SubQuestEvent;
            SubQuests.Remove(questable);
        }
    }
}
