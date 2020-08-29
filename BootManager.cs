using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BootManager : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        VolumeController.VolumeReset();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)) SceneManager.LoadScene("TitleScene");
    }
}
