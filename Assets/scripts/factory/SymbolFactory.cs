using UnityEngine;

namespace SlotProject
{

    public class SymbolFactory
    {

        public Sprite create(SymbolTypeEnum symbolType)
        {
            return Resources.Load<Sprite>($"sprites/{symbolType.ToString().ToLower()}");
        }

    }

}
