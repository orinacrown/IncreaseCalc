using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TitleIncreaser : MonoBehaviour
{
    private TimeFlagger increaseFlag;
    private readonly int increaseMinSpanMS = 400;
    private readonly int increaseMaxSpanMS = 600;

    // Use this for initialization
    void Start()
    {
        ResetIncreaseTime();
    }

    // Update is called once per frame
    void Update()
    {
        if (increaseFlag.IsTimeOver())
        {
            ResetIncreaseTime();
            GameObject copyObject = Instantiate(gameObject);
            copyObject.transform.SetParent(transform.parent);
            copyObject.transform.localPosition = transform.localPosition;
            copyObject.transform.localScale = transform.localScale;
            copyObject.transform.SetAsFirstSibling();
            copyObject.AddComponent<TitleFaller>();
            copyObject.GetComponent<TitleIncreaser>().enabled = false;
            Text copyObjText = copyObject.GetComponent<Text>();
            Color copyObjColor = copyObjText.color;
            copyObjColor.a = 0.4f;
            copyObjText.color = copyObjColor;
        }
    }

    private void ResetIncreaseTime()
    {
        int increaseSpanMS = Random.Range(increaseMinSpanMS, increaseMaxSpanMS);
        increaseFlag = new TimeFlagger(increaseSpanMS);
    }
}
