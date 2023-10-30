using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameSystem.Quest
{
    public abstract class QuestableMission : ScriptableObject
    {
        public abstract bool IsCompleted { get; }
        public abstract UnityAction OnCompleted { get; set; }
        protected abstract void MissionComplete();
    }
}
