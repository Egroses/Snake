using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buton : MonoBehaviour
{
    public void DisplayChange(){
		SceneManager.LoadScene("Oyun");
	}
	public void doExitGame() {
     Application.Quit();
 }


}
