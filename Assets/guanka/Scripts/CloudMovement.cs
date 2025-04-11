using System.Collections;
using UnityEngine;

/// <summary>
/// Level1中的移动云朵
/// </summary>
public class CloudMovement : MonoBehaviour
{
    public float downHeight = 2f;
    public float speed = 1f;

    private float _startY;
    private Coroutine _moveCoroutine;
    private bool _movingDown = true;

    void Start()
    {
        _startY = transform.position.y;
        _moveCoroutine = StartCoroutine(SmoothMove());
    }

    void OnDisable()
    {
        if (_moveCoroutine != null) StopCoroutine(_moveCoroutine);
    }

    IEnumerator SmoothMove()
    {
        float targetYDown = _startY - downHeight;
        float targetYUp = _startY;

        while (true)
        {
            Vector3 currentPos = transform.position;
            float targetY = _movingDown ? targetYDown : targetYUp;
            while (Mathf.Abs(currentPos.y - targetY) > 0.01f)
            {
                currentPos.y = Mathf.Lerp(
                    currentPos.y,
                    targetY,
                    speed * Time.deltaTime);

                transform.position = currentPos;
                yield return null;
                currentPos = transform.position;
            }

            _movingDown = !_movingDown;
            yield return null;
        }
    }
}