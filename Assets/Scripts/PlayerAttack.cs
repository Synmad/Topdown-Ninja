using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] float attackForce;
    [SerializeField] GameObject shurikenprefab;

    Transform attackpoint;
    Camera cam;
    Vector3 mousePos;

    private void Awake()
    {
        attackpoint = GameObject.Find("AttackPoint").transform;
        cam = Camera.main;
    }
    public void Shuriken()
    {
        GameObject shuriken = Instantiate(shurikenprefab, attackpoint.position, Quaternion.identity);
        shuriken.GetComponent<Rigidbody2D>().AddForce(attackpoint.up * attackForce, ForceMode2D.Impulse);
    }
    public void Aim()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector2 aimPos = mousePos - attackpoint.position;
        float angle = Mathf.Atan2(aimPos.y, aimPos.x) * Mathf.Rad2Deg -90;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        attackpoint.rotation = Quaternion.Slerp(attackpoint.rotation, rotation, 1);
    }

}
