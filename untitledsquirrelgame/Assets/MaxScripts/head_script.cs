using UnityEngine;
using UnityEngine.InputSystem;
using System;


public class head_script : MonoBehaviour
{

    public GameObject squirrel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Sprite segment_sprite;
    //public GameObject obj;
    public int segment_length;
    public GameObject[] body_segments;
    public float[] segment_lengths;


    public Vector3 head_direction;

    public float radius;

    public float speed;
    public float scale;
    public CircleCollider2D coll;
    void Awake()
    {
        squirrel = GameObject.FindGameObjectWithTag("Player");

    }
    void Start()
    {
        
        int sorting_order = 30;
        segment_length = 50;
        scale = 0.08645276f;

        // Collider scaling added by Diego.
        coll = GetComponent<CircleCollider2D>();
        coll.radius = 0.2f;


        body_segments = new GameObject[segment_length];
        segment_lengths = CalcSegmentSizes(segment_length, scale);
        speed = 3;
        head_direction = new Vector3(0.0f, 1.0f, 0.0f);
        radius = 0.2f;
        transform.localScale = new Vector3(scale, scale, 1f);
        GetComponent<SpriteRenderer>().sortingOrder = sorting_order;


        for (int i = 0; i < segment_length; i++)
        {
            GameObject obj = new GameObject("segment");
            SpriteRenderer sprite_render = obj.AddComponent<SpriteRenderer>();
            obj.GetComponent<SpriteRenderer>().sortingOrder = sorting_order;
            sprite_render.sprite = segment_sprite;


            float seg_length = segment_lengths[i];
            obj.transform.localScale = new Vector3(seg_length, seg_length, 1f);

            body_segments[i] = obj;
        }


    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pixel_coords = Mouse.current.position.ReadValue();
        //Vector3 cursor_pos = Camera.main.ScreenToWorldPoint(new Vector3(pixel_coords.x, pixel_coords.y, 0f));


        Vector3 snake_pos = transform.position;
        Debug.Log(squirrel.transform.position);
        head_direction.x = squirrel.transform.position.x - snake_pos.x;
        head_direction.y = squirrel.transform.position.y - snake_pos.y;
        head_direction = head_direction.normalized;

        transform.position += (Time.deltaTime) * (head_direction) * speed;

        Vector3 next_segment_pos = transform.position;
        //move segment to the desired head distance
        for (int i = 0; i < segment_length; i++)
        {
            body_segments[i].transform.position = CalcNewDistance(body_segments[i].transform.position, radius, next_segment_pos);
            next_segment_pos = body_segments[i].transform.position;
        }
        //obj.transform.position = CalcNewDistance(obj.transform.position, radius, transform.position);

        Vector3 dir = squirrel.transform.position - transform.position;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

    }


    Vector3 CalcNewDistance(Vector3 current_pos, float radius, Vector3 next_segment_pos)
    {
        Vector2 new_path = new Vector2(next_segment_pos.x - current_pos.x, next_segment_pos.y - current_pos.y);

        float new_vector_magnitude = Math.Abs(radius - (new_path.magnitude));

        Vector2 new_vec = new_path;
        new_vec.x = (new_path.x / new_path.magnitude) * new_vector_magnitude;
        new_vec.y = (new_path.y / new_path.magnitude) * new_vector_magnitude;


        Vector3 return_vec = new Vector3(current_pos.x + new_vec.x, current_pos.y + new_vec.y, 1.0f);
        return return_vec;
    }

    float[] CalcSegmentSizes(int segments, float size)
    {
        int pivot_point = (int)((float)segments * (0.05f));
        float[] return_values = new float[segments];
        float max_added = size * 0.5f;
        for (int i=0; i<pivot_point;i++){
            return_values[i] = size + (max_added * ((float)(i + 1)/(float)(pivot_point + 1)));
        }

        float max_subtracted = return_values[pivot_point - 1] * 0.80f;
        for (int i = pivot_point; i < segments; i++)
        {
            return_values[i] = return_values[pivot_point - 1] - (max_subtracted* ((float)(i - pivot_point) / (float)(segments - pivot_point)));
        }
        
        
        return return_values;
    }
    


}

