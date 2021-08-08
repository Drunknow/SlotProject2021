using System.Collections.Generic;
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

        // 図柄が揃ったとき
        public void PlaySymbolSound(List<SymbolTypeEnum> symbols)
        {
            foreach (SymbolTypeEnum symbol in symbols)
            {

                switch (symbol)
                {
                    case SymbolTypeEnum.SEVEN:
                        this.bigSoundSource.Play();
                        break;
                    case SymbolTypeEnum.FULLHD:
                        this.fullhdSoundSource.Play();
                        break;
                    default:
                        break;
                }
            }
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
