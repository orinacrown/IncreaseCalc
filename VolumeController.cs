using UnityEngine;
using System.Collections;

public class VolumeController : MonoBehaviour
{
    private static float volume;
    // Use this for initialization
    void Start()
    {
        GetComponent<AudioSource>().volume = volume;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void SetVolume(float setVolume)
    {
        volume = setVolume;
    }

    public static float DefaultVolume()
    {
        return volume;
    }

    public static void VolumeReset()
    {
        volume = 1;
    }
}
