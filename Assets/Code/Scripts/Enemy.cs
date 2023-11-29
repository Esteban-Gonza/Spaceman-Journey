using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed;

    [Header("References")]
    private PlayerController player;
    private Rigidbody2D enemyRigid;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        enemyRigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (GameManager.Instance.isVulnerable)
            {
                player.Hit(collision.GetContact(0).normal);
            }
        }
    }
}