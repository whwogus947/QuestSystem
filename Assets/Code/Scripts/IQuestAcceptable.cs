using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameSystem.Quest
{
    public interface IQuestAcceptable
    {
        void UndertakeMission(UnityAction reward);
    }
}
