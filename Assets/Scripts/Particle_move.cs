using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle_move : Token {
 
  /// プレハブ
  static GameObject _prefab = null;
  /// パーティクルの生成
  public static Particle_move Add(float x, float y)
  {
    // プレハブを取得
    _prefab = GetPrefab(_prefab, "Particle");
    // プレハブからインスタンスを生成
    return CreateInstance2<Particle_move>(_prefab, x, y);
  }

	IEnumerator Start() 
	{
		float dir = Random.Range(0,359);
		float spd = Random.Range(10.0f,20.0f);
		SetVelocity(dir, spd);

		while(ScaleX > 0.01f)
		{
			//0.01秒ゲームループに制御を返す
			yield return new WaitForSeconds(0.01f);
			//だんだん小さく
			MulScale(0.9f);
			//だんだん減速
			MulVelocity(0.9f);
		}

		//消滅
		DestroyObj();
	}

	// Update is called once per frame
	void Update () {
		
	}
}
