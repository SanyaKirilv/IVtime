﻿using UnityEngine;
using System.Collections;
public class Player : MonoBehaviour
{
    
    public int level = 2;
    public int lives = 3;
    public Transform bulletWeak;
    public Transform bulletFast;
    public Transform bulletStrong;

    public MapLoad ML;
    public Animator shieldAnim;
    public int shieldTime = 0;

    void Start()
    {
        level = 2;
    }
    void Update()
    {
        if (level == 1)
        {
            gameObject.SendMessage("SetBullet", bulletWeak);
            gameObject.SendMessage("SetMaxBullets", 1);
        }
        if (level == 2)
        {
            gameObject.SendMessage("SetBullet", bulletFast);
            gameObject.SendMessage("SetMaxBullets", 1);
        }
        if (level == 3)
        {
            gameObject.SendMessage("SetBullet", bulletFast);
            gameObject.SendMessage("SetMaxBullets", 2);
        }
        if (level == 4)
        {
            gameObject.SendMessage("SetBullet", bulletStrong);
            gameObject.SendMessage("SetMaxBullets", 2);
        }

        gameObject.GetComponent<Animator>().SetInteger("level", level);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Transform other = collision.GetComponent<Transform>();
        
        if (other.name.Contains("PowerUp"))
        {
            int bonus = Mathf.RoundToInt(other.GetComponent<Animator>().GetFloat("bonus"));

            if (bonus == 4)
            {
                SetShield(15);
            }

            other.gameObject.SendMessage("HidePowerUp");
        }
    }
    private void SetShield(int time)
    {
        if (shieldTime <= 0)
        {
            shieldTime = time;
            StartCoroutine(ShieldEnumerator());
        }

        shieldTime = time;
        shieldAnim.SetBool("isOn", true);
        gameObject.GetComponent<Animator>().SetBool("shield", true);
    }
    IEnumerator ShieldEnumerator()
    {
        while (shieldTime > 0)
        {
            yield return new WaitForSeconds(1);
            shieldTime--;
        }
        if (shieldTime <= 0)
        {
            shieldAnim.SetBool("isOn", false);
            gameObject.GetComponent<Animator>().SetBool("shield", false);
        }
    }
    public void SetLevel(int level)
    {
        this.level = level;
    }
    public void Hit()
    {
        lives--;
        if(lives <= 0)
        {
            ML.resetLevel();
        }

    }
    public void GetLives(ArgsPointer<int> pointer)
    {
        pointer.Args = new int[] { lives };
    }
    public void SetLives(int lives)
    {
        this.lives = lives;
    }

}
