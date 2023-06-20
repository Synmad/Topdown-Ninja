using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] float attackForce;
    [SerializeField] float katanaCooldownTime;
    bool cantAttack;
    [SerializeField] GameObject katanaprefab;
    [SerializeField] GameObject shurikenprefab;

    Transform katanaaim;
    Transform shurikenaim;
    Camera cam;
    Vector3 mousePos;
    Animator animator;

    private void Awake()
    {
        katanaaim = GameObject.Find("KatanaAim").transform;
        shurikenaim = GameObject.Find("ShurikenAim").transform;
        cam = Camera.main;
        animator = GetComponent<Animator>();
    }
    public void Katana()
    {
        if (cantAttack)
        {
            return;
        }
        GameObject shuriken = Instantiate(katanaprefab, katanaaim.position, Quaternion.identity);
        animator.SetBool("Attacking", true);
        cantAttack = true;
        StartCoroutine(KatanaCooldown());
    }
    private IEnumerator KatanaCooldown()
    {
        yield return new WaitForSeconds(katanaCooldownTime);
        cantAttack = false;
    }
    public void Aim()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector2 aimPos = mousePos - shurikenaim.position;
        float angle = Mathf.Atan2(aimPos.y, aimPos.x) * Mathf.Rad2Deg - 90;

        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        shurikenaim.rotation = rotation;
    }
    public void Shuriken()
    {
        GameObject shuriken = Instantiate(shurikenprefab, shurikenaim.position, Quaternion.identity);
        shuriken.GetComponent<Rigidbody2D>().AddForce(shurikenaim.up * attackForce, ForceMode2D.Impulse);
    }
}
