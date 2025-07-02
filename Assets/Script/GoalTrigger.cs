using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    public Timer TimerController; // タイマー制御スクリプト（Timer.cs）を Inspector でアタッチする

    // ゴールのトリガーに他のオブジェクトが入ったときに呼ばれる
    private void OnTriggerEnter(Collider other)
    {
        // 入ってきたオブジェクトのタグが "player" のとき
        if (other.CompareTag("player"))
        {
            TimerController.stopTimer();//タイマー停止
        }
    }
}
