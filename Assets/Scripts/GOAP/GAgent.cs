using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GOAP
{
    public class SubGoal
    {
        public Dictionary<string, int> sgoals;
        public bool remove;

        public SubGoal(string s, int i, bool r)
        {
            sgoals = new Dictionary<string, int>();
            sgoals.Add(s, i);
            remove = r;
        }
    }

    public class GAgent : MonoBehaviour
    {
       
        public List<GAction> actions = new List<GAction>();
        public Dictionary<SubGoal, int> goals = new Dictionary<SubGoal, int>();
        public GInventory inventory = new GInventory();
        public WorldStates beliefs = new WorldStates();

        Queue<GAction> actionQueue;
        public GAction currentAction;
        private SubGoal currentGoal;
        private GPlanner planner;
        protected virtual void Start()
        {
            GAction[] acts = this.GetComponents<GAction>();
            foreach (GAction a in acts)
                actions.Add(a);
        }

        private bool invoked = false;

        private void CompleteAction()
        {
            currentAction.running = false;
            currentAction.PostPerform();
            invoked = false;
        }
        private void LateUpdate()
        {

            if (currentAction != null && currentAction.running)
            {
                float distanceToTarget = Vector3.Distance(currentAction.target.transform.position, this.transform.position);
                if (currentAction.agent.hasPath && distanceToTarget < 2f)
                {
                    if(!invoked)
                    {
                        Invoke(nameof(CompleteAction), currentAction.duration);
                        invoked = true;
                    }
                }
                return;
            }

            if (planner == null || actionQueue == null)
            {
                planner = new GPlanner();
                var sortedGoals = from entry in goals orderby entry.Value descending select entry;

                foreach (KeyValuePair<SubGoal, int> sg in sortedGoals)
                {
                    actionQueue = planner.Plan(actions, sg.Key.sgoals, beliefs);
                    if(actionQueue!=null)
                    {
                        currentGoal = sg.Key;
                        break;
                    }
                }
            }

            if(actionQueue != null && actionQueue.Count == 0)
            {
                if(currentGoal.remove)
                {
                    goals.Remove(currentGoal);
                }
                planner = null;
            }

            if(actionQueue!=null && actionQueue.Count > 0)
            {
            
                currentAction = actionQueue.Dequeue();
                if (currentAction.PrePerform())
                {
                    if(currentAction.target == null && currentAction.targetTag != "")
                    {
                        currentAction.target = GameObject.FindWithTag(currentAction.targetTag);
                    }

                    if (currentAction.target == null) 
                    {
                        Debug.Log("Idiot");
                    }

                    if (currentAction.target != null) 
                    {
                        currentAction.running = true;
                        //Debug.Log($"Setting DESTINATION OF {this.name} TO {currentAction.target.name} ");
                        currentAction.agent.SetDestination(currentAction.target.transform.position);
                    }
                }
                else
                {
                    actionQueue = null;
                }
            }
        
        }
    }
}