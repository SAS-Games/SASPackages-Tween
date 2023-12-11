using SAS.TweenManagment;
using UnityEngine;

abstract class V2TweenMonoBase : TweenMonoBase
{
    [SerializeField] protected Vector2 m_from = Vector2.one;
    [SerializeField] protected Vector2 m_To = Vector2.one;
}