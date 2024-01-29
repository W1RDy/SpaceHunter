using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerModel playerModel;

    void Start() => playerModel = GetComponent<PlayerModel>();

    void Update() =>
        playerModel.SetDirection(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
}
