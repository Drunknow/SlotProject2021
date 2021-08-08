using UnityEngine;

namespace SlotProject
{

    public class ReelFactory : MonoBehaviour
    {

        private SymbolTypeEnum[] leftSymbols;
        private SymbolTypeEnum[] centerSymbols;
        private SymbolTypeEnum[] rightSymbols;

        [SerializeField] ReelModel leftReel;
        [SerializeField] ReelModel centerReel;
        [SerializeField] ReelModel rightReel;

        public ReelFactory()
        {
            const int SYMBOL_LENGTH = 21;

            // 左リールの図柄を定義
            this.leftSymbols = new SymbolTypeEnum[SYMBOL_LENGTH] {
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

            // 中央リールの図柄を定義
            this.centerSymbols = new SymbolTypeEnum[SYMBOL_LENGTH] {
                SymbolTypeEnum.FULLHD,
                SymbolTypeEnum.BELL,
                SymbolTypeEnum.WATERMELON,
                SymbolTypeEnum.REPLAY,
                SymbolTypeEnum.TRASH,
                SymbolTypeEnum.BELL,
                SymbolTypeEnum.REPLAY,
                SymbolTypeEnum.CHERRY,
                SymbolTypeEnum.SEVEN,
                SymbolTypeEnum.BELL,
                SymbolTypeEnum.REPLAY,
                SymbolTypeEnum.WATERMELON,
                SymbolTypeEnum.BAR,
                SymbolTypeEnum.REPLAY,
                SymbolTypeEnum.BELL,
                SymbolTypeEnum.REPLAY,
                SymbolTypeEnum.BELL,
                SymbolTypeEnum.WATERMELON,
                SymbolTypeEnum.SEVEN,
                SymbolTypeEnum.REPLAY,
                SymbolTypeEnum.BELL,
            };

            // 右リールの図柄一覧を定義
            this.rightSymbols = new SymbolTypeEnum[SYMBOL_LENGTH] {
                SymbolTypeEnum.FULLHD,
                SymbolTypeEnum.BELL,
                SymbolTypeEnum.BELL,
                SymbolTypeEnum.REPLAY,
                SymbolTypeEnum.WATERMELON,
                SymbolTypeEnum.REPLAY,
                SymbolTypeEnum.CHERRY,
                SymbolTypeEnum.BELL,
                SymbolTypeEnum.SEVEN,
                SymbolTypeEnum.BAR,
                SymbolTypeEnum.BELL,
                SymbolTypeEnum.REPLAY,
                SymbolTypeEnum.WATERMELON,
                SymbolTypeEnum.BELL,
                SymbolTypeEnum.CHERRY,
                SymbolTypeEnum.BAR,
                SymbolTypeEnum.REPLAY,
                SymbolTypeEnum.WATERMELON,
                SymbolTypeEnum.BELL,
                SymbolTypeEnum.TRASH,
                SymbolTypeEnum.REPLAY,
            };
        }

        public ReelModel create(ReelTypeEnum reelType)
        {
            switch (reelType)
            {
                case ReelTypeEnum.LEFT:
                    this.leftReel.SetSymbols(this.leftSymbols);
                    return this.leftReel;

                case ReelTypeEnum.CENTER:
                    this.centerReel.SetSymbols(this.centerSymbols);
                    return this.centerReel;

                case ReelTypeEnum.RIGHT:
                    this.rightReel.SetSymbols(this.rightSymbols);
                    return this.rightReel;

                default:
                    // FIXME: null返すと怒られるので
                    return this.leftReel;
            }
        }

    }

}
