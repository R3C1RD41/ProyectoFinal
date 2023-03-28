using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public enum SFXType { JUMP, DAMAGE, DIE }
public class AudioManager : MonoBehaviour
{
    public AudioSource musica;
    public AudioSource SFX;
    public AudioClip[] musicCollection;
    public AudioClip[] sfxCollection;
    public AudioMixer mixer;
    public Slider sliderVolMusica;
    public Slider sliderSFX;
    private void Update()
    {
        mixer.SetFloat("VolumeMusic", sliderVolMusica.value);
        mixer.SetFloat("VolumeSFX", sliderSFX.value);
    }

    public void musicaInicio()
    {
        PlayMusic(0);
    }

    public void musicaEncierro()
    {
        PlayMusic(2);
    }

    public void musicaBoss1()
    {
        PlayMusic(3);
    }

    public void musicaWin()
    {
        PlayMusic(4);
    }
    public void PlaySFX(SFXType sfxType)
    {
        switch (sfxType)
        {
            case SFXType.DAMAGE:
                SFX.PlayOneShot(sfxCollection[1]);
                break;
            case SFXType.DIE:
                SFX.PlayOneShot(sfxCollection[2]);
                break;
            case SFXType.JUMP:
                SFX.PlayOneShot(sfxCollection[0]);
                break;
        }
    }
    public void PlayMusic(int music)
    {
        musica.Pause();
        musica.clip = musicCollection[music];
        musica.Play();
    }

    public void pauseMusic()
    {
        musica.Pause();
    }

    public void ResumeMusic()
    {
        musica.UnPause();
    }

    public void enemyFire()
    {
        SFX.PlayOneShot(sfxCollection[0]);
    }
    public void enemyDead()
    {
        SFX.PlayOneShot(sfxCollection[1]);
    }

    public void playerDead()
    {
        SFX.PlayOneShot(sfxCollection[2]);
    }

    public void GeneradorDestruccion()
    {
        SFX.PlayOneShot(sfxCollection[3]);
    }

    public void Item()
    {
        SFX.PlayOneShot(sfxCollection[4]);
    }

    public void Confirmacion()
    {
        SFX.PlayOneShot(sfxCollection[5]);
    }
    public void turrent()
    {
        SFX.PlayOneShot(sfxCollection[6]);
    }

    public void gameOver()
    {
        PlayMusic(1);
    }
}
