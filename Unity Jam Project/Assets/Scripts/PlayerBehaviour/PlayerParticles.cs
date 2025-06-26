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
        
        
        public override void InitializeEvents()
        {
            m_player.OnPlayerTurn.AddListener(PlayTurnParticle);
        }

        protected void PlayTurnParticle()
        {
            Play(turnParticle);
        }
        
        protected void Awake()
        {
            m_player = GetComponent<Player>();
        }
    }
}