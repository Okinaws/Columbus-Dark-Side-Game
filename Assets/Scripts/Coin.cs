using UnityEngine;

public class Coin : MonoBehaviour
{
    private bool flag = true;
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
            player.coins += 1;
            player.coinsMenu.text = "" + player.coins;
            Destroy(gameObject);
        }
    }
}
