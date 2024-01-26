using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    public Sprite chestOpened;
    private SpriteRenderer chestRenderer;

    private void Start()
    {
        chestRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            chestRenderer.sprite = chestOpened;
        }
    }
}
