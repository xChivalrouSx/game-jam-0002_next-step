using Cinemachine;
using System.Linq;
using UnityEngine;

public class Iron : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {

    }

    public void TakeIron()
    {
        Debug.Log("Taken Iron");
        Inventory.INSTANCE.addIron();
        Destroy(gameObject);

        GameObject playerGameObject = ((GameObject)FindObjectsByType(typeof(GameObject), FindObjectsInactive.Include, FindObjectsSortMode.None).FirstOrDefault(x => x.name.Equals("Player")));
        GameObject playerRobotGameObject = ((GameObject)FindObjectsByType(typeof(GameObject), FindObjectsInactive.Include, FindObjectsSortMode.None).FirstOrDefault(x => x.name.Equals("PlayerRobot")));
        playerRobotGameObject.transform.position = playerGameObject.transform.position;

        playerGameObject.SetActive(false);
        playerRobotGameObject.SetActive(true);

        CinemachineVirtualCamera virtualCamera = (CinemachineVirtualCamera)FindObjectsByType(typeof(CinemachineVirtualCamera), FindObjectsInactive.Exclude, FindObjectsSortMode.None).FirstOrDefault();
        virtualCamera.Follow = playerRobotGameObject.transform;
    }
}
