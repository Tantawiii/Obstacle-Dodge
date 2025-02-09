using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] float speed = 10.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        float valueX = Input.GetAxis("Horizontal") * speed * Time.deltaTime, valueY = 0.0f, valueZ = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Translate(valueX, valueY, valueZ);
    }
}
