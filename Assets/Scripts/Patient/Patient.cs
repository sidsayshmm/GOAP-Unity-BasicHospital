using GOAP;

namespace Patient
{
    public class Patient : GAgent
    {
        protected  void OnEnable()
        {
            base.Start();
            SubGoal s1 = new SubGoal("isWaiting", 1, true);
            goals.Add(s1, 3);
            SubGoal s2 = new SubGoal("isTreated", 1, true);
            goals.Add(s2, 5);
            SubGoal s3 = new SubGoal("isHome", 1, true);
            goals.Add(s3, 10000);
        }
    }
}
