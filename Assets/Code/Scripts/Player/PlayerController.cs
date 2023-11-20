using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int health;

    [SerializeField] private float loseControlTime;
    public bool canMove = true;
    [SerializeField] private Vector2 bounceSpeed;

    [Header("References")]
    private Animator playerAnim;
    private Rigidbody2D playerRigid;

    private void Start()
    {
        playerAnim = GetComponent<Animator>();
        playerRigid = GetComponent<Rigidbody2D>();
    }

    public void Bounce(Vector2 hitPoint)
    {
        playerRigid.velocity = new Vector2(-bounceSpeed.x * hitPoint.x, bounceSpeed.y);
    }

    public void Hit(int damage, Vector2 position)
    {
        health -= damage;
        playerAnim.SetTrigger("Hit");
        StartCoroutine(LoseControl());
        StartCoroutine(NoCollisions());
        Bounce(position);
    }

    public void Death()
    {
        playerAnim.SetTrigger("Death");
    }

    IEnumerator LoseControl(){
        canMove = false;
        yield return new WaitForSeconds(loseControlTime);
        canMove = true;
    }

    IEnumerator NoCollisions()
    {
        Physics2D.IgnoreLayerCollision(7, 8, true);
        yield return new WaitForSeconds(loseControlTime);
        Physics2D.IgnoreLayerCollision(7, 8, false);
    }
}