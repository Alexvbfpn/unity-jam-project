using System;
using GeneralPurpose;
using UnityEngine;

namespace PlayerBehaviour
{
    [RequireComponent(typeof(Player))]
    public class PlayerParticles : ParticlePlayer
    {
        protected Player m_player;

        [Header("Particles")] public ParticleSystem turnParticle;
        public ParticleSystem killParticle;
        public override void InitializeEvents()
        {
            m_player.OnPlayerTurn.AddListener(PlayTurnParticle);
            m_player.Health.OnPlayerDied.AddListener(PlayKillParticle);
        }

        protected void PlayTurnParticle()
        {
            Play(turnParticle);
        }
        
        protected void PlayKillParticle()
        {
            Play(killParticle);
        }
        
        protected void Awake()
        {
            m_player = GetComponent<Player>();
        }
    }
}