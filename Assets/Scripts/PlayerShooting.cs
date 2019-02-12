using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour
{
    public Text countText;
    public Text winText;
    private Camera playerCam;
    private int count;
    

    // Start is called before the first frame update
    void Start()
    {
        playerCam = GetComponent<Camera>();
        count = 0;
        SetCountText();
        winText.text = "";

        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float x = playerCam.pixelWidth / 2;
        float y = playerCam.pixelHeight / 2;
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 point = new Vector3(x, y, 0);
            Ray ray = playerCam.ScreenPointToRay(point);
            RaycastHit hit;
            if(Physics.Raycast (ray,out hit))
            {
                GameObject hitObject = hit.transform.gameObject;

                EnemyController target = hitObject.GetComponent<EnemyController>();

                if (target != null)
                {
                    target.GotShot();
                    count= count +1;
                    SetCountText();
                }
                else
                {
                    StartCoroutine(ShotGen(hit.point));
                }
            }
        }
    }
    private IEnumerator ShotGen(Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        sphere.transform.position = pos;

        yield return new WaitForSeconds(1);
        Destroy(sphere);

    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count >= 3)
        {
            winText.text = "You win";
        }
    }
    /* private void OnGUI()
     {
         int size = 120;
         float posX = playerCam.pixelWidth / 2 - size / 4;
         float posY = playerCam.pixelHeight / 2 - size / 2;
         GUI.Label(new Rect(posX, posY, size, size),"*");

     }*/
}
