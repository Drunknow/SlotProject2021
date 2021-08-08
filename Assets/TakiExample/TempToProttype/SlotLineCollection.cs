using SlotProject;

public class SlotLineCollection
{

    public DisplayedSymbolTypeEnum[][] slotLineCollection;

    public SlotLineCollection()
    {
        slotLineCollection = new DisplayedSymbolTypeEnum[5][];

        slotLineCollection[0] =
            new DisplayedSymbolTypeEnum[]
            {
                DisplayedSymbolTypeEnum.TOP,
                DisplayedSymbolTypeEnum.TOP,
                DisplayedSymbolTypeEnum.TOP
            };

        slotLineCollection[1] =
            new DisplayedSymbolTypeEnum[]
            {
                DisplayedSymbolTypeEnum.CENTER,
                DisplayedSymbolTypeEnum.CENTER,
                DisplayedSymbolTypeEnum.CENTER
            };


        slotLineCollection[2] =
            new DisplayedSymbolTypeEnum[]
            {
                    DisplayedSymbolTypeEnum.UNDER,
                    DisplayedSymbolTypeEnum.UNDER,
                    DisplayedSymbolTypeEnum.UNDER
            };

        slotLineCollection[3] =
            new DisplayedSymbolTypeEnum[]
            {
                    DisplayedSymbolTypeEnum.TOP,
                    DisplayedSymbolTypeEnum.CENTER,
                    DisplayedSymbolTypeEnum.UNDER
            };


        slotLineCollection[4] =
            new DisplayedSymbolTypeEnum[]
            {
                    DisplayedSymbolTypeEnum.UNDER,
                    DisplayedSymbolTypeEnum.CENTER,
                    DisplayedSymbolTypeEnum.TOP
            };

    }

}
