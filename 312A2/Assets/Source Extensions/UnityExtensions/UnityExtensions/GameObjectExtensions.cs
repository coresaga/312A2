using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Object = UnityEngine.Object;

namespace UnityExtensions
{
    public static class GameObjectExtensions
    {
        public static TFindable FindObjectOfType<TFindable>()
            where TFindable : Object
        {
            return (TFindable)Object.FindObjectOfType(typeof(TFindable));
        }
        public static TFindable FindObjectOfType<TFindable>(this GameObject gameObject)
            where TFindable : Object
        {
            return FindObjectOfType<TFindable>();
        }


        public static IEnumerable<TFindable> FindObjectsOfType<TFindable>()
            where TFindable : Object
        {
            return Object.FindObjectsOfType(typeof(TFindable)).Cast<TFindable>();
            
        } 

        public static IEnumerable<TFindable> FindObjectsOfType<TFindable>(this GameObject gameObject)
            where TFindable : Object
        {
            return FindObjectsOfType<TFindable>();
        } 
    }
}
