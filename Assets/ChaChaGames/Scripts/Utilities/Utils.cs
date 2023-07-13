using ChaChaGames.Scripts.Collisions;
using UnityEngine;

namespace ChaChaGames.Scripts.Utilities
{
    public static class Utils
    {
        public static IHittable GetNearestHittable(Vector3 position,RaycastHit[] hits,int hitCount)
        {
            var minDistance = Mathf.Infinity;
            var minIndex = 0;
            for (var i = 0; i < hitCount; i++)
            {
                var distance = Vector3.Distance(position, hits[i].transform.position);
                if (!(distance < minDistance)) 
                    continue;
                minDistance = distance;
                minIndex = i;
            }

            hits[minIndex].collider.TryGetComponent(out IHittable target);
            return target;
        }
    }
}