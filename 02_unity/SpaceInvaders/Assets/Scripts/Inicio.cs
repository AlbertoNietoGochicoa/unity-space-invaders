using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Inicio : MonoBehaviour {

	public void botonEmpezar(){
		SceneManager.LoadScene ("Nivel1");

	}

	public void botonSalir(){
		Application.Quit ();
	}
}
