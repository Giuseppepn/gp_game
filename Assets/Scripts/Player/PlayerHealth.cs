using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHP = 3;
    [SerializeField] private float damageRecoveryTime = 1f;
    [SerializeField] private Color damageColor;
    [SerializeField] private float restoreDefaultColorTime = .2f;
    private Color defaultColor;
    private SpriteRenderer spriteRenderer;
    private PlayerController playerController;
    private int currentHP;
    private bool canTakeDamage = true;

    void Start()
    {
        playerController = GetComponent<PlayerController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHP = maxHP;
        defaultColor = spriteRenderer.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Slime" && canTakeDamage)
        {
            TakeDamage(1);
            StartCoroutine(DamageAnimation());
        }
    }

    private IEnumerator DamageAnimation()
    {
        spriteRenderer.color = new Color(0.61f, 0.01f, 0.01f);
        yield return new WaitForSeconds(restoreDefaultColorTime);
        spriteRenderer.color = defaultColor;

    }

    private void TakeDamage(int i)
    {
        canTakeDamage = false;
        currentHP -= i;
        StartCoroutine(PlayerRecover());

        if(currentHP == 0)
        {
            Debug.Log("Il player è morto! aveva con se monete: " + playerController.GetCoins());
        }
    }

    private IEnumerator PlayerRecover()
    {
        yield return new WaitForSeconds(damageRecoveryTime);
        canTakeDamage = true;
    }
}
