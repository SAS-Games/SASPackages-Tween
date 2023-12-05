using SAS.TweenManagment;
using UnityEngine;

abstract class V3TweenMonoBase : TweenMonoBase
{
    [SerializeField] protected Vector3 m_from = Vector3.one;
    [SerializeField] protected Vector3 m_To = Vector3.one;
}