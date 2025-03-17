using UnityEngine;

public class CheckPointFunction : MonoBehaviour
{
    public GameObject player;
    private bool isChecked;
    private Vector3 checkedPosition;
    private float checkedTime;
    public Renderer cpRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        checkedPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isChecked)
        {
            cpRenderer.material.color = Color.black;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player && !isChecked)
        {
            checkedPosition = transform.position;
            checkedTime = Time.time;

            isChecked = true;

            cpRenderer.material.color = Color.black;
        }
    }

    private void ResetPlayerToCheckedPoint()
    {
        if (isChecked)
        {
            player.transform.position = checkedPosition;

        }
    }
}
