using InitialPrefabs.Attributes.Messages;
using UnityEditor;
using UnityEngine;

namespace InitialPrefabs.Editor.Attributes.Messages {

    [CustomPropertyDrawer(typeof(MsgAttribute))]
    public class MsgAttributePropertyDrawer : BasePropertyDrawer {

        protected override void OnInspectorAttribute(Rect rect, SerializedProperty prop, GUIContent label) {
            var msgAttribute = attribute as MsgAttribute;

            var originalHeight = EditorGUI.GetPropertyHeight(prop);
            var propRect = new Rect(rect.x, rect.y, rect.width, originalHeight);
            EditorGUI.PropertyField(propRect, prop);

            var msgRect = new Rect(rect.x, rect.y + originalHeight, rect.width, originalHeight * 
                    (msgAttribute.height - 1));
            EditorGUI.HelpBox(msgRect, msgAttribute.message, (MessageType)msgAttribute.messageLevel);
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
            var msgAttribute = attribute as MsgAttribute;
            return (msgAttribute.height) * EditorGUI.GetPropertyHeight(property);
        }
    }
}
