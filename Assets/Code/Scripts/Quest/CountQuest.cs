using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameSystem.Quest
{
    public class CountQuest : QuestBase<int>
    {
        protected override int CompareTarget => 1;

        public override bool IsEqual(int other)
        {
            throw new System.NotImplementedException();
        }
    }
}
