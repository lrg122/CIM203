using UnityEngine;

public class LetterBehavior : MonoBehaviour
{
    public char letterChar;
    public float fallSpeed = 1.3f;

    void Update()
    {
        
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;

        
        float drift = Mathf.Sin(Time.time * 1.5f + letterChar) * 0.2f;
        transform.position += new Vector3(drift * Time.deltaTime, 0, 0);

        
        if (transform.position.y < -10f)
            Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            Manager.Instance.OnLetterCaught(letterChar);
            Destroy(gameObject);
        }
    }
}


