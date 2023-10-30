using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystem.Quest
{
    public class CountUpMissionExample : MonoBehaviour, IComparableObjective<int>
    {
        public int MissionObjective => conditionCount;
        public CountQuest countQuest;
        public List<SearchQuest> searchQuests;
        public MissionInstance<GameObject> MI
        {
            get
            {
                _MI.MissionObjective = FindOut();
                return _MI;
            }
        }
        private readonly MissionInstance<GameObject> _MI = new();
        private int conditionCount = 0;

        void Start()
        {
            countQuest.WithReward(() => SuccessLog("Main mission COMPLETE!")).Accept();
            searchQuests.ForEach(x => x.
                WithReward(() => SuccessLog(x.item.name)).
                WithReward(() => Destroy(MI.MissionObjective)).
                WithReward(() => { conditionCount++; }).
                WithReward(() => { x.Accept(); }).
                Accept());
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                searchQuests?.ForEach(quest => quest.TryComplete(MI));
                countQuest.TryComplete(this);
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
