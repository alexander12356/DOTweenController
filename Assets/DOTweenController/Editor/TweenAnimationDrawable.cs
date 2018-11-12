using UnityEngine;
using UnityEditor;

namespace DOTWeenControllerClasses.Editor
{
    [CustomPropertyDrawer(typeof(TweenAnimation))]
    public class TweenAnimationDrawable : PropertyDrawer
    {
        private float m_FieldHeight = 18f;
        private float m_VerticalSpacing = 22f;

        private TweenAnimationType GetTweenAnimationType(SerializedProperty property)
        {
            var typeProperty = property.FindPropertyRelative("m_Type");
            return (TweenAnimationType)typeProperty.enumValueIndex;
        }

        private void DrawField(int index, string fieldName, string labelName, float labelWidth, SerializedProperty property, Rect position)
        {
            var fieldRect = new Rect(position.x + labelWidth, position.y + (index * m_VerticalSpacing), position.width, m_FieldHeight);
            var labelRect = new Rect(position.x, position.y + (index * m_VerticalSpacing), position.width, m_FieldHeight);

            EditorGUI.LabelField(labelRect, labelName);
            EditorGUI.PropertyField(fieldRect, property.FindPropertyRelative(fieldName), GUIContent.none);
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            switch (GetTweenAnimationType(property))
            {
                default:
                    return 120f;
            }
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(new Rect(position.x, position.y, position.width, position.height), label, property);

            EditorGUI.PropertyField(new Rect(position.x, position.y, 200f, 20f), property.FindPropertyRelative("m_Type"), GUIContent.none);
            EditorGUI.PropertyField(new Rect(position.x + 210f, position.y, 200f, 20f), property.FindPropertyRelative("m_Ease"), GUIContent.none);

            var type = GetTweenAnimationType(property);

            switch (type)
            {
                case TweenAnimationType.TransformScale:
                    DrawTransformScale(position, property, label);
                    break;
                case TweenAnimationType.TransformMoving:
                    DrawTransformMoving(position, property, label);
                    break;
                case TweenAnimationType.RectTransformLocalMove:
                    DrawRectTransformLocalMove(position, property, label);
                    break;
                case TweenAnimationType.CanvasGroupFade:
                    DrawCanvasGroupFade(position, property, label);
                    break;
                case TweenAnimationType.ImageFade:
                    DrawImageFade(position, property, label);
                    break;
                default:
                    break;
            }

            EditorGUI.EndProperty();
        }

        private void DrawTransformScale(Rect position, SerializedProperty property, GUIContent label)
        {
            DrawField(1, "m_TransformTarget", "Target", 80f, property, position);
            DrawField(2, "m_FloatInitValue", "Init value", 80f, property, position);
            DrawField(3, "m_FloatTargetValue", "Target value", 80f, property, position);
            DrawField(4, "m_DurationValue", "Duration", 80f, property, position);
        }

        private void DrawTransformMoving(Rect position, SerializedProperty property, GUIContent label)
        {
            DrawField(1, "m_TransformTarget", "Target", 80f, property, position);
            DrawField(2, "m_Vector3InitValue", "Init value", 80f, property, position);
            DrawField(3, "m_Vector3TargetValue", "Target value", 80f, property, position);
            DrawField(4, "m_DurationValue", "Duration", 80f, property, position);
        }

        private void DrawRectTransformLocalMove(Rect position, SerializedProperty property, GUIContent label)
        {
            DrawField(1, "m_RectTransformTarget", "Target", 80f, property, position);
            DrawField(2, "m_Vector3InitValue", "Init value", 80f, property, position);
            DrawField(3, "m_Vector3TargetValue", "Target value", 80f, property, position);
            DrawField(4, "m_DurationValue", "Duration", 80f, property, position);
        }

        private void DrawCanvasGroupFade(Rect position, SerializedProperty property, GUIContent label)
        {
            DrawField(1, "m_CanvasGroupTarget", "Target", 80f, property, position);
            DrawField(2, "m_FloatInitValue", "Init value", 80f, property, position);
            DrawField(3, "m_FloatTargetValue", "Target value", 80f, property, position);
            DrawField(4, "m_DurationValue", "Duration", 80f, property, position);
        }

        private void DrawImageFade(Rect position, SerializedProperty property, GUIContent label)
        {
            DrawField(1, "m_ImageTarget", "Target", 80f, property, position);
            DrawField(2, "m_FloatInitValue", "Init value", 80f, property, position);
            DrawField(3, "m_FloatTargetValue", "Target value", 80f, property, position);
            DrawField(4, "m_DurationValue", "Duration", 80f, property, position);
        }
    }
}