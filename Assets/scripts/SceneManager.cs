using UnityEngine;
using UnityEngine.UI;

namespace SlotProject
{

    public class SceneManager : MonoBehaviour
    {

        private ReelService reelService;

        [SerializeField] ButtonTypeEnum buttonType;

        public void Start()
        {
            this.reelService = new ReelService();

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
            Debug.Log("レバーだよ");
            this.reelService.StartSpinning(0);
        }

        // 左ボタンを押した
        public void HandlePushLeftButton()
        {
            Debug.Log("左ボタンだよ");
            this.reelService.StopSpinning(ReelTypeEnum.LEFT);
        }

        // 中央ボタンを押した
        public void HandlePushCenterButton()
        {
            Debug.Log("中央ボタンだよ");
            this.reelService.StopSpinning(ReelTypeEnum.CENTER);
        }

        // 右ボタンを押した
        public void HandlePushRightButton()
        {
            Debug.Log("右ボタンだよ");
            this.reelService.StopSpinning(ReelTypeEnum.RIGHT);
        }

    }

}
