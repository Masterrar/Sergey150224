using UnityEngine;

namespace Utility
{
    public static class UnityEngineUtils
    {
        public static void DestroyChilds(this GameObject container)
        {
            foreach (Transform child in container.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
        }
    }
}