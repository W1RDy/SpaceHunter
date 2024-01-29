using UnityEngine;

public class CameraModel : MonoBehaviour
{
    Transform player;

    void Start() => player = GameObject.FindGameObjectWithTag("Player").transform;

    void Update()
    {
        if (player) transform.position = new Vector3(player.position.x, player.position.y, -10f);
    }
}
