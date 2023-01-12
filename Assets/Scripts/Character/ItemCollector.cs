using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ItemCollector : MonoBehaviour
{
    private int cherries = 0;
    public TMP_Text cherryAmount;
    public AudioSource collectSoundEffect;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Cherry"))
        {
            Destroy(other.gameObject);
            cherries++;
            collectSoundEffect.Play();
            cherryAmount.text = cherries.ToString();
        }
    }
}
