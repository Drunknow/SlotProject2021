using UnityEngine;

namespace SlotProject
{

    public class ReelFactory : MonoBehaviour
    {

        [SerializeField] ReelModel leftReel;
        [SerializeField] ReelModel centerReel;
        [SerializeField] ReelModel rightReel;

        public void Start()
        {
            const int SYMBOL_LENGTH = 21;

            // 左リールの図柄を定義
            SymbolTypeEnum[] leftSymbols = new SymbolTypeEnum[SYMBOL_LENGTH] {
                SymbolTypeEnum.BELL,
                SymbolTypeEnum.FULLHD,
                SymbolTypeEnum.WATERMELON,
                SymbolTypeEnum.REPLAY,
                SymbolTypeEnum.BELL,
                SymbolTypeEnum.BAR,
                SymbolTypeEnum.CHERRY,
                SymbolTypeEnum.SEVEN,
                SymbolTypeEnum.REPLAY,
                SymbolTypeEnum.BELL,
                SymbolTypeEnum.WATERMELON,
                SymbolTypeEnum.REPLAY,
                SymbolTypeEnum.BELL,
                SymbolTypeEnum.CHERRY,
                SymbolTypeEnum.REPLAY,
                SymbolTypeEnum.TRASH,
                SymbolTypeEnum.BELL,
                SymbolTypeEnum.SEVEN,
                SymbolTypeEnum.WATERMELON,
                SymbolTypeEnum.REPLAY,
                SymbolTypeEnum.BELL,
            };
            this.leftReel.SetSymbols(leftSymbols);

            // 中央リールの図柄を定義
            SymbolTypeEnum[] centerSymbols = new SymbolTypeEnum[SYMBOL_LENGTH] {
                SymbolTypeEnum.BELL,
                SymbolTypeEnum.FULLHD,
                SymbolTypeEnum.WATERMELON,
                SymbolTypeEnum.REPLAY,
                SymbolTypeEnum.BELL,
                SymbolTypeEnum.BAR,
                SymbolTypeEnum.CHERRY,
                SymbolTypeEnum.SEVEN,
                SymbolTypeEnum.REPLAY,
                SymbolTypeEnum.BELL,
                SymbolTypeEnum.WATERMELON,
                SymbolTypeEnum.REPLAY,
                SymbolTypeEnum.BELL,
                SymbolTypeEnum.CHERRY,
                SymbolTypeEnum.REPLAY,
                SymbolTypeEnum.TRASH,
                SymbolTypeEnum.BELL,
                SymbolTypeEnum.SEVEN,
                SymbolTypeEnum.WATERMELON,
                SymbolTypeEnum.REPLAY,
                SymbolTypeEnum.BELL,
            };
            this.centerReel.SetSymbols(centerSymbols);

            // 右リールの図柄一覧を定義
            SymbolTypeEnum[] rightSymbols = new SymbolTypeEnum[SYMBOL_LENGTH] {
                SymbolTypeEnum.FULLHD,
                SymbolTypeEnum.BELL,
                SymbolTypeEnum.BELL,
                SymbolTypeEnum.WATERMELON,
                SymbolTypeEnum.REPLAY,
                SymbolTypeEnum.BELL,
                SymbolTypeEnum.CHERRY,
                SymbolTypeEnum.REPLAY,
                SymbolTypeEnum.SEVEN,
                SymbolTypeEnum.BAR,
                SymbolTypeEnum.BELL,
                SymbolTypeEnum.REPLAY,
                SymbolTypeEnum.WATERMELON,
                SymbolTypeEnum.BELL,
                SymbolTypeEnum.CHERRY,
                SymbolTypeEnum.BAR,
                SymbolTypeEnum.REPLAY,
                SymbolTypeEnum.TRASH,
                SymbolTypeEnum.BELL,
                SymbolTypeEnum.WATERMELON,
                SymbolTypeEnum.REPLAY,
            };
            this.rightReel.SetSymbols(rightSymbols);

        }
        public ReelModel create(ReelTypeEnum reelType)
        {
            switch (reelType)
            {
                case ReelTypeEnum.LEFT:
                    return this.leftReel;

                case ReelTypeEnum.CENTER:
                    return this.centerReel;

                case ReelTypeEnum.RIGHT:
                    return this.rightReel;

                default:
                    // FIXME: null返すと怒られるので
                    return this.leftReel;
            }
        }

    }

}
