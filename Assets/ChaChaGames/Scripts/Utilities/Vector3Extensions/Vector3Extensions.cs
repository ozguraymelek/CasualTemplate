using UnityEngine;

namespace ChaChaGames.Scripts.Utilities.Vector3Extensions
{
    public static class Vector3Extensions
    {
        public static Vector3 WithX(this Vector3 thisVector, float x)
        {
            return new Vector3(x, thisVector.y, thisVector.z);
        }

        public static Vector3 WithY(this Vector3 thisVector, float y)
        {
            return new Vector3(thisVector.x, y, thisVector.z);
        }

        public static Vector3 WithZ(this Vector3 thisVector, float z)
        {
            return new Vector3(thisVector.x, thisVector.y, z);
        }
        
        public static Vector3 WithAddedX(this Vector3 thisVector, float x)
        {
            return new Vector3(thisVector.x + x, thisVector.y, thisVector.z);
        }
        
        public static Vector3 WithAddedY(this Vector3 thisVector, float y)
        {
            return new Vector3(thisVector.x, thisVector.y + y, thisVector.z);
        }
        
        public static Vector3 WithAddedZ(this Vector3 thisVector, float z)
        {
            return new Vector3(thisVector.x, thisVector.y, thisVector.z + z);
        }
    }
}