using UnityEngine;

namespace SAS.TweenManagement
{
    internal sealed class TweenRunnerFixedUpdate : TweenRunnerTick<TweenRunnerFixedUpdate>
    {
        private void FixedUpdate()
        {
            deltaTime = Time.deltaTime;
            for (int i = 0; i < mSize; ++i)
                DoUpdate(mTweens[i]._Tween, mTweens[i]._TweenConfig);
        }
    }
}
