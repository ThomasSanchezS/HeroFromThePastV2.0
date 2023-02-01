using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
   public void BotonJugar(){
       SceneManager.LoadScene("Juego");
   }

   public void BotonSalir(){
       Application.Quit();
   }

   public void BotonMenu(){
       SceneManager.LoadScene("Menu");
   }
}
