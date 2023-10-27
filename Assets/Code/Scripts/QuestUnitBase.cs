using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameSystem.Quest
{
    public abstract class QuestUnitBase : ScriptableObject, IQuestAcceptable, IQuestCheck
    {
        protected bool IsCompleted { get; private set; } = false;
        protected UnityAction OnCompleted;

        public abstract void UndertakeMission(UnityAction mission);

        public abstract void Revert();

        public abstract void TryCheckQuest();

        protected void RestoreQuest() => IsCompleted = false;
    }
}