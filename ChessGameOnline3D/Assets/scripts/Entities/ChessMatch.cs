using Assets.scripts.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class ChessMatch : MonoBehaviour
{
    public GameObject ground, groundB, pawn, bishop, horse, tower, queen, king;
    public Material black, white, darkGrey, brown;
    public Transform groundStarterPoint;

    List<GameObject> table = new List<GameObject>();
    List<GameObject> piaces = new List<GameObject> ();


    public struct ObjectRender
    {
        public float width;
        public float height;
        public float lenght;
    }

    void Start()
    {
        groundStarterPoint.position = new Vector3(0f, 0f, 0f);
        TableOrganize();
        FillListOfObjects();
        SummonPiaces();
    }

    void Update()
    {

    }

    void SummonPiaces()
    {
        for (int i = 0; i < 16; i++)
        {
            GameObject go = piaces[i];
            GameObject goVec = table[i];
            Vector3 vec = goVec.transform.position;

            Instantiate(go, new Vector3(vec.x, 65f, vec.y), Quaternion.Euler(90f*-1, 0f, 0f));
            Debug.Log($"{vec.x} //// {vec.y}");
        }
    }
    void FillListOfObjects()
    {
        piaces.Add(tower);
        piaces.Add(horse);
        piaces.Add(bishop);
        piaces.Add(king);
        piaces.Add(queen);
        piaces.Add(bishop);
        piaces.Add(horse);
        piaces.Add(tower);

        for (int i = 0; i < 8; i++)
        {
            piaces.Add(pawn);
        }

        Debug.Log($"\n{piaces.Count}");
    }
    public void TableOrganize()
    {
        float posY = groundStarterPoint.position.y;
        float posX = groundStarterPoint.position.x;

        ObjectRender groundDimensions = RenderOf(ground);
        float dimensionX = groundDimensions.width;
        float dimensionY = groundDimensions.height;

        float x = posX;

        int q = 0;
        for (int y = 0; y < 8; y++)
        {
            for (int i = 0; i < 8; i++)
            {
                GameObject toInstantiate;
                if ((i+y)% 2 == 0)
                {
                    toInstantiate = ground;
                }
                else
                {
                    toInstantiate = groundB;
                }

                Instantiate(toInstantiate, new Vector3(x, 0f, posY), Quaternion.Euler(90f, 0f, 0f));

               // Debug.Log($"\n{x:F2} /// {posY:F2}");
                table.Add(toInstantiate);


                x += dimensionX;
            }
            x = posX;
            posY += dimensionY;
        }
    }

    public ObjectRender RenderOf(GameObject toRender)
    {
        Renderer groundRenderer = toRender.GetComponent<Renderer>();

        ObjectRender dimensions = new ObjectRender();
        dimensions.width = groundRenderer.bounds.size.x;
        dimensions.height = groundRenderer.bounds.size.z;

        return dimensions;
    }


}
