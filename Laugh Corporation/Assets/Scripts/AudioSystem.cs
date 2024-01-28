using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSystem : MonoBehaviour
{
    public static AudioSystem Instance;

    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        else
            Instance = this;

        audioSource = gameObject.GetComponent<AudioSource>();
    }

    private AudioSource audioSource;

    [SerializeField] private AudioClip buttonSound;
    [SerializeField] private AudioClip tabletSound;
    [SerializeField] private AudioClip laughSound;
    [SerializeField] private AudioClip antiLaughSound;
    [SerializeField] private AudioClip clickSound;
    [SerializeField] private AudioClip yesSound;


    public void PlayButtonSound() => audioSource.PlayOneShot(buttonSound);
    public void PlayTabletSound() => audioSource.PlayOneShot(tabletSound);
    public void PlayLaughSound() => audioSource.PlayOneShot(laughSound);
    public void PlayAntiLaughSound() => audioSource.PlayOneShot(antiLaughSound);
    public void PlayClickSound() => audioSource.PlayOneShot(clickSound);
    public void PlayYesSound() => audioSource.PlayOneShot(yesSound);
    
}
