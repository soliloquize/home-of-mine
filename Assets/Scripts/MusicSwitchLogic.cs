using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class MusicSwitchLogic : MonoBehaviour
{
    public float bpm = 140.0F;
    public int numBeatsPerSegment = 16;
    public AudioClip[] clips = new AudioClip[5];

    public float curMusicTime;
    public double nextEventTime;
    private int flip = 0;
    //private AudioSource[] audioSources = new AudioSource[4];
    private AudioSource curBgm;
    private bool running = false;

    void Start()
    {
        curBgm = this.GetComponent<AudioSource>();
        flip = PlayerPrefs.GetInt("CurDaySpirit", 0);
        MusicOnStart();
    }


    void Update()
    {
        curMusicTime = curBgm.time;
        nextEventTime = AudioSettings.dspTime;
    }

    private void MusicOnStart()
    {
        curBgm.clip = clips[flip];
        curBgm.Play();
    }

    public void ChangeMusic(int nextFlip)
    {
        if(nextFlip == flip) {
            print("spirit doesnt change");
        } else
        {
            print("should change bgm to spr = " + nextFlip);
            curBgm.clip = clips[nextFlip];
            curMusicTime = curMusicTime * clips[nextFlip].length / clips[flip].length;
            curBgm.time = curMusicTime;
            curBgm.PlayScheduled(nextEventTime);
            nextEventTime += 60.0F / bpm * numBeatsPerSegment;
            flip = nextFlip;
        }
    }
}