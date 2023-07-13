#if UNITY_EDITOR

using ChaChaGames.Scripts.Game_Events;
using nyy.System_Extensions.Odin;
using Sirenix.OdinInspector;
using Sirenix.Utilities;

namespace ChaChaGames.Editor
{
    public class GameEventCreator : GlobalConfig<GameEventCreator>
    {
        #region PROPERTIES
        
        [ColoredGroup("",.1f,.1f,1f)]
        [InlineButton("Create")]
        public new string name;
        
        #endregion

        #region PRIVATE FUNCTIONS
        
        public void Create()
        {
            var instanceSo = CreateInstance<GameEvent>();
            UnityEditor.AssetDatabase.CreateAsset(instanceSo, $"Assets/ChaChaGames/Game Events/{name}.asset");
            UnityEditor.AssetDatabase.SaveAssets();
        }
        
        #endregion
    }
}

#endif