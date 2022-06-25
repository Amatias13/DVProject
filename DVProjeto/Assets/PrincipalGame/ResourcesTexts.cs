using TMPro;
using UnityEngine;

public class ResourcesTexts : MonoBehaviour
{
    //Variaveis
    [SerializeField] private GameObject diamondsText;
    [SerializeField] private GameObject powerText;
    [SerializeField] private GameObject waterText;
    [SerializeField] private GameObject resourcesText;
    [SerializeField] private GameObject foodText;
    [SerializeField] private GameObject peopleText;

    //Define o texto com a variavel recebida por parametro
    public void DiamondsText(int diamonds)
    {
        diamondsText.GetComponent<TextMeshProUGUI>().text = "" + diamonds;
    }

    //Define o texto com a variavel recebida por parametro
    public void PowerText(int power)
    {
        powerText.GetComponent<TextMeshProUGUI>().text = "" + power;
    }

    //Define o texto com a variavel recebida por parametro
    public void WaterText(int water)
    {
        waterText.GetComponent<TextMeshProUGUI>().text = "" + water;
    }

    //Define o texto com a variavel recebida por parametro
    public void ResourcesText(int resources)
    {
        resourcesText.GetComponent<TextMeshProUGUI>().text = "" + resources;
    }

    //Define o texto com a variavel recebida por parametro
    public void FoodText(int food)
    {
        foodText.GetComponent<TextMeshProUGUI>().text = "" + food;
    }

    //Define o texto com a variavel recebida por parametro
    public void PeopleText(int people)
    {
        peopleText.GetComponent<TextMeshProUGUI>().text = "" + people;
    }
}
