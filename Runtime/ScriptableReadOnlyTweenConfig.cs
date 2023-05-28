using UnityEngine;

namespace SAS.TweenManagment
{
    [CreateAssetMenu(menuName = "SAS/ScriptableTypes/ReadOnly/TweenConfig")]
    public class ScriptableReadOnlyTweenConfig : ScriptableObject
    {
        [SerializeField] private TweenConfig m_Params = default;
        public TweenConfig value => m_Params;
    }
}
