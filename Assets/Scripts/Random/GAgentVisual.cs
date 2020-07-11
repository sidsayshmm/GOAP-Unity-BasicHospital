using GOAP;
using UnityEngine;

namespace Random
{
    [ExecuteInEditMode]
    public class GAgentVisual : MonoBehaviour
    {
        public GAgent thisAgent;

        private void Start()
        {
            thisAgent = this.GetComponent<GAgent>();
        }
    }
}