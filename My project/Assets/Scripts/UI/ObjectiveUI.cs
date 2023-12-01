using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

//Classe responsável por mostrar os objetivos na tela
public class ObjectiveUI : MonoBehaviour
{
    public TMP_Text objective;
    public Savefile savefile = new Savefile();
    // Start is called before the first frame update
    void Start()
    {
        savefile = savefile.LoadFile();
        objective.text = "OBJETIVO: " + savefile.objectives.Where(x => x.status == false).First().description;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
