using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectManager:MonoBehaviour {

    public AudioClip[] bgms;
    public AudioClip[] soundEffects;
    public AudioSource curSound;

    void Start(){
        curSound.clip = bgms[0];
        curSound.Play();
    }

    public void SwitchMusic(int id)
    {
        curSound.clip = bgms[id];
        curSound.Play();
    }

    public void PlaySoundEffect(int id){
        curSound.PlayOneShot(soundEffects[id]);
    }
}
