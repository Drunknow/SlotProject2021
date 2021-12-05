using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerialReceive : MonoBehaviour
{
  //先ほど作成したクラス
  public SerialHandler serialHandler;
  public string[] data;

  void Start()
  {
     //信号を受信したときに、そのメッセージの処理を行う
     serialHandler.OnDataReceived += OnDataReceived;
  }

  void Update()
  {
    //文字列を送信
   // serialHandler.Write("hogehoge");
  }

    //受信した信号(message)に対する処理
    public void OnDataReceived(string message)
    {
        data = message.Split(
                new string[]{"\t"}, System.StringSplitOptions.None);

                Debug.Log(data);
        /*if (data == 1){
            sceneManager.HandlePullLever();
        }*/

        if (data.Length < 2) return;

        try {

        } catch (System.Exception e) {
            Debug.LogWarning(e.Message);
        }
    }
}
