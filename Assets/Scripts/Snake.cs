using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private Vector2 _direction = Vector2.right;
    private List<Transform> _segments;
    public Transform segmentPrefab;
    void Start() {
        _segments = new List<Transform>();
        _segments.Add(this.transform);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.W)) {
            _direction = Vector2.up;
        } else if (Input.GetKeyDown(KeyCode.S)) {
            _direction = Vector2.down;
        } else if (Input.GetKeyDown(KeyCode.A)) {
            _direction = Vector2.left;
        } else if (Input.GetKeyDown(KeyCode.D)) {
            _direction = Vector2.right;
        }
    }

    // Called at a fixed timed interval (NOT frame based)
    private void FixedUpdate()
    {
        /*
        Moves the body of the snake
        Starts at the tail and follows the segment in front of it
        */
        for(int i=_segments.Count-1; i>0; i--) {
            _segments[i].position = _segments[i-1].position;
        }

        this.transform.position = new Vector3(
            // Values are rounded to hold our snake to a grid
            Mathf.Round(this.transform.position.x) + _direction.x,
            Mathf.Round(this.transform.position.y) + _direction.y,
            0.0f
        );
    }

    private void Grow() {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = _segments[_segments.Count-1].position;

        _segments.Add(segment);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Food") {
        Grow();
        }
    }
}
