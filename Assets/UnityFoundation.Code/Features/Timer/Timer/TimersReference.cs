using System;
using UnityEngine;

namespace UnityFoundation.Code.Timer
{
    public class TimersReference : Singleton<TimersReference>
    {
        public Transform GetTransform() => transform;

        /// <summary>
        /// Create and start a timer that will be self destroyed after complete.
        /// </summary>
        public ITimer Create(float totalTime, Action callback)
        {
            return new Timer(totalTime, callback) {
                SelfDestroyAfterComplete = true
            }
            .Start();
        }
    }
}