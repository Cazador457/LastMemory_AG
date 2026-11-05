using UnityEngine;

public class WarpManager : MonoBehaviour
{
    [SerializeField] private RavenInputActions RavenInput;
    [SerializeField] private GameObject UI;
    //public GameManager gameManager;
    public Transform[] WarpPoints;
    public GameObject playerPos;

    public void OnEnable()
    {
        RavenInput.SearchPerformed += SearchActive;
    }
    public void OnDisable()
    {
        RavenInput.SearchPerformed -= SearchActive;
    }
    public void SearchActive()
    {
        bool IsOpen = !UI.activeSelf;
        UI.SetActive(IsOpen);
        if (IsOpen)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void WarpAltar()
    {
        playerPos.GetComponent<CharacterController>().enabled = false;
            playerPos.transform.position = WarpPoints[0].position;
            playerPos.GetComponent<CharacterController>().enabled = true;
    }
    public void WarpTrade()
    {
        playerPos.GetComponent<CharacterController>().enabled = false;
        playerPos.transform.position = WarpPoints[1].position;
        playerPos.GetComponent<CharacterController>().enabled = true;
    }
    public void WarpFarm()
    {
        playerPos.GetComponent<CharacterController>().enabled = false;
        playerPos.transform.position = WarpPoints[2].position;
        playerPos.GetComponent<CharacterController>().enabled = true;
    }
    public void WarpCombat()
    {
        playerPos.GetComponent<CharacterController>().enabled = false;
        playerPos.transform.position = WarpPoints[3].position;
        playerPos.GetComponent<CharacterController>().enabled = true;
    }
}
