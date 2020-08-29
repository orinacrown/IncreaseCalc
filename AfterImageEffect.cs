using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


public class AfterImageEffect : MonoBehaviour
{
    private List<TimeFlagger> cloneDeleteFlag;
    private List<GameObject> clones;
    private readonly float force = 2200;
    // Use this for initialization
    void Awake()
    {
        cloneDeleteFlag = new List<TimeFlagger>();
        clones = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < cloneDeleteFlag.Count; i++)
        {
            if (cloneDeleteFlag[i].IsTimeOver())
            {
                cloneDeleteFlag.RemoveAt(i);
                Destroy(clones[i]);
                clones.RemoveAt(i);
            }
        }
    }

    public void Wrong()
    {
        GameObject cloneA = CreateClone(1000);
        GameObject cloneB = CreateClone(1000);
        Rigidbody2D rigidA = MovableClone(cloneA);
        Rigidbody2D rigidB = MovableClone(cloneB);
        rigidA.AddForce(new Vector2(force, 0));
        rigidB.AddForce(new Vector2(-force, 0));
    }

    public void Correct()
    {
        GameObject cloneA = CreateClone(1000);
        GameObject cloneB = CreateClone(1000);
        Rigidbody2D rigidA = MovableClone(cloneA);
        Rigidbody2D rigidB = MovableClone(cloneB);
        rigidA.AddForce(new Vector2(0, force));
        rigidB.AddForce(new Vector2(0, -force));
    }

    public void QuestionReset()
    {
        Wrong();
        Correct();
    }

    public void CircleDiffusion(int diffusionCount)
    {

        for(int i = 0; i < diffusionCount; i++)
        {
            GameObject clone = CreateClone(1000);
            Rigidbody2D rigid = MovableClone(clone);
            float vectorX = Mathf.Cos(i * Mathf.Asin(1) * 4 / diffusionCount) * force;
            float vectorY = Mathf.Sin(i * Mathf.Asin(1) * 4 / diffusionCount) * force;
            rigid.AddForce(new Vector2(vectorX, vectorY));
        }
    }

    private GameObject CreateClone(int displayTimeMS)
    {
        GameObject clone = Instantiate(gameObject);
        clone.transform.SetAsFirstSibling();
        clone.transform.SetParent(transform.parent);
        clone.transform.localScale = transform.localScale;
        clone.transform.localPosition = transform.localPosition;
        clone.GetComponent<AfterImageEffect>().enabled = false;
        Text cloneText = clone.GetComponent<Text>();
        Color textColor = cloneText.color;
        textColor.a = 0.3f;
        cloneText.color = textColor;
        cloneDeleteFlag.Add(new TimeFlagger(displayTimeMS));
        clones.Add(clone);
        return clone;
    }

    private Rigidbody2D MovableClone(GameObject clone)
    {
        Rigidbody2D rigid = clone.AddComponent<Rigidbody2D>();
        rigid.gravityScale = 0f;
        return rigid;
    }
}
