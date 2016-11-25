using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof(PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        //private bool m_Jump;


        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }


        private void Update()
        {
            /*if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }
            */
            LeftMove();
            RightMove();
            Forward();

        }

        public void premikajLevo()
        {
            transform.position += -transform.right * Time.deltaTime;
        }


        private void FixedUpdate()
        {
            // Read the inputs.
            /* if(Input.GetKeyDown(KeyCode.A))
              {

              }*/
            /*float hi = Input.GetAxis("Horizontal");
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            // Pass all parameters to the character control script.


            if (Input.GetMouseButton(1))
            {
                m_Character.Move(hi);
            }*/
           // m_Jump = false;
        }

        public void LeftMove()
        {

            //float left = Input.GetAxis("Horizontal");

            if (Input.GetMouseButton(0))
            {

                transform.position += -transform.right * Time.deltaTime;
                // GetComponent<Rigidbody2D>().AddForce(Vector2.right * h);
                //m_Character.Move(left);


            }
        }
        public void RightMove()
        {
            float pos = Input.GetAxis("Horizontal");
            transform.position += transform.right * Time.deltaTime;
        }

        public void Forward()
        {
            transform.position += transform.forward * Time.deltaTime;
        }
    }
}
