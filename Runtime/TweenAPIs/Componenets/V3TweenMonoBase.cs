using SAS.TweenManagement;
using UnityEngine;

abstract class V3TweenMonoBase : TweenMonoBase
{
    [Header("Section1")]
    [SerializeField] protected Vector3 m_from = Vector3.one;
    [SerializeField] protected Vector3 m_To = Vector3.one;
}