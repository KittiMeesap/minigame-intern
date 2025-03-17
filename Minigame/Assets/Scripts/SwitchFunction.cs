using UnityEngine;

public class SwitchFunction : MonoBehaviour
{
    public GameObject door;
    private Renderer switchRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        switchRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switchRenderer.material.color = Color.green;

            if (door != null)
            {
                Destroy(door);
            }
        }
    }
}
