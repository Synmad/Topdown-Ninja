using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject katanaprefab;
    [SerializeField] GameObject shurikenprefab;
    Transform shurikenaim;
    Camera cam;
    Vector3 mousePos;
    Animator animator;
    
    [SerializeField] float shurikenForce;
    public bool attacking;
    float attackCurTime;
    [SerializeField] float attackMaxTime;
    private void Awake() 
    { 
        shurikenaim = GameObject.Find("ShurikenAim").transform; cam = Camera.main; animator = GetComponent<Animator>();
    }

    public void AttackUpdate()
    {
        if (attacking)
        {
            attackCurTime -= Time.deltaTime; if (attackCurTime <= 0)
            {
                animator.SetBool("Attacking", false); attacking = false;
            }
        }
    }
    public void Katana()
    {
        if (attacking == false)
        {
            PlayerController.onPlayerAttack?.Invoke();
            attackCurTime = attackMaxTime;
            attacking = true; animator.SetBool("Attacking", true);
        }
    }
    public void ShurikenUpdate()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector2 aimPos = mousePos - shurikenaim.position;
        float angle = Mathf.Atan2(aimPos.y, aimPos.x) * Mathf.Rad2Deg - 90;

        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        shurikenaim.rotation = rotation;
    }
    public void Shuriken()
    {
        if (attacking == false)
        {
            PlayerController.onPlayerAttack?.Invoke();
            GameObject shuriken = Instantiate(shurikenprefab, shurikenaim.position, Quaternion.identity);
            shuriken.GetComponent<Rigidbody2D>().AddForce(shurikenaim.up * shurikenForce, ForceMode2D.Impulse);
        }
    }
}
