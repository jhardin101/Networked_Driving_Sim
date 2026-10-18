using UnityEngine;

public class SplitScreenSetup : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Camera player1Camera;
    public Camera player2Camera;

    void Start()
    {
    
        player1Camera.rect = new Rect(0f, 0f, 0.495f, 1f);

        player2Camera.rect = new Rect(0.505f, 0f, 0.495f, 1f);
    }

}
