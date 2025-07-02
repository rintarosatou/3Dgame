using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class goal : MonoBehaviour
{
    public Timer TimerController; // タイマー制御用スクリプト（Timer.cs）をInspectorから設定
    public GameObject chara; //Inspectorでキャラクターとゴールオブジェクトの指定をできるようにする。
    public GameObject gameclea; // ゲームクリア時に表示するUI（TextMeshProなど）
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        // もし入ってきたオブジェクトのタグが"Player"なら
        if (other.CompareTag("Player"))
        {
            TimerController.stopTimer();//タイマー停止
        }
        // もし入ってきたオブジェクトの名前がcharaと同じなら
        if (other.name==chara.name)
        {
            //ゲームクリアテキストを表示させてキャラクターを非表示にします。
            gameclea.SetActive(true);
            chara.SetActive(false); // キャラクターの表示をオフ（消す）
        }
    }
}
