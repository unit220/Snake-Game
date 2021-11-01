using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private Vector2 _direction = Vector2.right;
    private List<Transform> _segments = new List<Transform>();
    public Transform segmentPrefab;
    public int initialSize = 3;
    public GameManager gameManager;
    private KeyCode lastInput;

    void Start() {
        ResetState();
        lastInput = KeyCode.None;
    }

    private void Update()
    {
        // has to be else if statements, trust me. Don't feel bad about it future me.
        if(Input.GetKeyDown(KeyCode.W) && lastInput != KeyCode.S) {
            _direction = Vector2.up;
            lastInput = KeyCode.W;
        } else if (Input.GetKeyDown(KeyCode.S) && lastInput != KeyCode.W) {
            _direction = Vector2.down;
            lastInput = KeyCode.S;
        } else if (Input.GetKeyDown(KeyCode.A) && lastInput != KeyCode.D) {
            _direction = Vector2.left;
            lastInput = KeyCode.A;
        } else if (Input.GetKeyDown(KeyCode.D) && lastInput != KeyCode.A) {
            _direction = Vector2.right;
            lastInput = KeyCode.D;
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

    private void ResetState() {
        // destroy the snake
        for (int i=1; i< _segments.Count; i++) {
            Destroy(_segments[i].gameObject);
        }

        // adds the head back to the segment list
        _segments.Clear();
        _segments.Add(this.transform);

        // populates the default body size
        for (int i=1; i < this.initialSize; i++) {
            _segments.Add(Instantiate(this.segmentPrefab));
        }

        this.transform.position = Vector3.zero;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Food") {
        Grow();
        } else if (other.tag == "Obstacle") {
            this.gameManager.EndGame();
        }
    }
}
