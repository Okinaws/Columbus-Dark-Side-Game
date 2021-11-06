using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    private bool flag = true;
    public float heal = 20f;
    private PlayerController player;

    private void Start()
    {
        player = PlayerController.instance;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Contains("Player") && flag)
        {
            flag = false;
            player.hp.Heal(heal);
            Destroy(gameObject);
        }
    }
}
