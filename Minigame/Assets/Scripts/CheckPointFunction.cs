using UnityEngine;

public class CheckPointFunction : MonoBehaviour
{
    public GameObject player;
    public Renderer cpRenderer;
    public GameManager gameManager;

    private Vector3 lastcheckedPosition;
    private float lastcheckedTime;
    private static bool hasCheckPoint = false;

    private bool isChecked;

    private

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lastcheckedPosition = player.transform.position;
        lastcheckedTime = gameManager.GetRemainTime();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player && !isChecked)
        {
            lastcheckedPosition = transform.position;
            lastcheckedTime = gameManager.GetRemainTime();

            hasCheckPoint = true;
            isChecked = true;

            cpRenderer.material.color = Color.yellow;
        }
    }

    public void ResetPlayerToCheckedPoint()
    {
        if (isChecked)
        {
            player.transform.position = lastcheckedPosition;
            gameManager.ResetTime(lastcheckedTime);
        }
    }
}
