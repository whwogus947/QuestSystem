using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystem.Quest
{
    public class MissionInstance<T> : IComparableObjective<T>
    {
        public T MissionObjective { get; set; }
    }
}