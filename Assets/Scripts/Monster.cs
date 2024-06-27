using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] Sprite deadSprite;
    [SerializeField] ParticleSystem particle;
    bool hasDied = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(ShouldDie(collision))
        {
            StartCoroutine( Die());
        }
    }

    private IEnumerator Die()
    {
        GetComponent<SpriteRenderer>().sprite = deadSprite;
        particle.Play();
        yield return new WaitForSeconds(1);
        
        hasDied = true;
        gameObject.SetActive(false);
    }

    private bool ShouldDie(Collision2D collision)
    {   if (hasDied)
            return false;
        Bird bird = collision.gameObject.GetComponent<Bird>();
        if(bird != null )
        {
            return true;
        }
        if (collision.contacts[0].normal.y < -0.5)
        {
            return true;
        }
        return false;
    }
}
