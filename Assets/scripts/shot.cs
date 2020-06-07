using UnityEngine;
using System.Collections;

public class shot : MonoBehaviour {

    public UIManager uiman;

    public AudioClip bounceSound;
    public AudioClip bounceSound2;

    public float POWER;

    Rigidbody2D rig;

    public LayerMask lm;
    public LineRenderer line = null;
    Vector2 mousePos;
    Vector2 StartPos;

    bool canDraw =false;

    bool canShot = true;

	void Start ()
    {
        rig = GetComponent<Rigidbody2D>();
	}
	void Update ()
    {
        if (this.transform.position.y < -6)
        {
            uiman.Stop();
            Time.timeScale = 1;
        }

        Vector2 velocity = rig.velocity;
        if (velocity != Vector2.zero) return;

        if (Input.GetMouseButtonDown(0))
        {
            if (!canShot) return;
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (!Physics2D.OverlapPoint(mousePos, lm))
            {
                canDraw = false;
                return;
            }
            else canDraw = true;

            if (line == null)
                drawline();

            line.SetPosition(0, this.transform.position);
            line.SetPosition(1, mousePos);

            StartPos = this.transform.position;

            canShot = false;
        }
        else if(Input.GetMouseButtonUp(0)&&line&& canDraw)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            rig.isKinematic = false;
            rig.velocity = ((mousePos - (Vector2)this.transform.position) * POWER);

            line.SetPosition(1, StartPos);
        }
        else if(Input.GetMouseButton(0)&& line&& canDraw)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            line.SetPosition(1, mousePos);
        }

    }

    void drawline()
    {
        line = new GameObject("Line").AddComponent<LineRenderer>();
        line.material = new Material(Shader.Find("Diffuse"));
        line.SetVertexCount(2);
        line.SetWidth(0.1f, 0.1f);
        line.SetColors(Color.black, Color.black);
        line.useWorldSpace = true;
    }


    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "bounce")
            AudioSource.PlayClipAtPoint(bounceSound2, Vector2.zero);
        else
        AudioSource.PlayClipAtPoint(bounceSound, this.transform.position);
    }

}
