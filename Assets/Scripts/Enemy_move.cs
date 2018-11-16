using UnityEngine;
using System.Collections;

/// 敵
public class Enemy_move : Token
{
  // 生存数
  public static int Count = 0;
  /// 開始
  void Start()
  {
    Count++;

    SetSize(SpriteWidth / 2, SpriteWidth / 2);
    // ランダムな方向に移動する
    // 方向をランダムに決める
    float dir = Random.Range(0, 359);
    // 速さは2
    float spd = 2;
    SetVelocity(dir, spd);
  }

  void Update()
  {
    // カメラの左下座標を取得
    Vector2 min = GetWorldMin();
    // カメラの右上座標を取得
    Vector2 max = GetWorldMax();

    if (X < min.x || max.x < X)
    {
      //画面外に出たので、X移動量を反転する
      VX *= -1;
      //画面内に移動する
      ClampScreen();
    }
    if(Y < min.y || max.y < Y)
    {
      //画面外に出たので、Y移動量を反転する
      VY *= -1;
      // 画面内に移動する
      ClampScreen();
    }
  }

  /// クリックされた
  public void OnMouseDown()
  {
    //生存数をへらす
    Count--;
    // パーティクルを生成
    for (int i = 0; i < 32; i++)
    {
      Particle_move.Add(X, Y);
    }

    // 破棄する
    DestroyObj();
  }

}