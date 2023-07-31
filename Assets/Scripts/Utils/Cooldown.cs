using System;
using UnityEngine;

namespace Utils
{
    [Serializable]
    public class Cooldown
    {
        public float Value = 1f;

        private float _timesUP;

        public void Reset()
        {
            _timesUP = Time.time + Value;
        }

        public bool IsReady => _timesUP <= Time.time;
    }
}