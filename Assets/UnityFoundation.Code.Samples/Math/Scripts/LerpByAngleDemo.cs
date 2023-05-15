using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityFoundation.Code;

namespace UnityFoundationSamples.UnityFoundation.Code
{
    public class LerpByAngleDemo : MonoBehaviour
    {
        [SerializeField] private Transform start;
        [SerializeField] private Transform end;
        [SerializeField] private Transform referenceObject;
        private Transform referenceObject2;

        private LerpAngle lerp;
        private LerpAngle lerp2;

        private float radius;
        private Vector3 center;

        public void Awake()
        {
            lerp = new LerpAngle(startValue: 0f) { Looping = true, InterpolationSpeed = 20f };
            lerp.SetEndValue(180f);

            lerp2 = new LerpAngle(startValue: 0f) {
                Looping = true,
                CheckMinPath = false,
                InterpolationSpeed = 30f
            };
            lerp2.SetEndValue(360f);

            start = transform.FindTransform("start");
            end = transform.FindTransform("end");
            referenceObject = transform.FindTransform("reference_object");
            referenceObject2 = transform.FindTransform("reference_object_2");

            radius = Vector3.Distance(start.position, end.position) / 2f;

            var centerObj = transform.FindTransform("center");
            center = Vector3Utils.Center(start.position, end.position);
            centerObj.position = center;
        }

        public void Update()
        {
            UpdateReferenceObject(lerp, referenceObject);
            UpdateReferenceObject(lerp2, referenceObject2);
        }

        private void UpdateReferenceObject(LerpAngle lerp, Transform obj)
        {
            var radians = Mathf.PI * lerp.EvalAngle(Time.deltaTime) / 180f;
            var pX = radius * Mathf.Sin(radians) + center.x;
            var pY = radius * Mathf.Cos(radians) + center.y;

            var newPosition = new Vector3(pX, pY, start.position.z);

            obj.position = newPosition;
        }
    }
}