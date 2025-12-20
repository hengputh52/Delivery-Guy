using UnityEngine;

public class FloatUpDown : MonoBehaviour
{
    public float speed = 2f;
    public float height = 0.5f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {
        float yOffset = Mathf.Sin(Time.time * speed) * height;
        transform.localPosition = startPos + new Vector3(0, yOffset, 0);
    }
}
