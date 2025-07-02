using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class collision : MonoBehaviour
{
    public GameObject gameOverText;
    public GameObject retryButtonObj; // ← GameObjectとしてボタンを持つ

    // Start is called before the first frame update
    void Start()
    {
        if (retryButtonObj != null) // retryButtonObjが正しく設定されているか確認
        {
            Button retryButton = retryButtonObj.GetComponent<Button>(); // ボタンにクリックイベントを登録
            retryButton.onClick.RemoveAllListeners(); // 二重登録防止
            retryButton.onClick.AddListener(ReloadScene); // ボタンクリック時にReloadSceneメソッドを呼ぶように設定


            retryButtonObj.SetActive(false); // ゲーム開始時はリトライボタンを非表示にする
            // Debug.Log("Retryボタン非表示にしました");
        }
        //else
        //{
        //    Debug.LogError("retryButtonObj がアタッチされていません！");
        //}
    }
    void OnCollisionEnter(Collision collision)// オブジェクトが衝突したときに呼ばれるメソッド
    {
        Debug.Log("Collision");// 衝突が発生したことをログに出力
        gameOverText.SetActive(true);// ゲームオーバーテキストを表示
        retryButtonObj.SetActive(true); // ボタンを表示
    }
    void ReloadScene()
    {
        Time.timeScale = 1f;// 一時停止していた場合に時間を元に戻す
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);// 現在のシーンを再読み込み
    }
}
