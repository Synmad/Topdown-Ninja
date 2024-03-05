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

    [SerializeField] int shurikenCount;


    private void Awake() 
    { 
        shurikenaim = GameObject.Find("ShurikenAim").transform; cam = Camera.main; animator = GetComponent<Animator>();
    }

    private void Start()
    {
        ShurikenTextController.UpdateCounter(shurikenCount);
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
        if (attacking == false && shurikenCount > 0)
        {
            PlayerController.onPlayerAttack?.Invoke();

            GameObject shuriken = ShurikenPool.instance.GetPooledShurikens();
            shuriken.tag = "PlayerWeapon";
            shuriken.SetActive(true);
            shuriken.transform.position = shurikenaim.position; shuriken.transform.rotation = Quaternion.identity;
            shuriken.GetComponent<Rigidbody2D>().AddForce(shurikenaim.up * shurikenForce, ForceMode2D.Impulse);

            shurikenCount--;
            ShurikenTextController.UpdateCounter(shurikenCount);
        }
    }

    public void ShurikenPickup(int shurikensPickedUp)
    {
        shurikenCount+= shurikensPickedUp;
        ShurikenTextController.UpdateCounter(shurikenCount);
    }
}
