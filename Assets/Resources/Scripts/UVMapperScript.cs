using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UVMapperScript : MonoBehaviour
{
    void Start()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector2[] uvs = new Vector2[24];
        //front face
        uvs[4] = new Vector2(0.5f, 0.3f);
        uvs[5] = new Vector2(0.0f, 0.3f);
        uvs[8] = new Vector2(0.5f, 1.0f);
        uvs[9] = new Vector2(0.0f, 1.0f);
        //back face
        uvs[12] = new Vector2(0.5f, 0.3f);
        uvs[14] = new Vector2(1.0f, 1.0f);
        uvs[15] = new Vector2(1.0f, 0.3f);
        uvs[13] = new Vector2(0.5f, 1.0f);

        /*
        these below doesn't really matter as long as they are in
        (0.0,0.3)----(1.0,0.3)
            |            |
        (0.0,0.0)----(1.0,0.0) 
        rectangle
        */
        uvs[0] = new Vector2(0.0f, 0.0f);
        uvs[1] = new Vector2(0.5f, 0.0f);
        uvs[2] = new Vector2(0.0f, 0.1f);
        uvs[3] = new Vector2(0.5f, 0.1f);

        uvs[6] = new Vector2(0.5f, 0.1f);
        uvs[7] = new Vector2(1.0f, 0.1f);
        uvs[10] = new Vector2(0.5f, 0.2f);
        uvs[11] = new Vector2(1.0f, 0.2f);

        uvs[16] = new Vector2(0.0f, 0.0f);
        uvs[17] = new Vector2(0.5f, 0.0f);
        uvs[18] = new Vector2(0.0f, 0.1f);
        uvs[19] = new Vector2(0.5f, 0.1f);

        uvs[20] = new Vector2(1.0f, 0.1f);
        uvs[21] = new Vector2(0.5f, 0.1f);
        uvs[22] = new Vector2(1.0f, 0.2f);
        uvs[23] = new Vector2(0.5f, 0.2f);

        //switch mesh uvs to this
        mesh.uv = uvs;
    }

}
