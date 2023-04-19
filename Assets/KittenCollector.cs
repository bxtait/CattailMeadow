using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KittenCollector : MonoBehaviour
{
    private int kittens = 0;

    [SerializeField] private Text kittenText;
    [SerializeField] private AudioSource kittenSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("kitten"))
        {
            kittenSoundEffect.Play();
            Destroy(collision.gameObject);
            kittens++;
            kittenText.text = "Kittens Saved: " + kittens;
        }
    }
}
