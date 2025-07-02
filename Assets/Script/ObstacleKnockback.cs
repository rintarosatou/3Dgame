using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleKnockback : MonoBehaviour
{
    [Header("吹っ飛ばす力")]
    [SerializeField] private float knockbackForce = 100f;

    private void OnCollisionEnter(Collision collision)
    {
        // 衝突したオブジェクトのタグが "Player" かどうかチェック
        if (collision.gameObject.CompareTag("Player"))
        {
            // 衝突相手に Rigidbody があるか調べて取得
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            if (rb != null) // Rigidbody がちゃんと存在していれば
            {
                // 吹っ飛ばす方向を計算（自分から相手への方向ベクトル）
                Vector3 direction = (collision.transform.position - transform.position).normalized;

                // Y方向にも少し力を加えて、空中に浮かせる感じに
                direction.y = 0.5f;

                // デバッグログで方向と力を確認
                Debug.Log($"吹っ飛ぶ方向: {direction}, 力: {direction * knockbackForce}");

                // Rigidbody に力を加えて吹っ飛ばす（Impulse = 一瞬の強い力）
                rb.AddForce(direction * knockbackForce, ForceMode.Impulse);
            }
        }
    }
}
