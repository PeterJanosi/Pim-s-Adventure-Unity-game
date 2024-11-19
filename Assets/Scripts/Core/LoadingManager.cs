using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadingManager : MonoBehaviour
{
   /// <summary>
   /// Update is called every frame, if the MonoBehaviour is enabled.
   /// </summary>
   void Update()
   {
       if(Input.GetKeyDown(KeyCode.F))
            SceneManager.LoadScene(1);

   }
}
