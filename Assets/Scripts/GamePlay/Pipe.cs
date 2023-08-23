using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float speed;

    private StartData data;

    public void Start()
    {
        data = FindObjectOfType<StartData>();

        if (data.easyLevel)
        {
            speed = 2;
        }
        if (data.midleLevel)
        {
            speed = 3;
        }
        if (data.hardLevel)
        {
            speed = 4;
        }
    }

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}
