using UnityEngine;

namespace SAS.TweenManagement
{
    public sealed class TransformPositionRotationTween : TweenBase
    {
        private Transform _transform;

        private Vector3 _fromPos;
        private Vector3 _toPos;

        private Quaternion _fromRot;
        private Quaternion _toRot;

        private bool _isLocal;

        public void Setup(Transform transform, Vector3 fromPos, Vector3 toPos, Quaternion fromRot, Quaternion toRot, bool isLocal)
        {
            _transform = transform;

            _fromPos = fromPos;
            _toPos = toPos;

            _fromRot = fromRot;
            _toRot = toRot;
            
            _isLocal = isLocal;

            ResetState();
        }

        public override void DoAnim(float t)
        {
            Vector3 pos = Vector3.LerpUnclamped(_fromPos, _toPos, t);
            Quaternion rot = Quaternion.SlerpUnclamped(_fromRot, _toRot, t);

            if (_isLocal)
                _transform.SetLocalPositionAndRotation(pos, rot);
            else
                _transform.SetPositionAndRotation(pos, rot);
        }

        public override void Release()
        {
            _transform = null;
            TransformPositionRotationTweenPool.Release(this);
        }
    }
}