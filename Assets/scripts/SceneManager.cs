using UnityEngine;
using UnityEngine.UI;

namespace SlotProject
{

    public class SceneManager : MonoBehaviour
    {

        private enum ButtonType
        {

            LEVER,

            LEFT_BUTTON,

            CENTER_BUTTON,

            RIGHT_BUTTON,

        }

        private ReelService reelService;

        [SerializeField] ButtonType buttonType;

        public SceneManager()
        {
            this.reelService = new ReelService();
        }

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
                case ButtonType.LEVER:
                    this.HandlePullLever();
                    break;
                case ButtonType.LEFT_BUTTON:
                    this.HandlePushLeftButton();
                    break;
                case ButtonType.CENTER_BUTTON:
                    this.HandlePushCenterButton();
                    break;
                case ButtonType.RIGHT_BUTTON:
                    this.HandlePushRightButton();
                    break;
            }
        }

        // レバーを下げた
        public void HandlePullLever()
        {
            Debug.Log("レバーだよ");
            this.reelService.startSpinning(0);
        }

        // 左ボタンを押した
        public void HandlePushLeftButton()
        {
            Debug.Log("左ボタンだよ");
        }

        // 中央ボタンを押した
        public void HandlePushCenterButton()
        {
            Debug.Log("中央ボタンだよ");
        }

        // 右ボタンを押した
        public void HandlePushRightButton()
        {
            Debug.Log("右ボタンだよ");
        }

    }

}
