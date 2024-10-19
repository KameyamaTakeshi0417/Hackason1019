using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Banper : MonoBehaviour {

	/*
	 * 変数の提議
	*/
	public GameObject ball; // ボールのゲームオブジェクト 
	private Rigidbody ballRb;// ボールのリジッドボディー
	float pinPower; // ピンの弾く力

	float angle = 20f; //ピンボール版の傾き

	// 右フリッパー
	public GameObject RightFlipper; // 右フリッパーゲームオブジェクト
	public Vector3 springR; // スプリングの強さ （右）
	public float openAngleR; // 左
	public float closeAngleR;
	private HingeJoint hjR;
    private ConstantForce cfR;

	// 左フリッパー
	public GameObject LeftFlipper;
	public Vector3 springL;
	public float openAngleL;
	public float closeAngleL;
	private HingeJoint hjL;
    private ConstantForce cfL;

	// フリッパー制御用
	bool LFlipperTF, RFlipperTF;


	// 画面が生成（表示）されるときに呼ばれます
	void Start () {
		
		/*
		 * 変数の初期化
		*/

		// ボール
		// ball.transform.position = new Vector3(11.0f, 16.5f, 0f);	// ピンOBJの初期化
		ballRb = ball.GetComponent<Rigidbody> ();	// ボールのリジッドボディーを格納
		pinPower = 5f;	// 弾きの強さを初期化

		// 右フリッパー
		hjR = RightFlipper.GetComponent<HingeJoint>();
        cfR = RightFlipper.GetComponent<ConstantForce>();
		JointLimits limitsR = hjR.limits;
		limitsR.max = openAngleR;
		limitsR.min = closeAngleR;
		hjR.limits = limitsR;
		hjR.useLimits = true;
		// 左フリッパー
		hjL = LeftFlipper.GetComponent<HingeJoint>();
        cfL = LeftFlipper.GetComponent<ConstantForce>();
		JointLimits limitsL = hjL.limits;
		limitsL.max = openAngleL;
		limitsL.min = closeAngleL;
		hjL.limits = limitsL;
		hjL.useLimits = true;
		// フリッパー制御よう変数
		LFlipperTF = false;
		RFlipperTF = false;


	}
	
	// 画面が更新される各フレームごとによばれます
	void Update () {

		// リターン(Return)キーをクリックすると
		if (Input.GetKeyUp (KeyCode.Return)) {
			
			Debug.Log ("x,y=" + xVector(angle) + "," + yVector(angle));

			// ピンボール台の傾き（20度）に合わせたベクトルを計算
			Vector3 Pos1 = new Vector3 (xVector(angle), yVector(angle) ,0f);
			// ボールに力を加える
			ballRb.AddForce (Pos1*pinPower*105f);
		}

		// ピンボールに
		if (Input.GetKey (KeyCode.A)) {
			LFlipperTF = true;
			openFlipper(LFlipperTF, RFlipperTF);
		}
		if (Input.GetKey (KeyCode.D)) {
			RFlipperTF = true;
			openFlipper(LFlipperTF, RFlipperTF);
		}
		if (Input.GetKeyUp (KeyCode.A) || Input.GetKeyUp (KeyCode.D)) {
			LFlipperTF = false;
			RFlipperTF = false;
			closeFlipper();
		}

	}

	/*
	 * フリッパー オープン制御メソッド
	*/
	public void openFlipper(bool LF, bool RF){

		if (RF) {
            cfR.force = springR;
			Debug.Log ("FlipperR:" + cfR.force);
		}

		if (LF) {
			cfL.force = springL;
			Debug.Log ("FlipperL" + cfL.force);
		}
	}

	/*
	 * フリッパー クローズ制御メソッド
	*/
	public void closeFlipper(){
		cfR.force = -springR;

		cfL.force = -springL;
	}

	/*
	* 練習のためのメソッド化しています。
	* 頻繁に使うわけでもないので練習でなければ必要はないかもしれません
	*/
	// private メソッドは同じクラス内でのみ呼び出せる
	// メソッドからの値を取得したい場合は、「型」の宣言と「return」文による返り値の指定が必要です。
	private float yVector (float angle) {
		// 角度(angle)に対する、y軸のベクトルを計算します。
		float y = (float)Math.Sin(angle * (Math.PI / 180));
		return y;
	}

	private float xVector (float angle) {
		// 角度(angle)に対する、x軸のベクトルを計算します。
		float x = (float)Math.Cos(angle * (Math.PI / 180));
		return x;
	}


}
