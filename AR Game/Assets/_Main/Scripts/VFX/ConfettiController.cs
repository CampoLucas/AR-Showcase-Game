using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace AR.UI.VFX
{
    public class ConfettiController : MonoBehaviour
    {
        public Action OnPlay;
        public Action OnStop;
        
        [FormerlySerializedAs("particleSystem")] [SerializeField] private ParticleSystem particle;

        public bool IsPlaying() => particle.isPlaying;
        
        public void Play()
        {
            OnPlay?.Invoke();
            particle.Play();
        }

        public void Stop()
        {
            OnStop?.Invoke();
            particle.Stop();
        }

        public void Pause()
        {
            particle.Pause();
        }

        private void OnDestroy()
        {
            OnPlay = null;
            OnStop = null;
        }
    }
}
