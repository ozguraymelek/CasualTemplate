using UnityEngine;

namespace ChaChaGames.Scripts.Collisions
{
    public interface IHittable
    {
        public bool CanHit { get; set; }
        void Hit();
        Transform GetTransform();
    }
}