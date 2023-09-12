using System;
using UnityEngine;
using UnityFoundation.Code;

namespace UnityFoundation.Code.Timer
{
    public class Timer : ITimer
    {
        /// <summary>
        /// Get the time passed in the current loop in seconds
        /// </summary>
        public float CurrentTime {
            get {
                if(timerBehaviour == null)
                    return 0f;

                return timerBehaviour.Timer;
            }
        }

        /// <summary>
        /// Get the time to end the current loop in seconds
        /// </summary>
        public float RemainingTime { get { return TotalTime - timerBehaviour.Timer; } }

        /// <summary>
        /// Get the completion percentage of the timer
        /// </summary>
        public float Completion {
            get {
                return CurrentTime / TotalTime * 100f;
            }
        }

        /// <summary>
        /// Get if the timer finished it's execution
        /// </summary>
        public bool Completed => MathX.NearlyEqual(CurrentTime, TotalTime, 0.01f);

        /// <summary>
        /// Get if the timer is current running
        /// </summary>
        public bool IsRunning {
            get {
                return timerBehaviour != null && timerBehaviour.IsRunning;
            }
        }

        public float TotalTime { get; private set; }
        public bool SelfDestroyAfterComplete { get; set; }

        private TimerMonoBehaviour timerBehaviour;
        private string name;
        private bool isLoop;
        private readonly Action callback;

        /// <summary>
        /// Instantiate a gameobject to run the timer for some provider action, by default run once and stop
        /// </summary>
        /// <param name="totalTime">time in seconds</param>
        public Timer(float totalTime)
        {
            TotalTime = totalTime;
            callback = () => { };
        }

        /// <summary>
        /// Instantiate a gameobject to run the timer for some provider action, by default run once and stop
        /// </summary>
        /// <param name="totalTime">time in seconds</param>
        /// <param name="callback">callback called when totalTime of time is reached</param>
        public Timer(float totalTime, Action callback)
        {
            this.TotalTime = totalTime;
            this.callback = callback;
        }

        public ITimer SetTotalTime(float newtotalTime)
        {
            TotalTime = newtotalTime;
            return this;
        }

        public ITimer SetName(string name)
        {
            this.name = name;
            return this;
        }

        public ITimer RunOnce()
        {
            isLoop = false;
            return this;
        }

        public ITimer Loop()
        {
            isLoop = true;
            return this;
        }

        /// <summary>
        /// Start the timer with the setting parameters
        /// </summary>
        public ITimer Start()
        {
            if(timerBehaviour == null)
                InstantiateTimer();

            timerBehaviour.Setup(TotalTime, callback, isLoop, SelfDestroyAfterComplete);
            return this;
        }

        /// <summary>
        /// Stop running the timer
        /// </summary>
        public void Stop()
        {
            if(timerBehaviour == null)
                return;
            timerBehaviour.Deactivate();
        }

        public void Resume()
        {
            timerBehaviour.Activate();
        }

        public void Close()
        {
            if(timerBehaviour == null) return;
            timerBehaviour.Close();
        }

        private void InstantiateTimer()
        {
            if(string.IsNullOrEmpty(name)) name = Guid.NewGuid().ToString();

            timerBehaviour = new GameObject(name).AddComponent<TimerMonoBehaviour>();
            timerBehaviour.transform.SetParent(TimersReference.I.GetTransform());
        }
    }
}