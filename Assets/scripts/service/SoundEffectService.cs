using UnityEngine;

namespace SlotProject
{

    public class SoundEffectService : MonoBehaviour
    {

        [SerializeField] AudioSource leverSoundSource;

        [SerializeField] AudioSource buttonSoundSource;

        [SerializeField] AudioSource bigSoundSource;

        [SerializeField] AudioSource fullhdSoundSource;

        // レバーを押したとき
        public void PlayLeverSound()
        {
            this.leverSoundSource.Play();
        }

        // ボタンを押したとき
        public void PlayButtonSound()
        {
            this.buttonSoundSource.Play();
        }

        // 7が揃ったとき
        public void PlayBigSound()
        {
            this.bigSoundSource.Play();
        }

        // FULLHDが揃ったとき
        public void PlayFullhdSound()
        {
            this.fullhdSoundSource.Play();
        }

    }

}
