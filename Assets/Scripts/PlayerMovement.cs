using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Transform Player;

    private bool Lane1 = false;
    private bool Lane2 = true;
    private bool Lane3 = false;

    private bool isJumping = false;

    private void Start()
    {
        Player = GetComponent<Transform>();
    }

    private void Update()
    {
        // Jump
        //if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        //{
        //    StartCoroutine(JumpCoroutine());
        //}

        // Movement
        if (Lane3 && Player.position.z < 1.1f)
        {
            Player.position += new Vector3(0, 0, 10.5f * Time.deltaTime);
        }
        else if (Lane1 && Player.position.z > -1.1f)
        {
            Player.position += new Vector3(0, 0, -10.5f * Time.deltaTime);
        }
        else if (Lane2 && Player.position.z <= -0.1f)
        {
            Player.position += new Vector3(0, 0, 10.5f * Time.deltaTime);
        }
        else if (Lane2 && Player.position.z >= 0.1f)
        {
            Player.position += new Vector3(0, 0, -10.5f * Time.deltaTime);
        }

        // Change lanes
        if (Input.GetKeyDown(KeyCode.D) && Lane3 == false && Lane1 == true)
        {
            Lane2 = true;
            Lane1 = false;
            Lane3 = false;
        }
        else if (Input.GetKeyDown(KeyCode.A) && Lane2 == true && Player.position.z <= 0.2f)
        {
            Lane1 = true;
            Lane2 = false;
            Lane3 = false;
        }
        else if (Input.GetKeyDown(KeyCode.D) && Lane2 == true && Player.position.z >= -0.2f)
        {
            Lane3 = true;
            Lane1 = false;
            Lane2 = false;
        }
        else if (Input.GetKeyDown(KeyCode.A) && Lane1 == false && Lane3 == true)
        {
            Lane2 = true;
            Lane1 = false;
            Lane3 = false;
        }
    }

    private IEnumerator JumpCoroutine()
    {
        isJumping = true;
        Player.position += new Vector3(0, 1f, 0); // Jump
        yield return new WaitForSeconds(1.3f); // Wait for 2 seconds
        Player.position -= new Vector3(0, 1f, 0); // Return to ground
        isJumping = false;
    }
}
