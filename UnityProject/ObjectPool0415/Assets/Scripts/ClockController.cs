    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class ClockController : MonoBehaviour
    {
        [Range(0,23)]
        public int hour;
        [Range(0,59)]
        public int minute;
        
        private Transform hourTransform;
        private Transform minutetTransform;
        private int preHour = -1;
        private int preMinute = -1;
        
        
        private void Start()
        {
            hourTransform = transform.GetChild(1);
            minutetTransform = transform.GetChild(0);

        }

        private void Update()
        {
            if (preHour != hour)
            {
                UpdateHour();
                preHour = hour;
            }

            if (preMinute != minute)
            {
                UpdateMinute();
                preMinute = minute;
            }
        }

        private void UpdateHour()
        {
            //1시간당 30도 회전
            //-90 = 0시
            //0 = 3시
            float angle = ((hour % 12) - 3) * 30;
            hourTransform.localRotation = Quaternion.Euler(0, angle, 0);
        }

        private void UpdateMinute()
        {
            //1분당 360/60 = 6도 회전
            //-90도 = 0분
            //0도 = 15분
            float angle = (minute - 15) * 6;
            minutetTransform.localRotation = Quaternion.Euler(0, angle, 0);
        }
        
        
        
    }
