using UnityEngine;

public class WarpManager : MonoBehaviour
{
    //public GameManager gameManager;
    public Transform[] WarpPoints;
    public GameObject playerPos;
    public int NextPos;

    public void Warp()
    {
        playerPos.GetComponent<CharacterController>().enabled = false;
            playerPos.transform.position = WarpPoints[NextPos].position;
            playerPos.GetComponent<CharacterController>().enabled = true;
    }
}
