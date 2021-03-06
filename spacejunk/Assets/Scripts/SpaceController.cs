﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceController : MonoBehaviour {

    public float scrollRate;
    public Sprite debugSprite;
    public float movementMod;
    public float upperLimit;
    public float lowerLimit;

    SpriteRenderer spriteRender;
    private Rigidbody2D rb;
    private float steerShip;


	void Start () {
        spriteRender = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        spriteRender.sprite = debugSprite;
	}

    private void Update()
    {
        Debug.Log(Input.GetAxis("Steer_ship"));
        if(Input.GetAxis("Steer_ship") != 0)
        {
            steerShip = Input.GetAxis("Steer_ship") / movementMod;
        }
        else steerShip = 0f;
    }

    void FixedUpdate () {
        rb.MovePosition(new Vector2(rb.position.x + scrollRate, rb.position.y + steerShip));
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Space Junk")
            SceneManager.LoadScene("Game Over");
    }

    public void AddSprite(Sprite sprite) //This method will change the rocket body to any sprite passed into it
    {
        spriteRender.sprite = debugSprite;
    }
}
