using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 1;
    public float rateOfFire = 1;
    public GameObject projectilePrefab;
    public GameObject explosionPrefab;
    private float lastTimeFired = 0;
    //public AudioClip laserSound;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        transform.position += Vector3.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && (lastTimeFired + 1 / rateOfFire) < Time.time)
        {
            lastTimeFired = Time.time;
            FireTheLasers();
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("TrashItem"))
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            StartCoroutine(RestartTheGameAfterSeconds(1));
            Destroy(GetComponent<SpriteRenderer>());
        }
    }

    IEnumerator RestartTheGameAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void FireTheLasers()
    {
        //AudioSource.PlayClipAtPoint(laserSound, transform.position);
        Instantiate(projectilePrefab, transform.position + Vector3.up, Quaternion.identity);
    }
}
