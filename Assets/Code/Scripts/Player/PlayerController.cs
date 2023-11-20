using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    private Animator playerAnim;

    private void Start()
    {
        playerAnim = GetComponent<Animator>();
    }

    public void Death()
    {
        playerAnim.SetTrigger("Death");
    }
}