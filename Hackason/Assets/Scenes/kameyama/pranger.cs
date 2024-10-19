using UnityEngine;

public class Plunger : MonoBehaviour
{
    public Rigidbody ball;              // ボールのRigidbody
    public Transform plungerStartPos;   // プランジャーの初期位置
    public float maxPullDistance = 2.0f; // プランジャーの最大引き距離
    public float launchForce = 500.0f;   // ボールに加える力
    private float currentPull = 0f;     // 現在の引き具合
    private bool isPulling = false;     // 引いているかどうか

    void Update()
    {
        // プレイヤーが引いているかチェック
        if (Input.GetKey(KeyCode.Space))
        {
            isPulling = true;
            currentPull += Time.deltaTime;
            currentPull = Mathf.Clamp(currentPull, 0, maxPullDistance);
            
            // プランジャーを引く位置に移動
            Vector3 newPos = plungerStartPos.position - new Vector3(0, currentPull, 0);
            transform.position = newPos;
        }
        
        // 入力を離したときにボールを発射
        if (Input.GetKeyUp(KeyCode.Space))
        {
            LaunchBall();
            ResetPlunger();
        }
    }

    void LaunchBall()
    {
        // 引いた距離に基づいてボールに力を加える
        float force = launchForce * (currentPull / maxPullDistance);
        ball.AddForce(Vector3.up * force); // ボールを上向きに発射
    }

    void ResetPlunger()
    {
        // プランジャーを初期位置に戻す
        transform.position = plungerStartPos.position;
        currentPull = 0f;
        isPulling = false;
    }
}

