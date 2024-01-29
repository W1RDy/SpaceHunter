using System;
using System.Collections;
using UnityEngine;

public class PlayerModel : MonoBehaviour, IRadiated, IMovable, IRotatable
{
    SceneModel scene;
    Rigidbody2D rb;
    Rotator rotator;
    Vector2 direction;
    float speed = 3, rotationSpeed = 100;
    public event Action MoveForward;

    void Start()
    {
        rotator = new Rotator(rotationSpeed);
        rb = GetComponent<Rigidbody2D>();
        scene = GameObject.Find("Canvas").GetComponent<SceneModel>();
    }

    public void SetDirection(Vector2 direction) => this.direction = direction;

    public void Move()
    {
        rb.AddRelativeForce(direction * speed);
        if (direction.y > 0) MoveForward();
    }

    public void ChangeSpeed(float newSpeed) => speed = newSpeed;

    public void Rotate()
    {
        var target = Input.mousePosition;
        rotator.RotateTo(transform, Camera.main.ScreenToWorldPoint(target));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bonus")
        {
            AudioManager.instance.PlaySound("Bonus");
            collision.GetComponent<BonusModel>().EnableEffect();
            Destroy(collision.gameObject);
        }
    }

    public void Death() => scene.EndGame(false);
}
