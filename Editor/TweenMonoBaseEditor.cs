using UnityEditor;

namespace SAS.TweenManagement.Editor
{
    [CustomEditor(typeof(TweenMonoBase), true)]
    public class TweenMonoBaseEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            SerializedProperty useCurrentProp = serializedObject.FindProperty("m_useCurrentAsFrom");
            SerializedProperty additiveProp = serializedObject.FindProperty("m_isAdditive");
            SerializedProperty fromProp = serializedObject.FindProperty("m_from");
            SerializedProperty toProp = serializedObject.FindProperty("m_To");

            if (useCurrentProp != null)
                EditorGUILayout.PropertyField(useCurrentProp);

            if (fromProp != null && (useCurrentProp == null || !useCurrentProp.boolValue))
                EditorGUILayout.PropertyField(fromProp);

            if (toProp != null)
                EditorGUILayout.PropertyField(toProp);

            if (additiveProp != null)
                EditorGUILayout.PropertyField(additiveProp);

            DrawPropertiesExcluding(serializedObject, "m_useCurrentAsFrom", "m_isAdditive", "m_from", "m_To", "m_Script");

            serializedObject.ApplyModifiedProperties();
        }
    }
}
