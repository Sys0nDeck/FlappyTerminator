using UnityEngine;

public class SpawnField : MonoBehaviour
{
    [SerializeField] private float _size;



    private void OnDrawGizmos()
    {
        float minY = transform.position.y - (_size * 0.5f);
        float maxY = transform.position.y + (_size * 0.5f);
        var from = new Vector3(transform.position.x, minY, 0f);
        var to = new Vector3(transform.position.x, maxY, 0f);
        Gizmos.color = Color.green;

        Gizmos.DrawLine(from, to);
    }

    public Vector3 GetRandomPosition()
    {
        float minY = transform.position.y - (_size * 0.5f);
        float maxY = transform.position.y + (_size * 0.5f);

        float randomY = Random.Range(minY, maxY);
        var newPosition = new Vector3(transform.position.x, randomY, 0f);
        return newPosition;
    }
}
