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
            // レバーを押した時の動作を紐付け
            this.GetComponent<Button>().onClick.AddListener(HandlePushButton);
        }

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

        // レバーを下げた時
        public void HandlePullLever()
        {
            Debug.Log("レバーだよ");
            this.reelService.startSpinning(0);
        }

        // 左ボタンを押した時
        public void HandlePushLeftButton()
        {
            Debug.Log("左ボタンだよ");
        }

        // 中央ボタンを押した時
        public void HandlePushCenterButton()
        {
            Debug.Log("中央ボタンだよ");
        }

        // 右ボタンを押した時
        public void HandlePushRightButton()
        {
            Debug.Log("右ボタンだよ");
        }

    }

}
