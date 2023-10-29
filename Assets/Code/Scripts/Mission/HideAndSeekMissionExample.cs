using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystem.Quest
{
    public class HideAndSeekMissionExample : MonoBehaviour, IComparableObjective<GameObject>
    {
        public GameObject MissionObjective => FindOut();
        public List<SearchQuest> searchQuests;

        void Start()
        {
            searchQuests.ForEach(x => x.
                WithReward(() => SuccessLog(x.item.name)).
                WithReward(() => Destroy(MissionObjective.gameObject)).
                Accept());
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                searchQuests?.ForEach(quest => quest.TryComplete(this));
            }
        }

        private void SuccessLog(string log) => Debug.Log($"Found item : <color=white>{log}</color>");

        private GameObject FindOut()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity))
            {
                var detected = hitInfo.collider;
                if (detected != null)
                {
                    return detected.gameObject;
                }
            }
            return null;
        }
    }
}
