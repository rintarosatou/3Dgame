using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleKnockback : MonoBehaviour
{
    [Header("������΂���")]
    [SerializeField] private float knockbackForce = 100f;

    private void OnCollisionEnter(Collision collision)
    {
        // �Փ˂����I�u�W�F�N�g�̃^�O�� "Player" ���ǂ����`�F�b�N
        if (collision.gameObject.CompareTag("Player"))
        {
            // �Փˑ���� Rigidbody �����邩���ׂĎ擾
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            if (rb != null) // Rigidbody �������Ƒ��݂��Ă����
            {
                // ������΂��������v�Z�i�������瑊��ւ̕����x�N�g���j
                Vector3 direction = (collision.transform.position - transform.position).normalized;

                // Y�����ɂ������͂������āA�󒆂ɕ������銴����
                direction.y = 0.5f;

                // �f�o�b�O���O�ŕ����Ɨ͂��m�F
                Debug.Log($"������ԕ���: {direction}, ��: {direction * knockbackForce}");

                // Rigidbody �ɗ͂������Đ�����΂��iImpulse = ��u�̋����́j
                rb.AddForce(direction * knockbackForce, ForceMode.Impulse);
            }
        }
    }
}
