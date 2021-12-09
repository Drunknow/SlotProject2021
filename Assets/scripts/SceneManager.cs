using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace SlotProject
{

    public class SceneManager : MonoBehaviour
    {
        

        [SerializeField] ReelService reelService;

        [SerializeField] CoinService coinService;

        [SerializeField] SoundEffectService soundEffectService;

        [SerializeField] ButtonTypeEnum buttonType;

        public SerialHandler serialHandler;

        

        public void Start()
        {
            // ボタンを押した時に実行するメソッドを設定
            this.GetComponent<Button>().onClick.AddListener(HandlePushButton);

            //serialReceive = this.GetComponent<SerialReceive>();
            Debug.Log(gameObject.name);
            Debug.Log(serialHandler);
            Debug.Log(serialHandler.message_);
            /*if (serialHandler.message_ == "1"){
                this.HandlePullLever();
            }*/

        }

        void Update(){
            //if (buttonType == ButtonTypeEnum.LEVER){
                Debug.Log(serialHandler.message_);
                    if (serialHandler.message_ == "1"){
                        this.HandlePullLever();
                        StartCoroutine(DelayMethod(ReelTypeEnum.LEFT,1));
                        StartCoroutine(DelayMethod(ReelTypeEnum.CENTER,2));
                        StartCoroutine(DelayMethod(ReelTypeEnum.RIGHT,3));
                    }   
            //}
        }

        // ボタンが押された
        public void HandlePushButton()
        {
            switch (this.buttonType)
            {
                case ButtonTypeEnum.LEVER:
                    this.HandlePullLever();
                    break;
                case ButtonTypeEnum.LEFT:
                    this.HandlePushButton(ReelTypeEnum.LEFT);
                    break;
                case ButtonTypeEnum.CENTER:
                    this.HandlePushButton(ReelTypeEnum.CENTER);
                    break;
                case ButtonTypeEnum.RIGHT:
                    this.HandlePushButton(ReelTypeEnum.RIGHT);
                    break;
            }
        }

        // レバーを下げたとき
        public void HandlePullLever()
        {
            if (this.reelService.IsAllReelStop() && this.coinService.canInsertCredit())
            {
                this.soundEffectService.PlayLeverSound();
                this.coinService.InsertCredit();
                this.reelService.startAll();
            }
        }

        // ボタンを押したとき
        public void HandlePushButton(ReelTypeEnum reelType)
        {
            if (!this.reelService.IsReelStop(reelType))
            {
                this.soundEffectService.PlayButtonSound();
                this.reelService.StopSpinning(reelType);

                // 揃った図柄に応じた処理
                List<SymbolTypeEnum> symbols = this.reelService.GetObtainedSymbols();
                this.coinService.GivePayout(symbols);
                this.soundEffectService.PlaySymbolSound(symbols);
            }
        }

        IEnumerator DelayMethod(ReelTypeEnum reelType, int delayTime)
        {
            yield return new WaitForSeconds(delayTime);
            HandlePushButton(reelType);
        }

    }

}
