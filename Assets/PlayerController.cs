using UnityEngine.UI;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;


public class PlayerController : MonoBehaviour
{

    public Camera cam;
    public NavMeshAgent agent;
    public ThirdPersonCharacter character;
    public Text ScoreText;
    public Text SafeScoreText;
    public int count = 0;
    public int safecount = 0;

    public Animator anim;

    private void Start()
    {
        agent.updateRotation = false;
        anim = GetComponent<Animator>();

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PickUp")
        {
            other.gameObject.SetActive(false);
            count += 1;
            ScoreText.text = "Score: " + count;


            
        }
        if (other.gameObject.tag == "AttackCube")
        {
            count += 1;
            ScoreText.text = "hit Score: " + count;
        }
        if (other.gameObject.tag == "SafeZone")
        {
            safecount++;
            SafeScoreText.text = "Safe score: " + safecount;
        }

    }


// Update is called once per frame
void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }

        }
        if(agent.remainingDistance > agent.stoppingDistance)
        {
            character.Move(agent.desiredVelocity,false,false);
      
            anim.SetBool("isRunning", true);
            
           
       

        }
        else
        {
            character.Move(Vector3.zero, false, false);
            anim.SetBool("isRunning", false);
        }
        
    }
}
