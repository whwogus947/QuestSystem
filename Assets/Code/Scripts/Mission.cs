using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystem.Quest
{
    public class Mission : MonoBehaviour
    {
        public QuestUnitBase mission1;
        // Start is called before the first frame update
        void Start()
        {
            mission1 = ScriptableObject.CreateInstance<FindOutHidden>();
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
