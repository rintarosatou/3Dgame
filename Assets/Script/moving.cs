using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving : MonoBehaviour
{
    //物のスピード
    public int speed;
    //rigidbodyを保持する変数
    private Rigidbody rb;
    //スタートポジション
    private Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        //初期位置
        startPos = transform.position;
        // Rigidbody コンポーネントを取得
        rb = GetComponent<Rigidbody>();

    }

    // 一定の時間間隔で呼ばれる（物理演算用）
    //物理演算（Physics）は、固定時間間隔で処理されています。だから void FixedUpdate()
    void FixedUpdate()
    {
        // PingPong 関数で X座標を往復移動させる
        // Time.time * speed で移動スピードを制御
        // 40f は移動距離の範囲（0〜40）を指定
        float posX = startPos.x + Mathf.PingPong(Time.time * speed, 40f);
        // Rigidbody を使って位置を更新（YとZは初期位置のまま）
        rb.MovePosition(new Vector3(posX, startPos.y, startPos.z));
    }
}
