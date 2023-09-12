using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityFoundation.Code
{
    public static class GameObjectExtensions
    {
        public static T FindComponent<T>(this GameObject gameObject, string path)
            => FindComponent<T>(gameObject, SplitPath(path));

        public static T FindComponent<T>(this GameObject gameObject, params string[] path)
            => TransformUtils.FindComponent<T>(gameObject.transform, path);

        private static string[] SplitPath(string path) => path.Split('.');
    }
}
