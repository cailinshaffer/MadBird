using UnityEngine;

public class Enemy : MonoBehaviour
{
    // [SerializedField] displays GameObject to show up in the inspector in unity
    [SerializeField] private GameObject _cloudParticlePrefab;

    // when ever enemy get hits by another object, info will get stored in collision object
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // check if collision happens w bird
        if (collision.collider.GetComponent<Bird>() != null)
        {
            // spawns cloud at position of enemy when killed
            Instantiate(_cloudParticlePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            return;
        }

        // check if collision happens with other enemey
        Enemy enemy = collision.collider.GetComponent<Enemy>();
        if (enemy != null)
        {
            return;
        }

        // if anything besides enemy/bird crushes enemy
        // "contact" is the contact point and is an array
        // "noraml" is the angle where impact came from
        if(collision.contacts[0].normal.y < - 0.5)
        {
            Instantiate(_cloudParticlePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }
}
