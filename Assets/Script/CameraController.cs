using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform[] playerTransforms;

    public float zOffset = 2.0f;
    public float minDistance = 2.0f;

    private float xMin, xMax, yMin, yMax;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void LateUpdate()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        int index = 0;
        GameObject[] Player1s = GameObject.FindGameObjectsWithTag("Player1");
        GameObject[] Player2s = GameObject.FindGameObjectsWithTag("Player2");
        playerTransforms = new Transform[Player1s.Length + Player2s.Length];
        for (int i = 0; i < Player1s.Length; i++)
        {
            playerTransforms[index++] = Player1s[i].transform;
        }
        for (int j = 0; j < Player2s.Length; j++)
        {
            playerTransforms[index++] = Player2s[j].transform;
        }

        if (playerTransforms.Length == 0)
        {
            Debug.Log("No Player find");
            return;
        }
        xMin = xMax = playerTransforms[0].position.x;
        yMin = yMax = playerTransforms[0].position.y;

        for (int i = 1; i < playerTransforms.Length; i++)
        {
            if (playerTransforms[i].position.x < xMin)
                xMin = playerTransforms[i].position.x;
            if (playerTransforms[i].position.x > xMax)
                xMax = playerTransforms[i].position.x;
            if (playerTransforms[i].position.y < yMin)
                yMin = playerTransforms[i].position.y;
            if (playerTransforms[i].position.y > yMax)
                yMax = playerTransforms[i].position.y;
        }

        float xMiddle = (xMin + xMax) / 2;
        float yMiddle = (yMin + yMax) / 2;
        float distance = (xMax - xMin)/(2 * Mathf.Tan(Mathf.PI / 6));
        if (distance < minDistance)
            distance = minDistance;

        transform.position = new Vector3(xMiddle, yMiddle, -distance + zOffset);
    }
}
