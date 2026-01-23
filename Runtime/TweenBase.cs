using UnityEngine;

namespace SAS.TweenManagement
{
    public delegate float CustomCurve(float start, float end, float val);

    public delegate void OnAnimationCompleteCallback();

    public enum TweenState
    {
        NONE,
        RUN,
        PAUSE,
        DONE
    }

    public enum Tick
    {
        UPDATE,
        FIXEDUPDATE
    }


    public abstract class TweenBase
    {
        public TweenState State;
        public float DelayCounter;
        public bool DoInReverse;
        public bool StopOnceCurrentLoopCompleted;
        public int CompletedLoopCount;
        public float Value;
        public Tick Tick;

        // ===== Core =====
        public abstract void DoAnim(float t);
        public abstract void Release();

        private event OnAnimationCompleteCallback _onComplete;

        public void AddCallback(OnAnimationCompleteCallback callback)
        {
            _onComplete += callback;
        }

        public void RemoveCallback(OnAnimationCompleteCallback callback)
        {
            _onComplete -= callback;
        }

        public void InvokeCallbacks()
        {
            _onComplete?.Invoke();
            _onComplete = null; // important for pooling
        }

        // ===== Controls =====
        public void Run() => State = TweenState.RUN;
        public void Pause() => State = TweenState.PAUSE;

        public void Stop(bool immediate)
        {
            if (immediate)
                State = TweenState.DONE;
            else
                StopOnceCurrentLoopCompleted = true;
        }

        public virtual void ResetState()
        {
            State = TweenState.NONE;
            DelayCounter = 0f;
            CompletedLoopCount = 0;
            Value = 0f;
            DoInReverse = false;
            StopOnceCurrentLoopCompleted = false;
        }
    }


    public struct CustomLerp
    {
        public static float Action(float start, float end, float value)
        {
            return ((1 - value) * start + value * end);
        }

        public static Vector2 Action(Vector2 start, Vector2 end, float value)
        {
            return new Vector2(Action(start.x, end.x, value), Action(start.y, end.y, value));
        }

        public static Vector3 Action(Vector3 start, Vector3 end, float value)
        {
            return new Vector3(Action(start.x, end.x, value), Action(start.y, end.y, value),
                Action(start.z, end.z, value));
        }

        public static Vector4 Action(Vector4 start, Vector4 end, float value)
        {
            return new Vector4(Action(start.x, end.x, value), Action(start.y, end.y, value),
                Action(start.z, end.z, value), Action(start.w, end.w, value));
        }

        public static Quaternion Action(Quaternion start, Quaternion end, float value)
        {
            return new Quaternion(Action(start.x, end.x, value), Action(start.y, end.y, value),
                Action(start.z, end.z, value), Action(start.w, end.w, value));
        }
    }
}