// Telling editor to use these special methods/ classes
// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
// "public" is an access modifier
// MonoBehavior allows access to a bunch of unity callbacks
// allows it to be a component that can be attached to object in unity editor
{
    // underscore defines a private variable and only accessible in this class (like private)
    private Vector3 _initialPosition;
    private bool _birdWasLaunched;
    private float _timeSittingAround;

    // serialize field allows to see variable in inspector
    [SerializeField] private float _launchPower = 500;


    private void Awake()
    {
        // when bird first starts up save off initial position
        _initialPosition = transform.position;
    }

    void Update()
    {
        GetComponent<LineRenderer>().SetPosition(0, transform.position);
        GetComponent<LineRenderer>().SetPosition(1, _initialPosition);


        if(_birdWasLaunched && GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1)
        {
            // Time.deltaTime is the time between frames
           _timeSittingAround += Time.deltaTime;
        }

        // called once per frame (60 times per second)
        // check for postion of every frame has gotten outside of the screen
        if (transform.position.y > 10 || transform.position.y < -10 || transform.position.x > 10 || transform.position.x < -10 || _timeSittingAround > 3)
        {
          // reload current scene by name
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }

    private void OnMouseDown()
    {
    // turn red when bird was clicked
    GetComponent<SpriteRenderer>().color = Color.red;
    // turn on line renderer
    GetComponent<LineRenderer>().enabled = true;
    }

    private void OnMouseUp()
    {
        // turn white when bird was released
        GetComponent<SpriteRenderer>().color = Color.white;
        // get rigidbody component and add force
        // add force allows to give direction and magnitude to intial postion
        Vector2 directionToInitialPosition = _initialPosition - transform.position;

        GetComponent<Rigidbody2D>().AddForce(directionToInitialPosition * _launchPower);
        GetComponent<Rigidbody2D>().gravityScale = 1;
        _birdWasLaunched = true;

        // turn off line renderer
        GetComponent<LineRenderer>().enabled = false;
    }

    private void OnMouseDrag()
    {
        // save off desired position w vector3
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // set new postion on x/y values and leaze z alone
        transform.position = new Vector3(newPosition.x, newPosition.y);
    
    }
}
