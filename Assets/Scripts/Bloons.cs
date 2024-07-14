using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloons : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private int health;

    private void Update()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            GameObject projectile = collision.gameObject;
            Destroy(projectile);
            loseHealth();
        }
    }

    private void loseHealth()
    {
        health--;
        if (health <= 0)
            Destroy(gameObject);
    }
}
