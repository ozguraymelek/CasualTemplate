#if UNITY_EDITOR

using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;
using UnityEditor;
using Sirenix.Utilities;

namespace ChaChaGames.Editor
{
    public class EventsValuesCreator : OdinMenuEditorWindow
    {
        [MenuItem("Cha Cha/Creator/Events & Values")]
        private static void OpenWindow()
        {
            var window = GetWindow<EventsValuesCreator>();
            window.position = GUIHelper.GetEditorWindowRect().AlignCenter(800, 600);
        }
    
        protected override OdinMenuTree BuildMenuTree()
        {
            var tree = new OdinMenuTree(true)
            {
                { "Create Events", GameEventCreator.Instance, EditorIcons.Airplane },
                { "Create Ref Values", RefValueCreator.Instance, EditorIcons.Airplane },
            };

            tree.AddAllAssetsAtPath("Create Events/Game Events", "Assets/ChaChaGames/Game Events");
            
            tree.AddAllAssetsAtPath("Create Ref Values/FloatRef", "Assets/Data/Ref Values/Float");
            tree.AddAllAssetsAtPath("Create Ref Values/IntRef", "Assets/Data/Ref Values/Int");
            tree.AddAllAssetsAtPath("Create Ref Values/Vector3Ref", "Assets/Data/Ref Values/Vector3");
            tree.AddAllAssetsAtPath("Create Ref Values/TransformRef", "Assets/Data/Ref Values/Transform");
            tree.AddAllAssetsAtPath("Create Ref Values/StringRef", "Assets/Data/Ref Values/String");
            
            return tree;
        }
    }
}

#endif