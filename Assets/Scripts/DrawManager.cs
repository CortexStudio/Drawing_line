using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawManager : MonoBehaviour
{
    [SerializeField] private Line _linePrefab;
    private Line _currentLine;
    private Camera _cam;
    public const float RESOLUTION = 0.1f;// Resolução da linha

    void Start()
    {
        _cam = Camera.main;
    }

   
    void Update()
    {
        Vector2 mousePos = _cam.ScreenToWorldPoint(Input.mousePosition); // Posição do mouse na tela

        // Mantenha o mouse precionado para criar instancia da linha
        if (Input.GetMouseButtonDown(0)) _currentLine = Instantiate(_linePrefab, mousePos, Quaternion.identity);

        // Seta a posição da linha
        if (Input.GetMouseButton(0)) _currentLine.SetPosition(mousePos);
    }
}
