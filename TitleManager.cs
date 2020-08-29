using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{

    public AudioClip testSound;
    public Scrollbar scrollbar;

    // Use this for initialization
    void Start()
    {
        scrollbar.value = VolumeController.DefaultVolume();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SceneTransrate(string sceneName)
    {
        VolumeController.SetVolume(scrollbar.value);
        SceneManager.LoadScene(sceneName);
    }


    public void Ranking()
    {
        string prefKey = "Score";
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(PlayerPrefs.GetInt(prefKey, 0));
    }

    public void VolumeChange()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.volume = scrollbar.value;
        audio.PlayOneShot(testSound);
    }
}
