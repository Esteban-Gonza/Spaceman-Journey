using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTrigger : MonoBehaviour
{
    public event Action<Item> OnItemActivated;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Item item = GetComponent<Item>();
            item?.Activate();

            OnItemActivated?.Invoke(item);
        }
    }
}
