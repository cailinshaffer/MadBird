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
        // get the rigidbody component
        // Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        // // set the velocity of the rigidbody
        // rigidbody.velocity = new Vector2(2, 10);
        // // disable the bird
        // rigidbody.isKinematic = true;
    }
}
