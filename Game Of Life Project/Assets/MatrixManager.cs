using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixManager : MonoBehaviour
{
    public struct Element
    {
        public bool value { get; set; }
        public GameObject gameObject { get; set; }
    }

    public const int rowsCount = 20;
    public const int colsCount = 20;
    public float xScale = 0.95f;
    public float yScale = 0.1f;
    public float zScale = 0.95f;
    public Color on = Color.white;
    public Color off = Color.black;

    public GameObject gameBoard;
    public Element[,] elements;
    public Camera camera = new Camera();

    // Start is called before the first frame update
    void Start()
    {
        elements = new Element[rowsCount, colsCount];
        for (int i = 0; i < rowsCount; i++)
        {
            for (int k = 0; k < colsCount; k++)
            {
                elements[i, k].gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
                elements[i, k].gameObject.transform.parent = gameBoard.transform;
                elements[i, k].gameObject.transform.position = new Vector3(i, 0, k);
                elements[i, k].gameObject.transform.localScale = new Vector3(xScale, yScale, zScale);
                var color = elements[i, k].value ? on : off;
                elements[i, k].gameObject.GetComponent<Renderer>().material.SetColor("_Color", color);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        setElementOnClick();
    }

    private void setElementOnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("click");
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                var row = (int)hit.transform.position.x;
                var col = (int)hit.transform.position.z;
                toggle(row, col);
                Debug.Log("[" + row + "," + col + "]: " + countNeighbors(row, col));
            }
        }
    }

    private bool[,] nextMatrix()
    {
        var newMatrix = new bool[rowsCount, colsCount];
        for (int i = 0; i < rowsCount; i++)
        {
            for (int k = 0; k < colsCount; k++)
            {

            }
        }
        return newMatrix;
    }

    private int countNeighbors(int row, int col)
    {
        int sum = 0;
        int localRow = 0;
        int localCol = 0;
        for (int i = -1; i < 2; i++)
        {
            localRow = (row + i) < 0 ? rowsCount + i : (row + i >= rowsCount) ? 0 : row + i;
            for (int k = -1; k < 2; k++)
            {
                localCol = (col + k) < 0 ? colsCount + k : (col + k >= colsCount) ? 0 : col + k;
                sum += elements[localRow, localCol].value ? 1 : 0;
            }
        }
        sum -= elements[row, col].value ? 1 : 0;
        return sum;
    }

    private void toggle(int row, int col)
    {
        elements[row, col].value = !elements[row, col].value;
        var color = elements[row, col].value ? on : off;
        elements[row, col].gameObject.GetComponent<Renderer>().material.SetColor("_Color", color);
    }
}
