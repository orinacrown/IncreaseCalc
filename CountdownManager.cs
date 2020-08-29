using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class CountdownManager : MonoBehaviour
{
    public AfterImageEffect countEffect;
    public Text countText;
    public AudioClip countClip;
    public AudioClip startClip;

    private AudioSource audioSource;

    private int count;
    private TimeFlagger timeFlagger;
    // Use this for initialization
    void Start()
    {
        count = 3;
        timeFlagger = new TimeFlagger(1000);
        audioSource = GetComponent<AudioSource>();
        Count();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeFlagger.IsTimeOver() == false)
        {
            return;
        }
        timeFlagger = new TimeFlagger(1000);
        count--;
        if (count == -1)
        {
            SceneManager.LoadScene("GameScene");
            return;
        }
        if (count == 0)
        {
            countText.text = "START!";
            countEffect.CircleDiffusion(16);
            audioSource.PlayOneShot(startClip);
            return;
        }
        Count();
        return;
    }

    private void Count()
    {
        countText.text = count.ToString();
        countEffect.CircleDiffusion(8 / count);
        audioSource.PlayOneShot(countClip);
    }
}
