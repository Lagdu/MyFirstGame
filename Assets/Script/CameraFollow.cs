using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public float timeOffest;
    public Vector3 posOffest;

    private Vector3 velocity;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + posOffest, ref velocity, timeOffest);
    }
}
