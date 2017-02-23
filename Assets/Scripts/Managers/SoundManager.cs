using MindHunter.Managers;
using UnityEngine;

public class SoundManager : PersistentSingleton<SoundManager> {
	
    public void PlayAudioAtPoint(AudioClip clip, Vector3 point, float volume = 1, float pitch = 1)
    {
        //Create an empty game object
        GameObject go = new GameObject("Audio: " + clip.name);
        go.transform.position = point;
 
        //Create the source
        AudioSource source = go.AddComponent<AudioSource>();
        source.clip = clip;
        source.volume = volume;
        source.pitch = pitch;
        source.Play();
        Destroy(go, clip.length);
    }

}
