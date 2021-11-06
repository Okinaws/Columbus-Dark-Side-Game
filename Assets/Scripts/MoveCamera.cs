using UnityEngine;

public class MoveCamera : MonoBehaviour
{

    private GameObject player;

    private void Start()
    {
        player = PlayerController.instance.gameObject;
    }
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10f);
    }
}

