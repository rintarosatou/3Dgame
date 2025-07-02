using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class gamemanager : MonoBehaviour
{
    public void StartButton()// スタートボタンが押されたときに呼ばれる処理
    {
        SceneManager.LoadScene("GameScenes");// "GameScenes" という名前のシーンを読み込む（ゲーム開始）
    }
    public void RetryButton()// リトライボタンが押されたときに呼ばれる処理
    {
        SceneManager.LoadScene("GameScenes");// 同じく "GameScenes" シーンを再読み込み（リトライ処理）
    }
    public void TitleButton()// タイトルに戻るボタンが押されたときに呼ばれる処理
    {
        SceneManager.LoadScene("Title");// 同じく "GameScenes" シーンを再読み込み（タイトルに戻る処理）
    }
}
