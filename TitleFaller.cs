using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TitleFaller : MonoBehaviour
{
    private Rigidbody2D rigid;
    private CircleCollider2D collider;
    private TimeFlagger time;
    private readonly int remainTimeMS = 10000;
    private readonly float moveMagnification = 200;

    // Use this for initialization
    void Start()
    {
        collider = gameObject.AddComponent<CircleCollider2D>();
        rigid = gameObject.AddComponent<Rigidbody2D>();
        time = new TimeFlagger(remainTimeMS);
        float vectorX;
        float vectorY;
        float randomVector = Random.Range(0f, 360f);
        rigid.gravityScale = 0;
        vectorX = Mathf.Cos(randomVector) * moveMagnification;
        vectorY = Mathf.Sin(randomVector) * moveMagnification;
        rigid.AddForce(new Vector2(vectorX, vectorY));
        collider.radius = GetComponent<RectTransform>().sizeDelta.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (time.IsTimeOver())
        {
            Destroy(gameObject);
        }
    }
}
