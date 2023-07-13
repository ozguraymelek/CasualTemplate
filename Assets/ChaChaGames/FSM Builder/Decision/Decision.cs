using ChaChaGames.Controllers;
using Sirenix.OdinInspector;

namespace ChaChaGames.FSMBuilder
{
    public abstract class Decision : SerializedScriptableObject
    {
        #region PUBLIC FUNCTIONS
        
        public abstract bool Decide(StateController controller);
        
        #endregion  
    }
}