using UnityEngine;
using UnityEngine.UI;

public class Hp : MonoBehaviour
{
    public float MaxHP = 100f;
    public float HP;
    public Image bar;
    [Header("Optional")]
    public GameObject animObj;

    void Start()
    {
        HP = MaxHP;
    }

    void Update()
    {
        bar.fillAmount = HP / MaxHP;
    }

    public void Hit(float damage)
    {
        if (HP > 0f)
        {
            HP -= damage;
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            Invoke("StopHurting", 0.15f);
        }

        if (HP <= 0f)
        {
            if (gameObject.name.Contains("Player"))
            {
                Invoke("Death", 0.517f);
            }

            if (gameObject.name.Contains("Dummy"))
            {
                if (animObj != null)
                {
                    animObj.SetActive(true);
                }
                Destroy(gameObject, 0.517f);
            }

            if (gameObject.name.Contains("Bandit"))
            {
                Destroy(gameObject, 0.5f);
            }
        }
    }

    public void Heal(float heal)
    {
        if (HP <= 0f)
        {
            ;
        }
        else if (HP + heal >= MaxHP)
        {
            HP = MaxHP;
        }
        else
        {
            HP += heal;
        }
    }

    private void StopHurting()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
    
    private void Death()
    {
        gameObject.SetActive(false);
    }
}