using UnityEngine;
using UnityEngine.Audio;

namespace Sounds
{
	[System.Serializable]
	public class Sound
	{
		public string name;

		public AudioClip Clip;
		public AudioMixerGroup Mixer;

		[Range(0f, 1f)] public float volume = 1f;

		[Range(-3f, 3f)] public float pitch = 1f;

		public bool isLoop = false;

		[HideInInspector] public AudioSource SoundEffectsSource;
	}

	public class SoundEffectManager : MonoBehaviour
	{

		public static SoundEffectManager InstanceSoundEffectManager;

		public Sound[] SoundEffects;

		private void Awake()
		{
			InstanceSoundEffectManager = this;

			foreach (Sound SoundEffect in SoundEffects)
			{
				SoundEffect.SoundEffectsSource = gameObject.AddComponent<AudioSource>();

				SoundEffect.SoundEffectsSource.clip = SoundEffect.Clip;

				SoundEffect.SoundEffectsSource.outputAudioMixerGroup = SoundEffect.Mixer;

				SoundEffect.SoundEffectsSource.volume = SoundEffect.volume;

				SoundEffect.SoundEffectsSource.pitch = SoundEffect.pitch;

				SoundEffect.SoundEffectsSource.loop = SoundEffect.isLoop;
			}
		}

		public void PlaySoundEffect(string sound)
		{
			Sound SoundEffect = System.Array.Find(SoundEffects, item => item.name == sound);

			SoundEffect.SoundEffectsSource.Play();
		}

		public void Stop(string sound)
		{
			Sound SoundEffect = System.Array.Find(SoundEffects, item => item.name == sound);

			SoundEffect.SoundEffectsSource.Stop();
		}
	}
}
