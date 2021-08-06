namespace SlotProject
{

    public class ReelFactory
    {

        static int SYMBOL_LENGTH = 21;

        public ReelModel create(ReelTypeEnum reelType)
        {
            SymbolTypeEnum[] symbols = new SymbolTypeEnum[SYMBOL_LENGTH];

            switch (reelType)
            {
                case ReelTypeEnum.LEFT:
                    symbols = new SymbolTypeEnum[] {
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
                    break;

                case ReelTypeEnum.CENTER:
                    symbols = new SymbolTypeEnum[] {
                        SymbolTypeEnum.FULLHD,
                        SymbolTypeEnum.BELL,
                        SymbolTypeEnum.WATERMELON,
                        SymbolTypeEnum.REPLAY,
                        SymbolTypeEnum.TRASH,
                        SymbolTypeEnum.BELL,
                        SymbolTypeEnum.REPLAY,
                        SymbolTypeEnum.SEVEN,
                        SymbolTypeEnum.CHERRY,
                        SymbolTypeEnum.REPLAY,
                        SymbolTypeEnum.BELL,
                        SymbolTypeEnum.WATERMELON,
                        SymbolTypeEnum.REPLAY,
                        SymbolTypeEnum.BAR,
                        SymbolTypeEnum.BELL,
                        SymbolTypeEnum.REPLAY,
                        SymbolTypeEnum.BELL,
                        SymbolTypeEnum.WATERMELON,
                        SymbolTypeEnum.SEVEN,
                        SymbolTypeEnum.REPLAY,
                        SymbolTypeEnum.BELL,
                    };
                    break;

                case ReelTypeEnum.RIGHT:
                    symbols = new SymbolTypeEnum[] {
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
                    break;
            }

            return new ReelModel(symbols);
        }

    }

}
