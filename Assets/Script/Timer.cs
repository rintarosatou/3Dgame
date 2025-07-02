using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // TextMeshPro の名前空間

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Text → TextMeshProUGUI に変更
    public TextMeshProUGUI bestTimeText;     // ベストタイム表示用
    private float time = 0f;// 実際にカウントしている時間（秒）
    private bool isRunning = true;// タイマーが動いているかどうか（falseで停止）
    private const string BEST_TIME_KEY = "BestTime"; // PlayerPrefs に保存するキー名（固定）

    void Start()
    {
        // 保存されたベストタイムを読み込んで表示
        if (PlayerPrefs.HasKey(BEST_TIME_KEY))
        {
            // 保存されていた場合、値を取得して表示
            float best = PlayerPrefs.GetFloat(BEST_TIME_KEY);
            if (bestTimeText != null)
                bestTimeText.text = "Best: " + best.ToString("F2") + "s";// 小数点以下2桁で表示
        }
        else
        {
            // 初回などでまだ保存がない場合は "--" と表示
            if (bestTimeText != null)
                bestTimeText.text = "Best: --";
        }
    }

    void Update()
    {
        if (isRunning)
        {
            // 経過時間を加算（Time.deltaTime = 前フレームからの経過秒数）
            time += Time.deltaTime;

            // UIに現在の時間を表示（小数点以下2桁）
            if (timerText != null)
                timerText.text = time.ToString("F2"); // 小数点以下2桁表示
        }
    }

    // ゴール時に呼び出す用
    public void stopTimer()
    {
        isRunning = false;// タイマーを止める

        // 以前のベストタイムを取得（初回は非常に大きい数で初期化）
        float best = PlayerPrefs.GetFloat(BEST_TIME_KEY, float.MaxValue); // 初回は非常に大きい数で初期化
        // 今回のタイムがベストより速ければ更新
        if (time < best)
        {
            PlayerPrefs.SetFloat(BEST_TIME_KEY, time);// 新しいベストタイムを保存
            PlayerPrefs.Save();// 実際に保存されるのはこのタイミング
            // UIにも新しいベストタイムを表示
            if (bestTimeText != null)
                bestTimeText.text = "Best: " + time.ToString("F2") + "s";
        }
    }
    // ベストタイムをリセットする関数（ボタンから呼び出す）
    public void ResetBestTime()
    {
        // 保存されたベストタイムを削除
        PlayerPrefs.DeleteKey(BEST_TIME_KEY);
        PlayerPrefs.Save();

        // 表示を更新（"--" に戻す）
        if (bestTimeText != null)
            bestTimeText.text = "Best: --";

        Debug.Log("ベストタイムをリセットしました");
    }
}
