using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    public Sprite chestOpened;
    public Sprite chestClosed;
    private SpriteRenderer chestRenderer;
    private Renderer render;
    public GameObject Coin;

    private void Start()
    {
        chestRenderer = GetComponent<SpriteRenderer>();
        render = GetComponent<Renderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.name == "Player" && chestRenderer.sprite == chestClosed)
        {
            chestRenderer.sprite = chestOpened;
            render.sortingOrder = 2;
            Instantiate(Coin, transform.position, Quaternion.identity);

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {

    }
}
