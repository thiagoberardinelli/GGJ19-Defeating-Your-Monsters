using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Rigidbody rgbd;
    private int currentLane = 1; // A linha vai de 0 a 2, sendo a zero a linha mais a esquerda e linha 1 a do meio
    private Vector3 verticalTargetPosition;
    private bool jumping = false;
    private float jumpStart;
    private Animator anim;
    public float speed;

    [HideInInspector] public bool canMove;
    public float minSpeed; // velocidade minima do player
    public float maxSpeed; // velocidade maxima que o o player pode chegar
    public float laneSpeed; // velocidade de transicao entre linhas.
    public float jumpLength; // duracao do pulo
    public float jumpHeight; // altura do pulo
    public GameObject panel;

    private void Start()
    {
        canMove = false;

        rgbd = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();

        Invoke("StartRun", 2.75f);
    }

    private void Update()
    {
        if (!canMove)
            return;

        if (Input.GetKeyDown(KeyCode.A))
            ChangeLane(-1);
        else if (Input.GetKeyDown(KeyCode.D))
            ChangeLane(1);
        else if (Input.GetKeyDown(KeyCode.Space))
            Jump();

        // Referente ao pulo
        if (jumping) 
        {
            // Quando ratio for maior do que um, significa o final do pulo. Se eh igual a 1, quer dizer que ele chegou no Length max e ai deve parar de subir
            float ratio = (transform.position.z - jumpStart) / jumpLength;
            if (ratio >= 1) 
            {
                jumping = false;
                anim.SetBool("Jumping", false);
            }
            else 
            {
                // atualiza a posicao vertical do player enquanto ele ainda esta pulando
                verticalTargetPosition.y = Mathf.Sin(ratio * Mathf.PI) * jumpHeight;
            }
        }

        // O player não está mais pulando entao ele deve retonar ao chão
        else 
        {
            verticalTargetPosition.y = Mathf.MoveTowards(verticalTargetPosition.y, 0, 5 * Time.deltaTime);
        }

        Vector3 targetPosition = new Vector3(verticalTargetPosition.x, verticalTargetPosition.y, transform.position.z);

        // Atualizando a posicao do player entre as linhas, no movimento horizontal
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, laneSpeed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        rgbd.velocity = Vector3.forward * speed;
    }

    void ChangeLane(int direction)
    {
        // A linha que o player deve ir é igual a linha atual mais o parametro passado pela tecla clicada
        int targetLane = currentLane + direction;

        // Caso a linha seja maior do que 2 ou menor do que 0 ela nao existe, entao a funcao simplesmente retorn, senao, continua
        if (targetLane < 0 || targetLane > 2)
            return;

        currentLane = targetLane;
        verticalTargetPosition = new Vector3((currentLane - 1f), 0, 0); 
    }

    void Jump() 
    { 
        if (!jumping) 
        {
            // Posicao inicial do personagem antes do pulo
            jumpStart = transform.position.z;
            anim.SetFloat("JumpingSpeed", speed / jumpLength);
            anim.SetBool("Jumping", true);
            jumping = true;
        }
    }

    void StartRun() 
    {
        canMove = true;
        anim.SetTrigger("Start");
        speed = minSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle") 
        {
            Vector3 deathPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
            transform.position = deathPosition;
            speed = 0f;
            anim.SetTrigger("Death");

            Invoke("ActivateGameOverPanel", 2f);
        }       
    }

    public void IncreaseSpeed()
    {
        speed *= 1.15f;
        if (speed >= maxSpeed)
            speed = maxSpeed;
    }

    void ActivateGameOverPanel() 
    {
        panel.SetActive(true);
    }
}
