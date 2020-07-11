using System.Collections.Generic;
using Random;
using UnityEngine;
using UnityEngine.AI;

namespace GOAP
{
    public abstract class GAction : MonoBehaviour
    {
        public string actionName = "Action";
        public float cost = 1f;
        [ReadOnly] public GameObject target;
        public string targetTag;
        public float duration;

        public WorldState[] preConditions;
        public WorldState[] afterEffects;

        [ReadOnly] public NavMeshAgent agent;

        public Dictionary<string, int> preconditions;
        public Dictionary<string, int> aftereffects;

        [ReadOnly] public bool running;

        [ReadOnly] public GInventory inventory;
        [ReadOnly] public WorldStates beliefs;
    
        protected GAction()
        {
            preconditions = new Dictionary<string, int>();
            aftereffects = new Dictionary<string, int>();
        }

        private void Awake()
        {
            agent = this.gameObject.GetComponent<NavMeshAgent>();

            if (preConditions != null)
                foreach (WorldState ws in preConditions)
                    preconditions.Add(ws.key, ws.value);
            if (afterEffects != null)
                foreach (WorldState ws in afterEffects)
                    aftereffects.Add(ws.key, ws.value);

            inventory = this.GetComponent<GAgent>().inventory;
            beliefs = this.GetComponent<GAgent>().beliefs;
        }

        public bool IsAchievable()
        {
            return true;
        }

        public bool IsAchievableGiven(Dictionary<string,int> conditions)
        {
            foreach(KeyValuePair<string,int> p in preconditions)
            {
                if (!conditions.ContainsKey(p.Key))
                    return false;
            }
            return true;
        }

        public abstract bool PrePerform();
        public abstract bool PostPerform();
    }
}