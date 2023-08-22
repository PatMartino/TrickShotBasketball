using UnityEngine;

namespace Controllers
{
    public class Resetting : MonoBehaviour
    {
   

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(KeyCode.R))
            {
                ES3.DeleteKey("levelID");
                Debug.Log("Reset");
            }
            
        
        }
    }
}
