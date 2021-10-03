using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float speed;

    [SerializeField] float maxX;
    [SerializeField] float maxY;
    [SerializeField] float minX;
    [SerializeField] float minY;

    void Start()
    {
        transform.position = player.position;
    }

    void Update()
    {
        if (player == null) return;

        float clampedX = Mathf.Clamp(player.position.x, minX, maxX);
        float clampedY = Mathf.Clamp(player.position.y, minY, maxY);
        transform.position = Vector2.Lerp(transform.position, new Vector2(clampedX, clampedY), Time.deltaTime*speed);
    }
}
