using UnityEngine;

namespace SAS.TweenManagement
{
    internal sealed class TweenRunnerFixedUpdate : TweenRunnerTick<TweenRunnerFixedUpdate>
    {
        private void FixedUpdate()
        {
            deltaTime = Time.fixedDeltaTime;
            TickTweens();
        }
    }
}
