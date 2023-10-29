using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

namespace GameSystem.Quest
{
    public abstract class QuestBase<T> : ScriptableObject
    {
        protected UnityAction OnCompleted;

        private bool isCompleted = false;

        protected abstract T CompareTarget { get; }

        public abstract bool IsEqual(T other);

        public void Accept(UnityAction gift)
        {
            if (isCompleted)
                return;

            OnCompleted += gift;
        }

        public bool TryComplete(T other)
        {
            if (IsEqual(other) && !isCompleted && OnCompleted != null)
            {
                isCompleted = true;
                OnCompleted.Invoke();
                return true;
            }
            return false;
        }
    }
}
