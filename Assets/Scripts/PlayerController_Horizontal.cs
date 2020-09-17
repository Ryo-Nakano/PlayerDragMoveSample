using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController_Horizontal : MonoBehaviour {

    /// <summary>
    /// x軸方向にのみ動く
    /// </summary>

	Vector3 preMousePos;
	[SerializeField] float speed; //指の動きに対してどれくらいPlayerを動かすか

	float limitRightX = 2.6f;
	float limitLeftX = -2.6f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		DragMove (); //指の移動量に応じてPlayerを移動させる関数
	}
		


	//指の移動量に応じてPlayerを移動させる関数
	void DragMove(){

		//タッチした瞬間のマウスの座標をpreMousePosに格納
		if (Input.GetMouseButtonDown (0)) {
			preMousePos = Input.mousePosition;
		}

		if (Input.GetMouseButton (0)) {
			Vector3 deltaMousePos = Input.mousePosition - preMousePos;//マウスの現在位置と直近のマウスの位置(preMousePosの差分をとる)
			//→その差分を変数deltaMousePosに格納

			//preMousePosに現在のマウスの位置を格納(→次のフレームの処理で使う為)
			preMousePos = Input.mousePosition;
            
			this.transform.position += new Vector3(deltaMousePos.x / Screen.width, 0, 0) * speed;
			//Screen.widthを分母に置いているのは、端末毎に異なる画面サイズに適応する為に『画面幅に対してどれだけの割合移動したのか』を算出→speedの値をかけている！


			// 右の移動制限【1242×2208想定】
			if (this.transform.position.x > 2.6f){
				this.transform.position = new Vector3(limitRightX, this.transform.position.y, this.transform.position.z);
			}

			// 左の移動制限【1242×2208想定】
			if (this.transform.position.x < -2.6f){
				this.transform.position = new Vector3(limitLeftX, this.transform.position.y, this.transform.position.z);
			}
		}
	}
		
}
