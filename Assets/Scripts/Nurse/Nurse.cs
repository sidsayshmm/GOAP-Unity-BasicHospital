
using GOAP;

namespace Nurse
{
    public class Nurse : GAgent
    {
        protected override void Start()
        {
            base.Start();
            SubGoal s1 = new SubGoal("treatPatient", 1, false);
            goals.Add(s1, 3);

            SubGoal s2 = new SubGoal("rested", 1, false);
            goals.Add(s2, 1);
        
            Invoke(nameof(GetTired),UnityEngine.Random.Range(20, 50));
        }
    
        private void GetTired()
        {
            beliefs.ModifyState("exhausted", 0);
            Invoke(nameof(GetTired),UnityEngine.Random.Range(20, 25));
        }
    }
}