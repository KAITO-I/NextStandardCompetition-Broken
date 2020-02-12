using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // 物理演算
    Rigidbody2D rb2d;

    // 開始条件
    [SerializeField]
    bool startInSky = false;

    // 移動
    [Header("Move")]
    [SerializeField]
    bool smoothMove;
    [SerializeField]
    float moveSpeed;
    [SerializeField]
    float decelerationRate;

    public enum MoveDirection
    {
        Left  = -1,
        Right = 1
    }

    float speed;
    MoveDirection moveDir;

    // ジャンプ
    [Header("Jump")]
    [SerializeField]
    float jumpPower;

    public bool IsJumping { get; private set; }

    // 重力
    [Header("Gravity")]
    [SerializeField]
    float gravityScale;
    [SerializeField]
    float maxGravity;

    float gravity;

    void Start()
    {
        this.rb2d = GetComponent<Rigidbody2D>();

        this.speed = 0f;

        this.IsJumping = this.startInSky;
        this.gravity = 0f;
    }

    float time = 0f;
    // オブジェクトの移動はフレーム速度に依存させない
    void FixedUpdate()
    {
        // 滑らかな移動計算
        if (this.smoothMove)
        {
            // 徐々に減速
            this.speed -= Time.fixedDeltaTime * this.decelerationRate;
            if (this.speed < 0f) this.speed = 0f;

            // 反映
            var pos = this.rb2d.position;
            pos.x += this.speed * (int)this.moveDir * Time.fixedDeltaTime;
            this.rb2d.position = pos;
        }

        // 落下計算
        if (this.IsJumping)
        {
            this.gravity -= Time.fixedDeltaTime * this.gravityScale;
            if (this.gravity < this.maxGravity) this.gravity = this.maxGravity;

            // 反映
            var pos = this.rb2d.position;
            pos.y += this.gravity * Time.fixedDeltaTime;
            this.rb2d.position = pos;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // 床(Floor)に付いた場合にジャンプ終了処理を行う
        if (collision.gameObject.tag.Equals("Floor")) EndJump();
    }

    /// <summary>
    /// 横移動
    /// </summary>
    /// <param name="direction">移動方向</param>
    public void Move(MoveDirection direction)
    {
        if (this.smoothMove)
        {
            this.speed = this.moveSpeed;
            this.moveDir = direction;
        }
        else
        {
            var pos = this.rb2d.position;
            pos.x += this.moveSpeed * (int)direction * Time.deltaTime;
            this.rb2d.position = pos;
        }
    }

    /// <summary>
    /// 横移動
    /// </summary>
    /// <param name="direction">移動方向</param>
    /// <param name="multiple">速度倍率</param>
    public void Move(MoveDirection direction, float multiple)
    {
        if (this.smoothMove)
        {
            this.speed = this.moveSpeed * multiple;
            this.moveDir = direction;
        }
        else
        {
            var pos = this.rb2d.position;
            pos.x += this.moveSpeed * (int)direction * Time.fixedDeltaTime * multiple;
            this.rb2d.position = pos;
        }
    }

    /// <summary>
    /// ジャンプ
    /// </summary>
    public void Jump()
    {
        this.IsJumping = true;
        this.gravity = this.jumpPower;
    }

    /// <summary>
    /// ジャンプ終了
    /// </summary>
    public virtual void EndJump()
    {
        this.IsJumping = false;
    }
}
