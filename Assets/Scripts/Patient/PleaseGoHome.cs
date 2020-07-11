using GOAP;

namespace Patient
{
    public class PleaseGoHome : GAction
    {
        public override bool PostPerform()
        {
            Destroy(gameObject);
            return true;
        }

        public override bool PrePerform()
        {
            return true;
        }
    }
}
