using UnityEngine;

public class Pipe : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Transform topBody;
    [SerializeField] Transform topCap;
    [SerializeField] Transform bottomBody;
    [SerializeField] Transform bottomCap;
    [SerializeField] Transform scoreTrigger;

    [Header("Gap Settings")]
    [SerializeField] float gapSize = 2.5f;
    [SerializeField] float minGapY = -1f;
    [SerializeField] float maxGapY = 3f;

    [Header("Movement")]
    [SerializeField] float speed = 2f;

    Camera cam;

    void Start()
    {
        cam = Camera.main;

        float gapCenterY = Random.Range(minGapY, maxGapY);

        float screenTopY = cam.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;

        GameObject ground = GameObject.Find("Ground");
        float groundTopY = ground.GetComponent<SpriteRenderer>().bounds.max.y;

        float capHeight =
            topCap.GetComponent<SpriteRenderer>().bounds.size.y;

        // ===== 上管 =====
        topCap.position = new Vector3(
            transform.position.x,
            gapCenterY + gapSize / 2f + capHeight / 2f,
            0
        );

        float topBodyHeight = screenTopY - topCap.position.y;

        float topBodySpriteHeight =
            topBody.GetComponent<SpriteRenderer>().sprite.bounds.size.y;

        topBody.position = new Vector3(
            transform.position.x,
            topCap.position.y + topBodyHeight / 2f,
            0
        );

        topBody.localScale = new Vector3(
            1,
            topBodyHeight / topBodySpriteHeight,
            1
        );

        // ===== 下管 =====
        bottomCap.position = new Vector3(
            transform.position.x,
            gapCenterY - gapSize / 2f - capHeight / 2f,
            0
        );

        float bottomBodyHeight = bottomCap.position.y - groundTopY;

        float bottomBodySpriteHeight =
            bottomBody.GetComponent<SpriteRenderer>().sprite.bounds.size.y;

        bottomBody.position = new Vector3(
            transform.position.x,
            groundTopY + bottomBodyHeight / 2f,
            0
        );

        bottomBody.localScale = new Vector3(
            1,
            bottomBodyHeight / bottomBodySpriteHeight,
            1
        );

        // Score Trigger
        scoreTrigger.position = new Vector3(
            transform.position.x,
            gapCenterY,
            0
        );
    }

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
