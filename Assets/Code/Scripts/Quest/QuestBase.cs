
using UnityEngine;
using UnityEngine.Events;

namespace GameSystem.Quest
{
    public abstract class QuestBase<T> : ScriptableObject
    {
        protected abstract T CompareSource { get; }
        protected UnityAction OnCompleted;

        private bool isCompleted = false;

        public abstract bool IsEqual(IComparableObjective<T> other);

        public abstract QuestBase<T> ObjectiveAs(T missionObjective);

        public QuestBase<T> WithReward(UnityAction reward)
        {
            OnCompleted += reward;
            return this;
        }

        public bool TryComplete(IComparableObjective<T> other)
        {
            if (IsEqual(other) && !isCompleted && OnCompleted != null)
            {
                isCompleted = true;
                OnCompleted.Invoke();
                return true;
            }
            return false;
        }

        public void Accept()
        {
            isCompleted = false;
        }
    }
}
