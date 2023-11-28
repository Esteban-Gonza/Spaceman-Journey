using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPotion : Item
{
    private PlayerMovement player;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public override void Activate()
    {
        if(player.jumpForce < 16f)
        {
            StartCoroutine(JumpIncreaseTime());
        }
    }

    IEnumerator JumpIncreaseTime()
    {
        player.jumpForce *= 2;
        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(5f);
        player.jumpForce /= 2;
        gameObject.SetActive(false);
    }
}
