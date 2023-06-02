using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HA_plyerMove : MonoBehaviour
{
    public float maxSpeed;
    public float jumpPower;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;
    new CapsuleCollider2D collider;

    //반경 안 오브젝트 컨트롤
    public Vector2 colliderSize;
    public LayerMask whatIsLayer;

    private HA_objMove objMove;
    private GameObject apple;

    private HA_objDestory objRock;
    private GameObject rock;

    private HA_objDestory objFolwer;
    private GameObject flower;

    private HA_stage1UI UI;
    private HA_stage2UI UI_2;
    private GameObject skilEffect;
    private GameObject skilEffect_2;

    private GameObject obj_bridge;
    private HA_brigde hA_Brigde;

    private GameObject treeB;

    public GameObject UI_chatWindow;

    private HA_objForest objForest;

    public AudioSource SFX_jump;
    public AudioSource SFX_walk;
    public AudioSource SFX_plant;
    public AudioSource SFX_skill;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        collider = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        //Jump
        if (Input.GetButtonDown("Jump") && !anim.GetBool("isJumping"))
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            anim.SetBool("isJumping", true);
            SFX_jump.Play();
        }

        //Stop speed
        if (Input.GetButtonUp("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 2f, rigid.velocity.y);
            //spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;    //키 누른 상태에서 이미지 변화를 주기 위함
            //Debug.Log("Up" + spriteRenderer.flipX);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            anim.SetBool("isSquat", true);
            collider.size = new Vector2(0.8f, 0.5f);
        }
        else
        {
            anim.SetBool("isSquat", false);
            collider.size = new Vector2(0.8f, 0.9f);
        }

        //Directipon Sprite
        if (Input.GetButtonDown("Horizontal"))
        {
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
            //Debug.Log("Down" + spriteRenderer.flipX);
        }
        if (Mathf.Abs(rigid.velocity.x) < 1)
        {
            anim.SetBool("isWalking", false);
            SFX_walk.Play();
        }
        else
        {
            anim.SetBool("isWalking", true);
        }

        //반경 안 오브젝트 감지
        Collider2D[] hit = Physics2D.OverlapCapsuleAll(transform.position, colliderSize, 0, whatIsLayer);
        for (int i = 0; i < hit.Length; i++)
        {
            if (hit[i].tag == "Object")
            {
                if (hit[i].name == "obj_15")
                {
                    UI_chatWindow.SetActive(true);
                }
                else if (Input.GetKeyDown(KeyCode.Space))
                {
                    SFX_skill.Play();
                    if (GameObject.Find("Script"))
                    {
                        skilEffect = GameObject.Find("Script");
                        UI = skilEffect.GetComponent<HA_stage1UI>();
                        UI.skilUse = true;
                    }
                    else if (GameObject.Find("Script_2"))
                    {
                        skilEffect_2 = GameObject.Find("Script_2");
                        UI_2 = skilEffect_2.GetComponent<HA_stage2UI>();
                        UI_2.skilUse = true;
                    }
                    try
                    {
                        if (hit[i].name == "obj_16")
                        {
                            apple = GameObject.Find("obj_apple");
                            apple.AddComponent<Rigidbody2D>();
                            apple.GetComponent<Rigidbody2D>().mass = 20;
                        }
                        else if (hit[i].name == "obj_rock")
                        {
                            rock = GameObject.Find("obj_rock");
                            objRock = rock.GetComponent<HA_objDestory>();
                            objRock.start = true;
                        }
                        else if (hit[i].name == "obj_leafFlower(1)")
                        {
                            Debug.Log("꽃");
                            flower = GameObject.Find("obj_leafFlower(1)");
                            objFolwer = flower.GetComponent<HA_objDestory>();
                            objFolwer.boolFlower = true;
                        }
                        else if (hit[i].name == "obj_bridge")
                        {
                            obj_bridge = GameObject.Find("obj_bridge");
                            hA_Brigde = obj_bridge.GetComponent<HA_brigde>();
                            hA_Brigde.bridge_bool = true;
                        }
                        else if (hit[i].name == "obj_treeB(2)")
                        {
                            treeB = GameObject.Find("obj_treeB(2)");
                            treeB.AddComponent<Rigidbody2D>();
                            treeB.GetComponent<Rigidbody2D>().mass = 20;
                        }
                        else
                        {
                            objMove = hit[i].transform.GetComponent<HA_objMove>();
                            objMove.targetPoint = true;
                            SFX_plant.Play();
                            StartCoroutine(WaitForIt());
                        }
                    }
                    catch
                    {

                    }
                }
            }
            else if (hit[i].name == "obj_portal(1)")
            {
                SceneManager.LoadScene("HA_stage1");
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (GameObject.Find("Script"))
                {
                    skilEffect = GameObject.Find("Script");
                    UI = skilEffect.GetComponent<HA_stage1UI>();
                    UI.skilUse = true;
                }
                else if (GameObject.Find("Script_2"))
                {
                    skilEffect_2 = GameObject.Find("Script_2");
                    UI_2 = skilEffect_2.GetComponent<HA_stage2UI>();
                    UI_2.skilUse = true;
                }
                try
                {
                    if (hit[i].name == "obj_forest")
                    {
                        objForest = hit[i].transform.GetComponent<HA_objForest>();
                        objForest.isUse = true;
                    }
                }
                catch { }
            }

            if (hit[i].tag == "trap")
            {
                if (SceneManager.GetActiveScene().name == "HA_stage1")
                    SceneManager.LoadScene("HA_stage1");
                else if (SceneManager.GetActiveScene().name == "HA_tutorialScene")
                    SceneManager.LoadScene("HA_tutorialScene");
            }
        }
    }

        IEnumerator WaitForIt()
        {
            yield return new WaitForSeconds(10.0f);
            objMove.originPoint = true;
            yield return new WaitForSeconds(5.0f);
            objMove.Start();
        }

        void FixedUpdate()
        {
            //Move by key control
            float h = Input.GetAxisRaw("Horizontal");
            rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

            if (rigid.velocity.x > maxSpeed) //Right Max Speed
            {
                rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
            }
            else if (rigid.velocity.x < maxSpeed * (-1)) //Left Max Speed
            {
                rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
            }

            //Landing platform
            if (rigid.velocity.y < 0)
            {
                Debug.DrawRay(rigid.position, Vector3.down, new Color(0, 1, 0));

                RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("Platform"));

                if (rayHit.collider != null)
                {
                    if (rayHit.distance < 0.9f)
                        anim.SetBool("isJumping", false);
                }
            }
        }
}
