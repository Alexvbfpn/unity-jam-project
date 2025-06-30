using UnityEngine;

namespace PlayerBehaviour
{
    public class PlayerAudio : MonoBehaviour
    {
        [Header("Audio Clips")]
        public AudioClip killClip;

        public AudioClip[] turnClips; // Optional: Array of turn clips for random selection
        
        [Header("Audio Sources")]
        public AudioSource audioSource;

        protected Player m_player;
        
        protected AudioSource _audioSource;
        
        protected virtual void InitializePlayer() => m_player = GetComponent<Player>();

        protected virtual void InitializeAudio()
        {
            if (!TryGetComponent(out _audioSource))
            {
                _audioSource = gameObject.AddComponent<AudioSource>();
            }
        }
        
        private void Awake()
        {
            if (audioSource == null)
            {
                audioSource = GetComponent<AudioSource>();
            }
            InitializeAudio();
        }

        private void Start()
        {
            InitializePlayer();
        
            m_player.OnPlayerTurn.AddListener(() => PlayRandom(turnClips));
            m_player.Health.OnPlayerDied.AddListener(PlayKillSound);
        }

        protected virtual void Play(AudioClip audio, bool stopPrevious = true)
        {
            if(audio == null) 
                return;
            
            if(stopPrevious)
                _audioSource.Stop();
            
            _audioSource.PlayOneShot(audio);
        }

        protected virtual void PlayRandom(AudioClip[] clips)
        {
            if (clips != null && clips.Length > 0)
            {
                var index = Random.Range(0, clips.Length);
                
                if(clips[index])
                    Play(clips[index]);
            }
        }
        
        private void PlayKillSound()
        {
            if (killClip != null)
            {
                _audioSource.PlayOneShot(killClip);
            }
        }
    }
}