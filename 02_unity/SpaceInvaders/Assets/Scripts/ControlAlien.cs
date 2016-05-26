using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ControlAlien : MonoBehaviour
{
	// Conexión al marcador, para poder actualizarlo
	public GameObject marcador;

	//Variable para contar los marcianos muertos
	public static int muertos=28;

	// Por defecto, 100 puntos por cada alien
	public int puntos = 100;
	//variable para detectar cuando han chocado con la nave
	public bool chocado=false;


	// Use this for initialization
	void Start ()
	{
		// Localizamos el objeto que contiene el marcador
		marcador = GameObject.Find ("Marcador");
	}

	// Update is called once per frame
	void Update ()
	{

		// Calculamos la anchura visible de la cámara en pantalla
		float distanciaHorizontal = Camera.main.orthographicSize * Screen.width / Screen.height;

		// Calculamos el límite izquierdo y el derecho de la pantalla
		float limiteIzq = -1.0f * distanciaHorizontal;
		float limiteDer = 1.0f * distanciaHorizontal;


		//moviendo marcianitos
		if(SceneManager.GetActiveScene().name==("Nivel1")){
			
			if (this.transform.position.x < limiteDer) {
			this.transform.position = new Vector2 (this.transform.position.x + 0.1f, this.transform.position.y);
		} else {
			this.transform.position = new Vector2 (limiteIzq, this.transform.position.y - 1.0f);
		}
	
		} else {

			if (this.transform.position.x < limiteDer) {
				this.transform.position = new Vector2 (this.transform.position.x + 0.3f, this.transform.position.y);
			} else {
				this.transform.position = new Vector2 (limiteIzq, this.transform.position.y - 1.0f);
			}

		}
		//Controlamos cuando se acaban los marcianos
		if(muertos==0){
			muertos = 28;
			SceneManager.LoadScene ("Nivel2");
		}
	}

	void OnCollisionEnter2D (Collision2D coll)
	{
		// Detectar la colisión entre el alien y otros elementos

		// Necesitamos saber contra qué hemos chocado
		if (coll.gameObject.tag == "disparo") {
			//Matamos un marciano
			muertos -=1;

			// Sonido de explosión
			GetComponent<AudioSource> ().Play ();

			// Sumar la puntuación al marcador
			marcador.GetComponent<ControlMarcador> ().puntos += puntos;

			// El disparo desaparece (cuidado, si tiene eventos no se ejecutan)
			Destroy (coll.gameObject);

			// El alien desaparece (hay que añadir un retraso, si no, no se oye la explosión)

			// Lo ocultamos...
			GetComponent<Renderer> ().enabled = false;
			GetComponent<Collider2D> ().enabled = false;

			// ... y lo destruímos al cabo de 5 segundos, para dar tiempo al efecto de sonido
			Destroy (gameObject, 5f);
		}else if (coll.gameObject.tag=="nave"){
			//chocamos contra la nave

			// Sonido de explosión
			GetComponent<AudioSource> ().Play ();

			//paramos los marcianos
			chocado=true;
			SceneManager.LoadScene ("Nivel1");


		
	}
}
}