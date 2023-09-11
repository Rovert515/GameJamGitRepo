using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashItems : MonoBehaviour
{
    public float speed = 1;
    public float lifeTime = 10;
    public float rotationSpeed = 60;
    //public GameObject explosionPrefab;
    Vector2 direction = new Vector2();

    // Start is called before the first frame update
    void Start()
    {

        float angle = Random.Range(0f, 360f);
        float radians = angle * Mathf.Deg2Rad;
        direction = new Vector2(Mathf.Cos(radians), Mathf.Sin(radians));
        direction.Normalize();
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = transform.position + new Vector3(direction.x, direction.y, 0) * speed * Time.deltaTime;
        transform.rotation *= Quaternion.AngleAxis(rotationSpeed * Time.deltaTime, Vector3.forward);

        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void OnHit()
    {
        //Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
