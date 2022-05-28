using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
      anim = GetComponent<Animator>(); /* Komponent i unity inför för användning i c# kod */
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap")) /* ifall kollision med trap (object i unity med taggen "trap") utgör die */
        {
            Die();
        }
    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static; /* När spelaren "dör" omgörs rigidbody till static vilket tar bort all rörelse och gravitation */
        anim.SetTrigger("death"); /* Animation i unity animator med namnet "death" */
        
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}


