using UnityEngine;

namespace SAS.TweenManagement
{
    internal sealed class TweenRunnerUpdate : TweenRunnerTick<TweenRunnerUpdate>
    {
        private void Update()
        {
            deltaTime = Time.deltaTime;
            TickTweens();
        }
    }
}
