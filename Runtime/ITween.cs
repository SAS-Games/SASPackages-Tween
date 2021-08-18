using UnityEngine;

namespace SAS.TweenManagment
{
	public delegate float CustomCurve(float start, float end, float val);
	public delegate void OnAnimationCompleteCallback(object o);

	public enum TweenState
	{
		NONE,
		RUN,
		PAUSE,
		DONE
	}


    public interface ITween
    {
        TweenState State { get; set; }
        float DelayCounter { get; set; }
        bool DoInReverese { get; set; }
        bool StopOnceCurrentLoopCompleted { get; set; }
        short CompletedLoopCount { get; set; }
        float Value { get; set; }
        void DoAnim(float val);
        void Run();
        void Pause();
        void Stop(bool immediate);
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
            return new Vector3(Action(start.x, end.x, value), Action(start.y, end.y, value), Action(start.z, end.z, value));
        }

        public static Vector4 Action(Vector4 start, Vector4 end, float value)
        {
            return new Vector4(Action(start.x, end.x, value), Action(start.y, end.y, value), Action(start.z, end.z, value), Action(start.w, end.w, value));
        }

        public static Quaternion Action(Quaternion start, Quaternion end, float value)
        {
            return new Quaternion(Action(start.x, end.x, value), Action(start.y, end.y, value), Action(start.z, end.z, value), Action(start.w, end.w, value));
        }

    }
}

