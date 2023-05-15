using UnityEngine;
using UnityFoundation.Code;

namespace UnityFoundationSamples.UnityFoundation.Code
{
    public class QuadraticLerpDemo : MonoBehaviour
    {
        [SerializeField] private GameObject start;
        [SerializeField] private GameObject mid;
        [SerializeField] private GameObject end;

        [SerializeField] private GameObject refObject;

        private float interpolationAmount = 0f;

        public void Update()
        {
            interpolationAmount += Time.deltaTime;

            if(interpolationAmount >= 1f)
                interpolationAmount = 0f;

            refObject.transform.position = LinearInterpolation.Quadratic(
                start.transform.position,
                mid.transform.position,
                end.transform.position,
                interpolationAmount
            );
        }
    }
}