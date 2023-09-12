using UnityEngine;

namespace UnityFoundation.Code.Timer.Sample
{

    public class TimerSample : MonoBehaviour
    {
        [SerializeField] TimerDisplay loopDisplay;
        [SerializeField] TimerDisplay runOnceDisplay;
        [SerializeField] TimerDisplay selfDestroyDisplay;

        float totalTime = 5f;

        public void Awake()
        {
            CreateLoopTimer();
            CreateRunOnceTimer();
            CreateSelfDestroyTimer();
        }

        private void CreateSelfDestroyTimer()
        {
            var selfDestroyTimer = TimersReference.I.Create(
                totalTime, () => Debug.Log("Timer finalizado e destruído.")
            );
            selfDestroyDisplay.Setup(selfDestroyTimer, () => CreateSelfDestroyTimer());
        }

        private void CreateRunOnceTimer()
        {
            var runOnce = new Timer(totalTime, () => Debug.Log("Run once finalizou"))
                .RunOnce();
            runOnceDisplay.Setup(runOnce, () => runOnce.Start());
        }

        private void CreateLoopTimer()
        {
            var loop = new Timer(totalTime, () => Debug.Log("Loop completado."))
                .Loop();
            loopDisplay.Setup(loop, () => loop.Start());
        }
    }
}