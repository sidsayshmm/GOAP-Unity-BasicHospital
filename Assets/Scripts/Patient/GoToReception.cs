using GOAP;

namespace Patient
{
    public class GoToReception : GAction
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
