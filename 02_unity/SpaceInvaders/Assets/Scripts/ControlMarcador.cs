using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class ControlMarcador : MonoBehaviour
{

	// Puntos ganados en la partida
	public int puntos = 0;

	// Objeto donde mostramos el texto
	public GameObject puntuacion;

	private Text t;

	// Use this for initialization
	void Start ()
	{
		// Localizamos el componente del UI
		t = puntuacion.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (SceneManager.GetActiveScene ().name == ("Nivel1")) {
			
			// Actualizamos el marcador
			t.text = "Nivel 1 \n" +
				"Puntos: " + puntos.ToString () + "\n";
		} else {
			// Actualizamos el marcador
			t.text = "Nivel 2 \n" +
				"Puntos: " + puntos.ToString () + "\n";
		}
	}

}
