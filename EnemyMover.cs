using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    private float _speed = 3f;

    private void Update()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Destroyer destroyer))
            Destroy(gameObject);
        else if (other.TryGetComponent(out Player player))
            Destroy(gameObject);
    }
}
