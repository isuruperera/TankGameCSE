using UnityEngine;
using System.Collections;

public class TanksMovement : MonoBehaviour {

    // Use this for initialization
    int x = 0;
    int y = 0;
    void Start () {
        GameObject thePlayer = GameObject.Find("GameManager");
        PlaneGenerator generatorScript = thePlayer.GetComponent<PlaneGenerator>();
        x = (generatorScript.row-1) * 10;
        y = (generatorScript.col-1) * 10;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Vector3 position = this.transform.position;
            position.x = position.x - 10;
            if (position.x < 0) return;
            this.transform.position = position;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Vector3 position = this.transform.position;
            position.x = position.x + 10;
            if (position.x > x) return;
            this.transform.position = position;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Vector3 position = this.transform.position;
            position.z = position.z + 10;
            if (position.z > y) return;
            this.transform.position = position;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Vector3 position = this.transform.position;
            position.z = position.z - 10;
            if (position.z < 0) return;
            this.transform.position = position;
        }
    }
    void FixedUpdate()
    {

    }
}
