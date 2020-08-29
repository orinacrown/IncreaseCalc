using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndGong : MonoBehaviour
{
    private AudioSource audioSource;
    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (audioSource.isPlaying == true)
        {
            return;
        }
        SceneManager.LoadScene("ResultScene");
    }
}
