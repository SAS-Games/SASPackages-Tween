using SAS.TweenManagement;
using UnityEngine;

abstract class V2TweenMonoBase : TweenMonoBase
{
    [SerializeField] private bool m_useCurrentAsFrom = false;
    [SerializeField] private bool m_isAdditive = false;
    [SerializeField] private Vector2 m_from = Vector2.one;
    [SerializeField] private Vector2 m_To = Vector2.one;
    protected Vector2 _resolvedFrom;
    protected Vector2 _resolvedTo;
    private Vector2 From => m_useCurrentAsFrom ? GetCurrentValue() : m_from;
    private Vector2 To => m_isAdditive ? From + m_To : m_To;

    public override void Play(OnAnimationCompleteCallback onTweenCompleted)
    {
        _resolvedFrom = From;
        _resolvedTo = To;

        base.Play(onTweenCompleted);
    }

    protected abstract Vector2 GetCurrentValue();
}