using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystem.Quest
{
    public interface IQuestable
    {
        void Accept(IQuestAcceptable quest);
        void TryComplete(IQuestCheck quest);
    }
}