using UnityEngine;

namespace SAS.TweenManagement
{
    internal sealed class TweenRunnerUpdate : TweenRunnerTick<TweenRunnerUpdate>
    {
        private void Update()
        {
            deltaTime = Time.deltaTime;
            for (int i = 0; i < mSize; ++i)
                DoUpdate(mTweens[i]._Tween, mTweens[i]._TweenConfig);
        }
    }
}
