using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAInimigo : MonoBehaviour
{
    private float _velocidade = 4.0f;

    [SerializeField]
    private GameObject _explosaoDoInimigo;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _velocidade * Time.deltaTime);

        if (transform.position.y < -36.71f)
        {
            transform.position = new Vector3(Random.Range(-7.7f, 7.7f), -11.0f, 0);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Tiro")
        {
            Destroy(other.gameObject);
        }

        if ( other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                player.DanoAoPlayer();
            }

        }
        
        Destroy(this.gameObject);

        Instantiate(_explosaoDoInimigo, transform.position, Quaternion.identity);
    }
}
