using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField]private AudioSource bgmPlayer;
    [SerializeField]private AudioSource sfxPlayer;

    public float masterVolumeBGM = 1f;
    public float masterVolumeSFX = 1f;

    [SerializeField]private AudioClip[] bgmAudioClip;   //mainScene bgm
    [SerializeField]private AudioClip[] sfxAudioClips;    //soundEffect 
    //soundEffect Dictionary
    Dictionary<string, AudioClip> sfxAudioClipsDic = new Dictionary<string, AudioClip>();

    protected override void Awake() {
        base.Awake();
        foreach(AudioClip audioClip in sfxAudioClips){
            sfxAudioClipsDic.Add(audioClip.name, audioClip);
        }
    }

    private void Start() {
        StartCoroutine(PlayBGMSoundLoop());
    }

    IEnumerator PlayBGMSoundLoop(float volume = 0.3f){
        int i = 0;
        bgmPlayer.volume = volume;
        bgmPlayer.clip = bgmAudioClip[i];
        bgmPlayer.Play();
        while(true){
            yield return new WaitForSeconds(2f);
            if(bgmPlayer.isPlaying) continue;

            i++;
            if(i >= bgmAudioClip.Length-1){
                i = 0;
            }
            bgmPlayer.clip = bgmAudioClip[i];
            bgmPlayer.Play();
        }
    }
    
    public void PlaySFXSound(string name, float volume = 1f){
        if(sfxAudioClipsDic.ContainsKey(name) == false){
            Debug.Log(name + " is not contained.");
            return;
        }
        sfxPlayer.PlayOneShot(sfxAudioClipsDic[name], volume * masterVolumeSFX);
    }//soundEffect(name, volume(option))
}
