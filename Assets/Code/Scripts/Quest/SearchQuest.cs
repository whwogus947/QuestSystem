using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameSystem.Quest
{
    [CreateAssetMenu()]
    public class SearchQuest : QuestBase<GameObject>
    {
        public WorldItem item;
        protected override GameObject CompareTarget => item.model;

        public override bool IsEqual(GameObject other)
        {
            throw new System.NotImplementedException();
        }
    }
}
