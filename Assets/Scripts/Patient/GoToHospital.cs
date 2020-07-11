using GOAP;

namespace Patient
{
    public class GoToHospital : GAction
    {
        public override bool PostPerform()
        {
            return true;
        }

        public override bool PrePerform()
        {
            return true;
        }
    }
}
