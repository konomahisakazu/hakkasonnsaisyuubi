using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private VariableJoystick variableJoystick;
    [SerializeField] private float movementSpeed = 10f;
    private float xLimit = 1.8f;
    private float yLimit = 1.5f;

    // 各方向のスプライトを保持するための変数
    [SerializeField] private Sprite frontSprite;
    [SerializeField] private Sprite backSprite;
    [SerializeField] private Sprite leftSprite;
    [SerializeField] private Sprite rightSprite;

    // スプライトをレンダリングするためのSpriteRenderer
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // SpriteRenderer コンポーネントを取得
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector2 movementDirection = variableJoystick.Direction;
        transform.Translate(movementDirection * movementSpeed * Time.deltaTime);
        
        // 移動方向に応じてスプライトを変更
        if (Mathf.Abs(movementDirection.x) > Mathf.Abs(movementDirection.y))
        {
            // 左右の移動
            spriteRenderer.sprite = (movementDirection.x > 0) ? rightSprite : leftSprite;
        }
        else if (Mathf.Abs(movementDirection.y) > 0)
        {
            // 上下の移動
            spriteRenderer.sprite = (movementDirection.y > 0) ? backSprite : frontSprite;
        }

        // 現在のポジションを維持
        Vector2 currentPos = transform.position;
        currentPos.x = Mathf.Clamp(currentPos.x, -xLimit, xLimit);
        currentPos.y = Mathf.Clamp(currentPos.y, -yLimit, yLimit);
        transform.position = currentPos;
    }
}