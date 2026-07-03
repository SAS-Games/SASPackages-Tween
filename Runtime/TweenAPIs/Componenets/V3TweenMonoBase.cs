using SAS.TweenManagement;
using UnityEngine;

abstract class V3TweenMonoBase : TweenMonoBase
{
    [SerializeField] private bool m_useCurrentAsFrom = false;
    [SerializeField] private bool m_isAdditive = false;
    [SerializeField] private Vector3 m_from = Vector3.one;
    [SerializeField] private Vector3 m_To = Vector3.one;

    protected Vector3 _resolvedFrom;
    protected Vector3 _resolvedTo;

    private Vector3 From => m_useCurrentAsFrom ? GetCurrentValue() : m_from;
    private Vector3 To => m_isAdditive ? From + m_To : m_To;

    protected override void PrepareTween()
    {
        _resolvedFrom = From;
        _resolvedTo = To;
    }

    protected abstract Vector3 GetCurrentValue();
} 