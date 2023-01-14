using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public GameObject finishObject;
    private AudioSource FinishSoundEffect;
    // Start is called before the first frame update
    void Start()
    {
        FinishSoundEffect = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FinishSoundEffect.Play();
            CompleteLevel();
        }
    }

    private void CompleteLevel()
    {
        finishObject.SetActive(true);
        Time.timeScale = 0;
    }
}
