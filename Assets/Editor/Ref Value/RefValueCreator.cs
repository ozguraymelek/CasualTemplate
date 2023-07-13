#if UNITY_EDITOR

using System;
using ChaChaGames.Scripts.RefValue;
using nyy.System_Extensions.Odin;
using Sirenix.OdinInspector;
using Sirenix.Utilities;

namespace ChaChaGames.Editor
{
    public class RefValueCreator : GlobalConfig<RefValueCreator>
    {
        #region PROPERTIES
        
        private RefValueTypes _type;
        [ColoredGroup("",.1f,.1f,1f)][ShowInInspector]
        public RefValueTypes Type
        {
            get => _type;
            set
            {
                _type = value;
                if (_name == "") path = "";
                path = $"Assets/Data/Ref Values/{_type}/{_name}.asset";
            }
        }
        
        private string _name;
        [ColoredGroup("",.1f,.1f,1f)]
        [InlineButton("Create")][ShowInInspector]
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                path = path = $"Assets/Data/Ref Values/{_type}/{_name}.asset";
            }
        }
        
        [FolderPath][ColoredGroup("",.1f,.1f,1f)][ReadOnly]
        public string path;
        
        #endregion

        #region PRIVATE FUNCTIONS
        
        public void Create()
        {
            RefValue instanceSo = Type switch
            {
                RefValueTypes.Float => CreateInstance<FloatRef>(),
                RefValueTypes.Int => CreateInstance<IntRef>(),
                RefValueTypes.Vector3 => CreateInstance<Vector3Ref>(),
                RefValueTypes.Transform => CreateInstance<TransformRef>(),
                RefValueTypes.String => CreateInstance<StringRef>(),
                _ => null
            };

            path = $"Assets/Data/Ref Values/{Type}/{_name}.asset";
            
            UnityEditor.AssetDatabase.CreateAsset(instanceSo, path);
            UnityEditor.AssetDatabase.SaveAssets();
        }
        
        #endregion
    }
}

[Serializable][EnumToggleButtons]
public enum RefValueTypes
{
    Float,Int,
    Vector3,
    Transform,
    String,
}

#endif