using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject coin;
    public GameObject eButton;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && eButton.activeInHierarchy)
        {
            Instantiate(coin, new Vector3(transform.position.x + 3f, transform.position.y + 1f), Quaternion.identity);
            Instantiate(coin, new Vector3(transform.position.x - 3f, transform.position.y + 1f), Quaternion.identity);
            Instantiate(coin, new Vector3(transform.position.x + 2.3f, transform.position.y + 2f), Quaternion.identity);
            Instantiate(coin, new Vector3(transform.position.x - 2.3f, transform.position.y + 2f), Quaternion.identity);
            Instantiate(coin, new Vector3(transform.position.x + 1.5f, transform.position.y + 2.5f), Quaternion.identity);
            Instantiate(coin, new Vector3(transform.position.x - 1.5f, transform.position.y + 2.5f), Quaternion.identity);
            Instantiate(coin, new Vector3(transform.position.x + 0.5f, transform.position.y + 2.8f), Quaternion.identity);
            Instantiate(coin, new Vector3(transform.position.x - 0.5f, transform.position.y + 2.8f), Quaternion.identity);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("Player"))
        {
            eButton.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        eButton.SetActive(false);
    }
}
