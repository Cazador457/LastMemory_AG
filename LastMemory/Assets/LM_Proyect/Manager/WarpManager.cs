using UnityEngine;

public class WarpManager : MonoBehaviour
{
    public GameManager gameManager;
    public Transform[] WarpPoints;
    public GameObject playerPos;
    public int NextPos;


    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void Warp()
    {
        playerPos.transform.position = WarpPoints[NextPos].position;
    }
}
