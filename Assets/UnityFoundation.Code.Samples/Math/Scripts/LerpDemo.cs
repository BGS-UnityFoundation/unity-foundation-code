using UnityEngine;
using UnityFoundation.Code;

namespace UnityFoundationSamples.UnityFoundation.Code
{
    public class LerpDemo : MonoBehaviour
    {
        [SerializeField] private Transform start;
        [SerializeField] private Transform end;
        [SerializeField] private Transform referenceObject;
        [SerializeField] private float interpolationSpeed = 1;

        private LerpByValue lerp;

        public void Awake()
        {
            lerp = new LerpByValue(0, 1) { Looping = true, InterpolationSpeed = interpolationSpeed };

            start = transform.FindTransform("start");
            end = transform.FindTransform("end");
            referenceObject = transform.FindTransform("reference_object");
        }

        public void Update()
        {
            referenceObject.position = Vector3.Lerp(
                start.position,
                end.position,
                lerp.Eval(Time.deltaTime)
            );
        }
    }
}