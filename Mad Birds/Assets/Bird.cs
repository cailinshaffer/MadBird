// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
// MonoBehavior allows acces to a bunch of unity callbacks
{
  private void OnMouseDown()
  {
    // turn red when bird was clicked
    GetComponent<SpriteRenderer>().color = Color.red;
  }

    private void OnMouseUp()
    {
        // turn white when bird was released
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    private void OnMouseDrag()
    {
        // save off desired position w vector3
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // set new postion on x/y values and leaze z alone
        transform.position = new Vector3(newPosition.x, newPosition.y);
    
    }
}
