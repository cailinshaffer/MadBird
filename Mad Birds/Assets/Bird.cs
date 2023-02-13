using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
// MonoBehavior allows acces to a bunch of unity callbacks
{

    Vector3 _initialPosition;
    // underscore defines a private variable and only accessible in this class (like private)

    private void Awake()
    {
        // when bird first starts up save off initial position
        _initialPosition = transform.position;
    }

    private void Update()
    {
        // called once per frame (60 times per second)
        // check for postion of every frame has gotten outside of the screen
        if (transform.position.y > 10)
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
    }

    private void OnMouseUp()
    {
        // turn white when bird was released
        GetComponent<SpriteRenderer>().color = Color.white;
        // get rigidbody component and add force
        // add force allows to give direction and magnitude to intial postion
        Vector2 directionToInitialPosition = _initialPosition - transform.position;

        GetComponent<Rigidbody2D>().AddForce(directionToInitialPosition * 600);
        GetComponent<Rigidbody2D>().gravityScale = 1;
    }

    private void OnMouseDrag()
    {
        // save off desired position w vector3
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // set new postion on x/y values and leaze z alone
        transform.position = new Vector3(newPosition.x, newPosition.y);
    
    }
}
