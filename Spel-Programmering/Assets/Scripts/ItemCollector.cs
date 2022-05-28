using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private Text crystalText;

   public int crystals = 0;
    private void OnTriggerEnter2D(Collider2D collision) /* Använder IsTrigger på kristallen när man plocker upp den och då är det mest lämpat att använda Collider2D */
    {
        if (collision.gameObject.CompareTag("Crystal"))
        {
           Destroy(collision.gameObject);
           crystals++;
           crystalText.text = "Crystals: " + crystals;

        }
    }

    

}