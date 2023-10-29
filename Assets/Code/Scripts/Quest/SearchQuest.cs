
using UnityEngine;

namespace GameSystem.Quest
{
    [CreateAssetMenu()]
    public class SearchQuest : QuestBase<GameObject>
    {
        public WorldItem item;
        protected override GameObject CompareSource => item.model;

        public override bool IsEqual(IComparableObjective<GameObject> other)
        {
            if (other.MissionObjective == null || item.model == null) 
                return false;

            return item.model.name == other.MissionObjective.name;
        }

        public override QuestBase<GameObject> ObjectiveAs(GameObject missionObjective)
        {
            item.model = missionObjective;
            return this;
        }
    }
}
