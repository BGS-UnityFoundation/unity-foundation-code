using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UnityFoundation.Code.Timer.Sample
{
    public class TimerDisplay : MonoBehaviour
    {
        ITimer timer;
        TextMeshProUGUI valueText;

        public void Awake()
        {
            valueText = transform.FindComponent<TextMeshProUGUI>("value");
        }

        public void Setup(ITimer timer, Action start = null)
        {
            this.timer = timer;

            if(start != null)
            {
                var button = transform.FindComponent<Button>("start");
                button.onClick.RemoveAllListeners();
                button.onClick.AddListener(() => start());
            }
        }

        public void Update()
        {
            if(timer == null) return;
            if(!timer.IsRunning) return;
            valueText.text = $"{timer.RemainingTime:0.00} / {timer.TotalTime:0.00}";
        }
    }
}