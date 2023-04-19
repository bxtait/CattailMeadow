using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class yarncollector : MonoBehaviour
{
    private int yarns = 0;

    [SerializeField] private Text yarnText;
    [SerializeField] private AudioSource collectionSoundEffect;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("yarn"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            yarns++;
            yarnText.text = "Yarn Score: " + yarns;
        }


    }
}
