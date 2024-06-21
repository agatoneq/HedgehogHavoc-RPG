using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    
    public AudioClip soundtrack;
    public AudioClip playerWasHit;
    public AudioClip playerAttack;
    public AudioClip playerHitEnemie;

    void Start()
    {
        if (soundtrack != null)
        {
            musicSource.clip = soundtrack; //musyka grana w petli na danej scenie
            musicSource.Play();
        }
    }
    public void PlaySFX(AudioClip clip) //metoda do odtwarzania pojedynczego dzwieku
    {
        if (clip != null)
        {
            SFXSource.PlayOneShot(clip); //pojedyncze odtworzenie jednego z dzwiekow zadeklarowanych w polach tej klasy
        }
        else
            Debug.Log("wybrany clip jest nullem!");
    }
}
