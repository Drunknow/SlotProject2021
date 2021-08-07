using UnityEngine;
using UnityEngine.UI;

namespace SlotProject
{

    public class SceneManager : MonoBehaviour
    {

        [SerializeField] ReelService reelService;

        [SerializeField] CoinService coinService;

        [SerializeField] SoundEffectService soundEffectService;

        [SerializeField] ButtonTypeEnum buttonType;

        public void Start()
        {
            // ボタンを押した時に実行するメソッドを設定
            this.GetComponent<Button>().onClick.AddListener(HandlePushButton);
        }

        // 何かしらのボタンが押された
        public void HandlePushButton()
        {
            switch (this.buttonType)
            {
                case ButtonTypeEnum.LEVER:
                    this.HandlePullLever();
                    break;
                case ButtonTypeEnum.LEFT:
                    this.HandlePushLeftButton();
                    break;
                case ButtonTypeEnum.CENTER:
                    this.HandlePushCenterButton();
                    break;
                case ButtonTypeEnum.RIGHT:
                    this.HandlePushRightButton();
                    break;
            }
        }

        // レバーを下げた
        public void HandlePullLever()
        {
            if (this.reelService.IsAllReelStop() && this.coinService.canInsertCredit())
            {
                this.soundEffectService.PlayLeverSound();
                this.coinService.InsertCredit();
                this.reelService.startAll();
            }
        }

        // 左ボタンを押した
        public void HandlePushLeftButton()
        {
            this.soundEffectService.PlayButtonSound();
            this.reelService.StopSpinning(ReelTypeEnum.LEFT);
            this.coinService.GivePayout(this.reelService.GetObtainedSymbol());
        }

        // 中央ボタンを押した
        public void HandlePushCenterButton()
        {
            this.soundEffectService.PlayButtonSound();
            this.reelService.StopSpinning(ReelTypeEnum.CENTER);
            this.coinService.GivePayout(this.reelService.GetObtainedSymbol());
        }

        // 右ボタンを押した
        public void HandlePushRightButton()
        {
            this.soundEffectService.PlayButtonSound();
            this.reelService.StopSpinning(ReelTypeEnum.RIGHT);
            this.coinService.GivePayout(this.reelService.GetObtainedSymbol());
        }

    }

}
