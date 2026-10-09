using UnityEngine;

public class Realter : MonoBehaviour
{
    private int WalkLeft, WalkRight;
    public GameObject Text, Text2;
    public Animator animator;
    void Start()
    {
        WalkLeft = 1;
        WalkRight = 0;
    }
    void Update()
    {
        if (WalkLeft == 1) {transform.position += Vector3.left * Time.deltaTime;}
        if (WalkRight == 1) {transform.position += Vector3.right * Time.deltaTime;}
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "MainCamera")
        {
            WalkLeft = 0; 
            Text.SetActive(true);
            animator.enabled = false;
            Invoke("Right", 2f);
        }
    }
    private void Right()
    {
        Text.SetActive(false);
        animator.enabled = true;
        WalkRight = 1;
        Invoke("FireBall", 2f);
    }
    private void FireBall()
    {
        WalkRight = 0;
        animator.enabled = false;
        Text2.SetActive(true);
    }

    public void Finished()
    {
        Text2.SetActive(false);
        Destroy(gameObject);
    }
}
