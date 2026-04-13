using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AR.UI.VFX
{
    public class ConfettiController : MonoBehaviour
    {
        public Action OnPlay;
        public Action OnStop;
        
        [SerializeField] private ParticleSystem particleSystem;

        public bool IsPlaying() => particleSystem.isPlaying;
        
        public void Play()
        {
            OnPlay?.Invoke();
            particleSystem.Play();
        }

        public void Stop()
        {
            OnStop?.Invoke();
            particleSystem.Stop();
        }

        public void Pause()
        {
            particleSystem.Pause();
        }

        private void OnDestroy()
        {
            OnPlay = null;
            OnStop = null;
        }
    }
}
