using UnityEngine;

public class OBjectBumper : MonoBehaviour
{
    public float bumpForce = 30f;  // バンパーの反射力

    // ボールとの衝突時に呼ばれる
    private void OnCollisionEnter(Collision collision)
    {
        // ボールにRigidbodyがあるか確認
        Rigidbody ballRigidbody = collision.collider.GetComponent<Rigidbody>();

        if (ballRigidbody != null)
        {
            // 反射方向を計算
            Vector3 reflectionDirection = Vector3.Normalize(collision.contacts[0].normal+Vector3.up);

            // 反射力を加える
            ballRigidbody.AddForce(reflectionDirection * bumpForce, ForceMode.Impulse);
        }
    }
}
