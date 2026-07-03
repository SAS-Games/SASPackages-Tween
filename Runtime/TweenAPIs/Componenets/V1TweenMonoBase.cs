using SAS.TweenManagement;
using UnityEngine;

abstract class V1TweenMonoBase : TweenMonoBase
{
    [SerializeField] private bool m_useCurrentAsFrom = false;
    [SerializeField] private bool m_isAdditive = false;
    [SerializeField] private float m_from = 0;
    [SerializeField] private float m_To = 1;
    protected float _resolvedFrom;
    protected float _resolvedTo;
    private float From => m_useCurrentAsFrom ? GetCurrentValue() : m_from;
    private float To => m_isAdditive ? From + m_To : m_To;

    protected sealed override void PrepareTween()
    {
        _resolvedFrom = From;
        _resolvedTo = To;
    }

    protected abstract float GetCurrentValue();
}