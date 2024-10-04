using UnityEngine;
using System.Collections.Generic;
using System;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private Sound _music;
    [SerializeField] private Sound[] _sounds;

    [SerializeField] private float _lowPitch = 0f;
    [SerializeField] private float _topPitch = 2f;

    private Dictionary<string, Sound> _soundsNames = new();

    private void Awake()
    {
        CreateMusicSource();

        foreach (Sound sound in _sounds)
        {
            CreateSoundSurce(sound);
        }

        RefreshSettings();
    }

    public void RefreshSettings()
    {
        _music.SetMute(SaveService.MusicIsOn == false);
        _music.SetVolume(SaveService.MusicVolume);

        foreach (Sound sound in _sounds)
        {
            sound.SetMute(SaveService.SoundIsOn == false);
            sound.SetVolume(SaveService.SoundVolume);
        }
    }

    public void PlaySound(AudioClip clip)
    {
        if (clip == null)
            return;

        GetSound(clip).Play();
    }

    public void PlayRandomPitchSound(AudioClip clip)
    {
        if (clip == null)
            return;

        GetSound(clip).PlayRandomPitchSound();
    }

    private Sound GetSound(AudioClip clip)
    {
        if (_soundsNames.TryGetValue(clip.name, out Sound sound) == false)
            sound = CreateNewSoundSource(clip);
        
        return sound;
    }

    private void CreateSoundSurce(Sound sound)
    {
        sound.Init(gameObject.AddComponent<AudioSource>());
        _soundsNames.Add(sound.Name, sound);
    }

    private Sound CreateNewSoundSource(AudioClip clip)
    {
        Sound sound = new Sound();
        sound.Init(clip, gameObject.AddComponent<AudioSource>());
        _soundsNames.Add(sound.Name, sound);

        sound.SetMute(SaveService.SoundIsOn == false);
        sound.SetVolume(SaveService.SoundVolume);

        return sound;
    }

    private void CreateMusicSource()
    {
        AudioSource source = gameObject.AddComponent<AudioSource>();
        _music.Init(source);
        source.loop = true;
        source.Play();
    }
}