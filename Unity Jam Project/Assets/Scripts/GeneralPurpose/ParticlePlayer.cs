using System;
using UnityEngine;

namespace GeneralPurpose
{
    public class ParticlePlayer : MonoBehaviour
    {
        /// <summary>
        /// Start playing a given particle
        /// </summary>
        /// <param name="particle">The particle you want to play.</param>
        public virtual void Play(ParticleSystem particle)
        {
            if (!particle.isPlaying)
            {
                particle.Play();
            }
            else
            {
                Stop(particle);
                particle.Play();
            }
        }

        /// <summary>
        /// Stop playing a given particle
        /// </summary>
        /// <param name="particle"></param>
        public virtual void Stop(ParticleSystem particle, bool clear = false)
        {
            if (particle.isPlaying)
            {
                var mode = clear
                    ? ParticleSystemStopBehavior.StopEmittingAndClear
                    : ParticleSystemStopBehavior.StopEmitting;
                particle.Stop(true, mode);
            }
        }

        public virtual void InitializeEvents() { }

        public virtual void Start()
        {
            InitializeEvents();
        }
    }
}