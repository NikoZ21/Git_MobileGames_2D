using UnityEngine;

public class PipesMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    private Vector3 startPosition;
    private float leftEdge;

    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }

    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        if (transform.position.x < leftEdge)
        {
            transform.position = startPosition;
            gameObject.SetActive(false);
        }
    }

    public void SetStartPosition(Vector3 position)
    {
        startPosition = position;
    }

    public Vector3 GetStartPosition()
    {
        return startPosition;
    }
}