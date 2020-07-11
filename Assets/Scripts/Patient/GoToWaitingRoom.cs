using GOAP;
using UnityEngine.AI;

namespace Patient
{
    public class GoToWaitingRoom : GAction
    {
        public override bool PrePerform()
        {
            this.gameObject.GetComponent<NavMeshAgent>().updatePosition = true;
            return true;
        }
        public override bool PostPerform()
        {
            GWorld.Instance.GetWorld().ModifyState("Waiting", 1);
            GWorld.Instance.AddPatient(this.gameObject);
            this.gameObject.GetComponent<NavMeshAgent>().updatePosition = false;
            beliefs.ModifyState("atHospital", 1);
            return true;
        }
    }
}