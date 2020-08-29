using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    public GameObject playCanvas;
    public Sprite[] numberSprites = new Sprite[10];

    // Use this for initialization
    void Start()
    {
        int score = Score.CurrentScore();
        Score.SaveScore();
        List<GameObject> resultObjects = new List<GameObject>();
        do
        {
            int disp = score % 10;
            GameObject prefab = new GameObject();
            prefab.transform.localScale = new Vector3(1, 1, 1);
            prefab.AddComponent<SpriteRenderer>().sprite = numberSprites[disp];
            resultObjects.Insert(0, prefab);
            score /= 10;
        } while (score != 0);
        for(int i = 0; i < resultObjects.Count; i++)
        {
            resultObjects[i].transform.localPosition = new Vector3(i * 2.5f, 2, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SceneTransrate(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Retry()
    {
        SceneTransrate("GameScene");
    }

    public void Ranking()
    {
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(Score.CurrentScore());
    }

    public void Tweet()
    {
        naichilab.UnityRoomTweet.Tweet("Increasecalc", $"{Score.CurrentScore()}点獲得しました！あなたも是非チャレンジ！","インカル","IncreaseCalc","unityroom");
    }
}
