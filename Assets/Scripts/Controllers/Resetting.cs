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
                for (int i = 0; i < 9; i++)
                {
                    ES3.DeleteKey($"rareBallButtons{i}ButtonColor");
                    ES3.DeleteKey($"commonBallButtons{i}ButtonColor");
                    ES3.DeleteKey($"legendaryBallButtons{i}ButtonColor");
                
                    ES3.DeleteKey($"rareBallButtons{i}ImageColor");
                    ES3.DeleteKey($"commonBallButtons{i}ImageColor");
                    ES3.DeleteKey($"legendaryBallButtons{i}ImageColor");
                
                    ES3.DeleteKey($"rareBalls{i}");
                    ES3.DeleteKey($"commonBalls{i}");
                    ES3.DeleteKey($"legendaryBalls{i}");
                }
                ES3.DeleteKey("rareCount");
                ES3.DeleteKey("commonCount");
                ES3.DeleteKey("legendaryCount");
                ES3.DeleteKey("levelID");
                ES3.DeleteKey("Coin");
                ES3.DeleteKey("Ball");
                ES3.DeleteKey("reso");
                Debug.Log("Reset");
            }
            
        
        }
    }
}
