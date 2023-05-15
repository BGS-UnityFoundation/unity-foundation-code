using UnityEngine;
using UnityFoundation.Code;

namespace UnityFoundationSamples.UnityFoundation.Code
{
    public class LerpByTimeDemo : MonoBehaviour
    {
        [SerializeField] private Transform start;
        [SerializeField] private Transform end;
        [SerializeField] private Transform referenceObject;
        [SerializeField] private float time;

        private LerpByTime lerp;

        public void Awake()
        {
            lerp = new LerpByTime(startValue: 0, endValue: 1, time) { Looping = true };

            start = transform.FindTransform("start");
            end = transform.FindTransform("end");
            referenceObject = transform.FindTransform("reference_object");
        }

        public void Update()
        {
            lerp.Eval(Time.deltaTime);
            referenceObject.position = Vector3.Lerp(start.position, end.position, lerp.CurrentValue);
        }
    }
}