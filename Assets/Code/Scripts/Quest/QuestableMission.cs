using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameSystem.Quest
{
    public abstract class QuestableMission : ScriptableObject
    {
        public bool isLoop = false;
        public abstract bool IsCompleted { get; }
        public abstract UnityAction OnCompleted { get; set; }
        public abstract void SetCompleted();
        protected abstract void SubQuestEvent();
    }
}
