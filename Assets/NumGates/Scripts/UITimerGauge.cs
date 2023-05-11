using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NumGates.TestBattle;
using UnityEngine.UI;

namespace NumGates
{
    public class UITimerGauge : MonoBehaviour
    {
        [SerializeField] private Slider slider;

        private float smoothTime = 0.3f;
        private float velocity = 0.0f;
        private float maxTimer;
        private float targetTimer;

        // Create UITimerGauge with customize setup
        public static UITimerGauge Create(Vector3 origin, Vector3 offset, float width, float height, float maxTimer)
        {
            UITimerGauge timerGauge = Instantiate(AssetManager.instance.GetUITimerGauge());

            timerGauge.InitTimerGauge(origin, offset, width, height, maxTimer);

            return timerGauge;
        }

        private void InitTimerGauge(Vector3 origin, Vector3 offset, float width, float height, float maxTimer)
        {
            this.maxTimer = maxTimer;

            slider.transform.position = Camera.main.WorldToScreenPoint(origin + offset);
            slider.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);
        }

        public void UpdateTimer(float timer)
        {
            targetTimer = timer / maxTimer;
        }

        private void Update()
        {
            float currentTimer = Mathf.SmoothDamp(slider.value, targetTimer, ref velocity, smoothTime);
            slider.value = currentTimer;
        }
    }

}

