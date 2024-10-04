using System;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class Sound
{
    [SerializeField] private AudioClip _clip;
    [Range(0f, 1f)][SerializeField] private float _volume;

    [Range(.1f, 3f)][SerializeField] private float _defaultPitch = 1;
    [SerializeField] private float _lowPitch = 0f;
    [SerializeField] private float _topPitch = 2f;

    private AudioSource _source;

    public string Name { get; private set; }

    public void Init(AudioSource source)
    {
        Name = source.name;
        _source = source;
        _source.clip = _clip;
        _source.volume = _volume;
        _source.pitch = _defaultPitch;
    }

    public void Init(AudioClip clip, AudioSource source)
    {
        _clip = clip; 
        Init(source);
    }

    public void Play()
    {
        _source.Play();
    }

    public void PlayRandomPitchSound()
    {
        _source.pitch = Random.Range(_lowPitch, _topPitch);
        _source.Play();
    }

    public void SetMute(bool isMuted)
    {
        _source.mute = isMuted;
    }

    public void SetVolume(float volume)
    {
        _source.volume = volume;
    }
}