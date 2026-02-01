using UnityEngine;

public class Pipe : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Transform topPipe;
    [SerializeField] Transform bottomPipe;
    [SerializeField] Transform scoreTrigger;

    [Header("Movement")]
    [SerializeField] float speed = 2f;

    [Header("Gap Settings")]
    [SerializeField] float gapSize = 2.5f;
    [SerializeField] float minGapY = -1f;
    [SerializeField] float maxGapY = 3f;

    void Start()
    {
        float gapCenterY = Random.Range(minGapY, maxGapY);

        bottomPipe.localPosition = new Vector3(
            0,
            gapCenterY - gapSize / 2f - bottomPipe.localScale.y / 2f,
            0
        );

        topPipe.localPosition = new Vector3(
            0,
            gapCenterY + gapSize / 2f + topPipe.localScale.y / 2f,
            0
        );

        scoreTrigger.localPosition = new Vector3(0, gapCenterY, 0);
    }

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }
}