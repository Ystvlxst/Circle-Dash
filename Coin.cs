using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Player player))
            Destroy(gameObject);
        else if (other.TryGetComponent(out Destroyer destroyer))
            Destroy(gameObject);
    }
}
