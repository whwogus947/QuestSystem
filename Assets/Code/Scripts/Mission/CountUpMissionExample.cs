using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystem.Quest
{
    public class CountUpMissionExample : MonoBehaviour, IComparableObjective<int>
    {
        public int MissionObjective => conditionCount;
        public CountQuest countQuest;
        private int conditionCount = 0;

        void Start()
        {
            countQuest.WithReward(() => SuccessLog("Main mission COMPLETE!")).Accept();
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var foundItem = FindOut();
                if (countQuest.IsSubQuestItem<GameObject>(foundItem))
                {
                    conditionCount++;
                    Debug.Log("Current count is " + MissionObjective);
                    countQuest.TryComplete(this);
                    Destroy(foundItem);
                }
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
