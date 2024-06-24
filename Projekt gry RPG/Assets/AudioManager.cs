using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource SFXSource;
    
    public AudioClip soundtrack;
    public AudioClip playerWasHit;
    public AudioClip playerAttack;
    public AudioClip playerHitEnemie;
    public AudioClip playerTeleported;
    public AudioClip playerCollectedItem;
    public AudioClip openedBook;
    public AudioClip changedBookPage;
    public AudioClip newQuest;

    public static AudioManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        if (soundtrack != null)
        {
            Instance.musicSource.clip = soundtrack; //musyka grana w petli na danej scenie
            Instance.musicSource.Play();
        }
    }
    public void PlaySFX(AudioClip clip) //metoda do odtwarzania pojedynczego dzwieku
    {
        if (clip != null)
        {
            Instance.SFXSource.PlayOneShot(clip); //pojedyncze odtworzenie jednego z dzwiekow zadeklarowanych w polach tej klasy
        }
        else
            Debug.Log("wybrany clip jest nullem!");
    }
}
