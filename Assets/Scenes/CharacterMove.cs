using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMove : MonoBehaviour
{
  // あらかじめ Animator コンポーネントを持っておくようにする
  private Animator _animator;

  // 最初のフレーム更新の前に開始が呼び出されます
  void Start()
  {
    // オブジェクトに紐付いている Animator を取得する
    _animator = GetComponent<Animator>();

    // 最初の向き (下) を設定する
    _animator.SetFloat("X", 0);
    _animator.SetFloat("Y", -1);
  }

  /// <summary>一定時間ごとに呼ばれるメソッドです。</summary>
  void FixedUpdate()
  {
    // キーボードの入力方向を取得
    var move = GetMove();

    if (move != Vector2.zero)
    {
      // 入力されている場合はアニメーターに方向を設定
      _animator.SetFloat("X", move.x);
      _animator.SetFloat("Y", move.y);

      // 入力した方向に移動
      transform.Translate(move * 0.2f);
    }
  }

  /// <summary>キーボード入力による移動方向を取得します。</summary>
  /// <returns>キーボード入力による移動方向。</returns>
  private Vector2 GetMove()
  {
    Vector2 move = Vector2.zero;
    if (Keyboard.current.upArrowKey.isPressed)
    {
      move += new Vector2(0, 1);
    }
    if (Keyboard.current.downArrowKey.isPressed)
    {
      move += new Vector2(0, -1);
    }
    if (Keyboard.current.leftArrowKey.isPressed)
    {
      move += new Vector2(-1, 0);
    }
    if (Keyboard.current.rightArrowKey.isPressed)
    {
      move += new Vector2(1, 0);
    }

    // 入力した値がある場合は正規化して返す
    return move == Vector2.zero ? move : move.normalized;
  }
}