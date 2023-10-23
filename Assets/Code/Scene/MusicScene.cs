using DG.Tweening;
using UnityEngine;

namespace Code.Scene
{
    public class MusicScene : MonoBehaviour
    {
        [SerializeField] private AudioSource music;
        [SerializeField] private AudioSource dizzMusic;
        [SerializeField] private float musicFadeTime = 1f;

        public void StartDizz()
        {
            ChangeVolume(music, dizzMusic);
        }

        public void StopDizz()
        {
            ChangeVolume(dizzMusic, music);
        }

        private void ChangeVolume(AudioSource currentAudioSource, AudioSource newAudioSource)
        {
            Sequence sequence = DOTween.Sequence();

            sequence.Append(currentAudioSource.DOFade(0f, musicFadeTime));
            sequence.Append(newAudioSource.DOFade(1f, musicFadeTime));

            sequence.Play();
        }
    }
}
