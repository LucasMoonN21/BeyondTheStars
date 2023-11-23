using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;

public class Player : MonoBehaviour
{
    private float _veloc;
    public GameObject _pffire_ball;
    public float _tempoDeDisparo = 0.3f;
    private float _podeDisparar = 0.0f;
    public bool possoDarDisparoTriplo = false;
    public GameObject _disparoTriploPrefab;

    public int vidas = 3;

    private GerenciadorUI _uiGerenciador;

    [SerializeField]
    private GameObject _explosaoPlayerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Metodo Start de "+this.name);
        _veloc = 8.0f;
        transform.position = new Vector3(0.05045079f,-30.97f,0);

        _uiGerenciador = GameObject.Find("Canvas").GetComponent<GerenciadorUI>();
        if (_uiGerenciador != null)
        {
            _uiGerenciador.AtualizaVidas(vidas);

        }

    }

    // Update is called once per frame
    void Update()
    {
        this.Movimento();

        Movimento();

        if ( Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
        {
           Disparo();
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Disparo();
        }

    }
    private void Movimento()
    {
        float entradaHorizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * entradaHorizontal* Time.deltaTime*_veloc);
        if ( transform.position.y > -21.83f)
        {
            transform.position = new Vector3(transform.position.x,-21.83f,0);
        }
        else if (transform.position.y < -30.97f)
        {
            transform.position = new Vector3(transform.position.x,-30.97f,0);
        }

        float entradaVertical = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * entradaVertical * Time.deltaTime*_veloc);
        if ( transform.position.x > 10.76f)
        {
            transform.position = new Vector3( 10.76f, transform.position.y,0);
        }
        else if ( transform.position.x < -10.74f )
        {
            transform.position = new Vector3( -10.74f, transform.position.y,0);
        }
    }
      private void Disparo(){
         if (Time.time > _podeDisparar)
        {
            if (possoDarDisparoTriplo == true )
            {
                Instantiate(_disparoTriploPrefab,transform.position,Quaternion.identity);
            }
            else 
            {
                Instantiate(_pffire_ball, transform.position + new Vector3(0, 1.1f, 0), Quaternion.identity);
            }
            _podeDisparar = Time.time + _tempoDeDisparo;
        }
    }
    public void LigarPUDisparoTriplo(){
        possoDarDisparoTriplo = true;

        StartCoroutine(DisparoTriploRotina());
    }
    public IEnumerator DisparoTriploRotina(){
        yield return new WaitForSeconds(7.0f);
        possoDarDisparoTriplo = false;
    }
    public void DanoAoPlayer()
    {
        //vidas = vidas - 1;
        vidas--;

        _uiGerenciador.AtualizaVidas(vidas);
        
        if ( vidas < 1)
        {
            Instantiate(_explosaoPlayerPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }

    }
}