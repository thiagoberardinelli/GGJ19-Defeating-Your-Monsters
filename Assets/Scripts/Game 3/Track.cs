using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour
{
    public GameObject[] obstacles;
    public Vector2 numberOfObstacles; // Quantidade de obstaculos que vao apacer de uma vez.

    public List<GameObject> newObstacles;

    private void Start()
    {
        int newNumberOfObstacles = (int)Random.Range(numberOfObstacles.x, numberOfObstacles.y);

        for (int i = 0; i < newNumberOfObstacles; i++)
        {
            // Adiciono um novo gameObject obstacle a lista de novos obstaculos de acordo com o numero existente de tipos de obstaculo
            newObstacles.Add(Instantiate(obstacles[Random.Range(0, obstacles.Length)], transform));

            // Inicialmente, ele começa desativado porque primeiro eu preciso posiciona-los no mapa
            newObstacles[i].SetActive(false);
        }

        PositionationObstacles();
    }

    void PositionationObstacles()
    {
        for (int i = 0; i < newObstacles.Count; i++)
        {
            float posZMin = (219f / newObstacles.Count) + (219f / newObstacles.Count) * i;
            float posZMax = (219f / newObstacles.Count) + (219f / newObstacles.Count) * i + 1;
            newObstacles[i].transform.localPosition = new Vector3(0, 0, Random.Range(posZMin, posZMax));
            newObstacles[i].SetActive(true);
            if (newObstacles[i].GetComponent<ChangeLane>() != null)
                newObstacles[i].GetComponent<ChangeLane>().PositionLane();
        }
    }
}
