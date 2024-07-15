using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    
    private float xDeadZone = 16f;

    private void Update()
    {
        if (transform.position.x > xDeadZone)
            Destroy(gameObject);

        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }
}
