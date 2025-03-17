using UnityEngine;

public class CheckPointFunction : MonoBehaviour
{
    public Renderer cpRenderer;
    private static Vector3 lastcheckedPosition;
    private static float lastcheckedTime;
    private static bool hasCheckPoint = false;
    private bool isChecked;

    private

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!hasCheckPoint)
        {
            GameObject player = GameObject.FindWithTag("Player");
            GameManager gameManager = FindFirstObjectByType<GameManager>();

            lastcheckedPosition = player.transform.position;
            lastcheckedTime = gameManager.GetRemainTime();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isChecked)
        {
            lastcheckedPosition = transform.position;
            lastcheckedTime = FindFirstObjectByType<GameManager>().GetRemainTime();

            hasCheckPoint = true;
            isChecked = true;

            cpRenderer.material.color = Color.yellow;
        }
    }

    public void ResetPlayerToCheckedPoint(GameObject player, GameManager gameManager)
    {
        if (hasCheckPoint)
        {
            player.GetComponent<PlayerController>().ResetPlayerPositon(lastcheckedPosition);
            gameManager.ResetTime(lastcheckedTime);
        }
    }
}
